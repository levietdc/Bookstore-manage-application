using System;
using System.Windows.Forms;
using BookstoreManagement.DAO;

namespace BookstoreManagement.FORMS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtboxEmail.Text;
            string password = txtboxPassword.Text;
            string hashPass = AccountDetailDAO.Instance.HashPass(password);

            if (LoginDAO.Instance.login(email, hashPass))
            {
                this.Hide();
                string id = AccountDetailDAO.Instance.getIdByEmail(email);
                MenuForm menu = new MenuForm(id);
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập sai mật khẩu hoặc email");
            }
        }
    }
}
