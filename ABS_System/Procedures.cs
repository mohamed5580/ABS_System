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
    public partial class Procedures : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public static Procedures instance;
        public Procedures()
        {
            InitializeComponent();
            
            instance = this;
        }
        private void Procedures_Load(object sender, EventArgs e)
        {
            auto();


        }
        public void auto()
        {
            try
            {
                // Assuming txtID and txtInvoiceNo are on your form.
                // Use CustomerID as the ID for the Customer table.
                txtID.Text = GenerateID();

                // Since we want Invoice Number to be "Inv-XXXX", I can use CustomerID to get the same ID.
                txtProcedureCode.Text = "P-" + GenerateID();
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
            txtProcedure.Text = "";
            txtCID.Text = "";      
            auto();
            txtEID.Text = ""; 
            dtpProcedureCreationDate.Value = DateTime.Today;
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
                    string sql = $"SELECT ISNULL(MAX(ProcedureID), 0) FROM Procedures ";
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


        
        private void Print()
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

                    MyCommand.Parameters.AddWithValue("@d1", txtProcedureCode.Text);

                    MyCommand1.CommandText = "SELECT * FROM Company";

                    MyCommand.CommandType = CommandType.Text;
                    MyCommand1.CommandType = CommandType.Text;

                    myDA.SelectCommand = MyCommand;
                    myDA1.SelectCommand = MyCommand1;

                    myDA.Fill(myDS, "Service");
                    myDA.Fill(myDS, "Customer");
                    myDA1.Fill(myDS, "Company");

                    rpt.SetDataSource(myDS);
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
        private void DeleteRecord()
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
                    string deleteQuery = "DELETE FROM Procedures WHERE ProcedureID = @ServiceID";

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

                // Clear the form fields after deletion
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LedgerDelete(string a, string b)
        {
            using (SqlConnection con = DataAccessLayer.cn)
            {
                con.Open();
                string cq = "DELETE FROM LedgerBook WHERE LedgerNo=@d1 AND Label=@d2";
                using (var cmd = new SqlCommand(cq, con))
                {
                    cmd.Parameters.AddWithValue("@d1", a);
                    cmd.Parameters.AddWithValue("@d2", b);
                    cmd.ExecuteReader();
                }
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
            // التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txtProcedure.Text))
            {
                MessageBox.Show("Please enter the procedure name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcedure.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbSubCategory.Text))
            {
                MessageBox.Show("Please select a sub-service", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSubCategory.Focus();
                return;
            }

            try
            {
                // إدخال البيانات إلى الجدول Procedures
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"
                INSERT INTO Procedures (SubService,ProcedureCode, ProcedureName, ProcedureDate)
                VALUES (@SubService,@ProcedureCode, @ProcedureName, @ProcedureDate)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SubService", cmbSubCategory.Text);
                        cmd.Parameters.AddWithValue("@ProcedureCode", txtProcedureCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProcedureName", txtProcedure.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.Date);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Procedure saved successfully!", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset(); // إعادة ضبط الحقول
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // التحقق من صحة المدخلات
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter the procedure ID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtProcedure.Text))
            {
                MessageBox.Show("Please enter the procedure name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProcedure.Focus();
                return;
            }

            try
            {
                // تحديث البيانات في الجدول Procedures
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"
                UPDATE Procedures 
                SET SubService = @SubService,
                    ProcedureCode = @ProcedureCode,
                    ProcedureName = @ProcedureName, 
                    ProcedureDate = @ProcedureDate 
                WHERE ProcedureID = @ProcedureID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProcedureID", Convert.ToInt32(txtID.Text));
                        cmd.Parameters.AddWithValue("@SubService", cmbSubCategory.Text);
                        cmd.Parameters.AddWithValue("@ProcedureCode", txtProcedureCode.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProcedureName", txtProcedure.Text.Trim());
                        cmd.Parameters.AddWithValue("@ProcedureDate", DateTime.Now.Date);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Procedure updated successfully!", "Procedures", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset(); // إعادة ضبط الحقول
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating procedure: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ValidateNumeric(string input)
        {
            return int.TryParse(input, out int result) ? result : 0;
        }

        private decimal ValidateDecimal(string input)
        {
            return decimal.TryParse(input, out decimal result) ? result : 0;
        }

        public static void LedgerUpdate(DateTime a, string b, decimal e, decimal f, string g, string h, string i)
        {
            using (SqlConnection con = DataAccessLayer.cn)
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            ProceduresScreen frmProceduresRecord = new ProceduresScreen();
            frmProceduresRecord.lblSet.Text = "Procedures";
            frmProceduresRecord.Show();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void txtChargesQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
         
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
                string text = this.txtProcedure.Text;
                int selectionStart = this.txtProcedure.SelectionStart;
                int selectionLength = this.txtProcedure.SelectionLength;

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
        

        private void txtChargesQuote_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPaymentDue_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtTotalPayment_TextChanged(object sender, EventArgs e)
        {

 
        }

        private void Procedures_Load_1(object sender, EventArgs e)
        {
            auto();
            fillCategory();
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }
    }
}
