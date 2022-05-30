using System;
using System.Data;

namespace BookstoreManagement.DTO
{
    public class Customer
    {
        private string _customerID;
        private string _name;
        private string _phonenumber;
        private string _address;
        private string _email;
        private double _deptMoney;

        public Customer() { }
        public Customer(string customerID, string name, string phonenumber, string address, string email, double deptMoney)
        {
            this._customerID = customerID;
            this._name = name;
            this._phonenumber = phonenumber;
            this._address = address;
            this._email = email;
            this._deptMoney = deptMoney;
        }

        public Customer(DataRow row)
        {
            this._customerID = row["MaKH"].ToString();
            this._name = row["TenKH"].ToString();
            this._phonenumber = row["DienThoai"].ToString();
            this._address = row["DiaChi"].ToString();
            this._email = row["Email"].ToString();
            this._deptMoney = Convert.ToDouble(row["TienNo"].ToString());
        }

        public string CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; } 
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phonenumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public double DeptMoney
        {
            get { return _deptMoney; }
            set { _deptMoney = value; }
        }
    }
}
