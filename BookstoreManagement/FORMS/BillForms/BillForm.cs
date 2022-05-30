using System;
using System.Data;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            DataTable data = BillsDAO.Instance.DisplayData();
            DisplayData(data);
        }

        public void DisplayData(DataTable data)
        {
            dtgvBillList.Rows.Clear();

            int i = 0;

            foreach (DataRow item in data.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvBillList);

                row.Cells[0].Value = ++i;
                row.Cells[1].Value = item["MaHD"].ToString();
                row.Cells[2].Value = item["TenKH"].ToString();
                row.Cells[3].Value = item["NgayLap"].ToString();

                dtgvBillList.Rows.Add(row);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewBillForm addNewBill = new AddNewBillForm();
            addNewBill.ShowDialog();

            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txbFind.Text == "")
            {
                LoadData();
                return;
            }

            if (cbxSearch.Text == "Tên KH")
            {
                DataTable data = BillsDAO.Instance.searchName(txbFind.Text);
                DisplayData(data);
            }
            else
            {
                DataTable data = BillsDAO.Instance.searchDate(txbFind.Text);
                DisplayData(data);
            }

            txbFind.Text = "";
        }

        private void dtgvBillList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string billCode = dtgvBillList.CurrentRow.Cells[1].Value.ToString();
            BillDetailsForm detail = new BillDetailsForm(billCode);
            detail.ShowDialog();

            LoadData();
        }
    }
}
