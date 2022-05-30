using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class InventoryReportAddForm : Form
    {
        public InventoryReportAddForm()
        {
            InitializeComponent();
            List<string> Names = BooksDAO.Instance.getId();
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
            string query = "insert into BaoCaoTonKho values ";

            for (int rows = 0; rows < dataGridView1.Rows.Count ; rows++)
            {
                string st = "";
                if (rows == 0)
                    st = "(" + lb1.Text + "," + lb2.Text + ",";
                else
                    st = ",(" + lb1.Text + "," + lb2.Text + ",";
                string value = dataGridView1.Rows[rows].Cells["MaSach"].Value?.ToString();
                st = st + "'" + value + "', ";
                value = dataGridView1.Rows[rows].Cells["TonDau"].Value?.ToString();
                st += value + ", ";
                value = dataGridView1.Rows[rows].Cells["PhatSinh"].Value?.ToString();
                st += value + ")  ";
                query += st;
            }

            //MessageBox.Show(query);

            query += ';';
            bool ck = InventoryReportDAO.Instance.InsertReport(query);
            if (ck)
            {
                MessageBox.Show("Thêm báo cáo thành công");
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = comboBox1.SelectedItem.ToString();
            dataGridView1.Rows[n].Cells[1].Value = txtNoDau.Text;
            dataGridView1.Rows[n].Cells[2].Value = txtPhatSInh.Text;
            comboBox1.Items.Remove(comboBox1.SelectedItem);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
