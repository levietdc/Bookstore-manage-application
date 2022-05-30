using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using BookstoreManagement.DTO;

namespace BookstoreManagement.DAO
{
    public class BooksDAO
    {
        private static BooksDAO _instance;

        public static BooksDAO Instance
        {
            get { if (_instance == null) _instance = new BooksDAO(); return BooksDAO._instance; }
            private set { BooksDAO._instance = value; }
        }

        private BooksDAO() { }

        public void getTypeItem(ComboBox box)
        {
            string query = "select distinct LoaiSach from Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                box.Items.Add(row[0].ToString());
            }
        }

        public List<string> getId()
        {
            List<string> Names = new List<string>();
            string query = "select MaSach from Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                Names.Add(row[0].ToString());
            }
            return Names;
        }

        public void getActorItem(ComboBox box)
        {
            string query = "select distinct TacGia from Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                box.Items.Add(row[0].ToString());
            }
        }

        public List<Book> LoadData()
        {
            List<Book> booklist = new List<Book>();
            string query = "select * from Sach";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in data.Rows)
            {
                booklist.Add(new Book(row));
            }
            
            return booklist;
        }

        public List<Book> SearchID(string ID)
        {
            List<Book> booklist = new List<Book>();
            string query = "select * from Sach where MaSach='" + ID + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                booklist.Add(new Book(row));
            }

            return booklist;
        }

        public List<Book> SearchName(string name)
        {
            List<Book> booklist = new List<Book>();
            string query = "select * from Sach where TenSach=N'" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                booklist.Add(new Book(row));
            }

            return booklist;
        }

        public int count(string name)
        {
            string query = "select SoLuong from Sach where TenSach = N'" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return int.Parse(data.Rows[0][0].ToString());
        }

        public List<Book> SearchType(string type)
        {
            List<Book> booklist = new List<Book>();
            string query = "select * from Sach where LoaiSach=N'" + type + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                booklist.Add(new Book(row));
            }

            return booklist;
        }

        public List<Book> SearchActor(string actor)
        {
            List<Book> booklist = new List<Book>();
            string query = "select * from Sach where TacGia=N'" + actor + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                booklist.Add(new Book(row));
            }

            return booklist;
        }

        public bool Delete(string ID)
        {
            string query = "delete from Sach where MaSach='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool Update(string ID, string name, string type, string actor, double price, int number)
        {
            string query = "update Sach set TenSach = N'" + name + "', LoaiSach=N'" + type + "', TacGia=N'" + actor + "', Gia=" + price + ", SoLuong=" + number + " where MaSach='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool add(string ID, string name, string type, string author, string price, string number)
        {
            string query = "update Sach set TenSach=N'" + name + "', LoaiSach='" + type + "', TacGia=N'" + author + "', Gia=" + price + ", SoLuong=" + number + " where MaSach='" + ID + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool isExistedName(string name, string id)
        {
            string query = "select * from  Sach where TenSach=N'" +  name + "' and MaSach <> '" + id + "'";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            return dt.Rows.Count > 0;
        }

        public List<Book> AddList(List<Book> list, string name, int number)
        {
            string query = "select MaSach, TenSach, LoaiSach, Gia from Sach where TenSach = '" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book newBook = new Book(item, number);
                list.Add(newBook);
            }

            return list;
        }

        public List<Book> AddListEntry(List<Book> list, string name, int number)
        {
            string query = "select MaSach, TenSach, LoaiSach, TacGia from Sach where TenSach = '" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book newBook = new Book(item, number, true);
                list.Add(newBook);
            }

            return list;
        }

        public bool updateNumber(string id, string number)
        {
            string query = "update Sach set SoLuong = SoLuong " + number + " where MaSach = '" + id + "'";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public bool addID()
        {
            string query = "call sp_addIdBook('" + "S0" + "')";
            int success = DataProvider.Instance.ExecuteNonQuery(query);
            return success > 0;
        }

        public string getID()
        {
            string ID = "";
            string query = "select * from Sach where TenSach is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            ID = dt.Rows[0][0].ToString();
            return ID;
        }
    }
}
