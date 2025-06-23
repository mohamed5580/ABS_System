using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_System
{
    public partial class EmployeeServicesReport : Form
    {
        public EmployeeServicesReport()
        {
            InitializeComponent();
        }

        private void SalesProductsReport_Load(object sender, EventArgs e)
        {
            LoadProductNames();
        }
        private void LoadProductNames()
        {
            // Define the query to select both PID (or ProductCode) and ProductName for binding
            string query = "SELECT EmployeeID, EmployeeName FROM [dbo].[Employees]";

            using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable productTable = new DataTable();

                    // Fill DataTable with product data
                    adapter.Fill(productTable);

                    // Bind to comboBox1
                    comboBox1.DataSource = productTable;
                    comboBox1.DisplayMember = "EmployeeName"; // What user sees in the ComboBox
                    comboBox1.ValueMember = "EmployeeID";           // The actual value behind each item (e.g., PID)

 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    string query = @"
            SELECT 
                Services.ServiceID AS S_ID, 
                Services.InvoiceNumber AS ServiceCode, 
                Services.InvoiceDate AS ServiceCreationDate, 
                Customers.CustomerName AS CustomerName, 
                Employees.EmployeeCode AS EmployeeID, 
                Employees.EmployeeName AS EmployeeName, 
                Employees.PhoneNumber AS EmployeeNumber, 
                SubCategoryServices.SubCategoryName AS SubService, 
                SubCategoryServices.Category AS Service, 
                Services.Fees, 
                Services.Charges, 
                Services.Total AS Total, 
                Services.PaidAmount, 
                Services.RemainingAmount, 
                Services.PaymentMethod AS Status, 
                Services.PaymentDate
            FROM 
                Services
            INNER JOIN 
                Customers ON Services.CustomerID = Customers.CustomerID
            INNER JOIN 
                Employees ON Services.EmployeID = Employees.EmployeeID
            INNER JOIN 
                SubCategoryServices ON SubCategoryServices.ID = Services.SubService 
            WHERE 
                Services.InvoiceDate BETWEEN @d1 AND @d2 AND Employees.EmployeeID = @Employees
            ORDER BY 
                Services.InvoiceDate";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d1", dtpDateFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@d2", dtpDateTo.Value.Date);
                    cmd.Parameters.AddWithValue("@Employees", txtID.Text);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (!rdr.HasRows)
                    {
                        MessageBox.Show("عذرًا..لا يوجد سجلات", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rdr.Close();
                        return;
                    }

                    // If there are rows, load data into DataTable
                    DataTable dt = new DataTable("Services");
                    dt.Load(rdr);
                    rdr.Close();

                    // Set up the report
                    rptEmployeeServicesReport rpt = new rptEmployeeServicesReport();
                    rpt.SetDataSource(dt);

                    // Set any parameters in the report if needed
                    rpt.SetParameterValue("p1", dtpDateFrom.Value);
                    rpt.SetParameterValue("p2", dtpDateTo.Value);

                    // Show the report in a CrystalReportViewer
                    frmReport viewer = new frmReport();
                    viewer.crystalReportViewer1.ReportSource = rpt;
                    viewer.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void EmployeeServicesGenerateID()
        {
            try
            {
                comboBox1.Enabled = true;
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string ct = "SELECT EmployeeID FROM [dbo].[Employees]  WHERE EmployeeName = @d1";
                    using (SqlCommand cmd = new SqlCommand(ct, con))
                    {
                        cmd.Parameters.AddWithValue("@d1", comboBox1.Text);
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                txtID.Text = rdr[0].ToString();
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
        //private void btnGetData_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
        //        {
        //            con.Open();

            //            // SQL query to get the data for the report
            //            string query1 = @"SELECT Invoice_Product.InvoiceID, Invoice_Product.ProductID, Product.ProductName, 
            //                            Invoice_Product.Barcode, Invoice_Product.Qty, Invoice_Product.TotalAmount,Product.Unit,Temp_Stock.Qty as StockQty, Invoice_Payment.PaymentDate
            //                            FROM Invoice_Product 
            //                            JOIN Invoice_Payment ON Invoice_Product.InvoiceID = Invoice_Payment.InvoiceID 
            //                            JOIN Product ON Invoice_Product.ProductID = Product.PID 
            //                            JOIN Temp_Stock ON Temp_Stock.ProductID = Product.PID 
            //                            WHERE Invoice_Payment.PaymentDate Between @d1 And @d2
            //                            AND Product.ProductName LIKE '%' + @productName + '%' 
            //                            ORDER BY Product.ProductName";

            //            SqlCommand cmd = new SqlCommand(query1, con);
            //            cmd.Parameters.AddWithValue("@d1", dtpDateFrom.Value.Date);  // Adjust for your date input controls
            //            cmd.Parameters.AddWithValue("@d2", dtpDateTo.Value.Date);    // Adjust for your date input controls
            //            cmd.Parameters.AddWithValue("@productName", comboBox1.Text);  // Assuming you have a TextBox for product name search

            //            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            //            // Creating a DataTable to hold the data for the report
            //            DataTable dt = new DataTable();
            //            dt.Columns.Add("InvoiceID", typeof(int));
            //            dt.Columns.Add("ProductID", typeof(int));
            //            dt.Columns.Add("ProductName", typeof(string));
            //            dt.Columns.Add("Barcode", typeof(string));
            //            dt.Columns.Add("Qty", typeof(float));
            //            dt.Columns.Add("TotalAmount", typeof(float));
            //            dt.Columns.Add("Unit", typeof(string));
            //            dt.Columns.Add("StockQty", typeof(float));
            //            dt.Columns.Add("PaymentDate", typeof(DateTime));

            //            // Fill the DataTable with data from the SQL query
            //            adp.Fill(dt);

            //            con.Close();

            //            // Set up the report with the DataTable as data source
            //            rptEmployeeServicesReport rpt = new rptEmployeeServicesReport();
            //            rpt.SetDataSource(dt);

            //            // Set any parameters in the report if needed
            //            rpt.SetParameterValue("p1", dtpDateFrom.Value);
            //            rpt.SetParameterValue("p2", dtpDateTo.Value);

            //            // Show the report in a new form with CrystalReportViewer
            //            frmReport reportForm = new frmReport();
            //            reportForm.crystalReportViewer1.ReportSource = rpt;
            //            reportForm.ShowDialog();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeServicesGenerateID();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
