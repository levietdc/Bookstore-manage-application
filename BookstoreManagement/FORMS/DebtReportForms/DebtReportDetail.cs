using System.Data;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class DebtReportDetail : Form
    {
        public DebtReportDetail()
        {
            InitializeComponent();
        }

        public void ShowData(string month, string year, string debt)
        {
            lb1.Text = month;
            lb2.Text = year;
            lb3.Text = debt;

            DataTable dt = DebtReportDAO.Instance.DetailReport(month, year);
            dtgvDebt.DataSource = dt;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            string month = lb1.Text;
            string year = lb2.Text;
            int n = DebtReportDAO.Instance.delete(month, year);
            if (n > 0)
            {
                MessageBox.Show("Xóa báo cáo thành công");
            }
            this.Close();
        }
    }
}
