using Microsoft.Office.Interop.Excel;
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
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace Accounting_System
{
    public partial class Shipping : Form
    {
        public static Shipping instance;

        public Shipping()
        {
            InitializeComponent();
            instance = this;
            Driverexpenses.KeyPress += NumericTextBox1_KeyPress;
            Carexpenses.KeyPress += NumericTextBox2_KeyPress;
            expenses.KeyPress += NumericTextBox3_KeyPress;
            Totalexpenses.KeyPress += NumericTextBox4_KeyPress;

        }
        private void NumericTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a control key, a digit, or a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block the key if it's not a valid input
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && Driverexpenses.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }
        }
        private void NumericTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a control key, a digit, or a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block the key if it's not a valid input
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && expenses.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }
        }
        private void NumericTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a control key, a digit, or a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block the key if it's not a valid input
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && Totalexpenses.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }
        }
        private void NumericTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a control key, a digit, or a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block the key if it's not a valid input
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && Carexpenses.Text.Contains("."))
            {
                e.Handled = true; // Block additional decimal points
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation checks
                if (string.IsNullOrWhiteSpace(txtTransactionNo.Text))
                {
                    MessageBox.Show("الرجاء كتابة البيان", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTransactionNo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(Driverexpenses.Text))
                {
                    MessageBox.Show("الرجاء كتابة المبلغ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Driverexpenses.Focus();
                    return;
                }

               

                // Add the new row to DataGridView1
                DataGridView1.Rows.Add(txtID.Text, txtTransactionNo.Text, txtinvPay.Text,txtInvSale.Text, txtPymentInv.Text, txtSalesInv.Text, Driverexpenses.Text, Carexpenses.Text, expenses.Text, Totalexpenses.Text, txtPymentInv.Text, txtSalesInv.Text);

                // Clear fields after adding
                Clear1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Clear()
        {
            (txtTransactionNo.Text) = "";
            txtSalesInv.Text = "";
            txtPymentInv.Text = string.Empty;   
            Driverexpenses.Text = "";
            Carexpenses.Text = "";
            expenses.Text = "";
            Totalexpenses.Text = "";
            txtinvPay.Text = "";
            txtInvSale.Text = "";
            Totalexpenses.Text = "";
            DataGridView1.Rows.Clear();
            auto();
        }
        private void Clear1()
        {
            txtTransactionNo.Clear();
            txtinvPay.Clear();
            txtInvSale.Clear();
            Driverexpenses.Clear();
            Carexpenses.Clear();
            expenses.Clear();
            Totalexpenses.Clear();
            txtPymentInv.Clear();
            txtSalesInv.Clear();
            auto();

        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = DataAccessLayer.Con();

            try
            {
                // Check if DataGridView1 has rows
                if (DataGridView1.Rows.Count == 0 || DataGridView1.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
                {
                    MessageBox.Show("ادخل البيانات اولا", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in DataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue; // Skip the new row placeholder

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO ExpensesShipping (TransactionNo, PaymentInvoice, SalesInvoice, DriverExpenses, CarExpenses, OtherExpenses, TotalExpenses,InvPay,InvSale) VALUES (@TransactionNo, @PaymentInvoice, @SalesInvoice, @DriverExpenses, @CarExpenses, @OtherExpenses, @TotalExpenses,@InvPay,@InvSale)", conn))
                        {
                            cmd.Parameters.AddWithValue("@TransactionNo", row.Cells[1].Value ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@InvPay", (row.Cells[2].Value ?? 0));
                            cmd.Parameters.AddWithValue("@InvSale", (row.Cells[3].Value ?? 0));
                            cmd.Parameters.AddWithValue("@PaymentInvoice", row.Cells[4].Value ?? 0);
                            cmd.Parameters.AddWithValue("@SalesInvoice", row.Cells[5].Value ?? 0);
                            cmd.Parameters.AddWithValue("@DriverExpenses", Convert.ToDecimal(row.Cells[6].Value ?? 0));
                            cmd.Parameters.AddWithValue("@CarExpenses", Convert.ToDecimal(row.Cells[7].Value ?? 0));
                            cmd.Parameters.AddWithValue("@OtherExpenses", Convert.ToDecimal(row.Cells[8].Value ?? 0));
                            cmd.Parameters.AddWithValue("@TotalExpenses", Convert.ToDecimal(row.Cells[9].Value ?? 0));

                            cmd.ExecuteNonQuery();
                        }
                    }
                }


                MessageBox.Show("تم حفظ البيانات بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear(); // Clear fields after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateExpenseID()
        {
            string connectionString = DataAccessLayer.Con();

            string value = "0001";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Retrieve the latest Expense_ID from the Expenses table
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM ExpensesShipping ORDER BY ID DESC", conn);
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        value = rdr["ID"].ToString(); // Get the latest Expense_ID from the database
                    }

                    rdr.Close();

                    // Increment the ID by 1
                    int numericValue = int.Parse(value);
                    numericValue++;

                    // Format the ID to be 4 digits with leading zeros
                    value = numericValue.ToString("D4");
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log if necessary) and ensure a fallback value
                    value = "0001"; // Fallback ID
                }
                finally
                {
                    // Ensure the connection is closed
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

            return value;
        }

        public void auto()
        {
            try
            {
                // Set the values for txtID and txtExpenseNo using the generated Expense ID
                string generatedID = GenerateExpenseID();
                txtID.Text = generatedID;
                txtTransactionNo.Text = "Exp-" + generatedID;
            }
            catch (Exception ex)
            {
                // Display error if there’s an issue in the auto method
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveExpenses()
        {
            
        }

        private void Shipping_Load(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            ProcedureTrackinggScreen pymentinvoiceScreen = new ProcedureTrackinggScreen();
            pymentinvoiceScreen.lblSet.Text="SHIP";
            pymentinvoiceScreen.Show(); 
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            SalesInvoiceScreen salesInvoiceScreen = new SalesInvoiceScreen();
            salesInvoiceScreen.lblSet.Text = "SHIP";
            salesInvoiceScreen.Show();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if there is a selected row
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    // Confirm the deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Remove the selected row

                        DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows[0].Index);

                        MessageBox.Show("Row deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DataGridView1.CurrentRow != null)
            {
                txtID.Text= DataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTransactionNo.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtinvPay.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtInvSale.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
                Driverexpenses.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
                Carexpenses.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
                expenses.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
                Totalexpenses.Text = DataGridView1.CurrentRow.Cells[9].Value.ToString();
                txtPymentInv.Text = DataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtSalesInv.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
                button2.Enabled=true;
            }
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                    // Get the TransactionNo (or other identifier) from the selected row
                    string transactionNo = selectedRow.Cells[1].Value.ToString();

                    // Confirm deletion with the user
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this shipping record?",
                        "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Remove the row from the DataGridView
                        DataGridView1.Rows.Remove(selectedRow);

                        // Connect to the database
                        string connectionString = DataAccessLayer.Con(); // Update with your connection string
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();

                            // Prepare SQL DELETE query to remove the record from the database
                            string query = "DELETE FROM ExpensesShipping WHERE TransactionNo = @TransactionNo";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@TransactionNo", transactionNo);

                                // Execute the DELETE query
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Shipping record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the given TransactionNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            ShippingScreen screen = new ShippingScreen();   
            screen.Show();  
        }
        public void UpdateExpense()
        {
            string connectionString = DataAccessLayer.Con();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Use the unique ID or TransactionNo to identify the record to update
                    using (SqlCommand cmd = new SqlCommand("UPDATE ExpensesShipping SET PaymentInvoice = @PaymentInvoice, SalesInvoice = @SalesInvoice, DriverExpenses = @DriverExpenses, CarExpenses = @CarExpenses, OtherExpenses = @OtherExpenses, TotalExpenses = @TotalExpenses WHERE TransactionNo = @TransactionNo", conn))
                    {
                        // Update values from textboxes
                        cmd.Parameters.AddWithValue("@TransactionNo", txtTransactionNo.Text);
                        cmd.Parameters.AddWithValue("@PaymentInvoice", Convert.ToInt32(txtPymentInv.Text));
                        cmd.Parameters.AddWithValue("@SalesInvoice", Convert.ToInt32(txtSalesInv.Text));
                        cmd.Parameters.AddWithValue("@DriverExpenses", Convert.ToDecimal(Driverexpenses.Text));
                        cmd.Parameters.AddWithValue("@CarExpenses", Convert.ToDecimal(Carexpenses.Text));
                        cmd.Parameters.AddWithValue("@OtherExpenses", Convert.ToDecimal(expenses.Text));
                        cmd.Parameters.AddWithValue("@TotalExpenses", Convert.ToDecimal(Totalexpenses.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the DataGridView after update
                Clear(); // Clear the form fields
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
