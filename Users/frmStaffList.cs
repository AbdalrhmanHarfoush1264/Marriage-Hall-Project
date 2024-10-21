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
    public partial class frmStaffList : Form
    {
        private DataTable _dtAllStaffs;
        private clsUser _User;
        public frmStaffList()
        {
            InitializeComponent();
        }
        private void LoadStaffsTodgv()
        {
            _dtAllStaffs = clsUser.GetAllStaff();
            dgvStaffList.DataSource = _dtAllStaffs;
            lblRecordsCount.Text = dgvStaffList.Rows.Count.ToString();

            if (dgvStaffList.Rows.Count > 0)
            {
                dgvStaffList.Columns[0].HeaderText = "Staff ID";
                dgvStaffList.Columns[0].Width = 200;

                dgvStaffList.Columns[1].HeaderText = "Staff Name";
                dgvStaffList.Columns[1].Width = 350;

                dgvStaffList.Columns[2].HeaderText = "Phone";
                dgvStaffList.Columns[2].Width = 200;

                dgvStaffList.Columns[3].HeaderText = "Gender";
                dgvStaffList.Columns[3].Width = 200;

                dgvStaffList.Columns[4].HeaderText = "Password";
                dgvStaffList.Columns[4].Width = 160;
            }
        }
        private void ResetForm()
        {
            LoadStaffsTodgv();
            cbxGender.SelectedIndex = 0;
            txtName.Text = "";
            txtPassword.Text = "";
            txtPhone.Text = "";
        }
        private void frmStaffList_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void frmStaffList_Resize(object sender, EventArgs e)
        {
            //1210, 592
            this.Size = new Size(1210, 592);

            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
             string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //_Customer = new clsCustomer();
            _User = new clsUser();
            _User.Name = txtName.Text;
            _User.Password = txtPassword.Text;
            _User.Phone = txtPhone.Text;
            if (cbxGender.SelectedIndex == 0)
                _User.Gender = 0;
            else
                _User.Gender = 1;

            if (_User.Save())
            {
                MessageBox.Show("Staff Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStaffList_Load(null, null);

            }
            else
            {
                MessageBox.Show("Adding Staff failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            cbxGender.SelectedIndex = 0;
        }       
        private void dgvStaffList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int StaffID = (int)dgvStaffList.CurrentRow.Cells[0].Value;

            _User = clsUser.Find(StaffID);

            if (_User != null)
            {
                txtName.Text = _User.Name;
                txtPhone.Text = _User.Phone;
                txtPassword.Text = _User.Password;
                if (_User.Gender == 0)
                    cbxGender.SelectedIndex = 0;
                else
                    cbxGender.SelectedIndex = 1;

            }
            else
                MessageBox.Show("Staff ID is not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) ||
                string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
                string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User == null)
            {
                MessageBox.Show("Select The Staff To Be Update", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtPassword.Text = "";
                txtPhone.Text = "";
                return;
            }

            _User.Name = txtName.Text;
            _User.Password = txtPassword.Text;
            _User.Phone = txtPhone.Text;

            if (cbxGender.SelectedIndex == 0)
                _User.Gender = 0;
            else
                _User.Gender = 1;

            if (_User.Save())
            {
                MessageBox.Show("Staff Successfully Updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStaffList_Load(null, null);
            }
            else
                MessageBox.Show("The update process failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) ||
            string.IsNullOrEmpty(txtPassword.Text.Trim()) ||
            string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_User == null)
            {
                MessageBox.Show("Select The Staff To Be Delete", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtPassword.Text = "";
                txtPhone.Text = "";
                return;
            }

            if (_User.DeleteStaff())
            {
                MessageBox.Show("Staff Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmStaffList_Load(null, null);
            }
            else
            {
                MessageBox.Show("Staff Deleted failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddStaff_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }

        private void btnAddStaff_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void dgvStaffList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
