using System.Collections.Generic;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class BillsDAO
    {
        private static BillsDAO _instance;

        public static BillsDAO Instance
        {
            get { if (_instance == null) _instance = new BillsDAO(); return BillsDAO._instance; }
            private set { BillsDAO._instance = value; }
        }

        private BillsDAO() { }

        public DataTable DisplayData()
        {
            string query = "select MaHD, TenKH, date_format(NgayLap,'%Y/%m/%d') as NgayLap from HoaDon H join KhachHang K on H.MaKH = K.MaKH";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public bool addID()
        {
            string query = "call sp_addIdBill('HD')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string query = "select * from HoaDon where TongTien is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            string ID = dt.Rows[0][0].ToString();
            return ID;
        }

        public bool RegisterBill(string billId, string date, string customerId, string total, string paid, string dept)
        {
            string query = "update HoaDon set NgayLap = '" + date + "', MaKH = '" + customerId + "', TongTien = " + total + ", ThanhToan = " + paid + ", TienNo = " + dept + " where MaHD = '" + billId + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool RegisterBillDetails(string billId, List<Book> list)
        {
            string query;
            int success;

            for (int i = 0; i < list.Count; i++)
            {
                query = "insert into HoaDon_Sach values ('" + billId + "', '" + list[i].BookID + "', " + list[i].Number + ")";
                success = DataProvider.Instance.ExecuteNonQuery(query);

                if (success <= 0) return false;
            }

            return true;
        }

        public int DeleteHoaDon(string id)
        {
            string query = "delete from HoaDon where MaHD = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success;
        }

        public int DeleteHoaDon_Sach(string id)
        {
            string query = "delete from HoaDon_Sach where MaHD = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success;
        }

        public List<Bill> DisplayBillDetails(string billCode)
        {
            List<Bill> listBillDetails = new List<Bill>();

            string query = "select H.MaHD, date_format(NgayLap, '%Y/%m/%d') as NgayLap, K.MaKH, K.TenKH, S.TenSach, S.LoaiSach, HS.SoLuong, S.Gia, H.TongTien, H.ThanhToan, H.TienNo from HoaDon H, HoaDon_Sach HS, Sach S, KhachHang K where H.MaHD = HS.MaHD and HS.MaSach = S.MaSach and H.MaKH = K.MaKH and H.MaHD = '" + billCode + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Bill billDetails = new Bill(item);
                listBillDetails.Add(billDetails);
            }

            return listBillDetails;
        }

        public DataTable searchName(string name)
        {
            string query = string.Format("select MaHD, TenKH, date_format(NgayLap, '%Y/%m/%d') as NgayLap from HoaDon H join KhachHang K on H.MaKH = K.MaKH where TenKH like N'%{0}%'", name);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable searchDate(string date)
        {
            string query = string.Format("select MaHD, TenKH, date_format(NgayLap, '%Y/%m/%d') as NgayLap from HoaDon H join KhachHang K on H.MaKH = K.MaKH where date_format(NgayLap, '%Y/%m/%d') like '%{0}%'", date);
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
