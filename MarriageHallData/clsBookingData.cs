using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarriageHallData
{
    public class clsBookingData
    {

        public static DataTable GetAllBooking()
        {

            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_ViewBookingList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //Event Log Here!......
            }
            return dt;
        }
        public static int AddNewBooking(int CustomerID,DateTime Date,string Time,int NoPersons)
        {
            int BookingID = -1;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_AddNewBooking",connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        paraCustomerID.Value = CustomerID;
                        command.Parameters.Add(paraCustomerID);

                        SqlParameter paraDate = new SqlParameter("@Date", SqlDbType.DateTime);
                        paraDate.Value = Date;
                        command.Parameters.Add(paraDate);

                        SqlParameter paraTime = new SqlParameter("@Time", SqlDbType.NVarChar);
                        paraTime.Value = Time;
                        command.Parameters.Add(paraTime);

                        SqlParameter paraPersons = new SqlParameter("@NoPersons", SqlDbType.Int);
                        paraPersons.Value = NoPersons;
                        command.Parameters.Add(paraPersons);

                        SqlParameter resultBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
                        resultBookingID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultBookingID);

                        command.ExecuteNonQuery();
                        BookingID = Convert.ToInt32(resultBookingID.Value);
                    }
                }

            }catch(Exception ex)
            {
                //Event Log Here....!
            }
            return BookingID;
        }

        public static bool AddNewDrinkOrder(int BookingID,int DrinkID,int Quantity,decimal Price,decimal Cost)
        {
            bool isAdded = false;
            //int DrinkOrderID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_AddNewDrinkOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
                        paraBookingID.Value = BookingID;
                        command.Parameters.Add(paraBookingID);

                        SqlParameter paraDrinkID = new SqlParameter("@DrinkID", SqlDbType.Int);
                        paraDrinkID.Value = DrinkID;
                        command.Parameters.Add(paraDrinkID);

                        SqlParameter paraQuantity = new SqlParameter("@Quantity", SqlDbType.Int);
                        paraQuantity.Value = Quantity;
                        command.Parameters.Add(paraQuantity);

                        SqlParameter paraPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                        paraPrice.Value = Price;
                        command.Parameters.Add(paraPrice);

                        SqlParameter paraCost = new SqlParameter("@Cost", SqlDbType.Decimal);
                        paraCost.Value = Cost;
                        command.Parameters.Add(paraCost);

                        SqlParameter resultDrinkOrderID = new SqlParameter("@OrderID", SqlDbType.Int);
                        resultDrinkOrderID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultDrinkOrderID);

                        command.ExecuteNonQuery();
                        isAdded = true;
                        
                        //DrinkOrderID = Convert.ToInt32(resultDrinkOrderID.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                isAdded = false;
                //Event Log Here....!
            }
            return isAdded;
            //return DrinkOrderID;
        }

        public static bool AddNewFoodOrder(int BookingID, int FoodID, int Quantity, decimal Price, decimal Cost)
        {
            bool isAdded = false;
            //int DrinkOrderID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_AddNewFoodOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
                        paraBookingID.Value = BookingID;
                        command.Parameters.Add(paraBookingID);

                        SqlParameter paraFoodID = new SqlParameter("@FoodID", SqlDbType.Int);
                        paraFoodID.Value = FoodID;
                        command.Parameters.Add(paraFoodID);

                        SqlParameter paraQuantity = new SqlParameter("@Quantity", SqlDbType.Int);
                        paraQuantity.Value = Quantity;
                        command.Parameters.Add(paraQuantity);

                        SqlParameter paraPrice = new SqlParameter("@Price", SqlDbType.Decimal);
                        paraPrice.Value = Price;
                        command.Parameters.Add(paraPrice);

                        SqlParameter paraCost = new SqlParameter("@Cost", SqlDbType.Decimal);
                        paraCost.Value = Cost;
                        command.Parameters.Add(paraCost);

                        SqlParameter resultFoodOrderID = new SqlParameter("@OrderID", SqlDbType.Int);
                        resultFoodOrderID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultFoodOrderID);

                        command.ExecuteNonQuery();
                        isAdded = true;

                        //DrinkOrderID = Convert.ToInt32(resultDrinkOrderID.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                isAdded = false;
                //Event Log Here....!
            }
            return isAdded;
            //return DrinkOrderID;
        }

        public static int AddNewPayment(int CustomerID, decimal OtherCharges, decimal GrdTotal,
            decimal Advance, decimal Balance,int BookingID)
        {
            int PaymentID = -1;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using(SqlCommand command=new SqlCommand("sp_AddNewPayment",connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        paraCustomerID.Value = CustomerID;
                        command.Parameters.Add(paraCustomerID);

                        SqlParameter paraOtherCharges = new SqlParameter("@OtherCharges", SqlDbType.Decimal);
                        paraOtherCharges.Value = OtherCharges;
                        command.Parameters.Add(paraOtherCharges);

                        SqlParameter paraGrdTotal = new SqlParameter("@GrdTotal", SqlDbType.Decimal);
                        paraGrdTotal.Value = GrdTotal;
                        command.Parameters.Add(paraGrdTotal);

                        SqlParameter paraAdance=new SqlParameter("Advance",SqlDbType.Decimal);
                        paraAdance.Value = Advance;
                        command.Parameters.Add(paraAdance);

                        SqlParameter paraBalance = new SqlParameter("@Balance", SqlDbType.Decimal);
                        paraBalance.Value = Balance;
                        command.Parameters.Add(paraBalance);

                        SqlParameter paraBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
                        paraBookingID.Value = BookingID;
                        command.Parameters.Add(paraBookingID);

                        SqlParameter resultPaymentID = new SqlParameter("@PaymentID", SqlDbType.Int);
                        resultPaymentID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultPaymentID);

                        command.ExecuteNonQuery();
                        PaymentID = Convert.ToInt32(resultPaymentID.Value);
                    }
                }
            }catch(Exception ex)
            {
                //Event Log Here..!
            }
            return PaymentID;
        }

        public static bool DeleteBooking(int BookingID)
        {
            bool isDelete = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_DeleteBooking", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraID = new SqlParameter("@BookingID", SqlDbType.Int);
                        paraID.Value = BookingID;
                        command.Parameters.Add(paraID);

                        command.ExecuteNonQuery();
                        isDelete = true;
                    }

                }

            }
            catch (Exception ex)
            {
                ///Event Log Here....

                isDelete = false;
            }
            return isDelete;
        }
    }
}
