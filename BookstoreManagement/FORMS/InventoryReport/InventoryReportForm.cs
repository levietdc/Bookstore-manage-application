using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();
            comboboxMonth.SelectedIndex = 0;
            comboboxYear.SelectedIndex = 0;
            List<string> Items = InventoryReportDAO.Instance.getYearItem();
            foreach (string item in Items)
            {
                comboboxYear.Items.Add(item);
            }
            DiplayData();
        }

        public void DiplayData()
        {
            DataTable dt = InventoryReportDAO.Instance.Displaydata();
            dataGridView1.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InventoryReportPreAddForm form1 = new InventoryReportPreAddForm();
            form1.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string month = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string year = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string debt = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            InventoryReportDetailForm form1 = new InventoryReportDetailForm();
            form1.ShowData(month, year, debt);
            form1.ShowDialog();

            DiplayData();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string month = comboboxMonth.SelectedItem.ToString();
            string year = comboboxYear.SelectedItem.ToString();
            if (month != "*")
            {
                if (year == "*")
                {
                    DataTable dt = InventoryReportDAO.Instance.SearchMonth(month);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    DataTable dt = InventoryReportDAO.Instance.SearchMonthAndYear(month, year);
                    dataGridView1.DataSource = dt;
                }
            }
            else
            {
                if (year == "*")
                {
                    DiplayData();
                }
                else
                {
                    DataTable dt = InventoryReportDAO.Instance.SearchYear(year);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}
