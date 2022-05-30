using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BookstoreManagement.DTO;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class EntryDetailsForm : Form
    {
        public EntryDetailsForm(string id)
        {
            InitializeComponent();
            DisplayData(id);
        }

        public void DisplayData(string id)
        {
            List<EntryBook> list = EntryBookDAO.Instance.DisplayEntryDetails(id);

            lbCode.Text = list[0].Id;
            lbDatetime.Text = list[0].Date;

            int length = list.Count();
            for (int i = 0; i < length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtgvEntry);

                row.Cells[0].Value = i + 1;
                row.Cells[1].Value = list[i].BookName;
                row.Cells[2].Value = list[i].BookType;
                row.Cells[3].Value = list[i].Author;
                row.Cells[4].Value = list[i].Count;

                dtgvEntry.Rows.Add(row);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = lbCode.Text;
            EntryEditForm editForm = new EntryEditForm(id);
            editForm.ShowDialog();

            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = lbCode.Text;

            // xóa phiếu nhập sách thì cập nhật lại số lượng sách chưa làm


            EntryBookDAO.Instance.DeletePhieuNhapSach_Sach(id);
            EntryBookDAO.Instance.DeletePhieuNhapSach(id);

            this.Close();
        }
    }
}
