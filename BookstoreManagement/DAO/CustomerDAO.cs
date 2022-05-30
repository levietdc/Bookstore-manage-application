using System.Collections.Generic;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO _instance;

        public static CustomerDAO Instance
        {
            get { if (_instance == null) _instance = new CustomerDAO(); return CustomerDAO._instance; }
            private set { CustomerDAO._instance = value; }
        }

        public List<string> getId()
        {
            List<string> Names = new List<string>();
            string query = "select MaKH from KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Names.Add(row[0].ToString());
            }
            return Names;
        }

        private CustomerDAO() { }

        public List<Customer> DisplayData()
        {
            List<Customer> customerlist = new List<Customer>();
            string query = "select * from KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                customerlist.Add(new Customer(row));
            }
            return customerlist;
        }

        public List<Customer> SearchName(string name)
        {
            List<Customer> customerlist = new List<Customer>();
            string query = "select * from KhachHang where TenKH='" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                customerlist.Add(new Customer(row));
            }
            return customerlist;
        }

        public List<Customer> SearchID(string ID)
        {
            List<Customer> customerlist = new List<Customer>();
            string query = "select * from KhachHang where MaKH='" + ID + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                customerlist.Add(new Customer(row));
            }
            return customerlist;
        }

        public bool addID()
        {
            string query = "call sp_addidkh('" + "KH" + "')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string ID = "";
            string query = "select * from KhachHang where TenKH is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            ID = dt.Rows[0][0].ToString();
            return ID;
        }

        public bool Add(string ID, string name, string phonumber, string address, string email, double deptmoney)
        {
            string query = "update KhachHang set TenKH=N'" + name + "', DienThoai='" + phonumber + "', DiaChi=N'" + address + "', Email='" + email + "', TienNo=" + deptmoney +" where MaKH='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool Delete(string ID)
        {
            string query = "delete from KhachHang where MaKH='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool Update(string ID, string name, string phonumber, string address, string email, double deptmoney)
        {
            string query = "update KhachHang set TenKH=N'" + name + "', DienThoai='" + phonumber + "', DiaChi=N'" + address + "', Email='" + email + "', TienNo=" + deptmoney + " where MaKH='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public void Update(Customer a)
        {
            string query = "update KhachHang set TenKH=N'" + a.Name + "', DienThoai='" + a.Phonenumber + "', DiaChi=N'" + a.Address + "', Email='" + a.Email + "', TienNo=" + a.DeptMoney + " where MaKH='" + a.CustomerID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool updateDebt(string id, string debt)
        {
            string query = "update KhachHang set TienNo = TienNo " + debt + " where MaKH = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool updateDebt2(string id, string debt)
        {
            string query = "update KhachHang set TienNo = " + debt + " where MaKH = '" + id + "';";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public int debtById(string id)
        {
            string query = "select TienNo from KhachHang where MaKH = '" + id + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            int result = int.Parse(dt.Rows[0][0].ToString());
            return result;
        }
    }
}
