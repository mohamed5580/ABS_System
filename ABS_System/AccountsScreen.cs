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
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class AccountsScreen : Form
    {
        public AccountsScreen()
        {
            InitializeComponent();
        }

        private void basic_Load(object sender, EventArgs e)
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
                    string query = @"SELECT [AccountID]
                                        ,[AccountCode]
                                        ,[AccountName]
                                        ,[AccountDetails]
                                        ,[AccountDate]
                                    FROM [dbo].[Accounts]                                    
                                    ORDER BY 
                                        AccountID;";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                            {
                                dgw.Rows.Clear();
                                while (rdr.Read())
                                {
                                    dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
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

        private void gunaContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string query = @"SELECT [AccountID]
                                        ,[AccountCode]
                                        ,[AccountName]
                                        ,[AccountDetails]
                                        ,[AccountDate]
                                    FROM [dbo].[Accounts] 
                                    WHERE 
                                        AccountName LIKE  @SubCategoryName
                                    ORDER BY 
                                        AccountID;
                                    ";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SubCategoryName", "%" + txtProductName.Text + "%");
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            dgw.Rows.Clear();
                            while (rdr.Read())
                            {
                                dgw.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
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
                excelWorksheet.Rows["1:1"].Font.Size = 12;

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

        public void Reset()
        {
            txtProductName.Text = string.Empty;
            Getdata();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgw.CurrentRow != null && dgw.CurrentRow.Index != -1 && lblSet.Text == "Accounts")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    Accounts anotherPage = Accounts.instance;
                    anotherPage.txtID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                    anotherPage.txtAccountCode.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                    anotherPage.txtAccount.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                    anotherPage.txtAccountDetails.Text = dgw.CurrentRow.Cells[3].Value.ToString();

                    if (dgw.CurrentRow.Cells[4].Value != DBNull.Value)
                    {
                        anotherPage.dtpProcedureCreationDate.Value = Convert.ToDateTime(dgw.CurrentRow.Cells[4].Value);
                    }
                    else
                    {
                        anotherPage.dtpProcedureCreationDate.Value = DateTime.Now;

                    }
                    anotherPage.btnSave.Enabled = false;

                    this.Close();
                }
                else if (lblSet.Text == "Voucher")
                {
                    if (dgw.CurrentRow != null && dgw.CurrentRow.Index != -1)
                    {
                        DataGridViewRow selectedRow = dgw.CurrentRow;

                        // Assuming the other page is named `AnotherPage`
                        Voucher anotherPage = Voucher.instance;
                        anotherPage.txtAID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
                        anotherPage.txtAccountCode.Text = dgw.CurrentRow.Cells[1].Value.ToString();
                        anotherPage.txtName.Text = dgw.CurrentRow.Cells[2].Value.ToString();
                        anotherPage.txtDetails.Text = dgw.CurrentRow.Cells[3].Value.ToString();


                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

