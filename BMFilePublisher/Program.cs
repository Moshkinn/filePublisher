using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMFilePublisher
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
            MainForm form1 = new MainForm();
            if (form1.ReadConfig())
            {
                Application.Run(form1);
            }
            else
            {
                MessageBox.Show("Error read config file.");
            }
            
        }
    }
}
