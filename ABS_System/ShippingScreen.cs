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

namespace Accounting_System
{
    public partial class ShippingScreen : Form
    {
        public ShippingScreen()
        {
            InitializeComponent();
        }

        private void ShippingScreen_Load(object sender, EventArgs e)
        {
            GetData();
        }
        public void GetData()
        {
            try
            {
                // Define your connection string
                string connectionString = DataAccessLayer.Con(); // Update with your actual connection string

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // Define the SQL query to retrieve data from ExpensesShipping table
                    string query = "SELECT ID, TransactionNo,InvPay,InvSale, PaymentInvoice, SalesInvoice, DriverExpenses, CarExpenses, OtherExpenses, TotalExpenses, CreatedAt FROM ExpensesShipping";

                    // Create a SqlDataAdapter to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Create a DataTable to hold the data
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (rdr.Read() == true)
                            DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);

                        // Bind the DataTable to the DataGridView
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection issues)
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Ensure the click is on a valid row (not the header)
            if (DataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int rowIndex = DataGridView1.SelectedCells[0].RowIndex;

                try
                {
                    // Retrieve the data from the selected row by index (safe method)

                    string txtid = DataGridView1.Rows[rowIndex].Cells[0].Value.ToString(); // Assuming TransactionNo is in the 2nd column
                    string transactionNo = DataGridView1.Rows[rowIndex].Cells[1].Value.ToString(); // Assuming TransactionNo is in the 2nd column
                    string paymentInvoicen = DataGridView1.Rows[rowIndex].Cells[2].Value.ToString(); // Assuming PaymentInvoice is in the 3rd column
                    string salesInvoicen = DataGridView1.Rows[rowIndex].Cells[3].Value.ToString(); // Assuming TransactionNo is in the 2nd column
                    string paymentInvoice = DataGridView1.Rows[rowIndex].Cells[4].Value.ToString(); // Assuming PaymentInvoice is in the 3rd column
                    string salesInvoice = DataGridView1.Rows[rowIndex].Cells[5].Value.ToString(); // Assuming SalesInvoice is in the 4th column
                    decimal driverExpenses = Convert.ToDecimal(DataGridView1.Rows[rowIndex].Cells[6].Value); // 5th column for DriverExpenses
                    decimal carExpenses = Convert.ToDecimal(DataGridView1.Rows[rowIndex].Cells[7].Value); // 6th column for CarExpenses
                    decimal otherExpenses = Convert.ToDecimal(DataGridView1.Rows[rowIndex].Cells[8].Value); // 7th column for OtherExpenses
                    decimal totalExpenses = Convert.ToDecimal(DataGridView1.Rows[rowIndex].Cells[9].Value); // 8th column for TotalExpenses

                    // Get the singleton instance of Shipping form
                    Shipping shippingForm = Shipping.instance;
                    shippingForm.DataGridView1.Rows.Clear();
                    // Add the selected row data to DataGridView1 in the Shipping form
                    shippingForm.DataGridView1.Rows.Add(txtid,transactionNo, paymentInvoicen, salesInvoicen, paymentInvoice, salesInvoice, driverExpenses, carExpenses, otherExpenses, totalExpenses);
                    shippingForm.btnDelete.Enabled = true;
                    // Optionally, show the Shipping form if it's not already open
                    if (!shippingForm.Visible)
                    {
                        shippingForm.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception if a column is missing or invalid data is encountered
                    MessageBox.Show("Error while retrieving row data: " + ex.Message);
                }
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Define your connection string
                string connectionString = DataAccessLayer.Con(); // Update with your actual connection string

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    conn.Open();
                    DataGridView1.Rows.Clear();

                    // Define the SQL query to retrieve data from ExpensesShipping table
                    string query = "SELECT ID, TransactionNo,InvPay,InvSale, PaymentInvoice, SalesInvoice, DriverExpenses, CarExpenses, OtherExpenses, TotalExpenses, CreatedAt FROM ExpensesShipping WHERE TransactionNo LIKE @TransactionNo";
                    // Create a SqlDataAdapter to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@TransactionNo", "%" + txtCarName.Text + "%");

                        // Create a DataTable to hold the data
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (rdr.Read() == true)
                            DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);

                        // Bind the DataTable to the DataGridView
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection issues)
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Define your connection string
                string connectionString = DataAccessLayer.Con(); // Update with your actual connection string

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    conn.Open();
                    DataGridView1.Rows.Clear();

                    // Define the SQL query to retrieve data from ExpensesShipping table
                    string query = "SELECT ID, TransactionNo,InvPay,InvSale, PaymentInvoice, SalesInvoice, DriverExpenses, CarExpenses, OtherExpenses, TotalExpenses, CreatedAt FROM ExpensesShipping WHERE SalesInvoice LIKE @TransactionNo";
                    // Create a SqlDataAdapter to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@TransactionNo", "%" + textBox1.Text + "%");

                        // Create a DataTable to hold the data
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (rdr.Read() == true)
                            DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);

                        // Bind the DataTable to the DataGridView
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection issues)
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Define your connection string
                string connectionString = DataAccessLayer.Con(); // Update with your actual connection string

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the database connection
                    conn.Open();
                    DataGridView1.Rows.Clear();
                    // Define the SQL query to retrieve data from ExpensesShipping table
                    string query = "SELECT ID, TransactionNo,InvPay,InvSale, PaymentInvoice, SalesInvoice, DriverExpenses, CarExpenses, OtherExpenses, TotalExpenses, CreatedAt FROM ExpensesShipping WHERE PaymentInvoice LIKE @TransactionNo";
                    // Create a SqlDataAdapter to fetch data
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@TransactionNo", "%" + textBox2.Text + "%");

                        // Create a DataTable to hold the data
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        while (rdr.Read() == true)
                            DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10]);

                        // Bind the DataTable to the DataGridView
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection issues)
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
