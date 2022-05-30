using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (AccountDetailDAO.Instance.isExistedEmail(txtboxEmail.Text))
            {
                MessageBox.Show("Email đã tồn tại");
            }
            else
            {
                RegisterDAO.Instance.addID();
                string ID = RegisterDAO.Instance.getID();
                string hashPass = AccountDetailDAO.Instance.HashPass(txtboxPassword.Text);

                string isAdmin = "";
                if (radiobutAdmin.Checked == true)
                    isAdmin = "Quản lý";
                else
                    isAdmin = "Nhân viên";
                
                if (RegisterDAO.Instance.register(ID, txtboxUsername.Text, txtboxPhonenumber.Text, txtboxAddress.Text, txtboxEmail.Text, hashPass, isAdmin))
                {
                    this.Hide();
                    MenuForm menu = new MenuForm(ID);
                    menu.ShowDialog();
                    this.Close();
                }
            }
        }

        private void btnLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
        }
    }
}
