using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarriageHallData
{
    public class clsCustomerData
    {
        public static DataTable GetAllCustomers()
        {
            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_GetAllCustomers", connection))
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

        public static int AddNewCustomer(string Name, string Address, string Phone, byte Gender)
        {
            int CustomerID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AddNewCustomer", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter paraName = new SqlParameter("@Name", SqlDbType.NVarChar);
                        paraName.Value = Name;
                        command.Parameters.Add(paraName);

                        SqlParameter paraAddress = new SqlParameter("@Address", SqlDbType.NVarChar);
                        paraAddress.Value = Address;
                        command.Parameters.Add(paraAddress);

                        SqlParameter paraPhone = new SqlParameter("@Phone", SqlDbType.NVarChar);
                        paraPhone.Value = Phone;
                        command.Parameters.Add(paraPhone);

                        SqlParameter paraGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        paraGender.Value = Gender;
                        command.Parameters.Add(paraGender);

                        SqlParameter resultID = new SqlParameter("@ID", SqlDbType.Int);
                        resultID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultID);

                        command.ExecuteNonQuery();
                        CustomerID = Convert.ToInt32(resultID.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                //Event Log here.....
            }
            return CustomerID;
        }

        public static bool UpdateCustomer(int CustomerID, string Name, string Address, string Phone, byte Gender)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_UpdateCustomer",connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        paraID.Value = CustomerID;
                        command.Parameters.Add(paraID);

                        SqlParameter paraName = new SqlParameter("@Name", SqlDbType.NVarChar);
                        paraName.Value = Name;
                        command.Parameters.Add(paraName);

                        SqlParameter paraAddress = new SqlParameter("@Address", SqlDbType.NVarChar);
                        paraAddress.Value = Address;
                        command.Parameters.Add(paraAddress);

                        SqlParameter paraPhone = new SqlParameter("@Phone", SqlDbType.NVarChar);
                        paraPhone.Value = Phone;
                        command.Parameters.Add(paraPhone);

                        SqlParameter paraGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        paraGender.Value = Gender;
                        command.Parameters.Add(paraGender);

                        command.ExecuteNonQuery();
                        IsFound = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //Event Log....
                IsFound = false;
            }
            return IsFound;
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            bool isDelete = false;

            try
            {
                using(SqlConnection connection=new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using(SqlCommand command=new SqlCommand("sp_DeleteCustomer",connection))
                    {
                       command.CommandType=CommandType.StoredProcedure;

                        SqlParameter paraID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        paraID.Value = CustomerID;
                        command.Parameters.Add(paraID);

                        command.ExecuteNonQuery();
                        isDelete = true;
                    }

                }

            }catch(Exception ex)
            {
                ///Event Log Here....

                isDelete = false;
            }
            return isDelete;
        }

        public static bool GetCustomerInfoByID(int CustomerID, ref string Name, ref string Address,
            ref string Phone, ref byte Gender)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_FindCustomerByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter paraID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        paraID.Value = CustomerID;
                        command.Parameters.Add(paraID);

                        SqlParameter resultName = new SqlParameter("@Name", SqlDbType.NVarChar, 350);
                        resultName.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultName);

                        SqlParameter resultAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 350);
                        resultAddress.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultAddress);

                        SqlParameter resultPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                        resultPhone.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultPhone);

                        SqlParameter resultGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        resultGender.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultGender);

                        SqlParameter resultIsFound = new SqlParameter("@IsFound", SqlDbType.Int);
                        resultIsFound.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultIsFound);


                        command.ExecuteNonQuery();
                        Name = Convert.ToString(resultName.Value);
                        Address = Convert.ToString(resultAddress.Value);
                        Phone = Convert.ToString(resultPhone.Value);
                        Gender = Convert.ToByte(resultGender.Value);
                        IsFound = Convert.ToBoolean(resultIsFound.Value);
                    }

                }

            }
            catch (Exception ex)
            {
                //Event Log....Here
                IsFound = false;
            }
            return IsFound;
        }

        public static bool GetCustomerInfoByName(string Name,ref int CustomerID, ref string Address,
        ref string Phone, ref byte Gender)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_FindCustomerByName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter paraName = new SqlParameter("@Name", SqlDbType.NVarChar);
                        paraName.Value = Name;
                        command.Parameters.Add(paraName);

                        SqlParameter resultID = new SqlParameter("@CustomerID", SqlDbType.Int);
                        resultID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultID);

                        SqlParameter resultAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 350);
                        resultAddress.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultAddress);

                        SqlParameter resultPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                        resultPhone.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultPhone);

                        SqlParameter resultGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        resultGender.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultGender);

                        SqlParameter resultIsFound = new SqlParameter("@IsFound", SqlDbType.Int);
                        resultIsFound.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultIsFound);


                        command.ExecuteNonQuery();
                        CustomerID = Convert.ToInt32(resultID.Value);
                        Address = Convert.ToString(resultAddress.Value);
                        Phone = Convert.ToString(resultPhone.Value);
                        Gender = Convert.ToByte(resultGender.Value);
                        IsFound = Convert.ToBoolean(resultIsFound.Value);
                    }

                }

            }
            catch (Exception ex)
            {
                //Event Log....Here
                IsFound = false;
            }
            return IsFound;
        }

    }
}
