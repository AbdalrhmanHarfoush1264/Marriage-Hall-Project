using Marriage_Hall_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marriage_Hall_Project
{
    public partial class frmCustomer : Form
    {
        private DataTable _dtAllCustomers;
        private clsCustomer _Customer;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void LoadCustomersTodgv()
        {
            _dtAllCustomers = clsCustomer.GetAllCustomers();
            dgvCustomersList.DataSource = _dtAllCustomers;
            lblRecordsCount.Text = dgvCustomersList.Rows.Count.ToString();

            if(dgvCustomersList.Rows.Count>0)
            {
                dgvCustomersList.Columns[0].HeaderText = "Customer ID";
                dgvCustomersList.Columns[0].Width = 200;

                dgvCustomersList.Columns[1].HeaderText = "Customer Name";
                dgvCustomersList.Columns[1].Width = 350;

                dgvCustomersList.Columns[2].HeaderText = "Address";
                dgvCustomersList.Columns[2].Width = 200;

                dgvCustomersList.Columns[3].HeaderText = "Phone";
                dgvCustomersList.Columns[3].Width = 200;

                dgvCustomersList.Columns[4].HeaderText = "Gender";
                dgvCustomersList.Columns[4].Width = 160;
            }
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ResetForm();
        }
        private void ResetForm()
        {
            LoadCustomersTodgv();
            cbxGender.SelectedIndex = 0;
        }
        private void ResizeForm()
        {
            //1210, 592
            this.Size = new Size(1210, 592);

            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }
        private void frmCustomer_Resize(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text.Trim())||string.IsNullOrEmpty(txtAddress.Text.Trim())||
                string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Customer = new clsCustomer();

            _Customer.Name = txtName.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            if (cbxGender.SelectedIndex==0)
                _Customer.Gender = 0;
            else
                _Customer.Gender = 1;

            if(_Customer.Save())
            {
                MessageBox.Show("Customer Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomer_Load(null, null);

            }else
            {
                MessageBox.Show("Adding Customer failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            cbxGender.SelectedIndex = 0;
        }
        private void dgvCustomersList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int CustomerID = (int)dgvCustomersList.CurrentRow.Cells[0].Value;

            _Customer = clsCustomer.Find(CustomerID);

            if (_Customer != null)
            {
                txtName.Text = _Customer.Name;
                txtAddress.Text = _Customer.Address;
                txtPhone.Text = _Customer.Phone;
                if (_Customer.Gender == 0)
                    cbxGender.SelectedIndex = 0;
                else
                    cbxGender.SelectedIndex = 1;

            }
            else
                MessageBox.Show("Customer ID is not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            
            if( string.IsNullOrEmpty(txtName.Text.Trim())||
                string.IsNullOrEmpty(txtAddress.Text.Trim())||
                string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(_Customer==null)
            {
                MessageBox.Show("Select The Customer To Be Update", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                return;
            }

            _Customer.Name=txtName.Text;
            _Customer.Address=txtAddress.Text;
            _Customer.Phone=txtPhone.Text;

            if (cbxGender.SelectedIndex == 0)
                _Customer.Gender = 0;
            else
                _Customer.Gender = 1;

            if (_Customer.Save())
            {
                MessageBox.Show("Customer Successfully Updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomer_Load(null, null);
            }
            else
                MessageBox.Show("The update process failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) ||
              string.IsNullOrEmpty(txtAddress.Text.Trim()) ||
              string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Some Boxes is Empty", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Customer == null)
            {
                MessageBox.Show("Select The Customer To Be Delete", "Not Vailed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtAddress.Text = "";
                txtPhone.Text = "";
                return;
            }

            if(_Customer.DeleteCustomer())
            {
                MessageBox.Show("Customer Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmCustomer_Load(null, null);
            }
            else
            {
                MessageBox.Show("Customer Deleted failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void dgvCustomersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
