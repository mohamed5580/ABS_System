using Microsoft.VisualBasic;
using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Accounting_System
{
    public partial class EmployeeVoucher : Form
    {
        string connectionString = DataAccessLayer.Con();
        public static EmployeeVoucher instance;

        public EmployeeVoucher()
        {
            InitializeComponent();
            instance = this;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم السند", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVoucherCode.Text))
            {
                MessageBox.Show("الرجاء كتابة كود السند", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textMPay.Text))
            {
                MessageBox.Show("الرجاء كتابة تفاصيل السند", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Amount.Text))
            {
                MessageBox.Show("الرجاء كتابة المبلغ المدفوع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO EmployeePayments (PaymentDate, EmployeeID,EmployeeName, PaymentCode, PaymentType, Amount) " +
                               "VALUES (@PaymentDate, @EmployeeID,@EmployeeName, @PaymentCode, @PaymentType, @Amount)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentDate", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEID.Text));
                command.Parameters.AddWithValue("@PaymentCode", txtVoucherCode.Text);
                command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@PaymentType", textMPay.Text);
                command.Parameters.AddWithValue("@Amount", double.Parse(Amount.Text));

                connection.Open();

                command.ExecuteNonQuery();

                LedgerSave(dateTimePicker2.Value.Date, txtEmployeeName.Text, txtVoucherCode.Text, "سندات دفع موظف", 0, -double.Parse(Amount.Text), "", "");

                MessageBox.Show("Record saved successfully.");
            }
            Reset();
        }

        
        private void EmployeeVoucher_Load(object sender, EventArgs e)
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
                txtVoucherCode.Text = "EV-" + GenerateID();
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
                    string sql = $"SELECT ISNULL(MAX(PaymentID), 0) FROM EmployeePayments ";
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


        private void txtEID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            txtID.Text = string.Empty;
            dateTimePicker2.Value = DateTime.Now;
            txtEID.Text = string.Empty;
            textMPay.SelectedIndex = -1;
            txtVoucherCode.Text = string.Empty;
            textMPay.Text = string.Empty;
            Amount.Text = string.Empty;
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            auto();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEID.Text))
            {
                MessageBox.Show("Please enter EmployeeID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please enter PaymentID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtVoucherCode.Text))
            {
                MessageBox.Show("Please enter PaymentCode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textMPay.Text))
            {
                MessageBox.Show("Please enter PaymentType", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Amount.Text))
            {
                MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUpfront.Focus();
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE EmployeePayments SET PaymentDate = @PaymentDate, EmployeeID = @EmployeeID, " +
                               "PaymentCode = @PaymentCode, PaymentType = @PaymentType, Amount = @Amount,EmployeeName=@EmployeeName " +
                               "WHERE PaymentID = @PaymentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentID", int.Parse(txtID.Text));
                command.Parameters.AddWithValue("@PaymentDate", dateTimePicker2.Value);
                command.Parameters.AddWithValue("@EmployeeID", int.Parse(txtEID.Text));
                command.Parameters.AddWithValue("@PaymentCode", txtVoucherCode.Text);
                command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@PaymentType", textMPay.Text);
                command.Parameters.AddWithValue("@Amount", double.Parse(Amount.Text));
                LedgerUpdate(dateTimePicker2.Value.Date, txtEmployeeName.Text, 0, -Convert.ToDouble(Amount.Text), "", txtVoucherCode.Text, "سندات دفع موظف");

                connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully.");
            }
            Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM EmployeePayments WHERE PaymentID = @PaymentID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaymentID", int.Parse(txtID.Text));

                connection.Open();
                command.ExecuteNonQuery();
                LedgerDelete(txtVoucherCode.Text, "سندات دفع موظف");

                MessageBox.Show("Record deleted successfully.");
            }
            Reset();
        }
        public static void LedgerUpdate(DateTime a, string b, decimal e, double f, string g, string h, string i)
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
        public static void LedgerSave(DateTime a, string b, string c, string d, double e, double f, string g, string h)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cb = "INSERT INTO LedgerBook(Date, Name, LedgerNo, Label, Debit, Credit, PartyID, Manual_Inv) VALUES (@d1, @d2, @d3, @d4, @d5, @d6, @d7, @d8)";
                using (var cmd = new SqlCommand(cb, con))
                {
                    cmd.Parameters.AddWithValue("@d1", a);
                    cmd.Parameters.AddWithValue("@d2", b);
                    cmd.Parameters.AddWithValue("@d3", c);
                    cmd.Parameters.AddWithValue("@d4", d);
                    cmd.Parameters.AddWithValue("@d5", e);
                    cmd.Parameters.AddWithValue("@d6", f);
                    cmd.Parameters.AddWithValue("@d7", g);
                    cmd.Parameters.AddWithValue("@d8", h);
                    cmd.ExecuteReader();
                }
            }
        }
        public static void LedgerDelete(string a, string b)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
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

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeScreen employeeScreen = new EmployeeScreen();
            employeeScreen.lblSet.Text = "Voucher Entry";

            employeeScreen.Show();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            EmployeeVoucherScreen employeeScreen = new EmployeeVoucherScreen();
            employeeScreen.lblSet.Text = "Voucher Entry";

            employeeScreen.Show();
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
