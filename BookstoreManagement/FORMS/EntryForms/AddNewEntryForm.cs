using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class AddNewEntryForm : Form
    {
        private List<Book> list = new List<Book>();

        public AddNewEntryForm()
        {
            InitializeComponent();
            dtpkBill.CustomFormat = "yyyy/MM/dd";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewBookForm addNewBook = new AddNewBookForm(true);
            addNewBook.ShowDialog();

            if (addNewBook.Cancel == false)
            {
                list = BooksDAO.Instance.AddListEntry(list, addNewBook.NameBook, addNewBook.NumberBook);
                DisplayData();
            }
        }

        public void DisplayData()
        {
            dtgvEntry.Rows.Clear();

            int length = list.Count();

            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvEntry);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].Name;
                row.Cells[2].Value = list[i].Type;
                row.Cells[3].Value = list[i].Actor;
                row.Cells[4].Value = list[i].Number;

                dtgvEntry.Rows.Add(row);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EntryBookDAO.Instance.addID();
            string id = EntryBookDAO.Instance.getID();
            EntryBookDAO.Instance.RegisterEntry(id, dtpkBill.Text);
            EntryBookDAO.Instance.RegisterEntryDetails(id, list);

            foreach (Book b in list)
            {
                BooksDAO.Instance.updateNumber(b.BookID, "+" + b.Number);
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvEntry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sách này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int i = int.Parse(dtgvEntry.CurrentRow.Cells[0].Value.ToString()) - 1;
                list.RemoveAt(i);

                DisplayData();
            }
        }
    }
}
