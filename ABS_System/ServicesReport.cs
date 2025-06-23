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
    public partial class ServicesReport : Form
    {
        public ServicesReport()
        {
            InitializeComponent();
        }

        private void SalesProductsReport_Load(object sender, EventArgs e)
        {
            fillCategory();
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
                    Employees.EmployeeCode AS EmployeeID , 
                    Employees.EmployeeName AS EmployeeName , 
                    Employees.PhoneNumber AS EmployeeNumber , 
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
                    Services.InvoiceDate BETWEEN @d1 AND @d2 AND SubCategoryServices.ID = @SubCategoryServices 
                ORDER BY 
                    Services.InvoiceDate";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d1", dtpDateFrom.Value.Date);  // Replace with your date picker controls
                    cmd.Parameters.AddWithValue("@d2", dtpDateTo.Value.Date);
                    cmd.Parameters.AddWithValue("@SubCategoryServices", txtID.Text);


                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (!rdr.HasRows)
                    {
                        MessageBox.Show("عذرًا..لا يوجد سجلات", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rdr.Close();
                        return;
                    }
                    DataTable dt = new DataTable("Services");
                    dt.Load(rdr);


                    con.Close();

                    // Set up the report
                    rptServicesReport rpt = new rptServicesReport();
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

        }

        private void Label1_Click(object sender, EventArgs e)
        {

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
                                txtID.Text = rdr[1].ToString();
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

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategoryGenerateID();
        }
    }
}
