using System.Collections.Generic;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class DebtNoteDAO
    {
        private static DebtNoteDAO _instance;

        public static DebtNoteDAO Instance
        {
            get { if (_instance == null) _instance = new DebtNoteDAO(); return DebtNoteDAO._instance; }
            private set { DebtNoteDAO._instance = value; }
        }

        public List<DebtNote> LoadData()
        {
            List<DebtNote> list = new List<DebtNote>();
            string query = "select MaPTTN, MaKH, date_format(NgayLap,'%Y/%m/%d') as NgayLap, TienThu from PhieuThuTienNo";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DebtNote(row));
            }

            return list;
        }

        public bool addID()
        {
            string query = "call sp_addIdDebtNote('" + "PT" + "')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string ID = "";
            string query = "select MaPTTN, MaKH, date_format(NgayLap,'%Y/%m/%d') as NgayLap, TienThu from PhieuThuTienNo where NgayLap is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            ID = dt.Rows[0][0].ToString();
            return ID;
        }

        public bool add(string id, string customer, string date, string paid)
        {
            string query = "update PhieuThuTienNo set MaKH=N'" + customer + "', NgayLap='" + date + "', TienThu=" + paid + " where MaPTTN='" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool delete(string ID)
        {
            string query = "delete from PhieuThuTienNo where MaPTTN='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public List<DebtNote> searchName(string name)
        {
            List<DebtNote> list = new List<DebtNote>();
            string query = string.Format("select P.MaPTTN, P.MaKH, P.date_format(NgayLap, '%Y/%m/%d') as NgayLap, P.TienThu from PhieuThuTienNo P join KhachHang K on P.MaKH = K.MaKH where K.TenKH like N'%{0}%'", name);
            
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DebtNote(row));
            }
            return list;
        }

        public List<DebtNote> searchDate(string date)
        {

            List<DebtNote> list = new List<DebtNote>();
            string query = string.Format("select MaPTTN, MaKH, date_format(NgayLap, '%Y/%m/%d') as NgayLap, TienThu from PhieuThuTienNo where date_format(NgayLap, '%Y/%m/%d') like '%{0}%'", date);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DebtNote(row));
            }
            return list;
        }
    }
}
