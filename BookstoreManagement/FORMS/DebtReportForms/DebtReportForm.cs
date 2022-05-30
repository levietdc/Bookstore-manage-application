using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class DebtReportForm : Form
    {
        public DebtReportForm()
        {
            InitializeComponent();
            comboboxMonth.SelectedIndex = 0;
            comboboxYear.SelectedIndex = 0;
            List<string> Items = DebtReportDAO.Instance.getYearItem();
            foreach (string item in Items)
            {
                comboboxYear.Items.Add(item);
            }
            DiplayData();
        }

        public void DiplayData()
        {
            DataTable dt = DebtReportDAO.Instance.Displaydata();
            dtgvDebt.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DebtReportPreAddForm form1 = new DebtReportPreAddForm();
            form1.Show();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //string month = comboboxMonth.SelectedItem.ToString();
            //string year = comboboxYear.SelectedItem.ToString();

            string month = comboboxMonth.Text;
            string year = comboboxYear.Text;

            if (month != "*")
            {
                if (year == "*")
                {
                    DataTable dt = DebtReportDAO.Instance.SearchMonth(month);
                    dtgvDebt.DataSource = dt;
                }
                else
                {
                    DataTable dt = DebtReportDAO.Instance.SearchMonthAndYear(month, year);
                    dtgvDebt.DataSource = dt;
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
                    DataTable dt = DebtReportDAO.Instance.SearchYear(year);
                    dtgvDebt.DataSource = dt;
                }
            }
        }

        private void dtgvDebt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string month = dtgvDebt.CurrentRow.Cells[0].Value.ToString();
            string year = dtgvDebt.CurrentRow.Cells[1].Value.ToString();
            string debt = dtgvDebt.CurrentRow.Cells[2].Value.ToString();
            DebtReportDetail form1 = new DebtReportDetail();
            form1.ShowData(month, year, debt);
            form1.ShowDialog();

            DiplayData();
        }
    }
}
