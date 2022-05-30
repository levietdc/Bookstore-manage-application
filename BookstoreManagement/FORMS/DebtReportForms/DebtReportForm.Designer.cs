namespace BookstoreManagement.FORMS
{
    partial class DebtReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgvDebt = new System.Windows.Forms.DataGridView();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.comboboxYear = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.comboboxMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDebt)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvDebt
            // 
            this.dtgvDebt.AllowUserToAddRows = false;
            this.dtgvDebt.AllowUserToDeleteRows = false;
            this.dtgvDebt.AllowUserToOrderColumns = true;
            this.dtgvDebt.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(35)))));
            this.dtgvDebt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDebt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvDebt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDebt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.dtgvDebt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvDebt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvDebt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(16)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDebt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvDebt.ColumnHeadersHeight = 30;
            this.dtgvDebt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(43)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDebt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvDebt.EnableHeadersVisualStyles = false;
            this.dtgvDebt.Location = new System.Drawing.Point(109, 93);
            this.dtgvDebt.Margin = new System.Windows.Forms.Padding(100, 40, 100, 40);
            this.dtgvDebt.Name = "dtgvDebt";
            this.dtgvDebt.ReadOnly = true;
            this.dtgvDebt.RowHeadersVisible = false;
            this.dtgvDebt.RowHeadersWidth = 20;
            this.dtgvDebt.RowTemplate.Height = 50;
            this.dtgvDebt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDebt.Size = new System.Drawing.Size(664, 411);
            this.dtgvDebt.TabIndex = 107;
            this.dtgvDebt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDebt_CellDoubleClick);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // comboboxYear
            // 
            this.comboboxYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.comboboxYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboboxYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxYear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboboxYear.FormattingEnabled = true;
            this.comboboxYear.Items.AddRange(new object[] {
            "*"});
            this.comboboxYear.Location = new System.Drawing.Point(273, 26);
            this.comboboxYear.Name = "comboboxYear";
            this.comboboxYear.Size = new System.Drawing.Size(98, 36);
            this.comboboxYear.TabIndex = 111;
            this.comboboxYear.Text = "Năm";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Image = global::BookstoreManagement.Properties.Resources.plus;
            this.btnAdd.Location = new System.Drawing.Point(725, 21);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(48, 48);
            this.btnAdd.TabIndex = 108;
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFind
            // 
            this.btnFind.FlatAppearance.BorderSize = 0;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnFind.Image = global::BookstoreManagement.Properties.Resources.loupe;
            this.btnFind.Location = new System.Drawing.Point(109, 21);
            this.btnFind.Margin = new System.Windows.Forms.Padding(9);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(48, 48);
            this.btnFind.TabIndex = 109;
            this.btnFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // comboboxMonth
            // 
            this.comboboxMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.comboboxMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboboxMonth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboboxMonth.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.comboboxMonth.FormattingEnabled = true;
            this.comboboxMonth.Items.AddRange(new object[] {
            "*",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboboxMonth.Location = new System.Drawing.Point(169, 26);
            this.comboboxMonth.Name = "comboboxMonth";
            this.comboboxMonth.Size = new System.Drawing.Size(98, 36);
            this.comboboxMonth.TabIndex = 112;
            this.comboboxMonth.Text = "Tháng";
            // 
            // DebtReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.comboboxMonth);
            this.Controls.Add(this.dtgvDebt);
            this.Controls.Add(this.comboboxYear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnFind);
            this.Name = "DebtReportForm";
            this.Text = "Báo Cáo Nợ";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDebt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvDebt;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ComboBox comboboxYear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox comboboxMonth;
    }
}