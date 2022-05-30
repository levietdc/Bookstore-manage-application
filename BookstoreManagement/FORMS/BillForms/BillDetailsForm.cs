using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class BillDetailsForm : Form
    {
        public BillDetailsForm(string billcode)
        {
            InitializeComponent();
            DisplayData(billcode);
        }

        public void DisplayData(string billCode)
        {
            List<Bill> list = BillsDAO.Instance.DisplayBillDetails(billCode);

            lbBillCode.Text = list[0].Id;
            lbCustomerId.Text = list[0].CustomerId;
            lbCustomerName.Text = list[0].CustomerName;
            lbDatetime.Text = list[0].Date;
            lbTotal.Text = list[0].Total;
            lbPaid.Text = list[0].Paid;
            lbDebt.Text = list[0].Dept;

            int length = list.Count();
            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvBookList);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].BookName;
                row.Cells[2].Value = list[i].BookType;
                row.Cells[3].Value = list[i].Count;
                row.Cells[4].Value = list[i].Price;

                dtgvBookList.Rows.Add(row);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = lbBillCode.Text;

            // xóa hóa đơn thì cập nhật lại số lượng sách chưa làm


            BillsDAO.Instance.DeleteHoaDon_Sach(id);
            BillsDAO.Instance.DeleteHoaDon(id);

            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = lbBillCode.Text;
            BillEditForm editForm = new BillEditForm(id);
            editForm.ShowDialog();

            this.Close();
        }
    }
}
