using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class BookForm : Form
    {
        private BindingSource Bookslist = new BindingSource();

        public BookForm()
        {
            InitializeComponent();
            DisplayData();
        }
        
        public void DisplayData()
        {
            LoadData();
            dtgvBookList.DataSource = Bookslist;
            BindingBooks();
        }

        public void LoadData()
        {
            Bookslist.DataSource = BooksDAO.Instance.LoadData();
        }

        public void BindingBooks()
        {
            try
            {
                txbName.DataBindings.Add(new Binding("Text", dtgvBookList.DataSource, "Name", true, DataSourceUpdateMode.Never));
                txbType.DataBindings.Add(new Binding("Text", dtgvBookList.DataSource, "Type", true, DataSourceUpdateMode.Never));
                txbActor.DataBindings.Add(new Binding("Text", dtgvBookList.DataSource, "Actor", true, DataSourceUpdateMode.Never));
                txbPrice.DataBindings.Add(new Binding("Text", dtgvBookList.DataSource, "Price", true, DataSourceUpdateMode.Never));
                txbNumber.DataBindings.Add(new Binding("Text", dtgvBookList.DataSource, "Number", true, DataSourceUpdateMode.Never));
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dtgvBookList.CurrentRow.Cells[0].Value.ToString();

            if (BooksDAO.Instance.isExistedName(txbName.Text, id))
            {
                MessageBox.Show("Tên sách đã tồn tại");
            }
            else
            {
                double price = Convert.ToDouble(txbPrice.Text);
                int number = Convert.ToInt32(txbNumber.Text);

                if (BooksDAO.Instance.Update(id, txbName.Text, txbType.Text, txbActor.Text, price, number))
                {
                    MessageBox.Show("Cập nhật thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
        }

        private void dtgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sách này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (BooksDAO.Instance.Delete(dtgvBookList.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }

                DisplayData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbSearch.Text == "")
            {
                LoadData();
                return;
            }

            if (cbxSearch.Text == "Tên")
            {
                Bookslist.DataSource = BooksDAO.Instance.SearchName(txbSearch.Text);
            }
            else if (cbxSearch.Text == "Thể loại")
            {
                Bookslist.DataSource = BooksDAO.Instance.SearchType(txbSearch.Text);
            }
            else if (cbxSearch.Text == "Tác giả")
            {
                Bookslist.DataSource = BooksDAO.Instance.SearchActor(txbSearch.Text);
            }
            else
            {
                Bookslist.DataSource = BooksDAO.Instance.SearchID(txbSearch.Text);
            }

            txbSearch.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BooksDAO.Instance.isExistedName(txbName.Text, ""))
            {
                MessageBox.Show("Tên sách đã tồn tại");
            }
            else
            {
                BooksDAO.Instance.addID();
                string id = BooksDAO.Instance.getID();

                if (BooksDAO.Instance.add(id, txbName.Text, txbType.Text, txbActor.Text, txbPrice.Text, "0"))
                {
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }
    }
}
