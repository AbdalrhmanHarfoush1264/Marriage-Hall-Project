using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marriage_Hall_Project
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            frmBooking frm = new frmBooking();
            frm.ShowDialog();
        }

        private void btnViewBooking_Click(object sender, EventArgs e)
        {
            frmListBooking frm = new frmListBooking();
            frm.ShowDialog();
        }






        //private void btnLogout_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
