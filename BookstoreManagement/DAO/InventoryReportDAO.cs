using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BookstoreManagement.DAO
{
    class InventoryReportDAO
    {
        private static InventoryReportDAO _instance;

        public static InventoryReportDAO Instance
        {
            get { if (_instance == null) _instance = new InventoryReportDAO(); return InventoryReportDAO._instance; }
            private set { InventoryReportDAO._instance = value; }
        }
        public List<string> getYearItem()
        {
            List<string> year = new List<string>();
            string query = "select distinct Nam from BaoCaoTonKho";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                year.Add(row[0].ToString());
            }
            return year;
        }
        public DataTable Displaydata()
        {
            string query = "select Thang , Nam , sum(TonDau+PhatSinh) as TonCuoi from BaoCaoTonKho group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable SearchMonthAndYear(string month, string year)
        {
            string query = "select Thang , Nam , sum(TonDau+PhatSinh) as TonCuoi from BaoCaoTonKho where Thang = " + month + " and Nam = " + year + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchMonth(string month)
        {
            string query = "select Thang , Nam , sum(TonDau+PhatSinh) as TonCuoi from BaoCaoTonKho where Thang = " + month + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchYear(string year)
        {
            string query = "select Thang , Nam , sum(TonDau+PhatSinh) as TonCuoi from BaoCaoTonKho where Nam = " + year + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public int delete(string month, string year)
        {
            string query = "delete from BaoCaoTonKho where Thang = " + month + " and Nam = " + year + " ;";
            int n = DataProvider.Instance.ExecuteNonQuery(query);
            return n;
        }

        public DataTable DetailReport(string month, string year)
        {
            string query = "select s.TenSach, bc.TonDau, bc.PhatSinh, bc.TonDau + bc.PhatSinh as TonCuoi from BaoCaoTonKho bc, Sach as s where bc.MaSach = s.MaSach and Thang = " + month + " and Nam = " + year + " ;";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public bool checkExist(string month, string year)
        {
            string query = "select Thang , Nam   from BaoCaoTonKho where Thang = " + month + " and Nam = " + year + " ; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0) return true;
            else return false;
        }

        public bool InsertReport(string query)
        {
            int n = DataProvider.Instance.ExecuteNonQuery(query);
            return n > 0;
        }
    }
}
