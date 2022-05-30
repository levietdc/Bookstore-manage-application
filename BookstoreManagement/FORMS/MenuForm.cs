using System;
using System.Windows.Forms;
using BookstoreManagement.DTO;
using System.Runtime.InteropServices;
using BookstoreManagement.DAO;
using System.Drawing;

namespace BookstoreManagement.FORMS
{
    public partial class MenuForm : Form
    {
        private Button currentBtn;
        private Account _acc;

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void openChildForm(object sender, Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel_body.Controls.Add(childForm);
            this.panel_body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void activateButton(object sender)
        {
            if (sender != null)
            {
                if (currentBtn != null)
                    currentBtn.BackColor = Color.FromArgb(80, 62, 90);

                currentBtn = (Button)sender;
                currentBtn.BackColor = Color.FromArgb(122, 133, 224);
            }
        }

        public MenuForm(string id)
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            LoadData(id);
        }

        public void LoadData(string id)
        {
            _acc = AccountDetailDAO.Instance.getAccountByID(id);
            lbRole.Text = _acc.IsAdmin;
            btnName.Text = _acc.Username;
        }

        void f_updateAccount(object sender, AccountEvent e)
        {
            btnName.Text = e.Acc.Username;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            activateButton(sender);

            if (_acc.IsAdmin == "Quản lý")
                openChildForm(sender, new HomeAdminForm());
            else
                openChildForm(sender, new HomeEmployeeForm());
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new AboutForm());
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm(_acc.UserID);
            accountForm.updateAccountInfo += f_updateAccount;
            openChildForm(sender, accountForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
