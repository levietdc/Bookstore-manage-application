using System.Collections.Generic;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class EntryBookDAO
    {
        private static EntryBookDAO _instance;

        public static EntryBookDAO Instance
        {
            get { if (_instance == null) _instance = new EntryBookDAO(); return EntryBookDAO._instance; }
            private set { EntryBookDAO._instance = value; }
        }

        private EntryBookDAO() { }

        public DataTable DisplayData()
        {
            string query = "select MaPNS, date_format(NgayLap, '%Y/%m/%d') as NgayLap from PhieuNhapSach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public bool addID()
        {
            string query = "call sp_addIdEntry('PN')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string query = "select * from PhieuNhapSach where NgayLap is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            string ID = dt.Rows[0][0].ToString();
            return ID;
        }

        public bool RegisterEntry(string id, string date)
        {
            string query = "update PhieuNhapSach set NgayLap = '" + date + "' where MaPNS = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool RegisterEntryDetails(string id, List<Book> list)
        {
            string query;
            int success;

            for (int i = 0; i < list.Count; i++)
            {
                query = "insert into PhieuNhapSach_Sach values ('" + id + "', '" + list[i].BookID + "', " + list[i].Number + ")";
                success = DataProvider.Instance.ExecuteNonQuery(query);

                if (success <= 0) return false;
            }

            return true;
        }

        public int DeletePhieuNhapSach(string id)
        {
            string query = "delete from PhieuNhapSach where MaPNS = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success;
        }

        public int DeletePhieuNhapSach_Sach(string id)
        {
            string query = "delete from PhieuNhapSach_Sach where MaPNS = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success;
        }

        public List<EntryBook> DisplayEntryDetails(string id)
        {
            List<EntryBook> listEntryDetails = new List<EntryBook>();

            string query = "select P.MaPNS, date_format(NgayLap, '%Y/%m/%d') as NgayLap, S.TenSach, S.LoaiSach, S.TacGia, PS.SoLuong from PhieuNhapSach P, PhieuNhapSach_Sach PS, Sach S where P.MaPNS = PS.MaPNS and PS.MaSach = S.MaSach and P.MaPNS = '" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                EntryBook entry = new EntryBook(item);
                listEntryDetails.Add(entry);
            }

            return listEntryDetails;
        }

        public DataTable searchDate(string date)
        {
            string query = string.Format("select MaPNS, date_format(NgayLap, '%Y/%m/%d') as NgayLap from PhieuNhapSach where date_format(NgayLap, '%Y/%m/%d') like '%{0}%'", date);
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}