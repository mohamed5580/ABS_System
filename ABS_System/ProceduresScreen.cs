using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class ProceduresScreen : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public ProceduresScreen()
        {
            InitializeComponent();
            Getdata();
            dgw.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgw_RowPostPaint);
            txtCategory.TextChanged += new EventHandler(txtCategory_TextChanged);
            txtSubCategory.TextChanged += new EventHandler(txtSubCategory_TextChanged);
           
            dgw.MouseDoubleClick += new MouseEventHandler(dgw_MouseDoubleClick);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Getdata()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT 
                                        P.ProcedureID, 
                                        P.SubService, 
                                        P.ProcedureCode, 
                                        P.ProcedureName, 
                                        S.SubCategoryName, 
                                        C.CategoryName, 
                                        P.ProcedureDate
                                    FROM 
                                        Procedures P
                                    JOIN 
                                        SubCategoryServices S ON P.SubService = S.SubCategoryName
                                    JOIN 
                                        CategoryServices C ON S.Category = C.CategoryName
                                    
                                    ORDER BY 
                                        P.ProcedureCode;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                dgw.Rows.Clear();
                                while (rdr.Read())
                                {
                                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgw_RowPostPaint(object sender , DataGridViewRowPostPaintEventArgs e)
        {

/*                string strRowNumber = (e.RowIndex + 1).ToString();
                using (Graphics g = e.Graphics)
                {
                    SizeF size = g.MeasureString(strRowNumber, this.Font);
                    if (this.dgw.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
                    {
                        this.dgw.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
                    }

                    Brush b = SystemBrushes.ControlText;
                    g.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
                }
            */

        }
        public void Reset()
        {
            txtProductName.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtSubCategory.Text = string.Empty;
            Getdata();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT 
                                        P.ProcedureID, 
                                        P.SubService, 
                                        P.ProcedureCode, 
                                        P.ProcedureName, 
                                        S.SubCategoryName, 
                                        C.CategoryName, 
                                        P.ProcedureDate
                                    FROM 
                                        Procedures P
                                    JOIN 
                                        SubCategoryServices S ON P.SubService = S.SubCategoryName
                                    JOIN 
                                        CategoryServices C ON S.Category = C.CategoryName
                                    WHERE 
                                        C.CategoryName LIKE @CategoryName
                                    ORDER BY 
                                        P.ProcedureCode;
                                    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", "%" + txtCategory.Text + "%");
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
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
        private void txtSubCategory_TextChanged(object sender, EventArgs e) {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT 
                                        P.ProcedureID, 
                                        P.SubService, 
                                        P.ProcedureCode, 
                                        P.ProcedureName, 
                                        S.SubCategoryName, 
                                        C.CategoryName, 
                                        P.ProcedureDate
                                    FROM 
                                        Procedures P
                                    JOIN 
                                        SubCategoryServices S ON P.SubService = S.SubCategoryName
                                    JOIN 
                                        CategoryServices C ON S.Category = C.CategoryName
                                    WHERE 
                                        S.SubCategoryName LIKE @SubCategoryName
                                    ORDER BY 
                                        P.ProcedureCode;
                                    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SubCategoryName", "%" + txtSubCategory.Text + "%");
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
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
                excelWorksheet.Rows["1:1"].Font.Size = 7;

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
       
        private void dgw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // التحقق من وجود صف محدد
                if (dgw.CurrentRow != null && dgw.CurrentRow.Index != -1 && lblSet.Text == "Procedures")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    Procedures anotherPage = Procedures.instance;
                    // الحصول على القيم من الصف المحدد
                    anotherPage.txtID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                    anotherPage.txtProcedureCode.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                    anotherPage.txtProcedure.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                    anotherPage.cmbCategory.Text = dgw.CurrentRow.Cells[4].Value.ToString();
                    anotherPage.cmbSubCategory.Text = dgw.CurrentRow.Cells[5].Value.ToString();

                    // مثال لتاريخ الإجراء
                    if (dgw.CurrentRow.Cells[6].Value != DBNull.Value)
                    {
                        anotherPage.dtpProcedureCreationDate.Value = Convert.ToDateTime(dgw.CurrentRow.Cells[6].Value);
                    }
                    else
                    {
                        anotherPage.dtpProcedureCreationDate.Value = DateTime.Now;

                    }
                    this.Close();
                }else if (dgw.CurrentRow != null && dgw.CurrentRow.Index != -1 && lblSet.Text == "PTracking")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    ProcedureTrackingg anotherPage = ProcedureTrackingg.instance;
                    // الحصول على القيم من الصف المحدد
                    anotherPage.txtProcedureID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                    anotherPage.txtProductCode.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                    anotherPage.txtProductName.Text = dgw.CurrentRow.Cells[3].Value.ToString();
                    anotherPage.btnSave.Enabled = true;
              
            
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productRecord_Load(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT 
                                        P.ProcedureID, 
                                        P.SubService, 
                                        P.ProcedureCode, 
                                        P.ProcedureName, 
                                        S.SubCategoryName, 
                                        C.CategoryName, 
                                        P.ProcedureDate
                                    FROM 
                                        Procedures P
                                    JOIN 
                                        SubCategoryServices S ON P.SubService = S.SubCategoryName
                                    JOIN 
                                        CategoryServices C ON S.Category = C.CategoryName
                                    WHERE 
                                        P.ProcedureName LIKE @SubCategoryName
                                    ORDER BY 
                                        P.ProcedureCode;
                                    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SubCategoryName", "%" + txtProductName.Text + "%");
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6]);
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
