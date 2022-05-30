using System.Collections.Generic;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    class EmployeeDAO
    {
        private static EmployeeDAO _instance;

        public static EmployeeDAO Instance
        {
            get { if (_instance == null) _instance = new EmployeeDAO(); return EmployeeDAO._instance; }
            private set { EmployeeDAO._instance = value; }
        }

        private EmployeeDAO() { }

        public List<Employee>DisplayData()
        {
            List<Employee> Employeelist = new List<Employee>();
            string isAdmin = "Nhân viên";
            string query = "select MaNV, TenNV, DienThoai, DiaChi, Email, VaiTro from NhanVien where VaiTro=N'" + isAdmin + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                Employeelist.Add(new Employee(row));
            }
            return Employeelist;
        }

        public List<Employee>SearchName(string name)
        {
            List<Employee> Employeelist = new List<Employee>();
            string isAdmin = "Nhân viên";
            string query = "select MaNV, TenNV, DienThoai, DiaChi, Email, VaiTro from NhanVien where TenNV=N'" + name + "' and VaiTro=N'" + isAdmin + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Employeelist.Add(new Employee(row));
            }
            return Employeelist;
        }

        public List<Employee>SearchID(string ID)
        {

            List<Employee> Employeelist = new List<Employee>();
            string isAdmin = "Nhân viên";
            string query = "select MaNV, TenNV, DienThoai, DiaChi, Email, VaiTro from NhanVien where MaNV=N'" + ID + "' and VaiTro=N'" + isAdmin + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Employeelist.Add(new Employee(row));
            }
            return Employeelist;
        }

        public bool Delete(string ID)
        {
            string query = "delete from NhanVien where MaNV='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool Update(string ID, string username, string phonenumber, string address, string email, string isAdmin)
        {
            string query = "update NhanVien set TenNV=N'" + username + "', DienThoai='" + phonenumber + "', DiaChi=N'" + address + "', Email=N'" + email + "', VaiTro=N'" + isAdmin + "' where MaNV='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool isExistedEmail(string email, string id)
        {
            string query = "select * from NhanVien where Email='" + email + "' and MaNV <> '" + id + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt.Rows.Count > 0;
        }
    }
}
