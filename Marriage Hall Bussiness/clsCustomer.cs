using MarriageHallData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Marriage_Hall_Bussiness
{
    public class clsCustomer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte Gender { get; set; }

        public clsCustomer()
        {
            this.CustomerID = -1;
            this.Name = "";
            this.Address = "";
            this.Phone = "";
            this.Gender = 0;

            this.Mode = enMode.AddNew;
        }
        public clsCustomer(int customerID, string name, string address, string phone, byte gender)
        {
            this.CustomerID = customerID;
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Gender = gender;

            Mode = enMode.Update;
        }
       
        public static DataTable GetAllCustomers()
        {
            return clsCustomerData.GetAllCustomers();
        }

        public static clsCustomer Find(int CustomerID)
        {
            string name = "", address = "", phone = "";
            byte gender = 0;

            if (clsCustomerData.GetCustomerInfoByID(CustomerID, ref name, ref address, ref phone, ref gender))
            {
                return new clsCustomer(CustomerID, name, address, phone, gender);
            }
            else
                return null;
        }

        public static clsCustomer Find(string Name)
        {
            string address = "", phone = "";
            byte gender = 0;
            int CustomerID = -1;


            if (clsCustomerData.GetCustomerInfoByName(Name, ref CustomerID, ref address, ref phone, ref gender))
            {
                return new clsCustomer(CustomerID, Name, address, phone, gender);
            }
            else
                return null;
        }

        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(this.Name, this.Address, this.Phone, this.Gender);
            return (CustomerID != -1);
        }
        private bool _UpdateCustomer()
        {
            return clsCustomerData.UpdateCustomer(this.CustomerID, this.Name, this.Address, this.Phone, this.Gender);
        }

        public bool DeleteCustomer()
        {
            return clsCustomerData.DeleteCustomer(this.CustomerID);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewCustomer())
                        {
                            Mode = enMode.Update;
                            return true;
                        }else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    return _UpdateCustomer();
            }
            return false;
        }
    }
}
