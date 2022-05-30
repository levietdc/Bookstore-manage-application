using System.Data;

namespace BookstoreManagement.DTO
{
    public class Bill
    {
        private string _id;
        private string _date;
        private string _customerId;
        private string _customerName;
        private string _bookName;
        private string _bookType;
        private string _count;
        private string _price;
        private string _total;
        private string _paid;
        private string _dept;

        public Bill(DataRow row)
        {
            _id = row["MaHD"].ToString();
            _date = row["NgayLap"].ToString();
            _customerId = row["MaKH"].ToString();
            _customerName = row["TenKH"].ToString();
            _bookName = row["TenSach"].ToString();
            _bookType = row["LoaiSach"].ToString();
            _count = row["SoLuong"].ToString();
            _price = row["Gia"].ToString();
            _total = row["TongTien"].ToString();
            _paid = row["ThanhToan"].ToString();
            _dept = row["TienNo"].ToString();
        }

        public string Id { get => _id; set => _id = value; }
        public string Date { get => _date; set => _date = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string BookName { get => _bookName; set => _bookName = value; }
        public string BookType { get => _bookType; set => _bookType = value; }
        public string Count { get => _count; set => _count = value; }
        public string Price { get => _price; set => _price = value; }
        public string Total { get => _total; set => _total = value; }
        public string Paid { get => _paid; set => _paid = value; }
        public string Dept { get => _dept; set => _dept = value; }
        public string CustomerId { get => _customerId; set => _customerId = value; }
    }
}
