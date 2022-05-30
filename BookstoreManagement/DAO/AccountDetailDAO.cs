using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class AccountDetailDAO
    {
        private static AccountDetailDAO _instance;

        public static AccountDetailDAO Instance
        {
            get { if (_instance == null) _instance = new AccountDetailDAO(); return AccountDetailDAO._instance; }
            private set { AccountDetailDAO._instance = value; }
        }

        private AccountDetailDAO() { }

        public string HashPass(string PassBeforeHash)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(PassBeforeHash);
            byte[] hashdata = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashPass = "";
            foreach (byte item in hashdata)
            {
                hashPass += item;
            }
            return hashPass;
        }

        public bool isExistedEmail(string email)
        {
            string query = "select * from NhanVien where Email='" + email + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt.Rows.Count > 0;
        }

        public bool updateAccount(string ID, string username, string phonenumber, string address)
        {
            string query = "update NhanVien set TenNV=N'" + username + "', DienThoai='" + phonenumber + "', DiaChi=N'" + address + "' where MaNV='" + ID + "'";
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }

        public bool updateEmail(string ID, string email)
        {
            string query = "update NhanVien set Email='" + email + "' where MaNV='" + ID + "'";
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }

        public bool changePassword(string ID, string Password)
        {
            string query = "update NhanVien set MatKhau='" + Password + "' where MaNV='" + ID + "'";
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public Account getAccount(string email)
        {
            string query = "select * from NhanVien where Email='" + email + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Account account = new Account(data.Rows[0][0].ToString(), data.Rows[0][1].ToString(), data.Rows[0][2].ToString(), data.Rows[0][3].ToString(), data.Rows[0][4].ToString(), data.Rows[0][6].ToString(), data.Rows[0][5].ToString());
            return account;
        }

        public Account getAccountByID(string ID)
        {
            string query = "select * from NhanVien where MaNV='" + ID + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            Account account = new Account(data.Rows[0][0].ToString(), data.Rows[0][1].ToString(), data.Rows[0][2].ToString(), data.Rows[0][3].ToString(), data.Rows[0][4].ToString(), data.Rows[0][6].ToString(), data.Rows[0][5].ToString());
            return account;
        }

        public string getIdByEmail(string email)
        {
            string query = "select MaNV from NhanVien where Email = '" + email + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            string id = data.Rows[0][0].ToString();
            return id;
        }
    }
}
