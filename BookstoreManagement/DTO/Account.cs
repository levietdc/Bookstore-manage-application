using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BookstoreManagement.DTO
{
    public class Account
    {
        private string _userID;
        private string _userName;
        private string _phonenumber;
        private string _address;
        private string _email;
        private string _password;
        private string _isAdmin;

        public Account(string userID, string userName, string phonenumber, string address, string email, string isAdmin, string password = null)
        {
            this._userID = userID;
            this._userName = userName;
            this._address = address;
            this._phonenumber = phonenumber;
            this._email = email;
            this._password = password;
            this._isAdmin = isAdmin;
        }
        public Account(DataRow row)
        {
            this._userID = row["MaNV"].ToString();
            this._userName = row["TenNV"].ToString();
            this._phonenumber = row["DienThoai"].ToString();
            this._address = row["DiaChi"].ToString();
            this._email = row["Email"].ToString();
            this._password = row["MatKhau"].ToString();
            this._isAdmin = row["VaiTro"].ToString();
        }
        public Account() { }
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public string Username
        {
            get { return _userName; }
            set { _userName = value; }
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

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }
    }
}
