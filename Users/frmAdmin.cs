using Marriage_Hall_Bussiness;
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(467, 213);
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password is Empty!", "Not Valied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsUser.CheckPasswordForAdminIsTrue(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Wrong Password,Contact the Admin Of This System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmStaffList frm = new frmStaffList();
            frm.ShowDialog();
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }
    }
}
