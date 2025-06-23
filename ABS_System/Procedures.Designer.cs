namespace Accounting_System
{
    partial class Procedures
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
            System.Windows.Forms.Label Label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procedures));
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtEID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.txtProcedure = new System.Windows.Forms.TextBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.cmbSubCategory = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpProcedureCreationDate = new System.Windows.Forms.DateTimePicker();
            this.txtProcedureCode = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            Label5 = new System.Windows.Forms.Label();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            Label5.BackColor = System.Drawing.Color.DarkBlue;
            Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            Label5.ForeColor = System.Drawing.Color.White;
            Label5.Location = new System.Drawing.Point(713, 97);
            Label5.Name = "Label5";
            Label5.Size = new System.Drawing.Size(225, 32);
            Label5.TabIndex = 268;
            Label5.Text = "كود الاجراء :";
            Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            Label5.Click += new System.EventHandler(this.Label5_Click);
            // 
            // Panel3
            // 
            this.Panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnGetData);
            this.Panel3.Controls.Add(this.btnDelete);
            this.Panel3.Controls.Add(this.btnUpdate);
            this.Panel3.Controls.Add(this.btnSave);
            this.Panel3.Controls.Add(this.btnNew);
            this.Panel3.Location = new System.Drawing.Point(946, 91);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(183, 320);
            this.Panel3.TabIndex = 3;
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.Gold;
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnGetData.Location = new System.Drawing.Point(13, 255);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(156, 49);
            this.btnGetData.TabIndex = 5;
            this.btnGetData.Text = "بحث";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(13, 188);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 49);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SkyBlue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(13, 127);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(156, 49);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "تعديل";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(13, 66);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 49);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "حفظ ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(13, 9);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(156, 49);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "جديد";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtEID
            // 
            this.txtEID.BackColor = System.Drawing.SystemColors.Control;
            this.txtEID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEID.Location = new System.Drawing.Point(236, 19);
            this.txtEID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEID.Name = "txtEID";
            this.txtEID.ReadOnly = true;
            this.txtEID.Size = new System.Drawing.Size(172, 24);
            this.txtEID.TabIndex = 319;
            this.txtEID.Visible = false;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(116, 50);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(92, 24);
            this.txtID.TabIndex = 12;
            this.txtID.Visible = false;
            // 
            // txtCID
            // 
            this.txtCID.BackColor = System.Drawing.SystemColors.Control;
            this.txtCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCID.Location = new System.Drawing.Point(116, 17);
            this.txtCID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCID.Name = "txtCID";
            this.txtCID.ReadOnly = true;
            this.txtCID.Size = new System.Drawing.Size(92, 24);
            this.txtCID.TabIndex = 7;
            this.txtCID.Visible = false;
            // 
            // txtProcedure
            // 
            this.txtProcedure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcedure.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtProcedure.Location = new System.Drawing.Point(493, 178);
            this.txtProcedure.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcedure.Name = "txtProcedure";
            this.txtProcedure.Size = new System.Drawing.Size(203, 30);
            this.txtProcedure.TabIndex = 5;
            this.txtProcedure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProcedure.TextChanged += new System.EventHandler(this.txtChargesQuote_TextChanged);
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(11, 23);
            this.lblUserType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(71, 16);
            this.lblUserType.TabIndex = 315;
            this.lblUserType.Text = "User Type";
            this.lblUserType.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(11, 39);
            this.lblUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(36, 16);
            this.lblUser.TabIndex = 313;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(489, 19);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(121, 36);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "الاجراءات";
            this.Label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Panel2
            // 
            this.Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.txtSubCategoryID);
            this.Panel2.Controls.Add(this.txtEID);
            this.Panel2.Controls.Add(this.txtID);
            this.Panel2.Controls.Add(this.txtCID);
            this.Panel2.Controls.Add(this.lblUserType);
            this.Panel2.Controls.Add(this.lblUser);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Location = new System.Drawing.Point(12, 7);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1117, 76);
            this.Panel2.TabIndex = 0;
            // 
            // txtSubCategoryID
            // 
            this.txtSubCategoryID.Location = new System.Drawing.Point(692, 23);
            this.txtSubCategoryID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubCategoryID.Name = "txtSubCategoryID";
            this.txtSubCategoryID.Size = new System.Drawing.Size(53, 22);
            this.txtSubCategoryID.TabIndex = 331;
            this.txtSubCategoryID.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.GroupBox4);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1145, 422);
            this.Panel1.TabIndex = 3;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox4.Controls.Add(this.groupBox5);
            this.GroupBox4.Controls.Add(this.txtProcedure);
            this.GroupBox4.Controls.Add(this.Label10);
            this.GroupBox4.Controls.Add(this.dtpProcedureCreationDate);
            this.GroupBox4.Controls.Add(this.txtProcedureCode);
            this.GroupBox4.Controls.Add(this.Label4);
            this.GroupBox4.Controls.Add(Label5);
            this.GroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.GroupBox4.Location = new System.Drawing.Point(-6, 87);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox4.Size = new System.Drawing.Size(944, 324);
            this.GroupBox4.TabIndex = 0;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "معلومات الخدمة";
            this.GroupBox4.Enter += new System.EventHandler(this.GroupBox4_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.groupBox5.Controls.Add(this.Button3);
            this.groupBox5.Controls.Add(this.Button4);
            this.groupBox5.Controls.Add(this.Label17);
            this.groupBox5.Controls.Add(this.Label16);
            this.groupBox5.Controls.Add(this.cmbSubCategory);
            this.groupBox5.Controls.Add(this.cmbCategory);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.Location = new System.Drawing.Point(29, 96);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(452, 137);
            this.groupBox5.TabIndex = 348;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "معلومات الخدمة :";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // Button3
            // 
            this.Button3.BackColor = System.Drawing.Color.White;
            this.Button3.Image = ((System.Drawing.Image)(resources.GetObject("Button3.Image")));
            this.Button3.Location = new System.Drawing.Point(63, 72);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(41, 39);
            this.Button3.TabIndex = 349;
            this.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button3.UseVisualStyleBackColor = false;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Button4
            // 
            this.Button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button4.BackColor = System.Drawing.Color.White;
            this.Button4.Image = ((System.Drawing.Image)(resources.GetObject("Button4.Image")));
            this.Button4.Location = new System.Drawing.Point(63, 27);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(41, 39);
            this.Button4.TabIndex = 350;
            this.Button4.UseVisualStyleBackColor = false;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.ForeColor = System.Drawing.Color.Red;
            this.Label17.Location = new System.Drawing.Point(29, 33);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(24, 26);
            this.Label17.TabIndex = 348;
            this.Label17.Text = "*";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.ForeColor = System.Drawing.Color.Red;
            this.Label16.Location = new System.Drawing.Point(29, 82);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(24, 26);
            this.Label16.TabIndex = 347;
            this.Label16.Text = "*";
            // 
            // cmbSubCategory
            // 
            this.cmbSubCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCategory.Enabled = false;
            this.cmbSubCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.cmbSubCategory.FormattingEnabled = true;
            this.cmbSubCategory.Items.AddRange(new object[] {
            "لا يوجد"});
            this.cmbSubCategory.Location = new System.Drawing.Point(109, 79);
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
            this.cmbCategory.Location = new System.Drawing.Point(109, 34);
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
            this.label12.Location = new System.Drawing.Point(291, 79);
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
            this.label14.Location = new System.Drawing.Point(291, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 27);
            this.label14.TabIndex = 345;
            this.label14.Text = "الخدمة الرئيسية :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label10.BackColor = System.Drawing.Color.DarkBlue;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label10.ForeColor = System.Drawing.Color.White;
            this.Label10.Location = new System.Drawing.Point(711, 176);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(225, 32);
            this.Label10.TabIndex = 339;
            this.Label10.Text = "الاجراء :";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpProcedureCreationDate
            // 
            this.dtpProcedureCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpProcedureCreationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpProcedureCreationDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dtpProcedureCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProcedureCreationDate.Location = new System.Drawing.Point(495, 135);
            this.dtpProcedureCreationDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpProcedureCreationDate.Name = "dtpProcedureCreationDate";
            this.dtpProcedureCreationDate.Size = new System.Drawing.Size(203, 30);
            this.dtpProcedureCreationDate.TabIndex = 1;
            // 
            // txtProcedureCode
            // 
            this.txtProcedureCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProcedureCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtProcedureCode.Location = new System.Drawing.Point(495, 99);
            this.txtProcedureCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtProcedureCode.Name = "txtProcedureCode";
            this.txtProcedureCode.ReadOnly = true;
            this.txtProcedureCode.Size = new System.Drawing.Size(203, 30);
            this.txtProcedureCode.TabIndex = 0;
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.BackColor = System.Drawing.Color.DarkBlue;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(712, 133);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(225, 32);
            this.Label4.TabIndex = 335;
            this.Label4.Text = "تاريخ انشاء الاجراء :";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Procedures
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1145, 422);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Procedures";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Procedures_Load_1);
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.TextBox txtEID;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.TextBox txtCID;
        internal System.Windows.Forms.TextBox txtProcedure;
        internal System.Windows.Forms.Label lblUserType;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpProcedureCreationDate;
        internal System.Windows.Forms.TextBox txtProcedureCode;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.ComboBox cmbSubCategory;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtSubCategoryID;
    }
}