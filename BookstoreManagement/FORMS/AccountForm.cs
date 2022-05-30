using System;
using System.Drawing;
using System.Windows.Forms;
using BookstoreManagement.DAO;
using BookstoreManagement.DTO;

namespace BookstoreManagement.FORMS
{
    public partial class AccountForm : Form
    {
        Account _acc;
        private EventHandler<AccountEvent> _updateAccount;

        public AccountForm(string id)
        {
            InitializeComponent();
            LoadData(id);
        }

        public event EventHandler<AccountEvent> updateAccountInfo
        {
            add { _updateAccount += value; }
            remove { _updateAccount -= value; }
        }

        void LoadData(string id)
        {
            _acc = AccountDetailDAO.Instance.getAccountByID(id);
            txtboxUsername.Text = _acc.Username;
            txtboxPhonenumber.Text = _acc.Phonenumber;
            txtboxAddress.Text = _acc.Address;
            txtboxEmail.Text = _acc.Email;
        }

        public bool updateAccount()
        {
            string username = txtboxUsername.Text;
            string phonenumber = txtboxPhonenumber.Text;
            string address = txtboxAddress.Text;
            string pass = AccountDetailDAO.Instance.HashPass(txtConfirmChangeInfo.Text);

            if (pass.Equals(_acc.Password))
            {
                if (AccountDetailDAO.Instance.updateAccount(_acc.UserID, username, phonenumber, address))
                {
                    if (_updateAccount != null)
                    {
                        _updateAccount(this, new AccountEvent(AccountDetailDAO.Instance.getAccountByID(_acc.UserID)));
                    }
                    LoadData(_acc.UserID);
                    MessageBox.Show("Cập nhật thành công");
                    return true;
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu xác nhận");
            }

            return false;
        }

        public bool updateEmail()
        {
            string email = txtboxEmail.Text;
            string pass = AccountDetailDAO.Instance.HashPass(txtConfirmChangeEmail.Text);

            if (pass.Equals(_acc.Password))
            {
                if (AccountDetailDAO.Instance.isExistedEmail(email))
                {
                    MessageBox.Show("Email đã tồn tại");
                }
                else
                {
                    if (AccountDetailDAO.Instance.updateEmail(_acc.UserID, email))
                    {
                        LoadData(_acc.UserID);
                        MessageBox.Show("Cập nhật thành công");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu xác nhận");
            }

            return false;
        }

        public bool changePassword()
        {
            string confirmNewPass = txtboxConfirm.Text;
            string NewPass = txtboxNewPass.Text;
            string OldPass = AccountDetailDAO.Instance.HashPass(txtboxOldPass.Text);

            if (NewPass.Equals(confirmNewPass))
            {
                NewPass = AccountDetailDAO.Instance.HashPass(NewPass);

                if (OldPass.Equals(_acc.Password))
                {
                    if (OldPass.Equals(NewPass))
                    {
                        MessageBox.Show("Mật khẩu mới trùng mật khẩu cũ");
                    }
                    else
                    {
                        if (AccountDetailDAO.Instance.changePassword(_acc.UserID, NewPass))
                        {
                            LoadData(_acc.UserID);
                            MessageBox.Show("Cập nhật thành công");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai mật khẩu cũ");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại phải trùng nhau");
            }

            return false;
        }

        private Color RGB(int v1, int v2, int v3)
        {
            return Color.FromArgb(v1, v2, v3);
        }

        private void btnEnableInfo_Click(object sender, System.EventArgs e)
        {
            btnEnableInfo.Visible = false;

            txtboxUsername.ReadOnly = false;
            txtboxUsername.BorderStyle = BorderStyle.Fixed3D;
            txtboxUsername.BackColor = RGB(23, 22, 36);

            txtboxPhonenumber.ReadOnly = false;
            txtboxPhonenumber.BorderStyle = BorderStyle.Fixed3D;
            txtboxPhonenumber.BackColor = RGB(23, 22, 36);

            txtboxAddress.ReadOnly = false;
            txtboxAddress.BorderStyle = BorderStyle.Fixed3D;
            txtboxAddress.BackColor = RGB(23, 22, 36);

            label9.Visible = true;
            txtConfirmChangeInfo.Visible = true;
            btnUpdateInfo.Visible = true;
        }

        private void btnEnableEmail_Click(object sender, System.EventArgs e)
        {
            btnEnableEmail.Visible = false;

            txtboxEmail.ReadOnly = false;
            txtboxEmail.BorderStyle = BorderStyle.Fixed3D;
            txtboxEmail.BackColor = RGB(23, 22, 36);

            label12.Visible = true;
            txtConfirmChangeEmail.Visible = true;
            btnUpdateEmail.Visible = true;
        }

        private void btnEnablePassword_Click(object sender, System.EventArgs e)
        {
            btnEnablePassword.Visible = false;

            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            txtboxNewPass.Visible = true;
            txtboxConfirm.Visible = true;
            txtboxOldPass.Visible = true;
            btnUpdatePassword.Visible = true;
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (updateAccount())
            {
                btnEnableInfo.Visible = true;

                txtboxUsername.BorderStyle = BorderStyle.None;
                txtboxUsername.BackColor = RGB(34, 31, 46);
                txtboxUsername.ReadOnly = true;

                txtboxPhonenumber.BorderStyle = BorderStyle.None;
                txtboxPhonenumber.BackColor = RGB(34, 31, 46);
                txtboxPhonenumber.ReadOnly = true;

                txtboxAddress.BorderStyle = BorderStyle.None;
                txtboxAddress.BackColor = RGB(34, 31, 46);
                txtboxAddress.ReadOnly = true;

                label9.Visible = false;
                txtConfirmChangeInfo.Visible = false;
                btnUpdateInfo.Visible = false;
            }
        }

        private void btnUpdateEmail_Click(object sender, EventArgs e)
        {
            if (updateEmail())
            {
                btnEnableEmail.Visible = true;

                txtboxEmail.BorderStyle = BorderStyle.None;
                txtboxEmail.BackColor = RGB(34, 31, 46);
                txtboxEmail.ReadOnly = true;

                label12.Visible = false;
                txtConfirmChangeEmail.Visible = false;
                btnUpdateEmail.Visible = false;
            }
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (changePassword())
            {
                btnEnablePassword.Visible = true;

                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                txtboxNewPass.Visible = false;
                txtboxConfirm.Visible = false;
                txtboxOldPass.Visible = false;
                btnUpdatePassword.Visible = false;
            }
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account _acc;

        public Account Acc
        {
            get { return _acc; }
            set { _acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this._acc = acc;
        }
    }
}
