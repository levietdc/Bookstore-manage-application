using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class CustomerForm : Form
    {
        private BindingSource Customelist = new BindingSource();

        public CustomerForm()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            dtgvCustomer.DataSource = Customelist;
            LoadData();
            BindingCustomers();
        }

        public void LoadData()
        {
            Customelist.DataSource = CustomerDAO.Instance.DisplayData();
        }

        public void BindingCustomers()
        {
            try
            {
                txbName.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Name", true, DataSourceUpdateMode.Never));
                txbPhone.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Phonenumber", true, DataSourceUpdateMode.Never));
                txbAddress.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Address", true, DataSourceUpdateMode.Never));
                txbEmail.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "Email", true, DataSourceUpdateMode.Never));
                txbDebt.DataBindings.Add(new Binding("Text", dtgvCustomer.DataSource, "DeptMoney", true, DataSourceUpdateMode.Never));
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double deptmoney = Convert.ToDouble(txbDebt.Text);
            if (CustomerDAO.Instance.Update(dtgvCustomer.CurrentRow.Cells[0].Value.ToString(), txbName.Text, txbPhone.Text, txbAddress.Text, txbEmail.Text, deptmoney))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
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
                Customelist.DataSource = CustomerDAO.Instance.SearchName(txbSearch.Text);
            }
            else
            {
                Customelist.DataSource = CustomerDAO.Instance.SearchID(txbSearch.Text);
            }

            txbSearch.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double deptmoney = Convert.ToDouble(txbDebt.Text);
            CustomerDAO.Instance.addID();
            string ID = CustomerDAO.Instance.getID();
            if (CustomerDAO.Instance.Add(ID, txbName.Text, txbPhone.Text, txbAddress.Text, txbEmail.Text, deptmoney))
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void dtgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (CustomerDAO.Instance.Delete(dtgvCustomer.CurrentRow.Cells[0].Value.ToString()))
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
    }
}
