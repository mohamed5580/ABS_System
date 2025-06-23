using Microsoft.VisualBasic;
using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi.Parser;
using ZXing;
using Excel = Microsoft.Office.Interop.Excel;

namespace Accounting_System
{
    public partial class EmployeeVoucherScreen : Form
    {
        SqlConnection cn = new SqlConnection(DataAccessLayer.Con());

        public EmployeeVoucherScreen()
        {
            InitializeComponent();

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       public void Getdata()
        {
            try
            {
                string query = @"
            SELECT 
                ep.PaymentID,
                ep.EmployeeID,
                ep.PaymentCode,
                ep.PaymentType,
                ep.Amount,
                e.EmployeeCode,
                e.EmployeeName,
                ep.PaymentDate
            FROM 
                [dbo].[EmployeePayments] ep
            JOIN 
                Employees e
            ON 
                e.EmployeeID = ep.EmployeeID
            ORDER BY ep.PaymentID";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgw.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgw);

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    dgvRow.Cells[i].Value = row[i]?.ToString();
                                }

                                dgw.Rows.Add(dgvRow);
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


        private void frmLogs_Load(object sender, EventArgs e)
        {
            


        }




 
        public void Reset()
        {
            txtEmployeeName.Text = "";
            txtPhoneNumber.Text = "";
            Getdata();
        }
    


        private void txtSubCategory_TextChanged(object sender, EventArgs e)
        {
           
        }
       

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
          /*  ExportExcel(dgw);*/
        }

       

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgw_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            try
            {
                // Check if a row is selected
                if(lblSet.Text == "Voucher Entry")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    EmployeeVoucher anotherPage = EmployeeVoucher.instance;

                    anotherPage.txtID.Text = selectedRow.Cells[0].Value.ToString(); // EmployeeID
                    anotherPage.txtEID.Text = selectedRow.Cells[1].Value.ToString(); // EmployeeID
                    anotherPage.txtVoucherCode.Text = selectedRow.Cells[2].Value.ToString(); // EmployeeCode
                    anotherPage.textMPay.Text = selectedRow.Cells[3].Value.ToString(); // EmployeeName
                    anotherPage.Amount.Text = selectedRow.Cells[4].Value.ToString(); // EmployeeName
                    anotherPage.txtEmployeeID.Text = selectedRow.Cells[5].Value.ToString(); // EmployeeName
                    anotherPage.txtEmployeeName.Text = selectedRow.Cells[6].Value.ToString(); // EmployeeName
                    anotherPage.dateTimePicker2.Value = Convert.ToDateTime(selectedRow.Cells[7].Value);
                    anotherPage.btnUpdate.Enabled =true;
                    anotherPage.btnDelete.Enabled = true;
                    anotherPage.btnSave.Enabled = false;


                    // Optionally, show the other page
                    anotherPage.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        private void ProductsScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ProductsScreen_Load(object sender, EventArgs e)
        {
            Getdata();
        }

       
        private void dgw_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dgw.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
            {
                dgw.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + (e.RowBounds.Height - size.Height) / 2);

        }
       
        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txtPaymentCode_TextChanged(object sender, EventArgs e)
        {
           
        }



        private void GetFilteredData(string columnName, string filterText)
        {
          
        }

        private void ProductsScreen_FormClosed_1(object sender, FormClosedEventArgs e)
        {
          
            
        }

       




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
        private void dgw_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT 
                ep.PaymentID,
                ep.EmployeeID,
                ep.PaymentCode,
                ep.PaymentType,
                ep.Amount,
                e.EmployeeCode,
                e.EmployeeName,
                ep.PaymentDate
            FROM 
                [dbo].[EmployeePayments] ep
            JOIN 
                Employees e
            ON 
                e.EmployeeID = ep.EmployeeID
            WHERE 
                e.EmployeeName LIKE @EmployeeName
            ORDER BY ep.PaymentID";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeName", "%" + txtEmployeeName.Text + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgw.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgw);

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    dgvRow.Cells[i].Value = row[i]?.ToString();
                                }

                                dgw.Rows.Add(dgvRow);
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

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT 
                ep.PaymentID,
                ep.EmployeeID,
                ep.PaymentCode,
                ep.PaymentType,
                ep.Amount,
                e.EmployeeCode,
                e.EmployeeName,
                ep.PaymentDate
            FROM 
                [dbo].[EmployeePayments] ep
            JOIN 
                Employees e
            ON 
                e.EmployeeID = ep.EmployeeID
            WHERE 
                ep.PaymentCode LIKE @PaymentCode
            ORDER BY ep.PaymentID";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PaymentCode", "%" + txtPhoneNumber.Text + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgw.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgw);

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    dgvRow.Cells[i].Value = row[i]?.ToString();
                                }

                                dgw.Rows.Add(dgvRow);
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
