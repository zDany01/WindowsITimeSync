using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WindowsITimeSync
{
    public partial class GUI : Form
    {
        private static readonly string applicationDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\WindowsITimeSync\\";
        private static readonly string executablePath = applicationDirectory + Path.GetFileName(Application.ExecutablePath);
        private readonly RegistryKey currentUserRun = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
        private const string APP_NAME = "Windows Internet Time Sync";

        public bool isInstalled => File.Exists(executablePath);

        public GUI()
        {
            InitializeComponent();
            SyncBtn.Click += SyncBtn_Click;
            StartupCbx.CheckedChanged += StartupCbx_CheckedChanged;
            this.Load += GUI_Load;
        }

        public void SyncTime()
        {
            this.Enabled = false;
            try
            {
                Process checker = new Process { StartInfo = HiddenProgram("sc", "query w32time") };
                checker.StartInfo.RedirectStandardOutput = true;
                checker.Start();
                checker.WaitForExit();

                if (!checker.StandardOutput.ReadToEnd().Split('\n')[3].Contains("RUNNING")) Process.Start(HiddenProgram("net", "start w32time")).WaitForExit();

                Process.Start(HiddenProgram("w32tm", "/resync")).WaitForExit();

                notifyManager.ShowBalloonTip(500, APP_NAME, "Time successfully synchronized", ToolTipIcon.Info);
            }
            catch
            {
                notifyManager.ShowBalloonTip(500, APP_NAME, "Unable to synchronize your local time.\nCheck your Internet connection!", ToolTipIcon.Error);
            }
            this.Enabled = true;
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            StartupCbx.Checked = this.isInstalled;
        }

        private ProcessStartInfo HiddenProgram(string fileName, string args)
        {
            return new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }
        private void Uninstall(bool useShellDelete)
        {
            try
            {
                currentUserRun.DeleteValue("TimeSync");
                File.Delete($"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\{APP_NAME}.url");
                if (useShellDelete)
                {
                    Process.Start(HiddenProgram("cmd.exe", $"/c timeout 3 & rmdir \"{applicationDirectory}\" /s /q"));
                    Close();
                }
                else Directory.Delete(applicationDirectory, true);
            }
#if DEBUG
            catch (Exception ex)
            {

                Debug.WriteLine("Exception when trying to uninstall the app: " + ex.Message);
            }
#else
            catch { }
#endif

        }
        private void appShortcutToDesktop(string linkName) //I didn't think it was that hard to create a shortcut, i don't like to rely on WSHELL
        //https://stackoverflow.com/questions/234231/creating-application-shortcut-in-a-directory 
        {
            using (StreamWriter writer = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\{linkName}.url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=file:///" + executablePath);
                writer.WriteLine("IconIndex=0");
                writer.WriteLine("IconFile=" + executablePath.Replace('\\', '/'));
                writer.Flush();
            }
        }
        private void StartupCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (Application.ExecutablePath != executablePath)
            {
                if (StartupCbx.Checked)
                {
                    if (this.isInstalled) return;
                    Directory.CreateDirectory(applicationDirectory);
                    File.Copy(Application.ExecutablePath, executablePath, true);
                    currentUserRun.SetValue("TimeSync", $"\"{executablePath}\" --sync");
                    appShortcutToDesktop(APP_NAME);
                }
                else Uninstall(false);
            }
            else
            {
                if (!StartupCbx.Checked && MessageBox.Show("This will uninstall the application\nDo you want to continue?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Uninstall(true);
                else StartupCbx.Checked = true;
            }

        }
        private void SyncBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your current system time will be synchronized using your local timezone settings\nDo you want to continue?", APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) SyncTime();
        }
    }
}
