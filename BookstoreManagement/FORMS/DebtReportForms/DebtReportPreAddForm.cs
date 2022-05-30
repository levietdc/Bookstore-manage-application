using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class DebtReportPreAddForm : Form
    {
        public DebtReportPreAddForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string month = cbxMonth.SelectedItem.ToString();
            string year = txbYear.Text;
            if (int.TryParse(year, out _))
            {
                if (DebtReportDAO.Instance.checkExist(month, year) == false)
                {
                    DebtReportAddForm form1 = new DebtReportAddForm();
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
