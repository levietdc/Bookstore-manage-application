using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class EmployeeForm : Form
    {
        private BindingSource Employeelist = new BindingSource();

        public EmployeeForm()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            dtgvEmployee.DataSource = Employeelist;
            LoadData();
            BindingEmployees();
        }

        public void LoadData()
        {
            Employeelist.DataSource = EmployeeDAO.Instance.DisplayData();
        }
        
        public void BindingEmployees()
        {
            try
            {
                txbName.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "Name", true, DataSourceUpdateMode.Never));
                txbPhone.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "Phonenumber", true, DataSourceUpdateMode.Never));
                txbAddress.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "Address", true, DataSourceUpdateMode.Never));
                txbEmail.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "Email", true, DataSourceUpdateMode.Never));
                txbRole.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "IsAdmin", true, DataSourceUpdateMode.Never));
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dtgvEmployee.CurrentRow.Cells[0].Value.ToString();

            if (EmployeeDAO.Instance.isExistedEmail(txbEmail.Text, id))
            {
                MessageBox.Show("Email đã tồn tại");
            }
            else
            {
                if (EmployeeDAO.Instance.Update(id, txbName.Text, txbPhone.Text, txbAddress.Text, txbEmail.Text, txbRole.Text))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbSearch.Text == "")
            {
                LoadData();
                return;
            }

            if (cbxSearch.Text == "Tên")
            {
                Employeelist.DataSource = EmployeeDAO.Instance.SearchName(txbSearch.Text);
            }
            else
            {
                Employeelist.DataSource = EmployeeDAO.Instance.SearchID(txbSearch.Text);
            }

            txbSearch.Text = "";
        }

        private void dtgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (EmployeeDAO.Instance.Delete(dtgvEmployee.CurrentRow.Cells[0].Value.ToString()))
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
