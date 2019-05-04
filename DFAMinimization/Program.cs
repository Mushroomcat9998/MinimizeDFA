using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFAMinimization
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
            DFAMinimization dFAMinimization = new DFAMinimization();
            dFAMinimization.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(dFAMinimization);
        }
    }
}
