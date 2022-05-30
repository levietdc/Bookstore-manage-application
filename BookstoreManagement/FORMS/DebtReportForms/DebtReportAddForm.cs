using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class DebtReportAddForm : Form
    {
        public DebtReportAddForm()
        {
            InitializeComponent();
            List<string> Names = CustomerDAO.Instance.getId();
            foreach (string item in Names)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.Text = "";
        }

        public void MonthAndYear(string month, string year)
        {
            lb1.Text = month;
            lb2.Text = year;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string query = "insert into BaoCaoCongNo values ";

            for (int rows = 0; rows < dtgvDebt.Rows.Count; rows++)
            {
                string st = "";
                if (rows == 0)
                    st = "(" + lb1.Text + "," + lb2.Text + ",";
                else
                    st = ",(" + lb1.Text + "," + lb2.Text + ",";
                string value = dtgvDebt.Rows[rows].Cells["MaKH"].Value?.ToString();
                st = st + "'" + value + "', ";
                value = dtgvDebt.Rows[rows].Cells["NoDau"].Value?.ToString();
                st += value + ", ";
                value = dtgvDebt.Rows[rows].Cells["PhatSinh"].Value?.ToString();
                st += value + ")  ";
                query += st;

            }
            query += ';';
            bool ck = DebtReportDAO.Instance.InsertReport(query);
            if (ck)
            {
                MessageBox.Show("Thêm báo cáo thành công");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int n = dtgvDebt.Rows.Add();
            dtgvDebt.Rows[n].Cells[0].Value = comboBox1.SelectedItem.ToString();
            dtgvDebt.Rows[n].Cells[1].Value = txtNoDau.Text;
            dtgvDebt.Rows[n].Cells[2].Value = txtPhatSInh.Text;
            comboBox1.Items.Remove(comboBox1.SelectedItem);
        }
    }
}
