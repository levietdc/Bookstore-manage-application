using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class InventoryReportPreAddForm : Form
    {
        public InventoryReportPreAddForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string month = comboBox1.SelectedItem.ToString();
            string year = textBox1.Text;
            if (int.TryParse(year, out _))
            {
                if (InventoryReportDAO.Instance.checkExist(month, year) == false)
                {
                    InventoryReportAddForm form1 = new InventoryReportAddForm();
                    form1.MonthAndYear(month, year);
                    this.Close();
                    form1.ShowDialog();
                }
                else
                    MessageBox.Show("Báo cáo đã tồn tại");
            }
            else MessageBox.Show("Nhập năm không đúng");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
