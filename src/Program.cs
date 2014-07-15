using System;
using System.Windows.Forms;

namespace ZBreak
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += (s, e) => Config.Save();
            Config.Read();
            ActiveMonitor.Run();
            Application.Run();
        }
    }
}
