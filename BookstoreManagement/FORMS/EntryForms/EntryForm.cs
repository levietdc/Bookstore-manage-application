using System;
using System.Data;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            DataTable data = EntryBookDAO.Instance.DisplayData();
            DisplayData(data);
        }

        public void DisplayData(DataTable data)
        {
            dtgvEntry.Rows.Clear();

            int i = 0;

            foreach (DataRow item in data.Rows)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvEntry);

                row.Cells[0].Value = ++i;
                row.Cells[1].Value = item["MaPNS"].ToString();
                row.Cells[2].Value = item["NgayLap"].ToString();

                dtgvEntry.Rows.Add(row);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewEntryForm addNewEntry = new AddNewEntryForm();
            addNewEntry.ShowDialog();

            LoadData();
        }

        private void dtgvEntry_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dtgvEntry.CurrentRow.Cells[1].Value.ToString();
            EntryDetailsForm detail = new EntryDetailsForm(id);
            detail.ShowDialog();

            LoadData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txbFind.Text == "")
            {
                LoadData();
                return;
            }

            if (cbxSearch.Text == "Ngày lập")
            {
                DataTable data = EntryBookDAO.Instance.searchDate(txbFind.Text);
                DisplayData(data);
            }

            txbFind.Text = "";
        }
    }
}
