using System.Data;

namespace BookstoreManagement.DTO
{
    public class EntryBook
    {
        private string _id;
        private string _date;
        private string _bookName;
        private string _bookType;
        private string _author;
        private string _count;

        public EntryBook(DataRow row)
        {
            Id = row["MaPNS"].ToString();
            Date = row["NgayLap"].ToString();
            BookName = row["TenSach"].ToString();
            BookType = row["LoaiSach"].ToString();
            Author = row["TacGia"].ToString();
            Count = row["SoLuong"].ToString();
        }

        public string Id { get => _id; set => _id = value; }
        public string Date { get => _date; set => _date = value; }
        public string BookName { get => _bookName; set => _bookName = value; }
        public string BookType { get => _bookType; set => _bookType = value; }
        public string Author { get => _author; set => _author = value; }
        public string Count { get => _count; set => _count = value; }
    }
}
