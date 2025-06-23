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
    public partial class EmployeeScreen : Form
    {
        SqlConnection cn = new SqlConnection(DataAccessLayer.Con());

        public EmployeeScreen()
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
                    SELECT EmployeeID, EmployeeName, EmployeeCode, PhoneNumber, Address, Gender 
            FROM Employees 
                    ORDER BY EmployeeID";


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

                                dgvRow.Cells[0].Value = row["EmployeeID"].ToString();
                                dgvRow.Cells[1].Value = row["EmployeeCode"].ToString();
                                dgvRow.Cells[2].Value = row["EmployeeName"].ToString();
                                dgvRow.Cells[3].Value = row["PhoneNumber"].ToString();
                                dgvRow.Cells[4].Value = row["Address"].ToString();
                                dgvRow.Cells[5].Value = row["Gender"].ToString();
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
                if (dgw.CurrentRow != null && dgw.CurrentRow.Index != -1 && lblSet.Text== "Employee Entry")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    Employee anotherPage =  Employee.instance;

                    anotherPage.txtID.Text = selectedRow.Cells[0].Value.ToString(); // EmployeeID
                    anotherPage.txtEmployeeID.Text = selectedRow.Cells[1].Value.ToString(); // EmployeeCode
                    anotherPage.txtEmployeeName.Text = selectedRow.Cells[2].Value.ToString(); // EmployeeName
                    anotherPage.txtPhoneNumber.Text = selectedRow.Cells[3].Value.ToString(); // PhoneNumber
                    anotherPage.txtAddress.Text = selectedRow.Cells[4].Value.ToString(); // Address

                    // Gender
                    if (selectedRow.Cells[5].Value.ToString() == "Male")
                    {
                        anotherPage.rbMale.Checked = true;
                    }
                    else if (selectedRow.Cells[5].Value.ToString() == "Female")
                    {
                        anotherPage.rbFemale.Checked = true;
                    }

                    // Optionally, show the other page
                    anotherPage.Show();
                }
                else if (lblSet.Text == "Servece Entry")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    services anotherPage = services.instance;

                    anotherPage.txtEID.Text = selectedRow.Cells[0].Value.ToString(); // EmployeeID
                    anotherPage.txtEmployeeID.Text = selectedRow.Cells[1].Value.ToString(); // EmployeeCode
                    anotherPage.txtEmployeeName.Text = selectedRow.Cells[2].Value.ToString(); // EmployeeName

                    // Optionally, show the other page
                    anotherPage.Show();
                }
                else if (lblSet.Text == "Voucher Entry")
                {
                    DataGridViewRow selectedRow = dgw.CurrentRow;

                    // Assuming the other page is named `AnotherPage`
                    EmployeeVoucher anotherPage = EmployeeVoucher.instance;

                    anotherPage.txtEID.Text = selectedRow.Cells[0].Value.ToString(); // EmployeeID
                    anotherPage.txtEmployeeID.Text = selectedRow.Cells[1].Value.ToString(); // EmployeeCode
                    anotherPage.txtEmployeeName.Text = selectedRow.Cells[2].Value.ToString(); // EmployeeName

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
        private void txtProductName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT EmployeeID, EmployeeName, EmployeeCode, PhoneNumber, Address, Gender 
            FROM Employees 
            WHERE EmployeeName LIKE @EmployeeName
            ORDER BY EmployeeID";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add the wildcard directly in the SQL parameter
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

                                dgvRow.Cells[0].Value = row["EmployeeID"].ToString();
                                dgvRow.Cells[1].Value = row["EmployeeCode"].ToString();
                                dgvRow.Cells[2].Value = row["EmployeeName"].ToString();
                                dgvRow.Cells[3].Value = row["PhoneNumber"].ToString();
                                dgvRow.Cells[4].Value = row["Address"].ToString();
                                dgvRow.Cells[5].Value = row["Gender"].ToString();
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


        private void txtBarcode_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT EmployeeID, EmployeeName, EmployeeCode, PhoneNumber, Address, Gender 
            FROM Employees 
            WHERE PhoneNumber LIKE @PhoneNumber
            ORDER BY EmployeeID";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add the wildcard directly in the SQL parameter
                        cmd.Parameters.AddWithValue("@PhoneNumber", "%" + txtPhoneNumber.Text + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgw.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgw);

                                dgvRow.Cells[0].Value = row["EmployeeID"].ToString();
                                dgvRow.Cells[1].Value = row["EmployeeCode"].ToString();
                                dgvRow.Cells[2].Value = row["EmployeeName"].ToString();
                                dgvRow.Cells[3].Value = row["PhoneNumber"].ToString();
                                dgvRow.Cells[4].Value = row["Address"].ToString();
                                dgvRow.Cells[5].Value = row["Gender"].ToString();
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
    }
}
