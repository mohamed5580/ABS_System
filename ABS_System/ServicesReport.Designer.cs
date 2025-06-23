namespace Accounting_System
{
    partial class ServicesReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServicesReport));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnGetData = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.crystalOpenFileDialog1 = new CrystalDecisions.Shared.Interop.CrystalOpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Panel1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.GroupBox2);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1059, 292);
            this.Panel1.TabIndex = 4;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.groupBox5);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.dtpDateTo);
            this.GroupBox2.Controls.Add(this.btnGetData);
            this.GroupBox2.Controls.Add(this.dtpDateFrom);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(31, 93);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Size = new System.Drawing.Size(1021, 190);
            this.GroupBox2.TabIndex = 50;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "بحث باسم  الخدمة :";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.DarkBlue;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(195, 64);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(159, 30);
            this.Label5.TabIndex = 52;
            this.Label5.Text = "إلى تاريخ :";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.DarkBlue;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(395, 64);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(159, 30);
            this.Label6.TabIndex = 51;
            this.Label6.Text = "من تاريخ :";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(197, 94);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(157, 30);
            this.dtpDateTo.TabIndex = 14;
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.Color.White;
            this.btnGetData.Image = ((System.Drawing.Image)(resources.GetObject("btnGetData.Image")));
            this.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGetData.Location = new System.Drawing.Point(21, 74);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(154, 50);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "عرض التقرير";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(395, 94);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(161, 30);
            this.dtpDateFrom.TabIndex = 11;
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.txtID);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(8, 9);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1045, 76);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(418, 20);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(175, 29);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "تقرير بنوع الخدمة ";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // crystalOpenFileDialog1
            // 
            this.crystalOpenFileDialog1.FileName = "crystalOpenFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox5.Controls.Add(this.cmbSubCategory);
            this.groupBox5.Controls.Add(this.cmbCategory);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(628, 27);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(384, 137);
            this.groupBox5.TabIndex = 349;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "معلومات الخدمة :";
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCategory.Enabled = false;
            this.cmbSubCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Items.AddRange(new object[] {
            "لا يوجد"});
            this.cmbSubCategory.Location = new System.Drawing.Point(74, 85);
            this.cmbSubCategory.Name = "cmbSubCategory";
            this.cmbSubCategory.Size = new System.Drawing.Size(173, 31);
            this.cmbSubCategory.TabIndex = 344;
            this.cmbSubCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSubCategory_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.DropDownWidth = 100;
            this.cmbCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cmbCategory.Items.AddRange(new object[] {
            "لا يوجد"});
            this.cmbCategory.Location = new System.Drawing.Point(74, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(173, 31);
            this.cmbCategory.TabIndex = 343;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DarkBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(256, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 26);
            this.label12.TabIndex = 346;
            this.label12.Text = "الخدمة الفرعية :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.DarkBlue;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(256, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 27);
            this.label14.TabIndex = 345;
            this.label14.Text = "الخدمة الرئيسية :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(64, 25);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(92, 24);
            this.txtID.TabIndex = 13;
            this.txtID.Visible = false;
            // 
            // ServicesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 292);
            this.Controls.Add(this.Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServicesReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalesProductsReport";
            this.Load += new System.EventHandler(this.SalesProductsReport_Load);
            this.Panel1.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DateTimePicker dtpDateTo;
        internal System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.DateTimePicker dtpDateFrom;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Timer Timer1;
        private CrystalDecisions.Shared.Interop.CrystalOpenFileDialog crystalOpenFileDialog1;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.ComboBox cmbSubCategory;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtID;
    }
}