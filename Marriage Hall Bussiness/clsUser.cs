using MarriageHallData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marriage_Hall_Bussiness
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte Gender { get; set; }
        public string Password { get; set; }
        public static bool CheckUserNameAndPassword(string username, string password)
        {
            return clsUserData.CheckUsernameAndPassword(username, password);
        }
        public static bool CheckPasswordForAdminIsTrue(string Password)
        {
            return clsUserData.CheckPasswordForAdminIsTrue(Password);
        }
        public static DataTable GetAllStaff()
        {
            return clsUserData.GetAllStaff();
        }

        public clsUser()
        {
            this.StaffID = -1;
            this.Name = "";
            this.Password = "";
            this.Phone = "";
            this.Gender = 0;

            Mode=enMode.AddNew;
        }
        public clsUser(int staffID, string name, string password, string phone, byte gender)
        {
            this.StaffID = staffID;
            this.Name = name;
            this.Password = password;
            this.Phone = phone;
            this.Gender = gender;

            Mode = enMode.Update;
        }
        public static clsUser Find(int StaffID)
        {
            string name = "", password = "", phone = "";
            byte gender = 0;

            if (clsUserData.GetStaffInfoByID(StaffID,ref name,ref password,ref phone,ref gender))
            {
                return new clsUser(StaffID, name, password, phone, gender);
            }
            else
                return null;
        }


        private bool _AddNewStaff()
        {
            this.StaffID = clsUserData.AddNewStaff(this.Name,this.Password,this.Phone,this.Gender);
            return (this.StaffID != -1);
        }
        private bool _UpdateStaff()
        {
            return clsUserData.UpdateStaff(this.StaffID, this.Name, this.Password, this.Phone, this.Gender);
        }
        public bool DeleteStaff()
        {
            return clsUserData.DeleteStaff(this.StaffID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewStaff())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdateStaff();
            }
            return false;
        }
    }
}
