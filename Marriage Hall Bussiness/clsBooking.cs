using MarriageHallData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage_Hall_Bussiness
{
    public class clsBooking
    {
        public enum enMode { AddNew=0,Update=1};
        public enMode Mode = enMode.AddNew;

        public int BookingID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int NoPersons { get; set; }

        //Payment
        public int PaymentID { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal GrdTotal { get; set; }
        public decimal Advance { get; set; }
        public decimal Balance { get; set; }

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

        public List<stDrink> _stDrinks;
        public List<stFood> _stFoods;
        public clsBooking()
        {
            this.BookingID = -1;
            this.CustomerID = -1;
            this.Date = DateTime.Now;
            this.Time = "";
            this.NoPersons = 0;

            this.Mode = enMode.AddNew;
        }

        public static DataTable GetAllBooking()
        {
            return clsBookingData.GetAllBooking();
        }
        private bool _AddNewBooking()
        {
            //Fisrt Add Booking.
            //Second Add OrderDetails.
            this.BookingID = clsBookingData.AddNewBooking(this.CustomerID, this.Date, this.Time, this.NoPersons);
            
            //If the Booking is not added, it returns false 
            if (this.BookingID == -1)
                return false;

            //Do this if Client Checked Drinks
            if(this._stDrinks!=null)
            {
                foreach(stDrink drink in this._stDrinks)
                {
                    if(!clsBookingData.AddNewDrinkOrder(this.BookingID,drink.DrinkID,drink.Quantity,drink.Price,drink.Cost))
                    {
                        return false;
                    }
                }
            }

            //Do this if Client Checked Foods
            if (this._stFoods != null)
            {
                foreach (stFood food in this._stFoods)
                {
                    if (!clsBookingData.AddNewFoodOrder(this.BookingID,food.FoodID,food.Quantity,food.Price,food.Cost))
                    {
                        return false;
                    }
                }
            }

            this.PaymentID = clsBookingData.AddNewPayment(this.CustomerID, this.OtherCharges, this.GrdTotal,
                this.Advance, this.Balance,this.BookingID);

            //if the Payment is not added,it returns false
            if (this.PaymentID == -1)
                return false;


            return true;
        }

        public static bool DeleteBooking(int BookingID)
        {
            return clsBookingData.DeleteBooking(BookingID);
        }
        public bool Save()
        {
            if(_AddNewBooking())
            {
                return true;
            }else
            { 
                return false;
            }
        }
    }
}
