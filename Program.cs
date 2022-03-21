using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ednevnik
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static public int uloga;
        static public string ime;
        static public string prezime;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
