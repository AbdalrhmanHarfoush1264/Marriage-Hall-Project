using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MarriageHallData
{
    public class clsUserData
    {
        public static bool CheckUsernameAndPassword(string username,string password)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();
                    using(SqlCommand command=new SqlCommand("sp_CheckUsernameAndPassword",connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter usernamepara= new SqlParameter("@UserName",SqlDbType.NVarChar);
                        usernamepara.Value = username;
                        command.Parameters.Add(usernamepara);

                        SqlParameter passwordPara = new SqlParameter("@Password", SqlDbType.NVarChar);
                        passwordPara.Value = password;
                        command.Parameters.Add(passwordPara);

                        
                        SqlParameter result = new SqlParameter("@IsFound", SqlDbType.Int);
                        result.Direction = ParameterDirection.Output;
                        command.Parameters.Add(result);


                        command.ExecuteNonQuery();
                        isFound = Convert.ToBoolean(result.Value);
                       
                    }

                }
            }
            catch (Exception ex)
            {
                //Error Log
            }
            return (isFound);
        }
        public static bool CheckPasswordForAdminIsTrue(string Password)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_CheckAdmin", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraPassword = new SqlParameter("@Password", SqlDbType.NVarChar);
                        paraPassword.Value = Password;
                        command.Parameters.Add(paraPassword);

                        


                        SqlParameter result = new SqlParameter("@Found", SqlDbType.Bit);
                        result.Direction = ParameterDirection.Output;
                        command.Parameters.Add(result);


                        command.ExecuteNonQuery();
                        isFound = Convert.ToBoolean(result.Value);

                    }

                }
            }
            catch (Exception ex)
            {
                //Error Log
            }
            return (isFound);
        }

        public static DataTable GetAllStaff()
        {
            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_GetAllStaff", connection))
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
        public static bool GetStaffInfoByID(int StaffID, ref string Name, ref string Password,
           ref string Phone, ref byte Gender)
        {

            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_FindStaffByID", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter paraID = new SqlParameter("@StaffID", SqlDbType.Int);
                        paraID.Value = StaffID;
                        command.Parameters.Add(paraID);

                        SqlParameter resultName = new SqlParameter("@Name", SqlDbType.NVarChar, 350);
                        resultName.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultName);

                        SqlParameter resultPassword = new SqlParameter("@Password", SqlDbType.NVarChar, 350);
                        resultPassword.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultPassword);

                        SqlParameter resultPhone = new SqlParameter("@Phone", SqlDbType.NVarChar, 20);
                        resultPhone.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultPhone);

                        SqlParameter resultGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        resultGender.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultGender);

                        SqlParameter resultIsFound = new SqlParameter("@IsFound", SqlDbType.TinyInt);
                        resultIsFound.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultIsFound);


                        command.ExecuteNonQuery();
                        Name = Convert.ToString(resultName.Value);
                        Password = Convert.ToString(resultPassword.Value);
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

        public static int AddNewStaff(string Name, string Password, string Phone, byte Gender)
        {
            int StaffID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AddNewStaff", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter paraName = new SqlParameter("@Name", SqlDbType.NVarChar);
                        paraName.Value = Name;
                        command.Parameters.Add(paraName);

                        SqlParameter paraPassword = new SqlParameter("@Password", SqlDbType.NVarChar);
                        paraPassword.Value = Password;
                        command.Parameters.Add(paraPassword);

                        SqlParameter paraPhone = new SqlParameter("@Phone", SqlDbType.NVarChar);
                        paraPhone.Value = Phone;
                        command.Parameters.Add(paraPhone);

                        SqlParameter paraGender = new SqlParameter("@Gender", SqlDbType.TinyInt);
                        paraGender.Value = Gender;
                        command.Parameters.Add(paraGender);

                        SqlParameter resultID = new SqlParameter("@StaffID", SqlDbType.Int);
                        resultID.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultID);

                        command.ExecuteNonQuery();
                        StaffID = Convert.ToInt32(resultID.Value);
                    }
                }

            }
            catch (Exception ex)
            {
                //Event Log here.....
            }
            return StaffID;
        }
        public static bool UpdateStaff(int StaffID, string Name, string Password, string Phone, byte Gender)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_UpdateStaff", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraID = new SqlParameter("@StaffID", SqlDbType.Int);
                        paraID.Value = StaffID;
                        command.Parameters.Add(paraID);

                        SqlParameter paraName = new SqlParameter("@Name", SqlDbType.NVarChar);
                        paraName.Value = Name;
                        command.Parameters.Add(paraName);

                        SqlParameter paraPassword = new SqlParameter("@Password", SqlDbType.NVarChar);
                        paraPassword.Value = Password;
                        command.Parameters.Add(paraPassword);

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
        public static bool DeleteStaff(int StaffID)
        {
            bool isDelete = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsServerConnection.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_DeleteStaff", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter paraID = new SqlParameter("@StaffID", SqlDbType.Int);
                        paraID.Value = StaffID;
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
