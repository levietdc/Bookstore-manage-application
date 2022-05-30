using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DTO;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class BillEditForm : Form
    {
        private List<Book> _oldList = new List<Book>();
        private List<Book> _list = new List<Book>();
        string _id = "";
        string _oldDebt = "";
        string _oldCustomer = "";

        public BillEditForm(string id)
        {
            InitializeComponent();
            _id = id;
            loadData(id);
            dtpkBill.CustomFormat = "yyyy/MM/dd";
        }

        public void DisplayData()
        {
            dtgvBookList.Rows.Clear();

            int length = _list.Count();
            double total = 0;

            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvBookList);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = _list[i].Name;
                row.Cells[2].Value = _list[i].Type;
                row.Cells[3].Value = _list[i].Number;
                row.Cells[4].Value = _list[i].Price;

                dtgvBookList.Rows.Add(row);

                total += _list[i].Number * _list[i].Price;
            }

            lbTotal.Text = total.ToString();
        }

        void loadData(string id)
        {
            List<Bill> list = BillsDAO.Instance.DisplayBillDetails(id);

            dtpkBill.Value = DateTime.Parse(list[0].Date);

            loadCustomer();
            cbxCustomer.SelectedIndex = cbxCustomer.FindStringExact(list[0].CustomerId);
            lbCustomer.Text = loadCustomerNameById(list[0].CustomerId);
            _oldCustomer = list[0].CustomerId;

            lbTotal.Text = list[0].Total;
            txbPaid.Text = list[0].Paid;
            _oldDebt = (int.Parse(lbTotal.Text) - int.Parse(txbPaid.Text)).ToString();

            int length = list.Count();
            for (int i = 0; i < length; i++)
            {
                _list = BooksDAO.Instance.AddList(_list, list[i].BookName, int.Parse(list[i].Count));
                _oldList = BooksDAO.Instance.AddList(_oldList, list[i].BookName, int.Parse(list[i].Count));

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvBookList);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].BookName;
                row.Cells[2].Value = list[i].BookType;
                row.Cells[3].Value = list[i].Count;
                row.Cells[4].Value = list[i].Price;

                dtgvBookList.Rows.Add(row);
            }
        }

        private void loadCustomer()
        {
            List<Customer> listCustomer = CustomerDAO.Instance.DisplayData();
            cbxCustomer.DataSource = listCustomer;
            cbxCustomer.DisplayMember = "CustomerID";
        }

        private string loadCustomerNameById(string id)
        {
            List<Customer> listCustomer = CustomerDAO.Instance.SearchID(id);

            return listCustomer[0].Name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewBookForm addNewBook = new AddNewBookForm(false);
            addNewBook.ShowDialog();

            if (addNewBook.Cancel == false)
            {
                _list = BooksDAO.Instance.AddList(_list, addNewBook.NameBook, addNewBook.NumberBook);
                DisplayData();
            }
        }

        private void dtgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sách này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int i = int.Parse(dtgvBookList.CurrentRow.Cells[0].Value.ToString()) - 1;
                _list.RemoveAt(i);

                DisplayData();
            }
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = "";

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;

            Customer selected = cb.SelectedItem as Customer;
            id = selected.CustomerID;

            lbCustomer.Text = loadCustomerNameById(id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string customer = cbxCustomer.Text;
            int no = CustomerDAO.Instance.debtById(customer);

            if (RegulationsDAO.Instance.checkRule21(no))
            {
                int total = int.Parse(lbTotal.Text);
                int paid = int.Parse(txbPaid.Text);
                int debt = total - paid;

                BillsDAO.Instance.RegisterBill(_id, dtpkBill.Text, customer, total.ToString(), paid.ToString(), debt.ToString());

                BillsDAO.Instance.DeleteHoaDon_Sach(_id);
                BillsDAO.Instance.RegisterBillDetails(_id, _list);

                // xóa nợ cũ cho khách cũ
                CustomerDAO.Instance.updateDebt(_oldCustomer, "-" + _oldDebt);
                // cộng nợ mới cho khách mới
                CustomerDAO.Instance.updateDebt(customer, "+" + debt);

                // cộng lại số lượng sách bị xóa
                foreach (Book b in _oldList)
                {
                    BooksDAO.Instance.updateNumber(b.BookID, "+" + b.Number);
                }
                // trừ đi số lượng sách được mua
                foreach (Book b in _list)
                {
                    BooksDAO.Instance.updateNumber(b.BookID, "-" + b.Number);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Không thỏa quy định 2.1: Khách hàng đang nợ quá số tiền quy định.");
            }
        }
    }
}
