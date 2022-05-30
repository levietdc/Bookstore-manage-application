using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//goi message box
using System.Security.Cryptography;
using System.Data;

namespace BookstoreManagement.DAO
{
    public class LoginDAO
    {
        private static LoginDAO _instance;

        public static LoginDAO Instance
        {
            get { if (_instance == null) _instance = new LoginDAO(); return LoginDAO._instance; }
            private set { LoginDAO._instance = value; }
        }

        private LoginDAO() { }

        public bool login(string email, string password)
        {
            string query = "select * from NhanVien where Email='" + email + "' and MatKhau='" + password + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;
        }
    }
}
