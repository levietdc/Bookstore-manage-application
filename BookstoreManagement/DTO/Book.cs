using System;
using System.Data;

namespace BookstoreManagement.DTO
{
    public class Book
    {
        private string _bookID;
        private string _name;
        private string _type;
        private string _actor;
        private double _price;
        private int _number;

        public Book() { }

        public Book(string bookID, string name, string type, string actor, double price, int number)
        {
            this._bookID = bookID;
            this._name = name;
            this._type = type;
            this._actor = actor;
            this._price = price;
            this._number = number;
        }

        public Book(DataRow row)
        {
            this._bookID = row["MaSach"].ToString();
            this._name = row["TenSach"].ToString();
            this._type = row["LoaiSach"].ToString();
            this._actor = row["TacGia"].ToString();
            this._price = Convert.ToDouble(row["Gia"].ToString());
            this._number = Convert.ToInt32(row["SoLuong"].ToString());
        }

        public Book(DataRow row, int number)
        {
            _bookID = row["MaSach"].ToString();
            _name = row["TenSach"].ToString();
            _type = row["LoaiSach"].ToString();
            _number = number;
            _price = Convert.ToDouble(row["Gia"].ToString());
        }

        public Book(DataRow row, int number, bool sender)
        {
            _bookID = row["MaSach"].ToString();
            _name = row["TenSach"].ToString();
            _type = row["LoaiSach"].ToString();
            _number = number;
            _actor = row["TacGia"].ToString();
        }

        public string BookID
        {
            get{ return _bookID; }
            set { _bookID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Actor
        {
            get { return _actor; }
            set { _actor = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }
}
