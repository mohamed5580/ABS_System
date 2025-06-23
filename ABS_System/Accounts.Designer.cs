namespace Accounting_System
{
    partial class Accounts
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
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtEID = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCID = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtSubCategoryID = new System.Windows.Forms.TextBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAccountDetails = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.dtpProcedureCreationDate = new System.Windows.Forms.DateTimePicker();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            Label5 = new System.Windows.Forms.Label();
            this.Panel3.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
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
            Label5.Text = "كود الحساب :";
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
            // txtAccount
            // 
            this.txtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtAccount.Location = new System.Drawing.Point(38, 101);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(203, 30);
            this.txtAccount.TabIndex = 5;
            this.txtAccount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtChargesQuote_TextChanged);
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(11, 23);
            this.lblUserType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(74, 17);
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
            this.lblUser.Size = new System.Drawing.Size(38, 17);
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
            this.Label1.Size = new System.Drawing.Size(109, 36);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "الحسابات";
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
            this.GroupBox4.Controls.Add(this.txtAccountDetails);
            this.GroupBox4.Controls.Add(this.Label11);
            this.GroupBox4.Controls.Add(this.txtAccount);
            this.GroupBox4.Controls.Add(this.Label10);
            this.GroupBox4.Controls.Add(this.dtpProcedureCreationDate);
            this.GroupBox4.Controls.Add(this.txtAccountCode);
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
            // txtAccountDetails
            // 
            this.txtAccountDetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtAccountDetails.Location = new System.Drawing.Point(62, 165);
            this.txtAccountDetails.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountDetails.Multiline = true;
            this.txtAccountDetails.Name = "txtAccountDetails";
            this.txtAccountDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAccountDetails.Size = new System.Drawing.Size(284, 64);
            this.txtAccountDetails.TabIndex = 340;
            // 
            // Label11
            // 
            this.Label11.BackColor = System.Drawing.Color.DarkBlue;
            this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label11.ForeColor = System.Drawing.Color.White;
            this.Label11.Location = new System.Drawing.Point(357, 166);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(119, 32);
            this.Label11.TabIndex = 341;
            this.Label11.Text = "ملاحظات :";
            this.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label10
            // 
            this.Label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label10.BackColor = System.Drawing.Color.DarkBlue;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label10.ForeColor = System.Drawing.Color.White;
            this.Label10.Location = new System.Drawing.Point(254, 99);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(225, 32);
            this.Label10.TabIndex = 339;
            this.Label10.Text = "الحساب :";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpProcedureCreationDate
            // 
            this.dtpProcedureCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpProcedureCreationDate.CustomFormat = "dd/MM/yyyy";
            this.dtpProcedureCreationDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.dtpProcedureCreationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpProcedureCreationDate.Location = new System.Drawing.Point(495, 167);
            this.dtpProcedureCreationDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpProcedureCreationDate.Name = "dtpProcedureCreationDate";
            this.dtpProcedureCreationDate.Size = new System.Drawing.Size(203, 30);
            this.dtpProcedureCreationDate.TabIndex = 1;
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtAccountCode.Location = new System.Drawing.Point(495, 99);
            this.txtAccountCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.ReadOnly = true;
            this.txtAccountCode.Size = new System.Drawing.Size(203, 30);
            this.txtAccountCode.TabIndex = 0;
            this.txtAccountCode.TextChanged += new System.EventHandler(this.txtProcedureCode_TextChanged);
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.BackColor = System.Drawing.Color.DarkBlue;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(712, 165);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(225, 32);
            this.Label4.TabIndex = 335;
            this.Label4.Text = "تاريخ انشاء الحساب :";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Accounts
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1145, 422);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Accounts";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Procedures_Load_1);
            this.Panel3.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
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
        internal System.Windows.Forms.TextBox txtAccount;
        internal System.Windows.Forms.Label lblUserType;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ToolTip ToolTip1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.DateTimePicker dtpProcedureCreationDate;
        internal System.Windows.Forms.TextBox txtAccountCode;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.TextBox txtSubCategoryID;
        internal System.Windows.Forms.TextBox txtAccountDetails;
        internal System.Windows.Forms.Label Label11;
    }
}