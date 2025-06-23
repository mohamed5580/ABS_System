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
using System.Transactions;
using System.Windows.Forms;

namespace Accounting_System
{
    public partial class ProcedureTrackingg : Form
    {
        public static ProcedureTrackingg instance;
        public ProcedureTrackingg()
        {
            InitializeComponent();
            instance = this;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProceduresScreen proceduresScreen = new ProceduresScreen();
            proceduresScreen.lblSet.Text = "PTracking";
            proceduresScreen.Show();
        }

        private void ProcedureTrackingg_Load(object sender, EventArgs e)
        {
            Reset();
            auto(); 
        }

        public void auto()
        {
            try
            {
                // Assuming txtID and txtInvoiceNo are on your form.
                // Use CustomerID as the ID for the Customer table.
                txtID.Text = GenerateID();

                // Since we want Invoice Number to be "Inv-XXXX", I can use CustomerID to get the same ID.
                txtInvoiceNo.Text = "PT-" + GenerateID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset()
        {
            // Clear all TextBox controls
      
            txtRemarks.Clear();
            txtID.Clear();
            txtCName.Clear();
            txtEmp.Clear();
            txtServCategory.Clear();
            txtSubServ.Clear();
            txtS.Clear();
            // Reset DateTimePicker to the current date
            dtpDate.Value = DateTime.Now;

            // Clear DataGridView rows
            DataGridView1.Rows.Clear();

           
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            auto();

        }
        private string GenerateID()
        {
            string value = "0000";
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                try
                {
                    // Fetch the latest ID from the database
                    con.Open();
                    string sql = $"SELECT ISNULL(MAX(TrackingID), 0) FROM ProcedureTracking ";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.HasRows)
                        {
                            rdr.Read();
                            value = rdr[0].ToString();
                        }
                    }
                    // we need to replace them. If necessary.
                    if (Convert.ToDouble(value) <= 9) // Value is between 0 and 10
                    {
                        value = "000" + value;
                    }
                    else if (Convert.ToDouble(value) <= 99) // Value is between 9 and 100
                    {
                        value = "00" + value;
                    }
                    else if (Convert.ToDouble(value) <= 999) // Value is between 999 and 1000
                    {
                        value = "0" + value;
                    }
                    // Increase the ID by 1
                    int numericValue = int.Parse(value);
                    numericValue += 1;
                    value = numericValue.ToString("D4"); // Ensure the string is padded with leading zeros if necessary
                }
                catch (Exception ex)
                {
                    // If an error occurs, set the value to "0000"
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    value = "0000";
                }
            }
            return value;
        }

