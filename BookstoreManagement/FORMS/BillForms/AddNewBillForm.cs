using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class AddNewBillForm : Form
    {
        private List<Book> list = new List<Book>();
        private string customer;
        private double total = 0;
        private double paid = 0;
        private double debt = 0;

        public AddNewBillForm()
        {
            InitializeComponent();
            loadCustomer();
            dtpkBill.CustomFormat = "yyyy/MM/dd";
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
                list = BooksDAO.Instance.AddList(list, addNewBook.NameBook, addNewBook.NumberBook);
                DisplayData();
            }
        }

        public void DisplayData()
        {
            dtgvBookList.Rows.Clear();

            int length = list.Count();
            total = 0;

            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvBookList);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].Name;
                row.Cells[2].Value = list[i].Type;
                row.Cells[3].Value = list[i].Number;
                row.Cells[4].Value = list[i].Price;

                dtgvBookList.Rows.Add(row);

                total += list[i].Number * list[i].Price;
            }

            lbTotal.Text = total.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            customer = cbxCustomer.Text;
            int no = CustomerDAO.Instance.debtById(customer);

            if (RegulationsDAO.Instance.checkRule21(no))
            {
                paid = int.Parse(txbPaid.Text);
                debt = total - paid;

                BillsDAO.Instance.addID();
                string id = BillsDAO.Instance.getID();
                BillsDAO.Instance.RegisterBill(id, dtpkBill.Text, customer, total.ToString(), paid.ToString(), debt.ToString());
                BillsDAO.Instance.RegisterBillDetails(id, list);

                CustomerDAO.Instance.updateDebt(customer, "+" + debt);

                foreach (Book b in list)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại sách này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                int i = int.Parse(dtgvBookList.CurrentRow.Cells[0].Value.ToString()) - 1;
                list.RemoveAt(i);

                DisplayData();
            }
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string id = "";

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;

            Customer selected = cb.SelectedItem as Customer;
            //id = selected.CustomerID;

            lbCustomer.Text = selected.Name;
        }
    }
}
