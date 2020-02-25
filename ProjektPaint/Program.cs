using System;
using System.Windows.Forms;

namespace ProjektPaint
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormStart formStart = new FormStart();
            formStart.Show();
            Application.Run();
        }
    }
}
