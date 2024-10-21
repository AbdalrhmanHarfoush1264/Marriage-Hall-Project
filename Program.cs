using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marriage_Hall_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new frmMain());
            //Application.Run(new frmCustomer());
            //Application.Run(new frmBooking());
            //Application.Run(new frmListBooking());
            //Application.Run(new frmAdmin());
            //Application.Run(new frmStaffList());
        }
    }
}
