using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsITimeSync
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GUI ApplicationInstance = new GUI();
            ApplicationInstance.notifyManager.Icon = ApplicationInstance.Icon;
            if (args.Length == 1 && args[0] == "--sync") ApplicationInstance.SyncTime();
            else Application.Run(ApplicationInstance);
        }
    }
}
