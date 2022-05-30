using System;
using System.Windows.Forms;
using BookstoreManagement.DTO;
using BookstoreManagement.DAO;
using System.Drawing;

namespace BookstoreManagement.FORMS
{
    public partial class RegulationsForm : Form
    {
        private Regulations rule;

        public RegulationsForm()
        {
            InitializeComponent();
            LoadData();
            DisplayData();
        }

        public void LoadData()
        {
            rule = new Regulations(RegulationsDAO.Instance.loadData().Rows[0]);
        }

        public void DisplayData()
        {
            txb11.Text = rule.SoLuongNhapToiThieu.ToString();
            txb12.Text = rule.LuongTonToiDa.ToString();
            txb21.Text = rule.SoTienNoToiDa.ToString();
            txb22.Text = rule.LuongTonToiThieu.ToString();
            if (rule.TienThuTienNo == 0)
                cbxChoice.Text = "Không";
            else
                cbxChoice.Text = "Có";
        }

        private Color RGB(int v1, int v2, int v3)
        {
            return Color.FromArgb(v1, v2, v3);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            if (btn11.Text == "Sửa")
            {
                btn11.Text = "OK";
                txb11.BorderStyle = BorderStyle.Fixed3D;
                txb11.BackColor = RGB(23, 22, 36);
                txb11.ReadOnly = false;
            }
            else
            {
                btn11.Text = "Sửa";
                txb11.BorderStyle = BorderStyle.None;
                txb11.BackColor = RGB(34, 31, 46);
                txb11.ReadOnly = true;

                rule.SoLuongNhapToiThieu = int.Parse(txb11.Text);
                RegulationsDAO.Instance.update(rule);
            }
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            if (btn12.Text == "Sửa")
            {
                btn12.Text = "OK";
                txb12.BorderStyle = BorderStyle.Fixed3D;
                txb12.BackColor = RGB(23, 22, 36);
                txb12.ReadOnly = false;
            }
            else
            {
                btn12.Text = "Sửa";
                txb12.BorderStyle = BorderStyle.None;
                txb12.BackColor = RGB(34, 31, 46);
                txb12.ReadOnly = true;

                rule.LuongTonToiDa = int.Parse(txb12.Text);
                RegulationsDAO.Instance.update(rule);
            }
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            if (btn21.Text == "Sửa")
            {
                btn21.Text = "OK";
                txb21.BorderStyle = BorderStyle.Fixed3D;
                txb21.BackColor = RGB(23, 22, 36);
                txb21.ReadOnly = false;
            }
            else
            {
                btn21.Text = "Sửa";
                txb21.BorderStyle = BorderStyle.None;
                txb21.BackColor = RGB(34, 31, 46);
                txb21.ReadOnly = true;

                rule.SoTienNoToiDa = int.Parse(txb21.Text);
                RegulationsDAO.Instance.update(rule);
            }
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            if (btn22.Text == "Sửa")
            {
                btn22.Text = "OK";
                txb22.BorderStyle = BorderStyle.Fixed3D;
                txb22.BackColor = RGB(23, 22, 36);
                txb22.ReadOnly = false;
            }
            else
            {
                btn22.Text = "Sửa";
                txb22.BorderStyle = BorderStyle.None;
                txb22.BackColor = RGB(34, 31, 46);
                txb22.ReadOnly = true;

                rule.LuongTonToiThieu = int.Parse(txb22.Text);
                RegulationsDAO.Instance.update(rule);
            }
        }

        private void cbxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChoice.Text == "Không")
            {
                rule.TienThuTienNo = 0;
            }
            else
            {
                rule.TienThuTienNo = 1;
            }

            RegulationsDAO.Instance.update(rule);
        }
    }
}
