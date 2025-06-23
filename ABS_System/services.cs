using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pharmacy.DL;
using System.Net.Mail;
using System.Net;

namespace Accounting_System
{
    public partial class services : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public static services instance;
        public services()
        {
            InitializeComponent();
            txtUpfront.KeyPress += new KeyPressEventHandler(txtChargesQuote_KeyPress);
            txtTotalPayment.KeyPress += new KeyPressEventHandler(txtChargesQuote_KeyPress);
            
            txtChargesQuote.KeyPress += new KeyPressEventHandler(txtChargesQuote_KeyPress_1);
            instance = this;
        }
        private void services_Load(object sender, EventArgs e)
        {
            auto();
            fillCategory();


        }
        public void auto()
        {
            try
            {
                // Assuming txtID and txtInvoiceNo are on your form.
                // Use CustomerID as the ID for the Customer table.
                txtID.Text = GenerateID();

                // Since we want Invoice Number to be "Inv-XXXX", I can use CustomerID to get the same ID.
                txtServiceCode.Text = "S-" + GenerateID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GroupBox4_Enter(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtChargesQuote.Text = "";
            txtCID.Text = "";
            txtCustomerID.Text = "";
            textBox1.Text = "";
            txtUpfront.Text = "";
            auto();
            txtEID.Text = ""; 
            txtEmployeeID.Text = ""; 
            txtEmployeeName.Text = ""; 
            cmbCategory.SelectedIndex = -1;
            cmbSubCategory.SelectedIndex = -1;
            dtpServiceCreationDate.Value = DateTime.Today;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
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
                    string sql = $"SELECT ISNULL(MAX(ServiceID), 0) FROM Services ";
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


        
      /*  private void Print()
        {
            try
            {

                frmReport frmReport = new frmReport();
                var rpt = new rptServiceReceipt(); // The report you created.
                using (SqlConnection myConnection = new SqlConnection(DataAccessLayer.Con()))
                {
                    SqlCommand MyCommand = new SqlCommand();
                    SqlCommand MyCommand1 = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    SqlDataAdapter myDA1 = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); // The DataSet you created.

                    MyCommand.Connection = myConnection;
                    MyCommand1.Connection = myConnection;

                    MyCommand.CommandText = @"SELECT Service.S_ID, Service.ServiceCode, Service.ServiceType, 
                                      Service.ServiceCreationDate, Service.ItemDescription, 
                                      Service.ProblemDescription, Service.ChargesQuote, Service.AdvanceDeposit, 
                                      Service.EstimatedRepairDate, Service.Remarks, Service.Status, 
                                      Customer.ID, Customer.Name, Customer.Gender, Customer.Address, 
                                      Customer.City, Customer.State, Customer.ZipCode, Customer.ContactNo, 
                                      Customer.EmailID, Customer.Remarks AS Expr2, Customer.Photo 
                                      FROM Service 
                                      INNER JOIN Customer ON Service.CustomerID = Customer.ID 
                                      WHERE Service.ServiceCode = @d1";

                    MyCommand.Parameters.AddWithValue("@d1", txtServiceCode.Text);

                    MyCommand1.CommandText = "SELECT * FROM Company";

                    MyCommand.CommandType = CommandType.Text;
                    MyCommand1.CommandType = CommandType.Text;

                    myDA.SelectCommand = MyCommand;
                    myDA1.SelectCommand = MyCommand1;

                    myDA.Fill(myDS, "Service");
                    myDA.Fill(myDS, "Customer");
                    myDA1.Fill(myDS, "Company");

                    rpt.SetDataSource(myDS);
                    rpt.SetParameterValue("p1", txtCustomerID.Text);
                    rpt.SetParameterValue("p2", DateTime.Today);

                    frmReport.crystalReportViewer1.ReportSource = rpt;
                    frmReport.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
*/        private void DeleteRecord()
        {
            // Ensure ServiceID is provided
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    // Delete query
                    string deleteQuery = "DELETE FROM Services WHERE ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", txtID.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No record found with the given ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }

                LedgerDelete(txtServiceCode.Text, "دفعات خدمه");
                LedgerDelete(txtServiceCode.Text, "خدمة");

                // Clear the form fields after deletion
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public static void LogFunc(string st1, string st2)
        {
            using (SqlConnection con = DataAccessLayer.cn)
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
      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DeleteRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(txtChargesQuote.Text))
            {
                MessageBox.Show("الرجاء كتابة رسوم الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChargesQuote.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUpfront.Text))
            {
                MessageBox.Show("الرجاء كتابة اتعاب الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textMPay.Text))
            {
                MessageBox.Show("الرجاء اختيار طريقة الدفع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("الرجاء كتابة الخدمه الرئيسية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      
            try
            {
              

                // Insert into Services table
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string cb = "INSERT INTO Services (InvoiceNumber, InvoiceDate, CustomerID, SubService, AssignedEmployee, Fees, Charges, Total, PaidAmount, RemainingAmount, PaymentMethod, PaymentDate, EmployeID,CustomerCode,CustomerName,EmployeCode,EmployeName) " +
                                "VALUES (@InvoiceNumber, @InvoiceDate, @CustomerID, @SubService, @AssignedEmployee, @Fees, @Charges, @Total, @PaidAmount, @RemainingAmount, @PaymentMethod, @PaymentDate, @EmployeID,@CustomerCode,@CustomerName,@EmployeCode,@EmployeName)";
                    using (SqlCommand cmd = new SqlCommand(cb, con))
                    {
                        cmd.Parameters.AddWithValue("@InvoiceNumber", txtServiceCode.Text);
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(txtCID.Text));
                        cmd.Parameters.AddWithValue("@SubService", Convert.ToInt32(txtSubCategoryID.Text));
                        cmd.Parameters.AddWithValue("@AssignedEmployee", txtEID.Text);
                        cmd.Parameters.AddWithValue("@Fees", Convert.ToDecimal(txtChargesQuote.Text));
                        cmd.Parameters.AddWithValue("@Charges", Convert.ToDecimal(txtUpfront.Text));
                        cmd.Parameters.AddWithValue("@Total", Convert.ToDecimal(txtGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", Convert.ToDecimal(txtTotalPayment.Text));
                        cmd.Parameters.AddWithValue("@RemainingAmount", Convert.ToDecimal(txtPaymentDue.Text));
                        cmd.Parameters.AddWithValue("@PaymentMethod", textMPay.Text);
                        cmd.Parameters.AddWithValue("@PaymentDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EmployeID", Convert.ToInt32(txtEID.Text));
                        cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerID.Text);
                        cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cmd.Parameters.AddWithValue("@EmployeCode", txtEmployeeID.Text);
                        cmd.Parameters.AddWithValue("@EmployeName", txtEmployeeName.Text);

                        cmd.ExecuteNonQuery();
                    }
                }


                if (textMPay.SelectedIndex == 3)
                {
                    LedgerSave(dateTimePicker2.Value.Date, "اجل", txtServiceCode.Text, "خدمة", Math.Abs(Convert.ToDecimal(txtGrandTotal.Text)), Math.Abs(Convert.ToDecimal(txtTotalPayment.Text)), txtCID.Text, "");
                }
                else
                {
                    LedgerSave(dateTimePicker2.Value.Date, "نقدا", txtServiceCode.Text, "خدمة", Math.Abs(Convert.ToDecimal(txtGrandTotal.Text)), Math.Abs(Convert.ToDecimal(txtTotalPayment.Text)), txtCID.Text, "");
                }

                // Disable save button and reset form
                btnSave.Enabled = false;
                MessageBox.Show("Service created successfully", "Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = DataAccessLayer.Con();
            // Input validation
            if (string.IsNullOrWhiteSpace(txtChargesQuote.Text))
            {
                MessageBox.Show("الرجاء كتابة رسوم الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChargesQuote.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUpfront.Text))
            {
                MessageBox.Show("الرجاء كتابة اتعاب الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textMPay.Text))
            {
                MessageBox.Show("الرجاء اختيار طريقة الدفع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("الرجاء كتابة الخدمه الرئيسية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateQuery = @"
                UPDATE Services 
                SET 
                    InvoiceNumber = @InvoiceNumber,
                    InvoiceDate = @InvoiceDate,
                    CustomerID = @CustomerID,
                    SubService = @SubService,
                    AssignedEmployee = @AssignedEmployee,
                    Fees = @Fees,
                    Charges = @Charges,
                    Total = @Total,
                    PaidAmount = @PaidAmount,
                    RemainingAmount = @RemainingAmount,
                    PaymentMethod = @PaymentMethod,
                    PaymentDate = @PaymentDate,
                    EmployeID = @EmployeID,
                    CustomerCode = @CustomerCode,
                    CustomerName = @CustomerName,
                    EmployeCode = @EmployeCode,
                    EmployeName = @EmployeName
                WHERE 
                    ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        // Parameters mapping
                        cmd.Parameters.AddWithValue("@ServiceID", (txtID.Text));
                        cmd.Parameters.AddWithValue("@InvoiceNumber", txtServiceCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@CustomerID", (txtCID.Text));
                        cmd.Parameters.AddWithValue("@SubService", (txtSubCategoryID.Text));
                        cmd.Parameters.AddWithValue("@AssignedEmployee", txtEID.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fees", (txtChargesQuote.Text));
                        cmd.Parameters.AddWithValue("@Charges", (txtUpfront.Text));
                        cmd.Parameters.AddWithValue("@Total", (txtGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", (txtTotalPayment.Text));
                        cmd.Parameters.AddWithValue("@RemainingAmount", (txtPaymentDue.Text));
                        cmd.Parameters.AddWithValue("@PaymentMethod", textMPay.Text.Trim());
                        cmd.Parameters.AddWithValue("@PaymentDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EmployeID", (txtEID.Text));
                        cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerID.Text.Trim());
                        cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeCode", txtEmployeeID.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeName", txtEmployeeName.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                if (textMPay.SelectedIndex == 3)
                {

                    LedgerUpdate(dateTimePicker2.Value.Date, "اجل", Math.Abs(Convert.ToDecimal(txtGrandTotal.Text)), Math.Abs(Convert.ToDecimal(txtTotalPayment.Text)), txtCID.Text, txtServiceCode.Text, "دفعة خدمة");


                }
                else if (textMPay.SelectedIndex == 1)
                {

                    LedgerUpdate(dateTimePicker2.Value.Date, "فودافون كاش", Math.Abs(Convert.ToDecimal(txtGrandTotal.Text)), Math.Abs(Convert.ToDecimal(txtTotalPayment.Text)), txtCID.Text, txtServiceCode.Text, "دفعة خدمة");


                }
                else
                {
                    LedgerUpdate(dateTimePicker2.Value.Date, "نقدا", Math.Abs(Convert.ToDecimal(txtGrandTotal.Text)), Math.Abs(Convert.ToDecimal(txtTotalPayment.Text)), txtCID.Text, txtServiceCode.Text, "دفعه خدمة");
                }

                MessageBox.Show("تم التعديل بنجاح", "خدمات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في المدخلات" +ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                Reset();
        }

        private int ValidateNumeric(string input)
        {
            return int.TryParse(input, out int result) ? result : 0;
        }

        private decimal ValidateDecimal(string input)
        {
            return decimal.TryParse(input, out decimal result) ? result : 0;
        }

      
        private void btnGetData_Click(object sender, EventArgs e)
        {
            servicesRecord frmServicesRecord = new servicesRecord();
            frmServicesRecord.lblSet.Text = "Services";
            frmServicesRecord.Show();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Print();
        }
        private void txtChargesQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            if (char.IsControl(keyChar))
            {
                // Allow all control characters.
            }
            else if (char.IsDigit(keyChar) || keyChar == '.')
            {
                string text = this.txtUpfront.Text;
                int selectionStart = this.txtUpfront.SelectionStart;
                int selectionLength = this.txtUpfront.SelectionLength;

                text = text.Substring(0, selectionStart) + keyChar + text.Substring(selectionStart + selectionLength);

                if (int.TryParse(text, out _) && text.Length > 16)
                {
                    // Reject an integer that is longer than 16 digits.
                    e.Handled = true;
                }
                else if (double.TryParse(text, out _) && text.IndexOf('.') < text.Length - 3)
                {
                    // Reject a real number with too many decimal places.
                    e.Handled = false;
                }
            }
            else
            {
                // Reject all other characters.
                e.Handled = true;
            }
            
        }
        private void txtChargesQuote_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            if (char.IsControl(keyChar))
            {
                // Allow all control characters.
            }
            else if (char.IsDigit(keyChar) || keyChar == '.')
            {
                string text = this.txtChargesQuote.Text;
                int selectionStart = this.txtChargesQuote.SelectionStart;
                int selectionLength = this.txtChargesQuote.SelectionLength;

                text = text.Substring(0, selectionStart) + keyChar + text.Substring(selectionStart + selectionLength);

                if (int.TryParse(text, out _) && text.Length > 16)
                {
                    // Reject an integer that is longer than 16 digits.
                    e.Handled = true;
                }
                else if (double.TryParse(text, out _) && text.IndexOf('.') < text.Length - 3)
                {
                    // Reject a real number with too many decimal places.
                    e.Handled = false;
                }
            }
            else
            {
                // Reject all other characters.
                e.Handled = true;
            }

        }
        private void cmbServiceType_Format(object sender,ListControlConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                e.Value = e.Value.ToString().Trim();
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            customerRecord2 customerRecord2 = new customerRecord2();
            customerRecord2.Show();
        }

        private void txtUpfront_TextChanged(object sender, EventArgs e)
        {
            txtGrandTotal.Text = Compute();
            txtTotalPayment.Text = Compute();

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
        Category category = new Category(); 
        category.Show();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategoryGenerate();
        }
        public void SubCategoryGenerate()
        {
            try
            {
                cmbSubCategory.Enabled = true;
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string ct = "SELECT  RTRIM(SubCategoryName),SubCategoryServices.ID FROM SubCategoryServices INNER JOIN CategoryServices ON SubCategoryServices.Category = CategoryServices.CategoryName WHERE CategoryName = @d1";
                    using (SqlCommand cmd = new SqlCommand(ct, con))
                    {
                        cmd.Parameters.AddWithValue("@d1", cmbCategory.Text);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            cmbSubCategory.Items.Clear();
                            while (rdr.Read())
                            {
                                cmbSubCategory.Items.Add(rdr[0].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SubCategoryGenerateID()
        {
            try
            {
                cmbSubCategory.Enabled = true;
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string ct = "SELECT ID FROM SubCategoryServices  WHERE SubCategoryName = @d1";
                    using (SqlCommand cmd = new SqlCommand(ct, con))
                    {
                        cmd.Parameters.AddWithValue("@d1", cmbSubCategory.Text);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                txtSubCategoryID.Text = rdr[0].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fillCategory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    using (SqlDataAdapter adp = new SqlDataAdapter())
                    {
                        adp.SelectCommand = new SqlCommand("SELECT RTRIM(CategoryName) FROM CategoryServices", con);
                        DataSet ds = new DataSet("ds");
                        adp.Fill(ds);
                        System.Data.DataTable dtable = ds.Tables[0];
                        cmbCategory.Items.Clear();
                        foreach (DataRow drow in dtable.Rows)
                        {
                            cmbCategory.Items.Add(drow[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeScreen employeeScreen = new EmployeeScreen();
            employeeScreen.lblSet.Text = "Servece Entry";

            employeeScreen.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SubCategory category = new SubCategory();
            category.Show();
        }   

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategoryGenerateID();
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
        }
        public string Compute()
        {
            if (string.IsNullOrWhiteSpace(txtChargesQuote.Text))
            {
                txtChargesQuote.Text="0";
            }else if (string.IsNullOrWhiteSpace(txtUpfront.Text))
            {
                txtUpfront.Text="0";
            }
     
            string total = (Convert.ToDouble(txtChargesQuote.Text) + Convert.ToDouble(txtUpfront.Text)).ToString();
            
            return total;
        }

        private void txtChargesQuote_TextChanged(object sender, EventArgs e)
        {
            txtGrandTotal.Text = Compute();
            txtTotalPayment.Text = Compute();
        }

        private void txtPaymentDue_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtGrandTotal.Text))
            {
                txtGrandTotal.Text = "0";
            }
            else if (string.IsNullOrWhiteSpace(txtTotalPayment.Text))
            {
                txtTotalPayment.Text = "0";
            }
            string total = (Convert.ToDouble(txtGrandTotal.Text) -  Convert.ToDouble(txtTotalPayment.Text)).ToString();

            txtPaymentDue.Text = total;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = DataAccessLayer.Con();

            // Input validation
            if (string.IsNullOrWhiteSpace(txtChargesQuote.Text))
            {
                MessageBox.Show("الرجاء كتابة رسوم الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChargesQuote.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUpfront.Text))
            {
                MessageBox.Show("الرجاء كتابة اتعاب الخدمه", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم العميل", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textMPay.Text))
            {
                MessageBox.Show("الرجاء اختيار طريقة الدفع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("الرجاء كتابة الخدمه الرئيسية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = @"SELECT ServiceID FROM Services WHERE ServiceID=@ServiceID ";
            
            using (var cmd = new SqlCommand(query, con)){
                con.Open();
                cmd.Parameters.AddWithValue("@ServiceID", (txtID.Text));

                using (var rdr = cmd.ExecuteReader())
                {
                    if (!rdr.Read())
                    {
                        MessageBox.Show("رجاء ادخال فاتورة خدمه اولا قبل اضافة دفعه.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                con.Close();

            }
            txtTotalPayment.Text =(Convert.ToDouble(txtTotalPayment.Text)+ Convert.ToDouble(textBox1.Text)).ToString();
            if (Convert.ToDouble(txtTotalPayment.Text) > Convert.ToDouble(txtGrandTotal.Text))
            {
                MessageBox.Show("المبلغ المدفوع لا يكون ان يكون اكبر من قيمة الفاتورة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string updateQuery = @"
                UPDATE Services 
                SET 
                    InvoiceNumber = @InvoiceNumber,
                    InvoiceDate = @InvoiceDate,
                    CustomerID = @CustomerID,
                    SubService = @SubService,
                    AssignedEmployee = @AssignedEmployee,
                    Fees = @Fees,
                    Charges = @Charges,
                    Total = @Total,
                    PaidAmount = @PaidAmount,
                    RemainingAmount = @RemainingAmount,
                    PaymentMethod = @PaymentMethod,
                    PaymentDate = @PaymentDate,
                    EmployeID = @EmployeID,
                    CustomerCode = @CustomerCode,
                    CustomerName = @CustomerName,
                    EmployeCode = @EmployeCode,
                    EmployeName = @EmployeName
                WHERE 
                    ServiceID = @ServiceID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        // Parameters mapping
                        cmd.Parameters.AddWithValue("@ServiceID", (txtID.Text));
                        cmd.Parameters.AddWithValue("@InvoiceNumber", txtServiceCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@InvoiceDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@CustomerID", (txtCID.Text));
                        cmd.Parameters.AddWithValue("@SubService", (txtSubCategoryID.Text));
                        cmd.Parameters.AddWithValue("@AssignedEmployee", txtEID.Text.Trim());
                        cmd.Parameters.AddWithValue("@Fees", (txtChargesQuote.Text));
                        cmd.Parameters.AddWithValue("@Charges", (txtUpfront.Text));
                        cmd.Parameters.AddWithValue("@Total", (txtGrandTotal.Text));
                        cmd.Parameters.AddWithValue("@PaidAmount", (txtTotalPayment.Text));
                        cmd.Parameters.AddWithValue("@RemainingAmount", (txtPaymentDue.Text));
                        cmd.Parameters.AddWithValue("@PaymentMethod", textMPay.Text.Trim());
                        cmd.Parameters.AddWithValue("@PaymentDate", dtpServiceCreationDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EmployeID", (txtEID.Text));
                        cmd.Parameters.AddWithValue("@CustomerCode", txtCustomerID.Text.Trim());
                        cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeCode", txtEmployeeID.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeName", txtEmployeeName.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
          
                if (textMPay.SelectedIndex == 3)
                {
                    LedgerSave(dateTimePicker2.Value.Date, "اجل", txtServiceCode.Text, "دفعات خدمه", 0, Math.Abs(Convert.ToDecimal(textBox1.Text)), txtCID.Text, "");
                }
                else if (textMPay.SelectedIndex == 1)
                {
                    LedgerSave(dateTimePicker2.Value.Date, "نقدا", txtServiceCode.Text, "دفعات خدمه", 0, Math.Abs(Convert.ToDecimal(textBox1.Text)), txtCID.Text, "");
                }
                else
                {
                    LedgerSave(dateTimePicker2.Value.Date, "نقدا", txtServiceCode.Text, "دفعات خدمه", 0, Math.Abs(Convert.ToDecimal(textBox1.Text)), txtCID.Text, "");
                }

                MessageBox.Show("تم التعديل بنجاح", "خدمات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في المدخلات" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Reset();

        }
        public void LedgerSave(DateTime a, string b, string c, string d, decimal e, decimal f, string g, string h)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cb = "insert into LedgerBook(Date, Name, LedgerNo, Label,Debit,Credit,PartyID,Manual_Inv) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
                SqlCommand cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d1", a);
                cmd.Parameters.AddWithValue("@d2", b);
                cmd.Parameters.AddWithValue("@d3", c);
                cmd.Parameters.AddWithValue("@d4", d);
                cmd.Parameters.AddWithValue("@d5", e);
                cmd.Parameters.AddWithValue("@d6", f);
                cmd.Parameters.AddWithValue("@d7", g);
                cmd.Parameters.AddWithValue("@d8", h);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
            }
        }
        public void LedgerDelete(string a, string b)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cq = "delete from LedgerBook where LedgerNo=@d1 and Label=@d2";
                SqlCommand cmd = new SqlCommand(cq);
                cmd.Parameters.AddWithValue("@d1", a);
                cmd.Parameters.AddWithValue("@d2", b);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
            }
        }
        public static void LedgerUpdate(DateTime a, string b, decimal e, decimal f, string g, string h, string i)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cb = "UPDATE LedgerBook SET Date=@d1, Name=@d2, Debit=@d3, Credit=@d4, PartyID=@d5 WHERE LedgerNo=@d6 AND Label=@d7";
                using (var cmd = new SqlCommand(cb, con))
                {
                    cmd.Parameters.AddWithValue("@d1", a);
                    cmd.Parameters.AddWithValue("@d2", b);
                    cmd.Parameters.AddWithValue("@d3", e);
                    cmd.Parameters.AddWithValue("@d4", f);
                    cmd.Parameters.AddWithValue("@d5", g);
                    cmd.Parameters.AddWithValue("@d6", h);
                    cmd.Parameters.AddWithValue("@d7", i);
                    cmd.ExecuteReader();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void textMPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(textMPay.SelectedIndex == 3)
            {
                txtTotalPayment.Text = "";
            }
        }
    }
}
