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
    public partial class frmListBooking : Form
    {
        private DataTable _dtAllBooking;
        private clsBooking _Booking;
        public frmListBooking()
        {
            InitializeComponent();
        }

        private void frmListBooking_Resize(object sender, EventArgs e)
        {
            //1210, 592
            this.Size = new Size(1210, 592);

            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            int y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;

            this.Location = new Point(x, y);
        }
        private void LoadBookingsTodgv()
        {
            _dtAllBooking = clsBooking.GetAllBooking();
            dgvAllBookings.DataSource = _dtAllBooking;

            if (dgvAllBookings.Rows.Count > 0)
            {
                dgvAllBookings.Columns[0].HeaderText = "Booking ID";
                dgvAllBookings.Columns[0].Width = 70;

                dgvAllBookings.Columns[1].HeaderText = "Date";
                dgvAllBookings.Columns[1].Width = 100;

                dgvAllBookings.Columns[2].HeaderText = "Time";
                dgvAllBookings.Columns[2].Width = 70;

                dgvAllBookings.Columns[3].HeaderText = "Customer Name";
                dgvAllBookings.Columns[3].Width = 150;

                dgvAllBookings.Columns[4].HeaderText = "Persons";
                dgvAllBookings.Columns[4].Width = 100;

                dgvAllBookings.Columns[5].HeaderText = "All Foods";
                dgvAllBookings.Columns[5].Width = 200;

                dgvAllBookings.Columns[6].HeaderText = "All Drinks";
                dgvAllBookings.Columns[6].Width = 200;

                dgvAllBookings.Columns[7].HeaderText = "Food Cost";
                dgvAllBookings.Columns[7].Width = 100;

                dgvAllBookings.Columns[8].HeaderText = "Drinks Cost";
                dgvAllBookings.Columns[8].Width = 100;

                dgvAllBookings.Columns[9].HeaderText = "Other charges";
                dgvAllBookings.Columns[9].Width = 100;

                dgvAllBookings.Columns[10].HeaderText = "Grd Total";
                dgvAllBookings.Columns[10].Width = 100;

                dgvAllBookings.Columns[11].HeaderText = "Advance";
                dgvAllBookings.Columns[11].Width = 100;

                dgvAllBookings.Columns[12].HeaderText = "Balance";
                dgvAllBookings.Columns[12].Width = 100;
            }
        }
        private void frmListBooking_Load(object sender, EventArgs e)
        {
            LoadBookingsTodgv();
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {

            if (dgvAllBookings.SelectedRows.Count >= 0)
            {
                int BookingID = (int)dgvAllBookings.CurrentRow.Cells[0].Value;

                if (MessageBox.Show("Are you sure you want delete this booking ?", "Warring", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    == DialogResult.OK)
                {

                    if (clsBooking.DeleteBooking(BookingID))
                    {
                        MessageBox.Show("Booking Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListBooking_Load(null, null);
                    }
                    else
                        MessageBox.Show("Booking Deleted Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else
            {
                MessageBox.Show("Select the Item!");
            }
        }

    
    }
}
