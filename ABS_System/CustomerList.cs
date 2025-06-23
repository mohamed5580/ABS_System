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
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void basic_Load(object sender, EventArgs e)
        {
            GetData();

        }

        private void gunaContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        internal partial class SurroundingClass : Form
        {
            // Add your ExportExcel method implementation here
        }




        public void GetData()
        {
            try
            {
                string query = @"
                    SELECT 
                        CustomerID,
                        CustomerCode,
                        CustomerName,
                        PhoneNumber,
                        Address,
                        NationalID,
                        Email,
                        ActivityStartDate,
                        ActivityType,
                        OrganizationName,
                        WorkersCount,
                        TaxRegistrationNumber,
                        TaxCardNumber,
                        OldSystemUserName,
                        OldSystemPassword,
                        OldSystemEmailPassword,
                        InvoiceEmailPassword,
                        FormationCode,
                        InsuranceFileNumber,
                        GOVSystemEmail,
                        GOVSystemPassword,
                        OldGOVSystemEmail,
                        OldInvoiceEmail,
                        SAPUserName,
                        SAPPassword
                    FROM Customers
                    ORDER BY CustomerID";


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

                                dgvRow.Cells[0].Value = row["CustomerID"].ToString();
                                dgvRow.Cells[1].Value = row["CustomerCode"].ToString();
                                dgvRow.Cells[2].Value = row["CustomerName"].ToString();
                                dgvRow.Cells[3].Value = row["PhoneNumber"].ToString();
                                dgvRow.Cells[4].Value = row["Address"].ToString();
                                dgvRow.Cells[5].Value = row["NationalID"].ToString();
                                dgvRow.Cells[6].Value = row["Email"].ToString();

                                //ActivityStartDate Check if not Null
                                if (row["ActivityStartDate"] != DBNull.Value)
                                {
                                    dgvRow.Cells[7].Value = Convert.ToDateTime(row["ActivityStartDate"]).ToShortDateString();
                                }
                                else
                                {
                                    dgvRow.Cells[7].Value = "";
                                }


                                dgvRow.Cells[8].Value = row["ActivityType"].ToString();
                                dgvRow.Cells[9].Value = row["OrganizationName"].ToString();

                                //WorkersCount Check if not Null
                                if (row["WorkersCount"] != DBNull.Value)
                                {
                                    dgvRow.Cells[10].Value = row["WorkersCount"].ToString();
                                }
                                else
                                {
                                    dgvRow.Cells[10].Value = "";
                                }


                                dgvRow.Cells[11].Value = row["TaxRegistrationNumber"].ToString();
                                dgvRow.Cells[12].Value = row["TaxCardNumber"].ToString();
                                dgvRow.Cells[13].Value = row["OldSystemUserName"].ToString();
                                dgvRow.Cells[14].Value = row["OldSystemPassword"].ToString();
                                dgvRow.Cells[15].Value = row["OldSystemEmailPassword"].ToString();
                                dgvRow.Cells[16].Value = row["InvoiceEmailPassword"].ToString();
                                dgvRow.Cells[17].Value = row["FormationCode"].ToString();
                                dgvRow.Cells[18].Value = row["InsuranceFileNumber"].ToString();
                                dgvRow.Cells[19].Value = row["GOVSystemEmail"].ToString();
                                dgvRow.Cells[20].Value = row["GOVSystemPassword"].ToString();
                                dgvRow.Cells[21].Value = row["OldGOVSystemEmail"].ToString();
                                dgvRow.Cells[22].Value = row["OldInvoiceEmail"].ToString();
                                dgvRow.Cells[23].Value = row["SAPUserName"].ToString();
                                dgvRow.Cells[24].Value = row["SAPPassword"].ToString();

                                dgw.Rows.Add(dgvRow);
                            }
                        }
                    }
                }

                dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
         
        }






        private void SearchData(string column, string searchText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                   CustomerID,
                   CustomerCode,
                   CustomerName,
                   PhoneNumber,
                   Address,
                   NationalID,
                   Email,
                   ActivityStartDate,
                   ActivityType,
                   OrganizationName,
                   WorkersCount,
                   TaxRegistrationNumber,
                   TaxCardNumber,
                   OldSystemUserName,
                   OldSystemPassword,
                   OldSystemEmailPassword,
                   InvoiceEmailPassword,
                   FormationCode,
                   InsuranceFileNumber,
                   GOVSystemEmail,
                   GOVSystemPassword,
                   OldGOVSystemEmail,
                   OldInvoiceEmail,
                   SAPUserName,
                   SAPPassword
                FROM Customers ";

                    // Add the WHERE clause if search text and column are provided
                    if (!string.IsNullOrWhiteSpace(searchText) && !string.IsNullOrWhiteSpace(column))
                    {
                        query += " WHERE  " + column + " LIKE @searchText ";
                    }

                    query += " ORDER BY CustomerID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use the parameter if needed.
                        if (!string.IsNullOrWhiteSpace(searchText) && !string.IsNullOrWhiteSpace(column))
                        {
                            command.Parameters.AddWithValue("@searchText", $"%{searchText}%");
                        }

                        //Debugging output for SQL and Parameters
                        System.Diagnostics.Debug.WriteLine("SQL Query: " + query);
                        if (command.Parameters.Count > 0)
                        {
                            System.Diagnostics.Debug.WriteLine("Parameter: @searchText = " + command.Parameters["@searchText"].Value);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            //Debugging to see if rows were returned
                            System.Diagnostics.Debug.WriteLine("Rows Returned:" + dt.Rows.Count);

                            dgw.Rows.Clear();

                            foreach (DataRow row in dt.Rows)
                            {
                                DataGridViewRow dgvRow = new DataGridViewRow();
                                dgvRow.CreateCells(dgw);

                                dgvRow.Cells[0].Value = row["CustomerID"].ToString();
                                dgvRow.Cells[1].Value = row["CustomerCode"].ToString();
                                dgvRow.Cells[2].Value = row["CustomerName"].ToString();
                                dgvRow.Cells[3].Value = row["PhoneNumber"].ToString();
                                dgvRow.Cells[4].Value = row["Address"].ToString();
                                dgvRow.Cells[5].Value = row["NationalID"].ToString();
                                dgvRow.Cells[6].Value = row["Email"].ToString();

                                //ActivityStartDate Check if not Null
                                if (row["ActivityStartDate"] != DBNull.Value)
                                {
                                    dgvRow.Cells[7].Value = Convert.ToDateTime(row["ActivityStartDate"]).ToShortDateString();
                                }
                                else
                                {
                                    dgvRow.Cells[7].Value = "";
                                }
                                dgvRow.Cells[8].Value = row["ActivityType"].ToString();
                                dgvRow.Cells[9].Value = row["OrganizationName"].ToString();

                                //WorkersCount Check if not Null
                                if (row["WorkersCount"] != DBNull.Value)
                                {
                                    dgvRow.Cells[10].Value = row["WorkersCount"].ToString();
                                }
                                else
                                {
                                    dgvRow.Cells[10].Value = "";
                                }

                                dgvRow.Cells[11].Value = row["TaxRegistrationNumber"].ToString();
                                dgvRow.Cells[12].Value = row["TaxCardNumber"].ToString();
                                dgvRow.Cells[13].Value = row["OldSystemUserName"].ToString();
                                dgvRow.Cells[14].Value = row["OldSystemPassword"].ToString();
                                dgvRow.Cells[15].Value = row["OldSystemEmailPassword"].ToString();
                                dgvRow.Cells[16].Value = row["InvoiceEmailPassword"].ToString();
                                dgvRow.Cells[17].Value = row["FormationCode"].ToString();
                                dgvRow.Cells[18].Value = row["InsuranceFileNumber"].ToString();
                                dgvRow.Cells[19].Value = row["GOVSystemEmail"].ToString();
                                dgvRow.Cells[20].Value = row["GOVSystemPassword"].ToString();
                                dgvRow.Cells[21].Value = row["OldGOVSystemEmail"].ToString();
                                dgvRow.Cells[22].Value = row["OldInvoiceEmail"].ToString();
                                dgvRow.Cells[23].Value = row["SAPUserName"].ToString();
                                dgvRow.Cells[24].Value = row["SAPPassword"].ToString();


                                dgw.Rows.Add(dgvRow);
                            }
                        }
                    }
                    dgw.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtCustomerName.Text = "";
            txtContactNo.Text = "";
            txtCity.Text = "";
            GetData();
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            // Implement your ExportExcel method here
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            // Implementation here if needed
        }
        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            SearchData(" CustomerName ", txtCustomerName.Text);

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            SearchData("Address", txtCity.Text);

        }

        private void txtContactNo_TextChanged_1(object sender, EventArgs e)
        {
            SearchData("PhoneNumber", txtContactNo.Text);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            ExportExcel(dgw);
        }
        public void ExportExcel(DataGridView dataGridView)
        {
            int rowsTotal, colsTotal;
            int I, j, iC;
            Cursor.Current = Cursors.WaitCursor;
            Excel.Application xlApp = new Excel.Application();

            try
            {
                Excel.Workbook excelBook = xlApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets[1];
                xlApp.Visible = true;

                rowsTotal = dataGridView.RowCount;
                colsTotal = dataGridView.Columns.Count - 3;

                excelWorksheet.Cells.Select();
                excelWorksheet.Cells.Delete();

                for (iC = 0; iC <= colsTotal; iC++)
                {
                    excelWorksheet.Cells[1, iC + 1].Value = dataGridView.Columns[iC].HeaderText;
                }

                for (I = 0; I < rowsTotal; I++)
                {
                    for (j = 0; j <= colsTotal; j++)
                    {
                        excelWorksheet.Cells[I + 2, j + 1].Value = dataGridView.Rows[I].Cells[j].Value;
                    }
                }

               
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

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure at least one row is selected
                if (dgw.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a customer to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row
                DataGridViewRow selectedRow = dgw.SelectedRows[0];

                // Ensure the column "رقم العميل" exists
                if (selectedRow.Cells["Column2"] == null)
                {
                    MessageBox.Show("The selected row does not have a 'رقم العميل' column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve CustomerID from the selected row
                string customerID = selectedRow.Cells["Column2"].Value.ToString();

                // Prepare SQL DELETE command
                string deleteQuery = "DELETE FROM Customer WHERE CustomerID = @CustomerID";

                using (SqlConnection cn = new SqlConnection(DataAccessLayer.Con()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, cn))
                    {
                        // Add parameter with proper data type
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);

                        // Execute the delete command
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No customer was deleted. Please check the CustomerID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Notify user of success
                MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh the customer list
                CustomerList customers = new CustomerList();
                customers.GetData();

                // Close the form
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL error occurred: {sqlEx.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                GetData();
            }
        }


        private void dgw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgw.SelectedRows.Count > 0) // Check if a row is selected
            {
                DataGridViewRow selectedRow = dgw.SelectedRows[0]; // Get the first selected row
                Customer customer = Customer.instance;
                // Populate textboxes with values from selected row.
                // Use safe string handling to avoid issues with DBNull
                customer.txtID.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                customer.txtCustomerCode.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                customer.txtCustomerName.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                customer.txtPhoneNumber.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                customer.txtAddress.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                customer.txtNationalID.Text = selectedRow.Cells[5].Value?.ToString() ?? "";
                customer.txtEmail.Text = selectedRow.Cells[6].Value?.ToString() ?? "";

                // Handle ActivityStartDate
                if (selectedRow.Cells[7].Value != null && selectedRow.Cells[7].Value != DBNull.Value && !string.IsNullOrEmpty(selectedRow.Cells[7].Value.ToString()))
                {
                    customer.txtActivityStartDate.Text = DateTime.Parse(selectedRow.Cells[7].Value.ToString()).ToShortDateString();
                }
                else
                {
                    customer.txtActivityStartDate.Text = "";
                }

                customer.txtActivityType.Text = selectedRow.Cells[8].Value?.ToString() ?? "";
                customer.txtOrganizationName.Text = selectedRow.Cells[9].Value?.ToString() ?? "";

                //Handle WorkersCount
                if (selectedRow.Cells[10].Value != null && selectedRow.Cells[10].Value != DBNull.Value && !string.IsNullOrEmpty(selectedRow.Cells[10].Value.ToString()))
                {
                    customer.txtWorkersCount.Text = selectedRow.Cells[10].Value.ToString();
                }
                else
                {
                    customer.txtWorkersCount.Text = "";
                }

                customer.txtTaxRegistrationNumber.Text = selectedRow.Cells[11].Value?.ToString() ?? "";
                customer.txtTaxCardNumber.Text = selectedRow.Cells[12].Value?.ToString() ?? "";
                customer.txtOldSystemUserName.Text = selectedRow.Cells[13].Value?.ToString() ?? "";
                customer.txtOldSystemPassword.Text = selectedRow.Cells[14].Value?.ToString() ?? "";
                customer.txtOldSystemEmailPassword.Text = selectedRow.Cells[15].Value?.ToString() ?? "";
                customer.txtInvoiceEmailPassword.Text = selectedRow.Cells[16].Value?.ToString() ?? "";
                customer.txtFormationCode.Text = selectedRow.Cells[17].Value?.ToString() ?? "";
                customer.txtInsuranceFileNumber.Text = selectedRow.Cells[18].Value?.ToString() ?? "";
                customer.txtGOVSystemEmail.Text = selectedRow.Cells[19].Value?.ToString() ?? "";
                customer.txtGOVSystemPassword.Text = selectedRow.Cells[20].Value?.ToString() ?? "";
                customer.txtOldGOVSystemEmail.Text = selectedRow.Cells[21].Value?.ToString() ?? "";
                customer.txtOldInvoiceEmail.Text = selectedRow.Cells[22].Value?.ToString() ?? "";
                customer.txtSAPUserName.Text = selectedRow.Cells[23].Value?.ToString() ?? "";
                customer.txtSAPPassword.Text = selectedRow.Cells[24].Value?.ToString() ?? "";
                customer.btnUpdate.Enabled = true;
                customer.btnSave.Enabled = false;
                // Reset the filetext
                customer.filetext.Text = "";
                this.Close();

            }
        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