        private void btnSelection_Click(object sender, EventArgs e)
        {
            servicesRecord services = new servicesRecord();
            services.lblSet.Text = "PTracking";
            services.Show();
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtProcedureID.Text))
                {
                    MessageBox.Show("الرجاء إدخال معرف الإجراء", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProcedureID.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtProductCode.Text))
                {
                    MessageBox.Show("الرجاء إدخال رمز المنتج", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductCode.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show("الرجاء إدخال اسم المنتج", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductName.Focus();
                    return;
                }
               
               
                DataGridView1.Rows.Add(txtProcedureID.Text, txtProductCode.Text, txtProductName.Text);
                DataGridView1.Enabled = true;

                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Clear()
        {
            txtProcedureID.Text ="";
            txtProductCode.Text ="";
            txtProductName.Text ="";
            btnSave.Enabled = true;

        }
        private void Search_Click(object sender, EventArgs e)
        {
            ProceduresScreen proceduresScreen = new ProceduresScreen();
            proceduresScreen.lblSet.Text = "PTracking";

            proceduresScreen.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation checks
                if (string.IsNullOrWhiteSpace(txtServiceID.Text))
                {
                    MessageBox.Show("الرجاء إدراج رقم الخدمة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceID.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
                {
                    MessageBox.Show("الرجاء كتابة رقم العملية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvoiceNo.Focus();
                    return;
                }

                if (DataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("يجب إضافة إجراءات أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    // Insert into ProcedureTracking table
                    string insertTrackingQuery = "INSERT INTO ProcedureTracking (ServiceID, TrackingCode, Notes, TrackingDate) " +
                                                 "OUTPUT INSERTED.TrackingID " +
                                                 "VALUES (@ServiceID, @TrackingCode, @Notes, @TrackingDate)";
                    int trackingID;
                    using (SqlCommand cmd = new SqlCommand(insertTrackingQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", txtS.Text);
                        cmd.Parameters.AddWithValue("@TrackingCode", txtInvoiceNo.Text);
                        cmd.Parameters.AddWithValue("@Notes", txtRemarks.Text);
                        cmd.Parameters.AddWithValue("@TrackingDate", dtpDate.Value.Date);

                        // Retrieve the newly inserted TrackingID
                        trackingID = (int)cmd.ExecuteScalar();
                    }

                    // Insert into ProceduresJoin table for each DataGridView row
                    string insertProcedureJoinQuery = "INSERT INTO ProceduresJoin (ProcedureID, ProcedureTID, ProcedureName, ProcedureCode, Done) " +
                                                      "VALUES (@ProcedureID, @ProcedureTID, @ProcedureName, @ProcedureCode, @Done)";
                    using (SqlCommand cmd = new SqlCommand(insertProcedureJoinQuery, con))
                    {
                        foreach (DataGridViewRow row in DataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@ProcedureTID", trackingID); // Use the retrieved TrackingID
                                cmd.Parameters.AddWithValue("@ProcedureID", Convert.ToInt32(row.Cells[0].Value));
                                cmd.Parameters.AddWithValue("@ProcedureCode", row.Cells[1].Value.ToString());
                                cmd.Parameters.AddWithValue("@ProcedureName", row.Cells[2].Value.ToString());
                                cmd.Parameters.AddWithValue("@Done", Convert.ToBoolean(row.Cells[3].Value));

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("تم الحفظ بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (DataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("يرجى تحديد العنصر المراد حذفه", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row
                DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                DataGridView1.Rows.Remove(selectedRow);
                // Ensure the required column values are not null
/*                if (selectedRow.Cells[0].Value == null || selectedRow.Cells[1].Value == null)
                {
                    MessageBox.Show("العنصر المحدد غير صالح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the ID of the item to be removed
                int procedureID = Convert.ToInt32(selectedRow.Cells[0].Value);
                string procedureTID = txtID.Text; // Assuming txtID contains the TrackingID

                // Confirm deletion
                var confirmResult = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العنصر؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }

                // Remove from database
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM ProceduresJoin WHERE ProcedureID = @ProcedureID AND ProcedureTID = @ProcedureTID";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProcedureID", procedureID);
                        cmd.Parameters.AddWithValue("@ProcedureTID", procedureTID);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Remove from DataGridView
                DataGridView1.Rows.Remove(selectedRow);

                MessageBox.Show("تم حذف العنصر بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        Clear();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServiceID.Text))
                {
                    MessageBox.Show("الرجاء إدراج رقم الخدمة", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceID.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
                {
                    MessageBox.Show("الرجاء كتابة رقم العملية", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtInvoiceNo.Focus();
                    return;
                }

                if (DataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("يجب إضافة إجراءات أولاً", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Check if ProcedureTracking exists
                            string checkQuery = "SELECT COUNT(*) FROM ProcedureTracking WHERE TrackingID = @TrackingID";
                            int count;
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@TrackingID", txtID.Text);
                                count = (int)checkCmd.ExecuteScalar();
                            }

                            if (count == 0)
                            {
                                // Insert ProcedureTracking
                                string insertTrackingQuery = "INSERT INTO ProcedureTracking (TrackingID, ServiceID, TrackingCode, Notes, TrackingDate) " +
                                                             "VALUES (@TrackingID, @ServiceID, @TrackingCode, @Notes, @TrackingDate)";
                                using (SqlCommand insertCmd = new SqlCommand(insertTrackingQuery, con, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@TrackingID", txtID.Text);
                                    insertCmd.Parameters.AddWithValue("@ServiceID", txtS.Text);
                                    insertCmd.Parameters.AddWithValue("@TrackingCode", txtInvoiceNo.Text);
                                    insertCmd.Parameters.AddWithValue("@Notes", txtRemarks.Text);
                                    insertCmd.Parameters.AddWithValue("@TrackingDate", dtpDate.Value.Date);

                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Update ProcedureTracking
                                string updateTrackingQuery = "UPDATE ProcedureTracking SET " +
                                                             "ServiceID = @ServiceID, TrackingCode = @TrackingCode, Notes = @Notes, TrackingDate = @TrackingDate " +
                                                             "WHERE TrackingID = @TrackingID";

                                using (SqlCommand updateCmd = new SqlCommand(updateTrackingQuery, con, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@ServiceID", txtS.Text);
                                    updateCmd.Parameters.AddWithValue("@TrackingCode", txtInvoiceNo.Text);
                                    updateCmd.Parameters.AddWithValue("@Notes", txtRemarks.Text);
                                    updateCmd.Parameters.AddWithValue("@TrackingDate", dtpDate.Value.Date);
                                    updateCmd.Parameters.AddWithValue("@TrackingID", txtID.Text);

                                    updateCmd.ExecuteNonQuery();
                                }
                            }

                            // Delete related records from ProceduresJoin
                            string deleteProceduresJoinQuery = "DELETE FROM ProceduresJoin WHERE ProcedureTID = @ProcedureTID";
                            using (SqlCommand deleteCmd = new SqlCommand(deleteProceduresJoinQuery, con, transaction))
                            {
                                deleteCmd.Parameters.AddWithValue("@ProcedureTID", txtID.Text);
                                deleteCmd.ExecuteNonQuery();
                            }

                            // Insert ProceduresJoin
                            string insertProcedureJoinQuery = @"
                        INSERT INTO ProceduresJoin (ProcedureID, ProcedureTID, ProcedureName, ProcedureCode, Done)
                        VALUES (@ProcedureID, @ProcedureTID, @ProcedureName, @ProcedureCode, @Done)";

                            using (SqlCommand insertCmd = new SqlCommand(insertProcedureJoinQuery, con, transaction))
                            {
                                foreach (DataGridViewRow row in DataGridView1.Rows)
                                {
                                    if (!row.IsNewRow)
                                    {
                                        insertCmd.Parameters.Clear();

                                        insertCmd.Parameters.AddWithValue("@ProcedureTID", txtID.Text);
                                        insertCmd.Parameters.AddWithValue("@ProcedureID", Convert.ToInt32(row.Cells[0].Value));
                                        insertCmd.Parameters.AddWithValue("@ProcedureCode", row.Cells[1].Value?.ToString());
                                        insertCmd.Parameters.AddWithValue("@ProcedureName", row.Cells[2].Value?.ToString());
                                        insertCmd.Parameters.AddWithValue("@Done", Convert.ToBoolean(row.Cells[3].Value));

                                        insertCmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            transaction.Commit();

                            MessageBox.Show("تم التحديث بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Enabled = false;
                            Reset();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + "\n" + ex.StackTrace, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnGetData_Click(object sender, EventArgs e)
        {
            ProcedureTrackinggScreen procedureTrackinggScreen = new ProcedureTrackinggScreen();
            procedureTrackinggScreen.lblSet.Text = "PTracking";

            procedureTrackinggScreen.Show();    
        }

        private void txtProcedureID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        private void DeleteRecord()
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            // Delete related records from ProceduresJoin if they exist
                            string deleteProceduresJoinQuery = "DELETE FROM ProceduresJoin WHERE ProcedureTID = @ServiceID";
                            using (SqlCommand cmd = new SqlCommand(deleteProceduresJoinQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ServiceID", txtID.Text.Trim());
                                cmd.ExecuteNonQuery();
                            }

                            // Delete record from Procedures
                            string deleteQuery = "DELETE FROM ProcedureTracking WHERE TrackingID = @ServiceID";
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@ServiceID", txtID.Text.Trim());
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No record found with the given ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            // Commit transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction on error
                            transaction.Rollback();
                            throw; // Re-throw to be caught by outer catch block
                        }
                    }
                }

                // Reset the form fields after deletion
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();    
        }

        private void DataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (DataGridView1.CurrentRow != null && !DataGridView1.CurrentRow.IsNewRow)
                {
                    // Retrieve data from the selected row
                    txtProcedureID.Text = DataGridView1.CurrentRow.Cells[0].Value?.ToString();
                    txtProductCode.Text = DataGridView1.CurrentRow.Cells[1].Value?.ToString();
                    txtProductName.Text = DataGridView1.CurrentRow.Cells[2].Value?.ToString();
                    // Enable buttons for editing or deleting
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnRemove.Enabled = true;
                    
                }
                else
                {
                    MessageBox.Show("Please select a valid row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
