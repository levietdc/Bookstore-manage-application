using System;
using System.Drawing;
using System.Windows.Forms;

namespace BookstoreManagement.FORMS
{
    public partial class HomeEmployeeForm : Form
    {
        private Button currentBtn;

        public HomeEmployeeForm()
        {
            InitializeComponent();
        }

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
                    currentBtn.BackColor = Color.FromArgb(63, 47, 72);

                currentBtn = (Button)sender;
                currentBtn.BackColor = Color.FromArgb(163, 92, 214);
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new BookForm());
        }

        private void btnEntryBookNote_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new EntryForm());
        }

        private void btnBills_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new BillForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new CustomerForm());
        }

        private void btnDeptNote_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new DebtNoteForm());
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new InventoryReportForm());
        }

        private void btnDeptReport_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new DebtReportForm());
        }

        private void btnRule_Click(object sender, EventArgs e)
        {
            activateButton(sender);
            openChildForm(sender, new RegulationsForm());
        }
    }
}
