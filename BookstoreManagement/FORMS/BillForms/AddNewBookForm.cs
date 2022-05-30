using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class AddNewBookForm : Form
    {
        private bool _sender; // sender là phiếu nhập sách thì true, sender là hóa đơn thì false
        private string _nameBook;
        private int _numberBook;
        private bool _cancel = false;

        public AddNewBookForm(bool sender)
        {
            InitializeComponent();
            loadBook();
            _sender = sender;
        }

        private void loadBook()
        {
            List<Book> listBook = BooksDAO.Instance.LoadData();
            cbxName.DataSource = listBook;
            cbxName.DisplayMember = "Name";
        }

        public string NameBook { get => _nameBook; set => _nameBook = value; }

        public int NumberBook { get => _numberBook; set => _numberBook = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string name = cbxName.Text;
            int number = Convert.ToInt32(txbNumber.Text);

            if (_sender == false) // bill
            {
                int ton = BooksDAO.Instance.count(name) - number;

                if (RegulationsDAO.Instance.checkRule22(ton))
                {
                    _nameBook = name;
                    _numberBook = number;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thỏa quy định 2.2: Lượng tồn sau khi bán ít hơn quy định.");
                }
            }
            else // entry
            {
                if (RegulationsDAO.Instance.checkRule11(number))
                {
                    int count = BooksDAO.Instance.count(name);

                    if (RegulationsDAO.Instance.checkRule12(count))
                    {
                        _nameBook = name;
                        _numberBook = number;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thỏa quy định 1.2: Sách bạn vừa nhập có lượng tồn nhiều hơn quy định.");
                    }
                }
                else
                {
                    MessageBox.Show("Không thỏa quy định 1.1: Số lượng bạn vừa nhập ít hơn số lượng nhập tối thiểu.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
            this.Close();
        }
    }
}
