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
    public partial class frmBooking : Form
    {
        private int DrinksCost = 0;
        private int FoodsCost = 0;
        private int OtherCharges = 0;
        private int GrdTotal = 0;
        private int Advance = 0;
        private int Balance = 0;

        public struct stDrink
        {
           public int Quantity;
           public int Cost;
           public int Price;
           public byte DrinkID;
        }

        public struct stFood
        {
            public int Quantity;
            public int Cost;
            public int Price;
            public byte FoodID;
        }

        public List<stDrink> stDrinks = new List<stDrink>();
        public List<stFood> stFoods = new List<stFood>();
        
        public frmBooking()
        {
            InitializeComponent();
        }
        private void FillComboBoxWithCustomers()
        {
            DataTable dtAllCustomers = clsCustomer.GetAllCustomers();

            foreach(DataRow row in dtAllCustomers.Rows)
            {
                cbxCustomers.Items.Add(row["Name"]);
            }
        }
        private void ResetForm()
        {
            
            cbxCustomers.SelectedIndex = 0;

            //combo box
            cbxTime.SelectedIndex = 0; //Day

            //Data Time Picker
            dtpDate.MinDate = DateTime.Today;
            dtpDate.MaxDate = DateTime.Now.AddYears(100);

            
            //Text Box...For Beverage
            txtWatPrice.Enabled = false;
            txtWatQuant.Enabled = false;
            txtJuicQuant.Enabled = false;
            txtJuiPrice.Enabled = false;
            txtTeaPrice.Enabled = false;
            txtTeaQuant.Enabled = false;
            txtCofPrice.Enabled = false;
            txtCofQuant.Enabled = false;
            txtSodaPrice.Enabled = false;
            txtSodaQuant.Enabled = false;

            //Text Box...For Dishes
            txtChickPrice.Enabled = false;
            txtChickQuant.Enabled = false;
            txtFishPrice.Enabled = false;
            txtFishQuant.Enabled = false;
            txtSaucPrice.Enabled = false;
            txtSaucQuant.Enabled = false;
            txtMacarPrice.Enabled = false;
            txtMacarQuant.Enabled = false;
            txtKoftaPrice.Enabled = false;
            txtKoftaQuant.Enabled = false;



            //Text Box..for GrdTotal & Balance
            txtBalance.Enabled=false;
            txtGrdTotal.Enabled=false;


            txtWatPrice.Text = 0.ToString();
            txtWatQuant.Text=0.ToString();
            txtJuicQuant.Text = 0.ToString();
            txtJuiPrice.Text = 0.ToString();
            txtTeaPrice.Text = 0.ToString();
            txtTeaQuant.Text = 0.ToString();
            txtCofPrice.Text = 0.ToString();
            txtCofQuant.Text = 0.ToString();
            txtSodaPrice.Text = 0.ToString();
            txtSodaQuant.Text = 0.ToString();

            txtChickPrice.Text = 0.ToString();
            txtChickQuant.Text = 0.ToString();
            txtFishPrice.Text = 0.ToString();
            txtFishQuant.Text = 0.ToString();
            txtSaucPrice.Text = 0.ToString();
            txtSaucQuant.Text = 0.ToString();
            txtMacarPrice.Text = 0.ToString();
            txtMacarQuant.Text = 0.ToString();
            txtKoftaPrice.Text = 0.ToString();
            txtKoftaQuant.Text = 0.ToString();

            txtOtherCharges.Text = "";
            txtAdvance.Text = "";
            txtGrdTotal.Text = "";
            txtBalance.Text = "";
            txtNoPersons.Text = "";
            lblDrinkCost.Text = "DrinkCost";
            lblFoodCost.Text = "FoodCost";


        }
        private void frmBooking_Load(object sender, EventArgs e)
        {
            FillComboBoxWithCustomers();
            ResetForm();
        }
        private void txtWatPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cbxWater_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxWater.Checked)
            {
                txtWatPrice.Enabled = true;
                txtWatQuant.Enabled = true;
                txtWatPrice.Focus();
                txtWatPrice.SelectAll();
            }else
            {
                txtWatPrice.Enabled = false;
                txtWatQuant.Enabled = false;
                txtWatPrice.Text = 0.ToString();
                txtWatQuant.Text = 0.ToString();
            }
        }
        private void chbJuice_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxJuice.Checked)
            {
                txtJuiPrice.Enabled= true;
                txtJuicQuant.Enabled= true;
                txtJuiPrice.Focus();
                txtJuiPrice.SelectAll();
            }else
            {
                txtJuiPrice.Enabled = false;
                txtJuicQuant.Enabled = false;
                txtJuiPrice.Text=0.ToString();
                txtJuicQuant.Text= 0.ToString();
            }
        }
        private void cbxTea_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxTea.Checked)
            {
                txtTeaPrice.Enabled= true;
                txtTeaQuant.Enabled = true;
                txtTeaPrice.Focus();
                txtTeaPrice.SelectAll();
            }else
            {
                txtTeaPrice.Enabled = false;
                txtTeaQuant.Enabled = false;
                txtTeaPrice.Text = 0.ToString();
                txtTeaQuant.Text = 0.ToString();
            }
        }
        private void cbxCoffe_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxCoffe.Checked)
            {
                txtCofPrice.Enabled= true;
                txtCofQuant.Enabled= true;
                txtCofPrice.Focus();
                txtCofPrice.SelectAll();
            }
            else
            {
                txtCofPrice.Enabled = false;
                txtCofQuant.Enabled = false;
                txtCofPrice.Text=0.ToString();
                txtCofQuant.Text = 0.ToString();
            }
        }
        private void cbxSoda_CheckedChanged(object sender, EventArgs e)
        {
            if( cbxSoda.Checked)
            {
                txtSodaPrice.Enabled= true;
                txtSodaQuant.Enabled= true;
                txtSodaPrice.Focus();
                txtSodaPrice.SelectAll();
            }
            else
            {
                txtSodaPrice.Enabled = false;
                txtSodaQuant.Enabled=false;
                txtSodaPrice.Text=0.ToString();
                txtSodaQuant.Text = 0.ToString();
            }
        }
        private void cbxChicken_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxChicken.Checked)
            {
                txtChickPrice.Enabled= true;
                txtChickQuant.Enabled= true;
                txtChickPrice.Focus();
                txtChickPrice.SelectAll();
            }else
            {
                txtChickPrice.Enabled = false;
                txtChickQuant.Enabled=false;
                txtChickPrice.Text = 0.ToString();
                txtChickQuant.Text = 0.ToString();
            }
        }
        private void chxFish_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxFish.Checked)
            {
                txtFishPrice.Enabled = true;
                txtFishQuant.Enabled= true;
                txtFishPrice.Focus();
                txtFishPrice.SelectAll();
            }
            else
            {
                txtFishPrice.Enabled = false;
                txtFishQuant.Enabled= false;
                txtFishPrice.Text = 0.ToString();
                txtFishQuant.Text = 0.ToString();
            }
        }
        private void chbSaucage_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSaucage.Checked)
            {
                txtSaucPrice.Enabled = true;
                txtSaucQuant.Enabled= true;
                txtSaucPrice.Focus();
                txtSaucPrice.SelectAll();
            }else
            {
                txtSaucPrice.Enabled = false;
                txtSaucQuant.Enabled= false;
                txtSaucPrice.Text = 0.ToString();
                txtSaucQuant.Text = 0.ToString();
            }
        }
        private void cbxMacaroni_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxMacaroni.Checked)
            {
                txtMacarPrice.Enabled= true;
                txtMacarQuant.Enabled= true;
                txtMacarPrice.Focus();
                txtMacarPrice.SelectAll();
            }
            else
            {
                txtMacarPrice.Enabled = false;
                txtMacarQuant.Enabled= false;
                txtMacarPrice.Text = 0.ToString();
                txtMacarQuant.Text = 0.ToString();
            }
        }
        private void cbxKofta_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxKofta.Checked)
            {
                txtKoftaPrice.Enabled= true;
                txtKoftaQuant.Enabled= true;
                txtKoftaPrice.Focus();
                txtKoftaPrice.SelectAll();
            }
            else
            {
                txtKoftaPrice.Enabled = false;
                txtKoftaQuant.Enabled= false;
                txtKoftaPrice.Text = 0.ToString();
                txtKoftaQuant.Text = 0.ToString();
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void CalculateDrinksCost()
        {
            
            DrinksCost = 0;

            if (cbxWater.Checked)
            {
                stDrinks.Add(new stDrink
                {
                    Quantity = Convert.ToInt32(txtWatQuant.Text),
                    Price = Convert.ToInt32(txtWatPrice.Text),
                    Cost = Convert.ToInt32(txtWatPrice.Text) * Convert.ToInt32(txtWatQuant.Text),
                    DrinkID = 1
                });
                DrinksCost += Convert.ToInt32(txtWatPrice.Text) * Convert.ToInt32(txtWatQuant.Text);

                //Water.Price = Convert.ToInt32(txtWatPrice.Text);
                //Water.Quantity = Convert.ToInt32(txtWatQuant.Text);
                //Water.Cost = Water.Price * Water.Quantity;
                //Water.DrinkID = 1;
                // DrinksCost += Water.Cost;

            }

            if (cbxJuice.Checked)
            {
                stDrinks.Add(new stDrink
                {
                    Quantity = Convert.ToInt32(txtJuicQuant.Text),
                    Price = Convert.ToInt32(txtJuiPrice.Text),
                    Cost = Convert.ToInt32(txtJuiPrice.Text) * Convert.ToInt32(txtJuicQuant.Text),
                    DrinkID=2
                });

                DrinksCost += Convert.ToInt32(txtJuiPrice.Text) * Convert.ToInt32(txtJuicQuant.Text);
            }

            if (cbxTea.Checked)
            {
                stDrinks.Add(new stDrink
                {
                    Quantity=Convert.ToInt32(txtTeaQuant.Text),
                    Price=Convert.ToInt32(txtTeaPrice.Text),
                    Cost= Convert.ToInt32(txtTeaPrice.Text)* Convert.ToInt32(txtTeaQuant.Text),
                    DrinkID=3
                });
                DrinksCost += Convert.ToInt32(txtTeaPrice.Text) * Convert.ToInt32(txtTeaQuant.Text);
            }

            if (cbxCoffe.Checked)
            {
                stDrinks.Add(new stDrink
                {
                    Quantity = Convert.ToInt32(txtCofQuant.Text),
                    Price = Convert.ToInt32(txtCofPrice.Text),
                    Cost = Convert.ToInt32(txtCofPrice.Text) * Convert.ToInt32(txtCofQuant.Text),
                    DrinkID = 4
                });
                DrinksCost += Convert.ToInt32(txtCofPrice.Text) * Convert.ToInt32(txtCofQuant.Text);
            }

            if (cbxSoda.Checked)
            {
                stDrinks.Add(new stDrink
                {
                    Quantity = Convert.ToInt32(txtSodaQuant.Text),
                    Price = Convert.ToInt32(txtSodaPrice.Text),
                    Cost = Convert.ToInt32(txtSodaPrice.Text) * Convert.ToInt32(txtSodaQuant.Text),
                    DrinkID = 5
                });
                DrinksCost += Convert.ToInt32(txtSodaPrice.Text) * Convert.ToInt32(txtSodaQuant.Text);
            }

            lblDrinkCost.Text = DrinksCost.ToString();
        }
        private void CalculateFoodsCost()
        {
            FoodsCost = 0;

            if (cbxChicken.Checked)
            {
                stFoods.Add(new stFood
                {
                    Quantity = Convert.ToInt32(txtChickQuant.Text),
                    Price = Convert.ToInt32(txtChickPrice.Text),
                    Cost = Convert.ToInt32(txtChickPrice.Text) * Convert.ToInt32(txtChickQuant.Text),
                    FoodID = 1
                });
                
                FoodsCost += Convert.ToInt32(txtChickPrice.Text) * Convert.ToInt32(txtChickQuant.Text);
            }

            if (cbxFish.Checked)
            {
                stFoods.Add(new stFood
                {
                    Quantity = Convert.ToInt32(txtFishQuant.Text),
                    Price = Convert.ToInt32(txtFishPrice.Text),
                    Cost = Convert.ToInt32(txtFishPrice.Text) * Convert.ToInt32(txtFishQuant.Text),
                    FoodID = 2
                });

                FoodsCost += Convert.ToInt32(txtFishPrice.Text) * Convert.ToInt32(txtFishQuant.Text);
            }

            if (cbxSaucage.Checked)
            {
                stFoods.Add(new stFood
                {
                    Quantity = Convert.ToInt32(txtSaucQuant.Text),
                    Price = Convert.ToInt32(txtSaucPrice.Text),
                    Cost = Convert.ToInt32(txtSaucPrice.Text) * Convert.ToInt32(txtSaucQuant.Text),
                    FoodID = 3
                });
                FoodsCost += Convert.ToInt32(txtSaucPrice.Text) * Convert.ToInt32(txtSaucQuant.Text);
            }

            if (cbxMacaroni.Checked)
            {
                stFoods.Add(new stFood
                {
                    Quantity = Convert.ToInt32(txtMacarQuant.Text),
                    Price = Convert.ToInt32(txtMacarPrice.Text),
                    Cost = Convert.ToInt32(txtMacarPrice.Text) * Convert.ToInt32(txtMacarQuant.Text),
                    FoodID = 4
                });
                FoodsCost += Convert.ToInt32(txtMacarPrice.Text) * Convert.ToInt32(txtMacarQuant.Text);
            }

            if (cbxKofta.Checked)
            {

                stFoods.Add(new stFood
                {
                    Quantity = Convert.ToInt32(txtKoftaQuant.Text),
                    Price = Convert.ToInt32(txtKoftaQuant.Text),
                    Cost = Convert.ToInt32(txtKoftaPrice.Text) * Convert.ToInt32(txtKoftaQuant.Text),
                    FoodID = 5
                });
                FoodsCost += Convert.ToInt32(txtKoftaPrice.Text) * Convert.ToInt32(txtKoftaQuant.Text);
            }

            lblFoodCost.Text = FoodsCost.ToString();
        }
        private void btnCalculateBeverage_Click(object sender, EventArgs e)
        {
            CalculateDrinksCost();
        }
        private void btnCalculateDishes_Click(object sender, EventArgs e)
        {
            CalculateFoodsCost();
        }
        private void txtOtherCharges_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtOtherCharges.Text))
            {
                txtGrdTotal.Text = "";
                return;
            }
            OtherCharges = Convert.ToInt32(txtOtherCharges.Text);
            GrdTotal = DrinksCost + FoodsCost + OtherCharges;
            txtGrdTotal.Text= GrdTotal.ToString();
        }
        private void txtAdvance_TextChanged(object sender, EventArgs e)
        {
            Advance = 0;
            Balance = 0;

            if (string.IsNullOrEmpty(txtAdvance.Text))
            {
                txtBalance.Text = "";
                return;
            }

            //If Donot Have OtherChrges & GrdTotal
            if (string.IsNullOrEmpty(txtOtherCharges.Text))
            {
                Advance = Convert.ToInt32(txtAdvance.Text);
                Balance = (FoodsCost + DrinksCost) - Advance;
                txtBalance.Text= Balance.ToString();
                return;
            }

           
            Advance = Convert.ToInt32(txtAdvance.Text);
            Balance = GrdTotal - Advance;
            txtBalance.Text = Balance.ToString();
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAdvance.Text)||string.IsNullOrEmpty(txtOtherCharges.Text))
            {
                MessageBox.Show("Pay Money", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsBooking booking = new clsBooking();
            int CustomerID = clsCustomer.Find(cbxCustomers.Text).CustomerID;

            booking.Date = dtpDate.Value;
            booking.Time = cbxTime.SelectedItem.ToString();
            if (txtNoPersons.Text != "")
            {
                booking.NoPersons = Convert.ToInt32(txtNoPersons.Text);
            }
            else
            {
                booking.NoPersons = 0;
            }
            booking.CustomerID = CustomerID;

            booking.OtherCharges = OtherCharges;
            booking.GrdTotal = GrdTotal;
            booking.Advance = Advance;
            booking.Balance = Balance;

            booking._stDrinks = new List<clsBooking.stDrink>();
            foreach(stDrink drink in stDrinks)
            {
                clsBooking.stDrink ConvertedDrink = new clsBooking.stDrink
                {
                    Quantity = drink.Quantity,
                    Cost = drink.Cost,
                    Price = drink.Price,
                    DrinkID = drink.DrinkID
                };
                booking._stDrinks.Add(ConvertedDrink);
            }

            booking._stFoods = new List<clsBooking.stFood>();
            foreach(stFood food in stFoods)
            {
                clsBooking.stFood ConvertedFood = new clsBooking.stFood
                {
                    Quantity = food.Quantity,
                    Cost = food.Cost,
                    Price = food.Price,
                    FoodID = food.FoodID,
                };
                booking._stFoods.Add(ConvertedFood);
            }

            if(booking.Save())
            {
                MessageBox.Show("Booking Added Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show("Booking not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAddBooking_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Transparent;
        }

        private void btnAddBooking_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Crimson;
        }
    }
}
