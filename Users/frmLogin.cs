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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(630, 367);
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }
        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Crimson;
        }
        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.White;
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text.Trim())||txtUserName.Text.Trim()=="")
            {
                errorProvider1.SetError(txtUserName, "User Name is Empty!");
            }else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim())||txtPassword.Text.Trim()=="")
            {
                errorProvider1.SetError(txtPassword, "Password is Empty!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("Some Files are Empty!", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsUser.CheckUserNameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim()))
            {
                MessageBox.Show("Wrong UserName or Password!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //MessageBox.Show("Login is Successfully.");
            frmMain frm = new frmMain();
            frm.ShowDialog();
           
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void lnkAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frmAdmin frm = new frmAdmin();
            frm.ShowDialog();
        }
    }
}
