using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class RegisterDAO
    {
        private static RegisterDAO _instance;

        public static RegisterDAO Instance
        {
            get { if (_instance == null) _instance = new RegisterDAO(); return RegisterDAO._instance; }
            private set { RegisterDAO._instance = value; }
        }

        private RegisterDAO() { }

        public bool addID()
        {
            string query = "call sp_addid('" + "US" + "')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string ID = "";
            string query = "select * from NhanVien where MatKhau is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            ID = dt.Rows[0][0].ToString();
            return ID;
        }

        public bool register(string ID, string username, string phonenumber, string address, string email, string password, string isAdmin)
        {
            string query = "update NhanVien set MatKhau='" + password + "', TenNV=N'" + username + "', DienThoai='" + phonenumber + "', DiaChi=N'" + address + "', Email='" + email + "', VaiTro=N'" + isAdmin + "' where MaNV='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

    }
}
