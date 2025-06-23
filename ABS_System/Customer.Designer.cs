namespace Accounting_System
{
    partial class Customer
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
        /// the cntents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSAPPassword = new Guna.UI.WinForms.GunaTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSAPUserName = new Guna.UI.WinForms.GunaTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOldInvoiceEmail = new Guna.UI.WinForms.GunaTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtOldGOVSystemEmail = new Guna.UI.WinForms.GunaTextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblSet = new System.Windows.Forms.Label();
            this.txtBCode = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtGOVSystemPassword = new Guna.UI.WinForms.GunaTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtGOVSystemEmail = new Guna.UI.WinForms.GunaTextBox();
            this.txtInsuranceFileNumber = new Guna.UI.WinForms.GunaTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFormationCode = new Guna.UI.WinForms.GunaTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtInvoiceEmailPassword = new Guna.UI.WinForms.GunaTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtOldSystemEmailPassword = new Guna.UI.WinForms.GunaTextBox();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.txtOldSystemPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtOldSystemUserName = new Guna.UI.WinForms.GunaTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtTaxCardNumber = new Guna.UI.WinForms.GunaTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTaxRegistrationNumber = new Guna.UI.WinForms.GunaTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtWorkersCount = new Guna.UI.WinForms.GunaTextBox();
            this.txtOrganizationName = new Guna.UI.WinForms.GunaTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.filetext = new System.Windows.Forms.Label();
            this.txtFilePath = new Guna.UI.WinForms.GunaAdvenceButton();
            this.label27 = new System.Windows.Forms.Label();
            this.txtActivityStartDate = new Guna.UI.WinForms.GunaDateTimePicker();
            this.txtActivityType = new Guna.UI.WinForms.GunaTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNationalID = new Guna.UI.WinForms.GunaTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddress = new Guna.UI.WinForms.GunaTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerName = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new Guna.UI.WinForms.GunaTextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.BackColor = System.Drawing.Color.DarkBlue;
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Name = "label25";
            // 
            // txtSAPPassword
            // 
            resources.ApplyResources(this.txtSAPPassword, "txtSAPPassword");
            this.txtSAPPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtSAPPassword.BaseColor = System.Drawing.Color.White;
            this.txtSAPPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtSAPPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSAPPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtSAPPassword.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtSAPPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSAPPassword.Name = "txtSAPPassword";
            this.txtSAPPassword.PasswordChar = '\0';
            this.txtSAPPassword.Radius = 5;
            this.txtSAPPassword.SelectedText = "";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.BackColor = System.Drawing.Color.DarkBlue;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Name = "label14";
            // 
            // txtSAPUserName
            // 
            resources.ApplyResources(this.txtSAPUserName, "txtSAPUserName");
            this.txtSAPUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtSAPUserName.BaseColor = System.Drawing.Color.White;
            this.txtSAPUserName.BorderColor = System.Drawing.Color.Silver;
            this.txtSAPUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSAPUserName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtSAPUserName.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtSAPUserName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSAPUserName.Name = "txtSAPUserName";
            this.txtSAPUserName.PasswordChar = '\0';
            this.txtSAPUserName.Radius = 5;
            this.txtSAPUserName.SelectedText = "";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.BackColor = System.Drawing.Color.DarkBlue;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // txtOldInvoiceEmail
            // 
            resources.ApplyResources(this.txtOldInvoiceEmail, "txtOldInvoiceEmail");
            this.txtOldInvoiceEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtOldInvoiceEmail.BaseColor = System.Drawing.Color.White;
            this.txtOldInvoiceEmail.BorderColor = System.Drawing.Color.Silver;
            this.txtOldInvoiceEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldInvoiceEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOldInvoiceEmail.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOldInvoiceEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldInvoiceEmail.Name = "txtOldInvoiceEmail";
            this.txtOldInvoiceEmail.PasswordChar = '\0';
            this.txtOldInvoiceEmail.Radius = 5;
            this.txtOldInvoiceEmail.SelectedText = "";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.BackColor = System.Drawing.Color.DarkBlue;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Name = "label16";
            // 
            // txtOldGOVSystemEmail
            // 
            resources.ApplyResources(this.txtOldGOVSystemEmail, "txtOldGOVSystemEmail");
            this.txtOldGOVSystemEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtOldGOVSystemEmail.BaseColor = System.Drawing.Color.White;
            this.txtOldGOVSystemEmail.BorderColor = System.Drawing.Color.Silver;
            this.txtOldGOVSystemEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldGOVSystemEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOldGOVSystemEmail.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOldGOVSystemEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldGOVSystemEmail.Name = "txtOldGOVSystemEmail";
            this.txtOldGOVSystemEmail.PasswordChar = '\0';
            this.txtOldGOVSystemEmail.Radius = 5;
            this.txtOldGOVSystemEmail.SelectedText = "";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Panel2
            // 
            resources.ApplyResources(this.Panel2, "Panel2");
            this.Panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.Panel2.Controls.Add(this.lblSet);
            this.Panel2.Controls.Add(this.txtBCode);
            this.Panel2.Controls.Add(this.lblUser);
            this.Panel2.Controls.Add(this.lblUserType);
            this.Panel2.Controls.Add(this.txtID);
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Name = "Panel2";
            // 
            // lblSet
            // 
            resources.ApplyResources(this.lblSet, "lblSet");
            this.lblSet.Name = "lblSet";
            // 
            // txtBCode
            // 
            resources.ApplyResources(this.txtBCode, "txtBCode");
            this.txtBCode.Name = "txtBCode";
            this.txtBCode.ReadOnly = true;
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // lblUserType
            // 
            resources.ApplyResources(this.lblUserType, "lblUserType");
            this.lblUserType.Name = "lblUserType";
            // 
            // txtID
            // 
            resources.ApplyResources(this.txtID, "txtID");
            this.txtID.Name = "txtID";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Name = "Label1";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.BackColor = System.Drawing.Color.DarkBlue;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Name = "label17";
            // 
            // txtGOVSystemPassword
            // 
            resources.ApplyResources(this.txtGOVSystemPassword, "txtGOVSystemPassword");
            this.txtGOVSystemPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtGOVSystemPassword.BaseColor = System.Drawing.Color.White;
            this.txtGOVSystemPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtGOVSystemPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGOVSystemPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtGOVSystemPassword.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtGOVSystemPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGOVSystemPassword.Name = "txtGOVSystemPassword";
            this.txtGOVSystemPassword.PasswordChar = '\0';
            this.txtGOVSystemPassword.Radius = 5;
            this.txtGOVSystemPassword.SelectedText = "";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.BackColor = System.Drawing.Color.DarkBlue;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Name = "label18";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.BackColor = System.Drawing.Color.DarkBlue;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Name = "label19";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SkyBlue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtGOVSystemEmail
            // 
            resources.ApplyResources(this.txtGOVSystemEmail, "txtGOVSystemEmail");
            this.txtGOVSystemEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtGOVSystemEmail.BaseColor = System.Drawing.Color.White;
            this.txtGOVSystemEmail.BorderColor = System.Drawing.Color.Silver;
            this.txtGOVSystemEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGOVSystemEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtGOVSystemEmail.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtGOVSystemEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtGOVSystemEmail.Name = "txtGOVSystemEmail";
            this.txtGOVSystemEmail.PasswordChar = '\0';
            this.txtGOVSystemEmail.Radius = 5;
            this.txtGOVSystemEmail.SelectedText = "";
            // 
            // txtInsuranceFileNumber
            // 
            resources.ApplyResources(this.txtInsuranceFileNumber, "txtInsuranceFileNumber");
            this.txtInsuranceFileNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtInsuranceFileNumber.BaseColor = System.Drawing.Color.White;
            this.txtInsuranceFileNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtInsuranceFileNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInsuranceFileNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtInsuranceFileNumber.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtInsuranceFileNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInsuranceFileNumber.Name = "txtInsuranceFileNumber";
            this.txtInsuranceFileNumber.PasswordChar = '\0';
            this.txtInsuranceFileNumber.Radius = 5;
            this.txtInsuranceFileNumber.SelectedText = "";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.BackColor = System.Drawing.Color.DarkBlue;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Name = "label21";
            // 
            // txtFormationCode
            // 
            resources.ApplyResources(this.txtFormationCode, "txtFormationCode");
            this.txtFormationCode.BackColor = System.Drawing.Color.Transparent;
            this.txtFormationCode.BaseColor = System.Drawing.Color.White;
            this.txtFormationCode.BorderColor = System.Drawing.Color.Silver;
            this.txtFormationCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFormationCode.FocusedBaseColor = System.Drawing.Color.White;
            this.txtFormationCode.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtFormationCode.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFormationCode.Name = "txtFormationCode";
            this.txtFormationCode.PasswordChar = '\0';
            this.txtFormationCode.Radius = 5;
            this.txtFormationCode.SelectedText = "";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.BackColor = System.Drawing.Color.DarkBlue;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Name = "label22";
            // 
            // txtInvoiceEmailPassword
            // 
            resources.ApplyResources(this.txtInvoiceEmailPassword, "txtInvoiceEmailPassword");
            this.txtInvoiceEmailPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtInvoiceEmailPassword.BaseColor = System.Drawing.Color.White;
            this.txtInvoiceEmailPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtInvoiceEmailPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInvoiceEmailPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtInvoiceEmailPassword.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtInvoiceEmailPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInvoiceEmailPassword.Name = "txtInvoiceEmailPassword";
            this.txtInvoiceEmailPassword.PasswordChar = '\0';
            this.txtInvoiceEmailPassword.Radius = 5;
            this.txtInvoiceEmailPassword.SelectedText = "";
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.BackColor = System.Drawing.Color.DarkBlue;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Name = "label23";
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.Gold;
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnGetData, "btnGetData");
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click_1);
            // 
            // txtOldSystemEmailPassword
            // 
            resources.ApplyResources(this.txtOldSystemEmailPassword, "txtOldSystemEmailPassword");
            this.txtOldSystemEmailPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtOldSystemEmailPassword.BaseColor = System.Drawing.Color.White;
            this.txtOldSystemEmailPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtOldSystemEmailPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldSystemEmailPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOldSystemEmailPassword.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOldSystemEmailPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldSystemEmailPassword.Name = "txtOldSystemEmailPassword";
            this.txtOldSystemEmailPassword.PasswordChar = '\0';
            this.txtOldSystemEmailPassword.Radius = 5;
            this.txtOldSystemEmailPassword.SelectedText = "";
            // 
            // Panel3
            // 
            resources.ApplyResources(this.Panel3, "Panel3");
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.btnGetData);
            this.Panel3.Controls.Add(this.btnDelete);
            this.Panel3.Controls.Add(this.btnUpdate);
            this.Panel3.Controls.Add(this.btnSave);
            this.Panel3.Controls.Add(this.btnNew);
            this.Panel3.Name = "Panel3";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.BackColor = System.Drawing.Color.DarkBlue;
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Name = "label24";
            // 
            // txtOldSystemPassword
            // 
            resources.ApplyResources(this.txtOldSystemPassword, "txtOldSystemPassword");
            this.txtOldSystemPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtOldSystemPassword.BaseColor = System.Drawing.Color.White;
            this.txtOldSystemPassword.BorderColor = System.Drawing.Color.Silver;
            this.txtOldSystemPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldSystemPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOldSystemPassword.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOldSystemPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldSystemPassword.Name = "txtOldSystemPassword";
            this.txtOldSystemPassword.PasswordChar = '\0';
            this.txtOldSystemPassword.Radius = 5;
            this.txtOldSystemPassword.SelectedText = "";
            // 
            // txtOldSystemUserName
            // 
            resources.ApplyResources(this.txtOldSystemUserName, "txtOldSystemUserName");
            this.txtOldSystemUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtOldSystemUserName.BaseColor = System.Drawing.Color.White;
            this.txtOldSystemUserName.BorderColor = System.Drawing.Color.Silver;
            this.txtOldSystemUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldSystemUserName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOldSystemUserName.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOldSystemUserName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldSystemUserName.Name = "txtOldSystemUserName";
            this.txtOldSystemUserName.PasswordChar = '\0';
            this.txtOldSystemUserName.Radius = 5;
            this.txtOldSystemUserName.SelectedText = "";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.BackColor = System.Drawing.Color.DarkBlue;
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Name = "label26";
            // 
            // txtTaxCardNumber
            // 
            resources.ApplyResources(this.txtTaxCardNumber, "txtTaxCardNumber");
            this.txtTaxCardNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtTaxCardNumber.BaseColor = System.Drawing.Color.White;
            this.txtTaxCardNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtTaxCardNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaxCardNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtTaxCardNumber.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtTaxCardNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTaxCardNumber.Name = "txtTaxCardNumber";
            this.txtTaxCardNumber.PasswordChar = '\0';
            this.txtTaxCardNumber.Radius = 5;
            this.txtTaxCardNumber.SelectedText = "";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.BackColor = System.Drawing.Color.DarkBlue;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Name = "label12";
            // 
            // txtTaxRegistrationNumber
            // 
            resources.ApplyResources(this.txtTaxRegistrationNumber, "txtTaxRegistrationNumber");
            this.txtTaxRegistrationNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtTaxRegistrationNumber.BaseColor = System.Drawing.Color.White;
            this.txtTaxRegistrationNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtTaxRegistrationNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaxRegistrationNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtTaxRegistrationNumber.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtTaxRegistrationNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTaxRegistrationNumber.Name = "txtTaxRegistrationNumber";
            this.txtTaxRegistrationNumber.PasswordChar = '\0';
            this.txtTaxRegistrationNumber.Radius = 5;
            this.txtTaxRegistrationNumber.SelectedText = "";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.BackColor = System.Drawing.Color.DarkBlue;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // txtWorkersCount
            // 
            resources.ApplyResources(this.txtWorkersCount, "txtWorkersCount");
            this.txtWorkersCount.BackColor = System.Drawing.Color.Transparent;
            this.txtWorkersCount.BaseColor = System.Drawing.Color.White;
            this.txtWorkersCount.BorderColor = System.Drawing.Color.Silver;
            this.txtWorkersCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkersCount.FocusedBaseColor = System.Drawing.Color.White;
            this.txtWorkersCount.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtWorkersCount.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtWorkersCount.Name = "txtWorkersCount";
            this.txtWorkersCount.PasswordChar = '\0';
            this.txtWorkersCount.Radius = 5;
            this.txtWorkersCount.SelectedText = "";
            // 
            // txtOrganizationName
            // 
            resources.ApplyResources(this.txtOrganizationName, "txtOrganizationName");
            this.txtOrganizationName.BackColor = System.Drawing.Color.Transparent;
            this.txtOrganizationName.BaseColor = System.Drawing.Color.White;
            this.txtOrganizationName.BorderColor = System.Drawing.Color.Silver;
            this.txtOrganizationName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOrganizationName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtOrganizationName.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtOrganizationName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOrganizationName.Name = "txtOrganizationName";
            this.txtOrganizationName.PasswordChar = '\0';
            this.txtOrganizationName.Radius = 5;
            this.txtOrganizationName.SelectedText = "";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.DarkBlue;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // btnExportExcel
            // 
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(175)))), ((int)(((byte)(92)))));
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.btnExportExcel.ForeColor = System.Drawing.Color.Black;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click_1);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.BackColor = System.Drawing.Color.DarkBlue;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Controls.Add(this.btnExportExcel);
            resources.ApplyResources(this.Panel1, "Panel1");
            this.Panel1.Name = "Panel1";
            // 
            // Panel4
            // 
            resources.ApplyResources(this.Panel4, "Panel4");
            this.Panel4.Controls.Add(this.label32);
            this.Panel4.Controls.Add(this.label31);
            this.Panel4.Controls.Add(this.label30);
            this.Panel4.Controls.Add(this.label29);
            this.Panel4.Controls.Add(this.label28);
            this.Panel4.Controls.Add(this.filetext);
            this.Panel4.Controls.Add(this.txtFilePath);
            this.Panel4.Controls.Add(this.label27);
            this.Panel4.Controls.Add(this.txtActivityStartDate);
            this.Panel4.Controls.Add(this.label25);
            this.Panel4.Controls.Add(this.txtSAPPassword);
            this.Panel4.Controls.Add(this.label14);
            this.Panel4.Controls.Add(this.txtSAPUserName);
            this.Panel4.Controls.Add(this.label15);
            this.Panel4.Controls.Add(this.txtOldInvoiceEmail);
            this.Panel4.Controls.Add(this.label16);
            this.Panel4.Controls.Add(this.txtOldGOVSystemEmail);
            this.Panel4.Controls.Add(this.label17);
            this.Panel4.Controls.Add(this.txtGOVSystemPassword);
            this.Panel4.Controls.Add(this.label18);
            this.Panel4.Controls.Add(this.txtGOVSystemEmail);
            this.Panel4.Controls.Add(this.label19);
            this.Panel4.Controls.Add(this.txtInsuranceFileNumber);
            this.Panel4.Controls.Add(this.label21);
            this.Panel4.Controls.Add(this.txtFormationCode);
            this.Panel4.Controls.Add(this.label22);
            this.Panel4.Controls.Add(this.txtInvoiceEmailPassword);
            this.Panel4.Controls.Add(this.label23);
            this.Panel4.Controls.Add(this.txtOldSystemEmailPassword);
            this.Panel4.Controls.Add(this.label24);
            this.Panel4.Controls.Add(this.txtOldSystemPassword);
            this.Panel4.Controls.Add(this.txtOldSystemUserName);
            this.Panel4.Controls.Add(this.label26);
            this.Panel4.Controls.Add(this.txtTaxCardNumber);
            this.Panel4.Controls.Add(this.label12);
            this.Panel4.Controls.Add(this.txtTaxRegistrationNumber);
            this.Panel4.Controls.Add(this.label13);
            this.Panel4.Controls.Add(this.txtWorkersCount);
            this.Panel4.Controls.Add(this.label10);
            this.Panel4.Controls.Add(this.txtOrganizationName);
            this.Panel4.Controls.Add(this.label11);
            this.Panel4.Controls.Add(this.txtActivityType);
            this.Panel4.Controls.Add(this.label8);
            this.Panel4.Controls.Add(this.label9);
            this.Panel4.Controls.Add(this.txtEmail);
            this.Panel4.Controls.Add(this.label6);
            this.Panel4.Controls.Add(this.txtNationalID);
            this.Panel4.Controls.Add(this.label7);
            this.Panel4.Controls.Add(this.txtAddress);
            this.Panel4.Controls.Add(this.label4);
            this.Panel4.Controls.Add(this.txtPhoneNumber);
            this.Panel4.Controls.Add(this.label5);
            this.Panel4.Controls.Add(this.txtCustomerName);
            this.Panel4.Controls.Add(this.label2);
            this.Panel4.Controls.Add(this.txtCustomerCode);
            this.Panel4.Controls.Add(this.Label20);
            this.Panel4.Controls.Add(this.Label3);
            this.Panel4.Name = "Panel4";
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // filetext
            // 
            resources.ApplyResources(this.filetext, "filetext");
            this.filetext.Name = "filetext";
            // 
            // txtFilePath
            // 
            this.txtFilePath.AnimationHoverSpeed = 0.07F;
            this.txtFilePath.AnimationSpeed = 0.03F;
            this.txtFilePath.BaseColor = System.Drawing.Color.RoyalBlue;
            this.txtFilePath.BorderColor = System.Drawing.Color.Black;
            this.txtFilePath.CheckedBaseColor = System.Drawing.Color.Gray;
            this.txtFilePath.CheckedBorderColor = System.Drawing.Color.Black;
            this.txtFilePath.CheckedForeColor = System.Drawing.Color.White;
            this.txtFilePath.CheckedImage = ((System.Drawing.Image)(resources.GetObject("txtFilePath.CheckedImage")));
            this.txtFilePath.CheckedLineColor = System.Drawing.Color.DimGray;
            this.txtFilePath.DialogResult = System.Windows.Forms.DialogResult.None;
            this.txtFilePath.FocusedColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.ForeColor = System.Drawing.Color.White;
            this.txtFilePath.Image = ((System.Drawing.Image)(resources.GetObject("txtFilePath.Image")));
            this.txtFilePath.ImageSize = new System.Drawing.Size(20, 20);
            this.txtFilePath.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.txtFilePath.OnHoverBorderColor = System.Drawing.Color.Black;
            this.txtFilePath.OnHoverForeColor = System.Drawing.Color.White;
            this.txtFilePath.OnHoverImage = null;
            this.txtFilePath.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.txtFilePath.OnPressedColor = System.Drawing.Color.Black;
            this.txtFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFilePath.Click += new System.EventHandler(this.txtFilePath_Click);
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.BackColor = System.Drawing.Color.DarkBlue;
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Name = "label27";
            // 
            // txtActivityStartDate
            // 
            this.txtActivityStartDate.BaseColor = System.Drawing.Color.White;
            this.txtActivityStartDate.BorderColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.txtActivityStartDate, "txtActivityStartDate");
            this.txtActivityStartDate.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtActivityStartDate.ForeColor = System.Drawing.Color.Black;
            this.txtActivityStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtActivityStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtActivityStartDate.Name = "txtActivityStartDate";
            this.txtActivityStartDate.OnHoverBaseColor = System.Drawing.Color.White;
            this.txtActivityStartDate.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtActivityStartDate.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtActivityStartDate.OnPressedColor = System.Drawing.Color.Black;
            this.txtActivityStartDate.Value = new System.DateTime(2024, 12, 22, 13, 56, 26, 232);
            this.txtActivityStartDate.ValueChanged += new System.EventHandler(this.txtActivityStartDate_ValueChanged);
            // 
            // txtActivityType
            // 
            resources.ApplyResources(this.txtActivityType, "txtActivityType");
            this.txtActivityType.BackColor = System.Drawing.Color.Transparent;
            this.txtActivityType.BaseColor = System.Drawing.Color.White;
            this.txtActivityType.BorderColor = System.Drawing.Color.Silver;
            this.txtActivityType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActivityType.FocusedBaseColor = System.Drawing.Color.White;
            this.txtActivityType.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtActivityType.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtActivityType.Name = "txtActivityType";
            this.txtActivityType.PasswordChar = '\0';
            this.txtActivityType.Radius = 5;
            this.txtActivityType.SelectedText = "";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.DarkBlue;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.DarkBlue;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmail.BaseColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.Silver;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.FocusedBaseColor = System.Drawing.Color.White;
            this.txtEmail.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtEmail.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.Radius = 5;
            this.txtEmail.SelectedText = "";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.DarkBlue;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // txtNationalID
            // 
            resources.ApplyResources(this.txtNationalID, "txtNationalID");
            this.txtNationalID.BackColor = System.Drawing.Color.Transparent;
            this.txtNationalID.BaseColor = System.Drawing.Color.White;
            this.txtNationalID.BorderColor = System.Drawing.Color.Silver;
            this.txtNationalID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNationalID.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNationalID.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtNationalID.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.PasswordChar = '\0';
            this.txtNationalID.Radius = 5;
            this.txtNationalID.SelectedText = "";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.DarkBlue;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // txtAddress
            // 
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BaseColor = System.Drawing.Color.White;
            this.txtAddress.BorderColor = System.Drawing.Color.Silver;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.FocusedBaseColor = System.Drawing.Color.White;
            this.txtAddress.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtAddress.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.Radius = 5;
            this.txtAddress.SelectedText = "";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.DarkBlue;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // txtPhoneNumber
            // 
            resources.ApplyResources(this.txtPhoneNumber, "txtPhoneNumber");
            this.txtPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtPhoneNumber.BaseColor = System.Drawing.Color.White;
            this.txtPhoneNumber.BorderColor = System.Drawing.Color.Silver;
            this.txtPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNumber.FocusedBaseColor = System.Drawing.Color.White;
            this.txtPhoneNumber.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtPhoneNumber.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PasswordChar = '\0';
            this.txtPhoneNumber.Radius = 5;
            this.txtPhoneNumber.SelectedText = "";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.DarkBlue;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // txtCustomerName
            // 
            resources.ApplyResources(this.txtCustomerName, "txtCustomerName");
            this.txtCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomerName.BaseColor = System.Drawing.Color.White;
            this.txtCustomerName.BorderColor = System.Drawing.Color.Silver;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCustomerName.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtCustomerName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PasswordChar = '\0';
            this.txtCustomerName.Radius = 5;
            this.txtCustomerName.SelectedText = "";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.DarkBlue;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // txtCustomerCode
            // 
            resources.ApplyResources(this.txtCustomerCode, "txtCustomerCode");
            this.txtCustomerCode.BackColor = System.Drawing.Color.Transparent;
            this.txtCustomerCode.BaseColor = System.Drawing.Color.White;
            this.txtCustomerCode.BorderColor = System.Drawing.Color.Silver;
            this.txtCustomerCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerCode.FocusedBaseColor = System.Drawing.Color.White;
            this.txtCustomerCode.FocusedBorderColor = System.Drawing.Color.DarkBlue;
            this.txtCustomerCode.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.PasswordChar = '\0';
            this.txtCustomerCode.Radius = 5;
            this.txtCustomerCode.ReadOnly = true;
            this.txtCustomerCode.SelectedText = "";
            // 
            // Label20
            // 
            resources.ApplyResources(this.Label20, "Label20");
            this.Label20.ForeColor = System.Drawing.Color.Red;
            this.Label20.Name = "Label20";
            // 
            // Label3
            // 
            resources.ApplyResources(this.Label3, "Label3");
            this.Label3.BackColor = System.Drawing.Color.DarkBlue;
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Name = "Label3";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.ForeColor = System.Drawing.Color.Red;
            this.label29.Name = "label29";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.ForeColor = System.Drawing.Color.Red;
            this.label30.Name = "label30";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.ForeColor = System.Drawing.Color.Red;
            this.label31.Name = "label31";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.ForeColor = System.Drawing.Color.Red;
            this.label32.Name = "label32";
            // 
            // Customer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Panel1);
            this.Name = "Customer";
            this.Load += new System.EventHandler(this.Products_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Products_KeyDown);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label label25;
        public Guna.UI.WinForms.GunaTextBox txtSAPPassword;
        internal System.Windows.Forms.Label label14;
        public Guna.UI.WinForms.GunaTextBox txtSAPUserName;
        internal System.Windows.Forms.Label label15;
        public Guna.UI.WinForms.GunaTextBox txtOldInvoiceEmail;
        internal System.Windows.Forms.Label label16;
        public Guna.UI.WinForms.GunaTextBox txtOldGOVSystemEmail;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblSet;
        internal System.Windows.Forms.TextBox txtBCode;
        internal System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.Label lblUserType;
        internal System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label label17;
        public Guna.UI.WinForms.GunaTextBox txtGOVSystemPassword;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.Button btnUpdate;
        public Guna.UI.WinForms.GunaTextBox txtGOVSystemEmail;
        public Guna.UI.WinForms.GunaTextBox txtInsuranceFileNumber;
        internal System.Windows.Forms.Label label21;
        public Guna.UI.WinForms.GunaTextBox txtFormationCode;
        internal System.Windows.Forms.Label label22;
        public Guna.UI.WinForms.GunaTextBox txtInvoiceEmailPassword;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Button btnGetData;
        public Guna.UI.WinForms.GunaTextBox txtOldSystemEmailPassword;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Label label24;
        public Guna.UI.WinForms.GunaTextBox txtOldSystemPassword;
        public Guna.UI.WinForms.GunaTextBox txtOldSystemUserName;
        internal System.Windows.Forms.Label label26;
        public Guna.UI.WinForms.GunaTextBox txtTaxCardNumber;
        internal System.Windows.Forms.Label label12;
        public Guna.UI.WinForms.GunaTextBox txtTaxRegistrationNumber;
        internal System.Windows.Forms.Label label13;
        public Guna.UI.WinForms.GunaTextBox txtWorkersCount;
        public Guna.UI.WinForms.GunaTextBox txtOrganizationName;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button btnExportExcel;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel4;
        public Guna.UI.WinForms.GunaTextBox txtActivityType;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        public Guna.UI.WinForms.GunaTextBox txtEmail;
        internal System.Windows.Forms.Label label6;
        public Guna.UI.WinForms.GunaTextBox txtNationalID;
        internal System.Windows.Forms.Label label7;
        public Guna.UI.WinForms.GunaTextBox txtAddress;
        internal System.Windows.Forms.Label label4;
        public Guna.UI.WinForms.GunaTextBox txtPhoneNumber;
        internal System.Windows.Forms.Label label5;
        public Guna.UI.WinForms.GunaTextBox txtCustomerName;
        internal System.Windows.Forms.Label label2;
        public Guna.UI.WinForms.GunaTextBox txtCustomerCode;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label20;
        public Guna.UI.WinForms.GunaDateTimePicker txtActivityStartDate;
        internal System.Windows.Forms.Label label27;
        private Guna.UI.WinForms.GunaAdvenceButton txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.Label filetext;
        private System.Windows.Forms.Label label28;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.Label label30;
        internal System.Windows.Forms.Label label29;
    }
}