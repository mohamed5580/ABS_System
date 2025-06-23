using Microsoft.Office.Interop.Excel;
using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class ProcedureTrackinggScreen : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        private static ProcedureTrackinggScreen _instance;
        public static ProcedureTrackinggScreen Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ProcedureTrackinggScreen();
                }
                return _instance;
            }
        }
        public ProcedureTrackinggScreen()
        {
            InitializeComponent();
            Getdata();
        }
        public void Getdata()
        {
            try
            {
                using (con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    string query = @"SELECT 
                                        PT.[TrackingID],
                                        PT.[TrackingCode],
                                        PT.[TrackingDate],
                                        PT.[ServiceID],
	                                    S.InvoiceNumber,
                                        C.[CustomerName],
                                        E.[EmployeeName],
                                        SCS.[SubCategoryName],
                                        SCS.[Category],
	                                    PT.[Notes]
                                    FROM 
                                        [dbo].[ProcedureTracking] AS PT
                                    JOIN 
                                        [dbo].[Services] AS S ON PT.ServiceID = S.ServiceID
                                    JOIN 
                                        [dbo].[Customers] AS C ON S.CustomerID = C.CustomerID
                                    JOIN 
                                        [dbo].[Employees] AS E ON S.EmployeID = E.EmployeeID
                                    JOIN 
                                        [dbo].[SubCategoryServices] AS SCS ON S.SubService = SCS.ID;
                                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            dgw.Rows.Clear();

                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9]);
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date, RTRIM(PurchaseType), Supplier.ID, RTRIM(Supplier.SupplierID), RTRIM(Name), SubTotal, DiscountPer, Discount, VATPer, VATAmt, FreightCharges, OtherCharges, PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Stock.Remarks) FROM Supplier, Stock WHERE Supplier.ID = Stock.SupplierID AND [Date] BETWEEN @d1 AND @d2 ORDER BY [Date]", con);
                string query = @"SELECT 
                                       PT.[TrackingID],
                                        PT.[TrackingCode],
                                        PT.[TrackingDate],
                                        PT.[ServiceID],
	                                    S.InvoiceNumber,
                                        C.[CustomerName],
                                        E.[EmployeeName],
                                        SCS.[SubCategoryName],
                                        SCS.[Category],
	                                    PT.[Notes]
                                    FROM 
                                        [dbo].[ProcedureTracking] AS PT
                                    JOIN 
                                        [dbo].[Services] AS S ON PT.ServiceID = S.ServiceID
                                    JOIN 
                                        [dbo].[Customers] AS C ON S.CustomerID = C.CustomerID
                                    JOIN 
                                        [dbo].[Employees] AS E ON S.EmployeID = E.EmployeeID
                                    JOIN 
                                        [dbo].[SubCategoryServices] AS SCS ON S.SubService = SCS.ID
                                    WHERE TrackingDate BETWEEN @d1 AND @d2 ORDER BY [TrackingDate];
                                    ";
                cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = dtpDateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = dtpDateTo.Value.Date;

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    dgw.Rows.Clear();

                    while (rdr.Read())
                    {
                        dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18], rdr[19], rdr[20]);
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
        public void Reset()
        {
            dtpDateFrom.Text = DateTime.Today.ToString();
            dtpDateTo.Text = DateTime.Today.ToString();
            Getdata();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Assuming 'con' is a SqlConnection object defined at the class level

        private void dgw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgw.SelectedRows[0];
                if (dr != null && !dr.IsNewRow && lblSet.Text == "PTracking")
                {
                    // Retrieve values from the selected row
                    ProcedureTrackingg  procedureTrackingg =  ProcedureTrackingg.instance;
                    procedureTrackingg.txtID.Text = dr.Cells[0].Value?.ToString();
                    procedureTrackingg.txtInvoiceNo.Text = dr.Cells[1].Value?.ToString();
                    procedureTrackingg.dtpDate.Value = Convert.ToDateTime(dr.Cells[2].Value);
                    procedureTrackingg.txtS.Text = dr.Cells[3].Value?.ToString();
                    procedureTrackingg.txtServiceID.Text = dr.Cells[4].Value?.ToString();
                    procedureTrackingg.txtCName.Text = dr.Cells[5].Value?.ToString();
                    procedureTrackingg.txtEmp.Text = dr.Cells[6].Value?.ToString();
                    procedureTrackingg.txtServCategory.Text = dr.Cells[7].Value?.ToString();
                    procedureTrackingg.txtSubServ.Text = dr.Cells[8].Value?.ToString();
                    procedureTrackingg.txtRemarks.Text = dr.Cells[9].Value?.ToString();

                    string connectionString = DataAccessLayer.Con();
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        MessageBox.Show("The connection string is not initialized. Please check the configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        try
                        {
                            con.Open();
                            string sql = @"SELECT 
                                            [ProcedureID]
                                            ,[ProcedureCode]
                                            ,[ProcedureName]
                                            ,[Done]
                                        FROM [ProceduresJoin] where ProcedureTID = " + dr.Cells[0].Value + "";

                            SqlCommand cmd = new SqlCommand(sql, con);
                            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                            procedureTrackingg.DataGridView1.Rows.Clear();
                            while (rdr.Read())
                            {
                                procedureTrackingg.DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        procedureTrackingg.btnUpdate.Enabled = true;
                        procedureTrackingg.btnDelete.Enabled = true;
                        procedureTrackingg.btnSave.Enabled = false;


                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PymentinvoiceScreen_Load(object sender, EventArgs e)
        {
            Getdata();

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(dgw);
        }
        public static void ExportExcel(object obj)
        {
            short rowsTotal, colsTotal;
            short I, j, iC;
            Cursor.Current = Cursors.WaitCursor;
            var xlApp = new Excel.Application();
            try
            {
                var excelBook = xlApp.Workbooks.Add();
                var excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = (short)((DataGridView)obj).RowCount;
                colsTotal = (short)(((DataGridView)obj).Columns.Count - 1);
                excelWorksheet.Cells.Select();
                excelWorksheet.Cells.Delete();
                for (iC = 0; iC <= colsTotal; iC++)
                {
                    excelWorksheet.Cells[1, iC + 1].Value = ((DataGridView)obj).Columns[iC].HeaderText;
                }
                for (I = 0; I < rowsTotal; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        excelWorksheet.Cells[I + 2, j + 1].Value = ((DataGridView)obj).Rows[I].Cells[j].Value;
                    }
                }
                excelWorksheet.Rows["1:1"].Font.FontStyle = "Bold";
                excelWorksheet.Rows["1:1"].Font.Size = 9;

                excelWorksheet.Cells.Columns.AutoFit();
                excelWorksheet.Cells.Select();
                excelWorksheet.Cells.EntireColumn.AutoFit();
                excelWorksheet.Cells[1, 1].Select();
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
    }
}
