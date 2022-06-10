using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace WindowsITimeSync
{
    public partial class GUI : Form
    {
        readonly static string applicationDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\WindowsITimeSync\\";
        readonly static string executablePath = applicationDirectory + Path.GetFileName(Application.ExecutablePath);

        public bool isInstalled
        {
            get
            {
                return File.Exists(executablePath);
            }
        }

        private ProcessStartInfo HiddenProgram(string fileName, string args) => new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = args,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        private void SyncTime()
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

                notifyManager.ShowBalloonTip(500, "Windows Internet Time Sync", "Time successfully synchronized", ToolTipIcon.Info);
            } catch
            {
                notifyManager.ShowBalloonTip(500, "Windows Internet Time Sync", "Unable to synchronize your local time.\nCheck your Internet connection!", ToolTipIcon.Error);
            }
            this.Enabled = true;
        }

        public GUI()
        {
            InitializeComponent();
            SyncBtn.Click += SyncBtn_Click;
            StartupCbx.CheckedChanged += StartupCbx_CheckedChanged;
            this.Load += GUI_Load;
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            StartupCbx.Checked = isInstalled;
            notifyManager.Icon = this.Icon;
        }

        private void StartupCbx_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey currentUserRun = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);

            if (Application.ExecutablePath != executablePath)
            {
                if (StartupCbx.Checked)
                {
                    if (isInstalled) return;
                    Directory.CreateDirectory(applicationDirectory);
                    File.Copy(Application.ExecutablePath, executablePath, true);
                    currentUserRun.SetValue("TimeSync", $"\"{executablePath}\" --sync");
                }
                else
                {
                    Directory.Delete(applicationDirectory, true);
                    currentUserRun.DeleteValue("TimeSync");
                }
            }
            else
            {
                if (!StartupCbx.Checked)
                {
                    throw new NotImplementedException("Uninstall from program folder");
                }
            }

        }

        private void SyncBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your current system time will be synchronized using your local timezone settings\nDo you want to continue?", "Windows Internet Time Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) SyncTime();
        }
    }
}
