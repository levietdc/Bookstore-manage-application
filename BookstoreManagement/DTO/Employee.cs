using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BookstoreManagement.DTO
{
    public class Employee
    {
        private string _employeeID;
        private string _name;
        private string _phonenumber;
        private string _address;
        private string _email;
        private string _isAdmin;

        public Employee(string userID, string userName, string phonenumber, string address, string email, string isAdmin)
        {
            this._employeeID = userID;
            this._name = userName;
            this._address = address;
            this._phonenumber = phonenumber;
            this._email = email;
            this._isAdmin = isAdmin;
        }
        public Employee(DataRow row)
        {
            this._employeeID = row["MaNV"].ToString();
            this._name = row["TenNV"].ToString();
            this._phonenumber = row["DienThoai"].ToString();
            this._address = row["DiaChi"].ToString();
            this._email = row["Email"].ToString();
            this._isAdmin = row["VaiTro"].ToString();
        }
        public Employee() { }
        public string EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
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

        public string IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
    }
}
