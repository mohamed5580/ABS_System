using Microsoft.VisualBasic;
using Pharmacy.DL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ZXing;
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class Customer : Form
    {
        SqlConnection cn = new SqlConnection(DataAccessLayer.Con());
        public static Customer instance;

        public Customer()
        {

            InitializeComponent();
            base.Load += Products_Load;
            this.KeyDown += new KeyEventHandler(Products_KeyDown);

            instance = this;
        }




        private void Products_Load(object sender, EventArgs e)
        {
            auto();
            Getdata();



        }
        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }
        // Install-Package Microsoft.VisualBasic
        public void Getdata11()
        {


            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = "Select PID, RTRIM(ProductCode), RTRIM(Productname), SubCategoryID, RTRIM(CategoryName), RTRIM(SubCategoryName), RTRIM(Description), CostPrice, SellingPrice, Discount, VAT, ReorderPoint, RTRIM(Barcode), OpeningStock from Category, SubCategory, Product where Category.CategoryName = SubCategory.Category and Product.SubCategoryID = SubCategory.ID order by ProductCode";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private string GenerateID()
        {
            string value = "0000";
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                try
                {
                    // Fetch the latest ID from the database
                    con.Open();
                    string sql = $"SELECT ISNULL(MAX(CustomerID), 0)   FROM Customers ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.HasRows)
                        {
                            rdr.Read();
                            value = rdr[0].ToString();
                        }
                    }
                    // we need to replace them. If necessary.
                    if (Convert.ToDouble(value) <= 9) // Value is between 0 and 10
                    {
                        value = "000" + value;
                    }
                    else if (Convert.ToDouble(value) <= 99) // Value is between 9 and 100
                    {
                        value = "00" + value;
                    }
                    else if (Convert.ToDouble(value) <= 999) // Value is between 999 and 1000
                    {
                        value = "0" + value;
                    }
                    // Increase the ID by 1
                    int numericValue = int.Parse(value);
                    numericValue += 1;
                    value = numericValue.ToString("D4"); // Ensure the string is padded with leading zeros if necessary
                }
                catch (Exception ex)
                {
                    // If an error occurs, set the value to "0000"
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    value = "0000";
                }
            }
            return value;
        }
        public void auto()
        {
            try
            {
                // Assuming txtID and txtInvoiceNo are on your form.
                // Use CustomerID as the ID for the Customer table.
                txtID.Text = GenerateID();

                // Since we want Invoice Number to be "Inv-XXXX", I can use CustomerID to get the same ID.
                txtCustomerCode.Text = "C-" + GenerateID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtOpeningStock_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            // e.Handled = True
            // End If
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }



        // Button1 Click event to show frmSalesLocations
        private void Button1_Click(object sender, EventArgs e)
        {
            // Me.Hide()
            // Dim frm As New frmSalesLocations
            // frm.lblSet.Text = "Product Entry"
            // frm.Reset()
        }

        // Button2 Click event to generate and set a new barcode


        // Button4 Click event to show frmCategory
        private void Button4_Click(object sender, EventArgs e)
        {

        }

        // Button3 Click event to show frmSubCategory
        private void Button3_Click(object sender, EventArgs e)
        {
            /*            frmSubCategory.lblUser.Text = lblUser.Text;
                        frmSubCategory.Reset();
                        frmSubCategory.ShowDialog();*/
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }



        // Button5 Click event to show frmProductRecord
        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            SubCategory subc = new SubCategory();
            subc.Show();
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            Category category = new Category();
            category.lblUser.Text = lblUser.Text;

            category.Show();

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {


            Reset();
        }
        public static void LogFunc(string st1, string st2)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cb = "INSERT INTO Logs(UserID, Date, Operation) VALUES (@d1, @d2, @d3)";
                using (var cmd = new SqlCommand(cb, con))
                {
                    cmd.Parameters.AddWithValue("@d1", st1);
                    cmd.Parameters.AddWithValue("@d2", DateTime.Now);
                    cmd.Parameters.AddWithValue("@d3", st2);
                    cmd.ExecuteReader();
                }
            }
        }



        private void btnNew_Click_1(object sender, EventArgs e)
        {
            FileSystem.Reset();
            Reset();
        }



        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
        }


        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل أنت متأكد أنك تريد حذف سجل هذا الصنف?", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteRecord();
                    // Optionally refresh records here
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();
        }

        private void DeleteRecord()
        {

        }


        private void btnGetData_Click(object sender, EventArgs e)
        {
            EmployeeScreen ps = new EmployeeScreen();
            ps.lblSet.Text = "Product Entry";
            ps.Show();
        }
        private void Fill()
        {

        }

        public void Getdata()
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Button6_Click_1(object sender, EventArgs e)
        {
        }
        private void TextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)8)
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }


        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void Browse_Click(object sender, EventArgs e)
        {
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
        }
        public void ExportExcel(DataGridView dataGridView)
        {
            int rowsTotal, colsTotal;
            int I, j, iC;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView.RowCount;
                colsTotal = dataGridView.Columns.Count - 3;

                excelWorksheet.Cells.Select();
                excelWorksheet.Cells.Delete();

                for (iC = 0; iC <= colsTotal; iC++)
                {
                    excelWorksheet.Cells[1, iC + 1].Value = dataGridView.Columns[iC].HeaderText;
                }

                for (I = 0; I < rowsTotal; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        excelWorksheet.Cells[I + 2, j + 1].Value = dataGridView.Rows[I].Cells[j].Value;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                xlApp = null;
            }
        }


        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
        }

        private void Button5_Click_1(object sender, EventArgs e)
        {
            EmployeeScreen ps = new EmployeeScreen();
            ps.lblSet.Text = "Product Entry";
            /*            ps.FormClosed += (s, args) => this.Show(); // Show Product form when ProductsScreen is closed
            */
            ps.Show();

        }
        private void OpenProductsScreen()
        {
            EmployeeScreen frmProductsScreen = new EmployeeScreen();
            frmProductsScreen.FormClosed += (s, args) => this.Show(); // Show Product form when ProductsScreen is closed
            this.Hide(); // Hide the Product form
            frmProductsScreen.Show(); // Show the ProductsScreen form
        }



        private void dtpManufacturingDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
        }

        // Method to calculate the checksum digit for UPC-A
        private int CalculateUPCAChecksum(string barcodeWithoutChecksum)
        {
            int sumOdd = 0;
            int sumEven = 0;

            for (int i = 0; i < barcodeWithoutChecksum.Length; i++)
            {
                int digit = int.Parse(barcodeWithoutChecksum[i].ToString());
                if (i % 2 == 0) // Odd positions (0-based index)
                {
                    sumOdd += digit * 3;
                }
                else // Even positions
                {
                    sumEven += digit;
                }
            }

            int totalSum = sumOdd + sumEven;
            int checksum = (10 - (totalSum % 10)) % 10; // Calculate checksum digit

            return checksum;
        }


        private void Label18_Click(object sender, EventArgs e)
        {

        }

        private void txtOpeningStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Picture_Click(object sender, EventArgs e)
        {

        }

        private void BRemove_Click(object sender, EventArgs e)
        {
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dgw_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBarcode_Click(object sender, EventArgs e)
        {

        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            // Generate barcode text
            string generatedID = GenerateID();
            string barcodeWithoutChecksum = (10000000000 + int.Parse(generatedID)).ToString(); // 8 digits
            /*
                        // Ensure we have 11 digits first (add leading zeros if necessary)
                        while (barcodeWithoutChecksum.Length < 11)
                        {
                            barcodeWithoutChecksum =   barcodeWithoutChecksum+ "0";
                        }*/

            // Calculate the checksum digit
            int checksum = CalculateUPCAChecksum(barcodeWithoutChecksum);
            string fullBarcode = barcodeWithoutChecksum + checksum.ToString(); // 12 digits


            // Ensure the barcode text is valid for the specified format
            if (fullBarcode.Length >= 12)
            {
                BarcodeWriter barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.UPC_A // Specify the correct barcode format
                };
            }
            else
            {
                MessageBox.Show("Invalid barcode length. UPC-A barcodes must be 12 digits long.");
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the "ding" sound on Enter key press
                e.SuppressKeyPress = true;

                // Call the save button click event
                btnSave_Click_1(sender, e);
            }
        }

        private void txtOpeningStock_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("الرجاء كتابة عنوان العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNationalID.Text))
            {
                MessageBox.Show("الرجاء كتابة الرقم القومي", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalID.Focus();
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string sql = @"
                INSERT INTO Customers 
                (
                    OldSystemUserName,
                    OldSystemPassword,
                    OldSystemEmailPassword,
                    InvoiceEmailPassword,
                    FormationCode,
                    InsuranceFileNumber,
                    GOVSystemEmail,
                    GOVSystemPassword,
                    OldGOVSystemEmail,
                    OldInvoiceEmail,
                    SAPUserName,
                    SAPPassword,
                    CustomerCode,
                    CustomerName,
                    PhoneNumber,
                    Address,
                    NationalID,
                    Email,
                    ActivityStartDate,
                    ActivityType,
                    OrganizationName,
                    WorkersCount,
                    TaxRegistrationNumber,
                    TaxCardNumber,
                    FileUpload

                    )
                VALUES
                (
                   @OldSystemUserName,
                    @OldSystemPassword,
                    @OldSystemEmailPassword,
                    @InvoiceEmailPassword,
                    @FormationCode,
                    @InsuranceFileNumber,
                    @GOVSystemEmail,
                    @GOVSystemPassword,
                    @OldGOVSystemEmail,
                    @OldInvoiceEmail,
                    @SAPUserName,
                    @SAPPassword,
                    @CustomerCode,
                    @CustomerName,
                    @PhoneNumber,
                    @Address,
                    @NationalID,
                    @Email,
                    @ActivityStartDate,
                    @ActivityType,
                    @OrganizationName,
                    @WorkersCount,
                    @TaxRegistrationNumber,
                    @TaxCardNumber,
                    @FileUpload
                );
            ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add Parameters to avoid SQL injection and ensure correct data types.
                        command.Parameters.AddWithValue("@OldSystemUserName", txtOldSystemUserName.Text);
                        command.Parameters.AddWithValue("@OldSystemPassword", txtOldSystemPassword.Text);
                        command.Parameters.AddWithValue("@OldSystemEmailPassword", txtOldSystemEmailPassword.Text);
                        command.Parameters.AddWithValue("@InvoiceEmailPassword", txtInvoiceEmailPassword.Text);
                        command.Parameters.AddWithValue("@FormationCode", txtFormationCode.Text);
                        command.Parameters.AddWithValue("@InsuranceFileNumber", txtInsuranceFileNumber.Text);
                        command.Parameters.AddWithValue("@GOVSystemEmail", txtGOVSystemEmail.Text);
                        command.Parameters.AddWithValue("@GOVSystemPassword", txtGOVSystemPassword.Text);
                        command.Parameters.AddWithValue("@OldGOVSystemEmail", txtOldGOVSystemEmail.Text);
                        command.Parameters.AddWithValue("@OldInvoiceEmail", txtOldInvoiceEmail.Text);
                        command.Parameters.AddWithValue("@SAPUserName", txtSAPUserName.Text);
                        command.Parameters.AddWithValue("@SAPPassword", txtSAPPassword.Text);
                        command.Parameters.AddWithValue("@CustomerCode", txtCustomerCode.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@NationalID", txtNationalID.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);

                        // Handle ActivityStartDate
                        DateTime activityStartDate;
                        if (DateTime.TryParse(txtActivityStartDate.Text, out activityStartDate))
                        {
                            command.Parameters.AddWithValue("@ActivityStartDate", activityStartDate);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ActivityStartDate", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@ActivityType", txtActivityType.Text);
                        command.Parameters.AddWithValue("@OrganizationName", txtOrganizationName.Text);

                        // Handle WorkersCount
                        int workersCount;
                        if (int.TryParse(txtWorkersCount.Text, out workersCount))
                        {
                            command.Parameters.AddWithValue("@WorkersCount", workersCount);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@WorkersCount", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@TaxRegistrationNumber", txtTaxRegistrationNumber.Text);
                        command.Parameters.AddWithValue("@TaxCardNumber", txtTaxCardNumber.Text);
                        // Handle FileUpload
                        // Handle FileUpload
                        byte[] fileBytes = null;

                        // Check if the user provided a valid file path and if the file exists
                        if (!string.IsNullOrEmpty(filetext.Text) && File.Exists(filetext.Text))
                        {
                            fileBytes = File.ReadAllBytes(filetext.Text);
                        }

                        // Add parameter to the command with explicit SqlDbType
                        SqlParameter fileUploadParam = new SqlParameter("@FileUpload", SqlDbType.VarBinary);
                        fileUploadParam.Value = fileBytes ?? (object)DBNull.Value;
                        command.Parameters.Add(fileUploadParam);


                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reset()
        {
            // Reset all the TextBoxes, you need to set the name based on your design

            txtOldSystemUserName.Text = "";
            txtOldSystemPassword.Text = "";
            txtOldSystemEmailPassword.Text = "";
            txtInvoiceEmailPassword.Text = "";
            txtFormationCode.Text = "";
            txtInsuranceFileNumber.Text = "";
            txtGOVSystemEmail.Text = "";
            txtGOVSystemPassword.Text = "";
            txtOldGOVSystemEmail.Text = "";
            txtOldInvoiceEmail.Text = "";
            txtSAPUserName.Text = "";
            txtSAPPassword.Text = "";

            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtNationalID.Text = "";
            txtEmail.Text = "";
            txtActivityStartDate.Text = "";
            txtActivityType.Text = "";
            txtOrganizationName.Text = "";
            txtWorkersCount.Text = "";
            txtTaxRegistrationNumber.Text = "";
            txtTaxCardNumber.Text = "";
            txtCustomerCode.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnExportExcel.Enabled = false;
            auto();
        }

        public void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerId; // Added to hold parsed CustomerID
                            // Check if txtID is a valid number
            if (!int.TryParse(txtID.Text, out customerId) || customerId <= 0)
            {
                MessageBox.Show("الرجاء كتابة كود العميل", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("الرجاء كتابة عنوان العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNationalID.Text))
            {
                MessageBox.Show("الرجاء كتابة الرقم القومي", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalID.Focus();
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string sql = @"
                      UPDATE Customers
                      SET
                      OldSystemUserName = @OldSystemUserName,
                      OldSystemPassword = @OldSystemPassword,
                      OldSystemEmailPassword = @OldSystemEmailPassword,
                      InvoiceEmailPassword = @InvoiceEmailPassword,
                      FormationCode = @FormationCode,
                      InsuranceFileNumber = @InsuranceFileNumber,
                      GOVSystemEmail = @GOVSystemEmail,
                      GOVSystemPassword = @GOVSystemPassword,
                      OldGOVSystemEmail = @OldGOVSystemEmail,
                      OldInvoiceEmail = @OldInvoiceEmail,
                      SAPUserName = @SAPUserName,
                      SAPPassword = @SAPPassword,
                      CustomerCode = @CustomerCode,
                      CustomerName = @CustomerName,
                      PhoneNumber = @PhoneNumber,
                      Address = @Address,
                      NationalID = @NationalID,
                      Email = @Email,
                      ActivityStartDate = @ActivityStartDate,
                      ActivityType = @ActivityType,
                      OrganizationName = @OrganizationName,
                      WorkersCount = @WorkersCount,
                      TaxRegistrationNumber = @TaxRegistrationNumber,
                      TaxCardNumber = @TaxCardNumber
                      WHERE CustomerID = @CustomerID
                   ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add Parameters to avoid SQL injection and ensure correct data types.
                        command.Parameters.AddWithValue("@OldSystemUserName", txtOldSystemUserName.Text);
                        command.Parameters.AddWithValue("@OldSystemPassword", txtOldSystemPassword.Text);
                        command.Parameters.AddWithValue("@OldSystemEmailPassword", txtOldSystemEmailPassword.Text);
                        command.Parameters.AddWithValue("@InvoiceEmailPassword", txtInvoiceEmailPassword.Text);
                        command.Parameters.AddWithValue("@FormationCode", txtFormationCode.Text);
                        command.Parameters.AddWithValue("@InsuranceFileNumber", txtInsuranceFileNumber.Text);
                        command.Parameters.AddWithValue("@GOVSystemEmail", txtGOVSystemEmail.Text);
                        command.Parameters.AddWithValue("@GOVSystemPassword", txtGOVSystemPassword.Text);
                        command.Parameters.AddWithValue("@OldGOVSystemEmail", txtOldGOVSystemEmail.Text);
                        command.Parameters.AddWithValue("@OldInvoiceEmail", txtOldInvoiceEmail.Text);
                        command.Parameters.AddWithValue("@SAPUserName", txtSAPUserName.Text);
                        command.Parameters.AddWithValue("@SAPPassword", txtSAPPassword.Text);
                        command.Parameters.AddWithValue("@CustomerCode", txtCustomerCode.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@NationalID", txtNationalID.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);

                        //Handle Activity StartDate
                        DateTime activityStartDate;
                        if (DateTime.TryParse(txtActivityStartDate.Text, out activityStartDate))
                        {
                            command.Parameters.AddWithValue("@ActivityStartDate", activityStartDate);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ActivityStartDate", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@ActivityType", txtActivityType.Text);
                        command.Parameters.AddWithValue("@OrganizationName", txtOrganizationName.Text);

                        //Handle Worker Count
                        int workersCount;
                        if (int.TryParse(txtWorkersCount.Text, out workersCount))
                        {
                            command.Parameters.AddWithValue("@WorkersCount", workersCount);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@WorkersCount", DBNull.Value);
                        }

                        command.Parameters.AddWithValue("@TaxRegistrationNumber", txtTaxRegistrationNumber.Text);
                        command.Parameters.AddWithValue("@TaxCardNumber", txtTaxCardNumber.Text);

                        command.Parameters.AddWithValue("@CustomerID", customerId); //Use parsed id


                        command.ExecuteNonQuery();

                    }

                    MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(txtID.Text) <= 0)
            {
                MessageBox.Show("Please, load a customer record to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", txtID.Text);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Label20_Click(object sender, EventArgs e)
        {

        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {

        }

        private void txtActivityStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtFilePath_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filetext.Text = openFileDialog.FileName;
            }
        }

        private void btnGetData_Click_1(object sender, EventArgs e)
        {
            CustomerList customerList = new CustomerList();
            customerList.Show();
        }
    }
}
