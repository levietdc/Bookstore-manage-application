using System.Collections.Generic;
using System.Data;

namespace BookstoreManagement.DAO
{
    class DebtReportDAO
    {
        private static DebtReportDAO _instance;

        public static DebtReportDAO Instance
        {
            get { if (_instance == null) _instance = new DebtReportDAO(); return DebtReportDAO._instance; }
            private set { DebtReportDAO._instance = value; }
        }

        public List<string> getMonthItem()
        {
            return null;
        }

        public List<string> getYearItem()
        {
            List<string> year = new List<string>();
            string query = "select distinct Nam from BaoCaoCongNo";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                year.Add(row[0].ToString());
            }
            return year;
        }

        public DataTable Displaydata()
        {
            string query = "select Thang , Nam , sum(NoDau+PhatSinh) as NoCuoi from BaoCaoCongNo group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchMonthAndYear(string month, string year)
        {
            string query = "select Thang , Nam , sum(NoDau+PhatSinh) as NoCuoi from BaoCaoCongNo where Thang = " + month + " and Nam = " + year + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable DetailReport(string month, string year)
        {
            string query = "select kh.TenKH, bc.NoDau, bc.PhatSinh, bc.NoDau + bc.PhatSinh as NoCuoi from BaoCaoCongNo bc, KhachHang kh where bc.MaKH = kh.MaKH and Thang = " + month + " and Nam = " + year + " ;";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchMonth(string month)
        {
            string query = "select Thang , Nam , sum(NoDau+PhatSinh) as NoCuoi from BaoCaoCongNo where Thang = " + month + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchYear(string year)
        {
            string query = "select Thang , Nam , sum(NoDau+PhatSinh) as NoCuoi from BaoCaoCongNo where Nam = " + year + " group by Thang, Nam ORDER BY Nam, Thang; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable SearchID(string ID)
        {
            string query = "select * from NhanVien where MaKH='" + ID + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public bool InsertReport(string query)
        {
            int n = DataProvider.Instance.ExecuteNonQuery(query);
            return n > 0;
        }

        public bool checkExist(string month, string year)
        {
            string query = "select Thang , Nam  as NoCuoi from BaoCaoCongNo where Thang = " + month + " and Nam = " + year + " ; ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0) return true;
            else return false;
        }

        public int delete(string month, string year)
        {
            string query = "delete from BaoCaoCongNo where Thang = " + month + " and Nam = " + year + " ;";
            int n = DataProvider.Instance.ExecuteNonQuery(query);
            return n;
        }
    }

}
