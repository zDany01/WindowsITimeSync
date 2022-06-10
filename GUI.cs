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

namespace WindowsITimeSync
{
    public partial class GUI : Form
    {

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
            Process checker = new Process { StartInfo = HiddenProgram("sc","query w32time")};
            checker.StartInfo.RedirectStandardOutput = true;
            checker.Start();
            checker.WaitForExit();

            if (!checker.StandardOutput.ReadToEnd().Split('\n')[3].Contains("RUNNING")) Process.Start(HiddenProgram("net", "start w32time")).WaitForExit();

            Process.Start(HiddenProgram("w32tm", "/resync")).WaitForExit();

            MessageBox.Show("Time successfully synchronized","Windows Internet Time Sync",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Enabled = true;
        }

        public GUI()
        {
            InitializeComponent();
            SyncBtn.Click += SyncBtn_Click;
            StartupCbx.CheckedChanged += StartupCbx_CheckedChanged;
        }

        private void StartupCbx_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SyncBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Your current system time will be synchronized using your local timezone settings\nDo you want to continue?", "Windows Internet Time Sync", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) SyncTime();
        }
    }
}
