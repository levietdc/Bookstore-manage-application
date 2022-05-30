using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class RegulationsDAO
    {
        private static RegulationsDAO _instance;

        public static RegulationsDAO Instance
        {
            get { if (_instance == null) _instance = new RegulationsDAO(); return RegulationsDAO._instance; }
            private set { RegulationsDAO._instance = value; }
        }

        private RegulationsDAO() { }

        public DataTable loadData()
        {
            string query = "select * from QuyDinh";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public void update(int SLNhapToiThieu, int SLTonToiDa, int TienNoToiDa, int LuongTonToiThieuSauKhiBan, int TienThuKhongVuotQuaTienNo)
        {
            string query = "update QuyDinh set SLNhapToiThieu=" + SLNhapToiThieu + ", SLTonToiDa=" + SLTonToiDa + ", TienNoToiDa=" + TienNoToiDa + ", LuongTonToiThieuSauKhiBan=" + LuongTonToiThieuSauKhiBan + ", TienThuKhongVuotQuaTienNo=" + TienThuKhongVuotQuaTienNo + " where keyword=1";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void update(Regulations a)
        {
            string query = "update QuyDinh set SLNhapToiThieu='" + a.SoLuongNhapToiThieu + "', SLTonToiDa='" + a.LuongTonToiDa + "', TienNoToiDa='" + a.SoTienNoToiDa + "', LuongTonToiThieuSauKhiBan='" + a.LuongTonToiThieu + "', TienThuKhongVuotQuaTienNo='" + a.TienThuTienNo + "' where keyword='1'" ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public bool checkRule11(int value)
        {
            Regulations rule = new Regulations(loadData().Rows[0]);
            if (value >= rule.SoLuongNhapToiThieu) return true;
            return false;
        }

        public bool checkRule12(int value)
        {
            Regulations rule = new Regulations(loadData().Rows[0]);
            if (value < rule.LuongTonToiDa) return true;
            return false;
        }

        public bool checkRule21(int value)
        {
            Regulations rule = new Regulations(loadData().Rows[0]);
            if (value <= rule.SoTienNoToiDa) return true;
            return false;
        }

        public bool checkRule22(int value)
        {
            Regulations rule = new Regulations(loadData().Rows[0]);
            if (value >= rule.LuongTonToiThieu) return true;
            return false;
        }

        public bool checkRule4(int tienThu, int tienNo)
        {
            Regulations rule = new Regulations(loadData().Rows[0]);
            if (rule.TienThuTienNo == 1) return true;
            else
            {
                if (tienThu > tienNo) return false;
                return true;
            }
        }
    }
}

