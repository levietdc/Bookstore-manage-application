using System;
using System.Data;

namespace BookstoreManagement.DTO
{
    public class Regulations
    {
        private int soLuongNhapToiThieu;
        private int luongTonToiDa;
        private int soTienNoToiDa;
        private int luongTonToiThieu;
        private int tienThuTienNo;

        public int SoLuongNhapToiThieu { get => soLuongNhapToiThieu; set => soLuongNhapToiThieu = value; }
        public int LuongTonToiDa { get => luongTonToiDa; set => luongTonToiDa = value; }
        public int SoTienNoToiDa { get => soTienNoToiDa; set => soTienNoToiDa = value; }
        public int LuongTonToiThieu { get => luongTonToiThieu; set => luongTonToiThieu = value; }
        public int TienThuTienNo { get => tienThuTienNo; set => tienThuTienNo = value; }

        public Regulations() { }

        public Regulations(int SLNhapToiThieu, int LuongTonTD, int TienNoToiDa, int LuongTonTT, int ChenhLech)
        {
            this.SoLuongNhapToiThieu = SLNhapToiThieu;
            this.LuongTonToiDa = LuongTonTD;
            this.SoTienNoToiDa = TienNoToiDa;
            this.LuongTonToiThieu = LuongTonTT;
            this.TienThuTienNo = ChenhLech;
        }

        public Regulations(DataRow data)
        {
            this.SoLuongNhapToiThieu = Convert.ToInt32(data["SLNhapToiThieu"].ToString());
            this.LuongTonToiDa = Convert.ToInt32(data["SLTonToiDa"].ToString());
            this.SoTienNoToiDa = Convert.ToInt32(data["TienNoToiDa"].ToString());
            this.LuongTonToiThieu = Convert.ToInt32(data["LuongTonToiThieuSauKhiBan"].ToString());
            this.TienThuTienNo = Convert.ToInt32(data["TienThuKhongVuotQuaTienNo"].ToString());
        }
    }
}
