using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DTO;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class EntryEditForm : Form
    {
        private List<Book> _oldList = new List<Book>();
        private List<Book> _list = new List<Book>();
        private string _id = "";

        public EntryEditForm(string id)
        {
            InitializeComponent();
            _id = id;
            loadData(id);
            dtpkEntry.CustomFormat = "yyyy/MM/dd";
        }

        public void DisplayData()
        {
            dtgvEntry.Rows.Clear();

            int length = _list.Count();

            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvEntry);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = _list[i].Name;
                row.Cells[2].Value = _list[i].Type;
                row.Cells[3].Value = _list[i].Actor;
                row.Cells[4].Value = _list[i].Number;

                dtgvEntry.Rows.Add(row);
            }
        }

        void loadData(string id)
        {
            List<EntryBook> list = EntryBookDAO.Instance.DisplayEntryDetails(id);

            dtpkEntry.Value = DateTime.Parse(list[0].Date);

            int length = list.Count();
            for (int i = 0; i < length; i++)
            {
                _list = BooksDAO.Instance.AddListEntry(_list, list[i].BookName, int.Parse(list[i].Count));
                _oldList = BooksDAO.Instance.AddListEntry(_oldList, list[i].BookName, int.Parse(list[i].Count));

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvEntry);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].BookName;
                row.Cells[2].Value = list[i].BookType;
                row.Cells[3].Value = list[i].Author;
                row.Cells[4].Value = list[i].Count;

                dtgvEntry.Rows.Add(row);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewBookForm addNewBook = new AddNewBookForm(true);
            addNewBook.ShowDialog();

            if (addNewBook.Cancel == false)
            {
                _list = BooksDAO.Instance.AddListEntry(_list, addNewBook.NameBook, addNewBook.NumberBook);
                DisplayData();
            }
        }

        private void dtgvEntry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sách này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int i = int.Parse(dtgvEntry.CurrentRow.Cells[0].Value.ToString()) - 1;
                _list.RemoveAt(i);

                DisplayData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EntryBookDAO.Instance.RegisterEntry(_id, dtpkEntry.Text);

            EntryBookDAO.Instance.DeletePhieuNhapSach_Sach(_id);
            EntryBookDAO.Instance.RegisterEntryDetails(_id, _list);

            // xóa đi lượng sách cũ
            foreach (Book b in _oldList)
            {
                BooksDAO.Instance.updateNumber(b.BookID, "-" + b.Number);
            }
            // cộng lượng sách vừa nhập
            foreach (Book b in _list)
            {
                BooksDAO.Instance.updateNumber(b.BookID, "+" + b.Number);
            }

            this.Close();
        }
    }
}
