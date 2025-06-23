using DevExpress.Xpo.DB.Helpers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class servicesRecord : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public servicesRecord()
        {
            InitializeComponent();
            ////fillServiceCode();
            //dgw.MouseDoubleClick += new MouseEventHandler(dgw_MouseClick);
            //dgw.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgw_RowPostPaint);
            //cmbServiceCode.SelectedIndexChanged += new EventHandler(cmbOrderNo_SelectedIndexChanged);
            //txtCustomerName.TextChanged += new EventHandler(txtCustomerName_TextChanged);
            //cmbServiceCode.Format += new ListControlConvertEventHandler(cmbInvoiceNo_Format);
        }

        private void servicesRecord_Load(object sender, EventArgs e)
        {
            Getdata();

        }

        private void Getdata()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT 
                                    s.ServiceID, 
                                    s.CustomerID, 
                                    s.EmployeID, 
                                    s.InvoiceNumber, 
                                    s.InvoiceDate, 
                                    s.CustomerCode, 
                                    s.CustomerName, 
                                    s.EmployeCode, 
                                    s.EmployeName, 
                                    s.PaymentMethod, 
                                    s.Fees, 
                                    s.Charges, 
                                    s.Total, 
                                    s.PaidAmount, 
                                    s.RemainingAmount, 
                                    scs.SubCategoryName,
                                    scs.Category,
                                    s.SubService, 
                                    s.AssignedEmployee, 
                                    s.PaymentDate
                                
                                FROM
                                    Services s
                                JOIN
                                    SubCategoryServices scs ON s.SubService = scs.ID
                                ORDER BY
                                    s.InvoiceDate; ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18]);
                            }
                        }
                    }
                

                }
                foreach (DataGridViewRow row in dgw.Rows)
                {
                    if (row.Cells[14].Value != null &&
                        decimal.TryParse(row.Cells[14].Value.ToString(), out var paidAmount) &&
                        paidAmount != 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }


        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Ensure rows exist and a row is selected
                if (dgw.Rows.Count > 0 && dgw.SelectedRows.Count > 0)
                {
                    DataGridViewRow dr = dgw.SelectedRows[0];

                    if (lblSet.Text == "Services")
                    {
                        // Open the 'services' form
                        services frm =  services.instance;
                       
                        // Transfer data from DataGridView to form fields
                        frm.txtID.Text = dr.Cells[0].Value?.ToString();
                        frm.txtCID.Text = dr.Cells[1].Value?.ToString();
                        frm.txtEID.Text = dr.Cells[2].Value?.ToString();
                        frm.txtServiceCode.Text = dr.Cells[3].Value?.ToString();
                        frm.dtpServiceCreationDate.Value = dr.Cells[4].Value != null
                            ? DateTime.Now
                            : DateTime.Now; // Default to now if null

                        frm.txtCustomerID.Text = dr.Cells[5].Value?.ToString();
                        frm.txtCustomerName.Text = dr.Cells[6].Value?.ToString();
                        frm.txtEmployeeID.Text = dr.Cells[7].Value?.ToString();
                        frm.txtEmployeeName.Text = dr.Cells[8].Value?.ToString();
                        frm.textMPay.Text = dr.Cells[9].Value?.ToString();
                        frm.txtChargesQuote.Text = dr.Cells[10].Value?.ToString();
                        frm.txtUpfront.Text = dr.Cells[11].Value?.ToString();

                       
                        // Populate additional fields
                        frm.txtTotalPayment.Text = dr.Cells[13].Value?.ToString();
                        frm.txtPaymentDue.Text = dr.Cells[14].Value?.ToString();
                        frm.txtGrandTotal.Text = dr.Cells[12].Value?.ToString();
                        // Populate additional fields
                        frm.cmbCategory.Text = dr.Cells[15].Value?.ToString();
                        frm.cmbSubCategory.Text = dr.Cells[16].Value?.ToString();
                        frm.txtSubCategoryID.Text = dr.Cells[17].Value?.ToString();
                        // Enable or disable buttons based on the operation
                        frm.btnSave.Enabled = false;
                        frm.btnUpdate.Enabled = true;
                        frm.btnDelete.Enabled = true;
                        this.Hide();
                    }
                    else if (lblSet.Text== "PTracking")
                    {
                        // Open the 'services' form
                        ProcedureTrackingg frm = ProcedureTrackingg.instance;

                        frm.txtS.Text = dr.Cells[0].Value?.ToString();
                        frm.txtServiceID.Text = dr.Cells[3].Value?.ToString();
                        frm.txtCName.Text = dr.Cells[6].Value?.ToString();
                        frm.txtEmp.Text = dr.Cells[8].Value?.ToString();
                        frm.txtServCategory.Text = dr.Cells[15].Value?.ToString();
                        frm.txtSubServ.Text = dr.Cells[16].Value?.ToString();
                      
                        frm.btnSave.Enabled = true;
                        frm.btnUpdate.Enabled = true;
                        frm.btnDelete.Enabled = true;
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            if (dgw.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
            {
                dgw.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
            }

            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }
        public void Reset()
        {
            txtCustomerName.Text = "";
            dtpDateFrom.Value = DateTime.Today;
            dtpDateTo.Value = DateTime.Today;
            Getdata();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

       
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    string query = @"SELECT 
                                        s.ServiceID, 
                                        s.CustomerID, 
                                        s.EmployeID, 
                                        s.InvoiceNumber, 
                                        s.InvoiceDate, 
                                        s.CustomerCode, 
                                        s.CustomerName, 
                                        s.EmployeCode, 
                                        s.EmployeName, 
                                        s.PaymentMethod, 
                                        s.Fees, 
                                        s.Charges, 
                                        s.Total, 
                                        s.PaidAmount, 
                                        s.RemainingAmount, 
                                        scs.SubCategoryName,
                                        scs.Category,
                                        s.SubService, 
                                        s.AssignedEmployee, 
                                        s.PaymentDate
                                    FROM
                                        Services s
                                    JOIN
                                        SubCategoryServices scs ON s.SubService = scs.ID
                                    WHERE 
                                        s.InvoiceDate BETWEEN @d1 AND @d2 
                                    ORDER BY
                                        s.InvoiceDate;
                                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@d1", dtpDateFrom.Value.Date);
                        cmd.Parameters.Add("@d2", dtpDateTo.Value.Date);

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(
                                   rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18]);
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
       
       
        private void cmbInvoiceNo_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.DesiredType == typeof(string))
            {
                e.Value = e.Value.ToString().Trim();
            }

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
                excelWorksheet.Rows["1:1"].Font.Size = 14;

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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(dgw);
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCustomerName_TextChanged_1(object sender, EventArgs e)
        {
             try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    string query = @"SELECT 
                                        s.ServiceID, 
                                        s.CustomerID, 
                                        s.EmployeID, 
                                        s.InvoiceNumber, 
                                        s.InvoiceDate, 
                                        s.CustomerCode, 
                                        s.CustomerName, 
                                        s.EmployeCode, 
                                        s.EmployeName, 
                                        s.PaymentMethod, 
                                        s.Fees, 
                                        s.Charges, 
                                        s.Total, 
                                        s.PaidAmount, 
                                        s.RemainingAmount, 
                                        scs.SubCategoryName,
                                        scs.Category,
                                        s.SubService, 
                                        s.AssignedEmployee, 
                                        s.PaymentDate
                                    FROM
                                        Services s
                                    JOIN
                                        SubCategoryServices scs ON s.SubService = scs.ID
                                    WHERE 
                                        s.CustomerName LIKE @customerName 
                                    ORDER BY
                                        s.InvoiceDate;
                                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@customerName", "%" + txtCustomerName.Text + "%");

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(
                                   rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18]);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    string query = @"SELECT 
                                        s.ServiceID, 
                                        s.CustomerID, 
                                        s.EmployeID, 
                                        s.InvoiceNumber, 
                                        s.InvoiceDate, 
                                        s.CustomerCode, 
                                        s.CustomerName, 
                                        s.EmployeCode, 
                                        s.EmployeName, 
                                        s.PaymentMethod, 
                                        s.Fees, 
                                        s.Charges, 
                                        s.Total, 
                                        s.PaidAmount, 
                                        s.RemainingAmount, 
                                        scs.SubCategoryName,
                                        scs.Category,
                                        s.SubService, 
                                        s.AssignedEmployee, 
                                        s.PaymentDate
                                    FROM
                                        Services s
                                    JOIN
                                        SubCategoryServices scs ON s.SubService = scs.ID
                                    WHERE 
                                        s.EmployeName LIKE @EmployeName 
                                    ORDER BY
                                        s.InvoiceDate;
                                    ";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeName", "%" + txtEmployeName.Text + "%");

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(
                                   rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11], rdr[12], rdr[13], rdr[14], rdr[15], rdr[16], rdr[17], rdr[18]);
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
    }
}
