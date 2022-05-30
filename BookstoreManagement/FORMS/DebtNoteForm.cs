using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class DebtNoteForm : Form
    {
        private BindingSource debtList = new BindingSource();

        public DebtNoteForm()
        {
            InitializeComponent();
            DisplayData();
            dtpkDebt.CustomFormat = "yyyy/MM/dd";
        }

        public void LoadData()
        {
            debtList.DataSource = DebtNoteDAO.Instance.LoadData();
            loadCustomer();
        }

        public void DisplayData()
        {
            LoadData();
            dtgvDebt.DataSource = debtList;
            BindingDebt();
        }

        private void loadCustomer()
        {
            List<Customer> listCustomer = CustomerDAO.Instance.DisplayData();
            cbxCustomer.DataSource = listCustomer;
            cbxCustomer.DisplayMember = "CustomerID";
        }

        public void BindingDebt()
        {
            try
            {
                cbxCustomer.DataBindings.Add(new Binding("Text", dtgvDebt.DataSource, "CustomerId", true, DataSourceUpdateMode.Never));
                dtpkDebt.DataBindings.Add(new Binding("Text", dtgvDebt.DataSource, "Date", true, DataSourceUpdateMode.Never));
                txbPaid.DataBindings.Add(new Binding("Text", dtgvDebt.DataSource, "Paid", true, DataSourceUpdateMode.Never));
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = dtgvDebt.CurrentRow.Cells[0].Value.ToString();
            string tienThuTruoc = dtgvDebt.CurrentRow.Cells[3].Value.ToString();
            int tienNoTruoc = int.Parse(lbDebt.Text);
            int tienThuSau = int.Parse(txbPaid.Text);
            int tienNo = tienNoTruoc + Convert.ToInt32(tienThuTruoc);

            if (RegulationsDAO.Instance.checkRule4(tienThuSau, tienNo))
            {
                if (DebtNoteDAO.Instance.add(id, cbxCustomer.Text, dtpkDebt.Text, txbPaid.Text))
                {
                    int debt = tienThuSau > tienNo ? 0 : tienNo - tienThuSau;
                    CustomerDAO.Instance.updateDebt2(cbxCustomer.Text, debt.ToString());
                    MessageBox.Show("Sửa thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không thỏa quy định 4: Tiền thu không được lớn hơn tiền nợ");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int tienThu = int.Parse(txbPaid.Text);
            int tienNo = int.Parse(lbDebt.Text);

            if (RegulationsDAO.Instance.checkRule4(tienThu, tienNo))
            {
                DebtNoteDAO.Instance.addID();
                string id = DebtNoteDAO.Instance.getID();

                if (DebtNoteDAO.Instance.add(id, cbxCustomer.Text, dtpkDebt.Text, txbPaid.Text))
                {
                    int debt = tienThu > tienNo ? 0 : tienNo - tienThu;
                    CustomerDAO.Instance.updateDebt2(cbxCustomer.Text, debt.ToString());
                    MessageBox.Show("Thêm thành công");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Không thỏa quy định 4: Tiền thu không được lớn hơn tiền nợ");
            }
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;

            Customer selected = cb.SelectedItem as Customer;

            lbName.Text = selected.Name;
            lbPhone.Text = selected.Phonenumber;
            lbAddress.Text = selected.Address;
            lbEmail.Text = selected.Email;
            lbDebt.Text = selected.DeptMoney.ToString();
        }

        private void dtgvDebt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dtgvDebt.CurrentRow.Cells[0].Value.ToString();
            string tienThuBiXoa = dtgvDebt.CurrentRow.Cells[3].Value.ToString();
            int tienNoTruoc = int.Parse(lbDebt.Text);
            if (MessageBox.Show("Bạn có muốn xóa phiếu thu tiền nợ này?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (DebtNoteDAO.Instance.delete(id))
                {
                    int debt = tienNoTruoc + Convert.ToInt32(tienThuBiXoa);
                    CustomerDAO.Instance.updateDebt2(cbxCustomer.Text, debt.ToString());
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

            if (cbxSearch.Text == "Tên KH")
            {
                debtList.DataSource = DebtNoteDAO.Instance.searchName(txbSearch.Text);
            }
            else
            {
                debtList.DataSource = DebtNoteDAO.Instance.searchDate(txbSearch.Text);
            }

            txbSearch.Text = "";
        }
    }
}
