using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerControl2
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form1 = new Form1();
            form1.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form1.ShowInTaskbar = false;
            form1.StartPosition = FormStartPosition.Manual;
            form1.Location = new System.Drawing.Point(-2000, -2000);
            form1.Size = new System.Drawing.Size(1, 1);

            Application.Run(mainForm: form1);
        }
    }
}
