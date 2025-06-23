using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Pharmacy.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_System
{
    public partial class Employee : Form
    {
        SqlConnection cn = new SqlConnection(DataAccessLayer.Con());
        public static Employee _instance;
        public static Employee instance;
        public static Employee Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Employee();
                }
                return _instance;
            }

        }

        public Employee()
        {
            InitializeComponent();
            instance=this;
        }
        public static class SessionData
        {
            public static string EmployeeName { get; set; }
            public static string SalesManName { get; set; }
        }
        public void LoadEmployeeData(string id)
        {
            // Fetch Employee data by ID and populate fields
            try
            {
                string query = "SELECT * FROM [dbo].[Employees] WHERE ID = @ID";
                SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int) { Value = id } };

                if (DataAccessLayer.ExecuteTable(query, CommandType.Text, parameters).Rows.Count > 0)
                {
                    DataRow row = DataAccessLayer.ExecuteTable(query, CommandType.Text, parameters).Rows[0];

                    txtEmployeeID.Text = row["رقم الموظف"].ToString();
                    txtEmployeeName.Text = row["اسم الموظف"].ToString();
                    rbMale.Checked = row["Gender"].ToString() == "Male";
                    rbFemale.Checked = row["Gender"].ToString() == "Female";
                    txtAddress.Text = row["Address"].ToString();
              
                    // Handle image loading if required
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        public void LogFunc(string st1, string st2)
        {
            try
            {
                DataAccessLayer.cn.Open();

                string cb = "INSERT INTO Logs(UserID, Date, Operation) VALUES (@d1, @d2, @d3)";
                using (SqlCommand cmd = new SqlCommand(cb, DataAccessLayer.cn))
                {
                    cmd.Parameters.AddWithValue("@d1", st1);
                    cmd.Parameters.AddWithValue("@d2", DateTime.Now);
                    cmd.Parameters.AddWithValue("@d3", st2);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataAccessLayer.cn.Close();
            }

        }

        public void LedgerSave(DateTime a, string b, string c, string d, decimal e, decimal f, string g, string h)
        {
            try
            {
                DataAccessLayer.cn.Open();
                string cb = "INSERT INTO LedgerBook(Date, Name, LedgerNo, Label, Debit, Credit, PartyID, Manual_Inv) VALUES (@d1, @d2, @d3, @d4, @d5, @d6, @d7, @d8)";
                using (SqlCommand cmd = new SqlCommand(cb, DataAccessLayer.cn))
                {
                    cmd.Parameters.AddWithValue("@d1", a);
                    cmd.Parameters.AddWithValue("@d2", b);
                    cmd.Parameters.AddWithValue("@d3", c);
                    cmd.Parameters.AddWithValue("@d4", d);
                    cmd.Parameters.AddWithValue("@d5", e);
                    cmd.Parameters.AddWithValue("@d6", f);
                    cmd.Parameters.AddWithValue("@d7", g);
                    cmd.Parameters.AddWithValue("@d8", h);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataAccessLayer.cn.Close();
            }
        }

        public void FillState()
        {
            try
            {
                DataAccessLayer.cn.Open();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT DISTINCT RTRIM(State) FROM Employee ORDER BY 1", DataAccessLayer.cn);
                DataSet ds = new DataSet("ds");
                adp.Fill(ds);
                System.Data.DataTable dtable = ds.Tables[0];
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DataAccessLayer.cn.Close();
            }
        }
        public void Reset()
        {
            rbMale.Checked = true;

            txtID.Text = GenerateID();
            txtEmployeeID.Text = "E-" + GenerateID();
            txtEmployeeName.Text = "";
            txtAddress.Text = "";
            txtEmployeeID.Text = "";
            txtEmployeeName.Focus();
            auto();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    string sql = $"SELECT ISNULL(MAX(EmployeeID), 0) FROM Employees";
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
        private void auto()
        {
            try
            {
                txtID.Text = GenerateID();
                txtEmployeeID.Text = "E-" + GenerateID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void button8_Click_1(object sender, EventArgs e)
        {
            lblUser.Text = "admin"; // Example user, adjust as needed

            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                rbMale.Checked = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("الرجاء كتابة العنوان", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الهاتف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string sql = @"
                        INSERT INTO Employees
                        (
                            EmployeeName,
                            EmployeeCode,
                            PhoneNumber,
                            Address,
                            Gender
                        )
                        VALUES
                        (
                            @EmployeeName,
                            @EmployeeCode,
                            @PhoneNumber,
                            @Address,
                            @Gender
                        );
                    ";
                    string gender = rbMale.Checked ? rbMale.Text : rbFemale.Text;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add Parameters to avoid SQL injection and ensure correct data types.
                        command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                        command.Parameters.AddWithValue("@EmployeeCode", txtEmployeeID.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@Gender", gender); // Added Gender
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("تمت الاضافه ينجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           
  
        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

            if (basic.instance.tabControl1.SelectedTab != null)
            {
                basic.instance.tabControl1.TabPages.Remove(basic.instance.tabControl1.SelectedTab);

                // Optionally select the next tab if it exists
                if (basic.instance.tabControl1.TabPages.Count > 0)
                {
                    basic.instance.tabControl1.SelectedIndex = 0;
                }
            }

        }
        public void LedgerUpdate(DateTime a, string b, decimal e, decimal f, string g, string h, string i)
        {
            cn.Open();
            string cb = "Update LedgerBook set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,PartyID=@d5 where LedgerNo=@d6 and Label=@d7";
            SqlCommand cmd = new SqlCommand(cb);
            cmd.Parameters.AddWithValue("@d1", a);
            cmd.Parameters.AddWithValue("@d2", b);
            cmd.Parameters.AddWithValue("@d3", e);
            cmd.Parameters.AddWithValue("@d4", f);
            cmd.Parameters.AddWithValue("@d5", g);
            cmd.Parameters.AddWithValue("@d6", h);
            cmd.Parameters.AddWithValue("@d7", i);
            cmd.Connection = cn;
            cmd.ExecuteReader();
            cn.Close();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            string gender = "";

            // Validation checks
            if (string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("الرجاء كتابة اسم الموظف", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
                return;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("الرجاء اختيار النوع", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("الرجاء كتابة العنوان", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("الرجاء كتابة رقم الهاتف.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }


            if (Convert.ToInt32(txtID.Text) <= 0)
            {
                MessageBox.Show("Please, ادخل رقم الموظف", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
               string genderr = rbMale.Checked ? rbMale.Text : rbFemale.Text;
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();
                    string sql = @"
                        UPDATE Employees
                        SET
                            EmployeeName = @EmployeeName,
                            EmployeeCode =@EmployeeCode,
                            PhoneNumber = @PhoneNumber,
                            Address = @Address,
                            Gender = @Gender
                        WHERE EmployeeID = @EmployeeID
                    ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add Parameters to avoid SQL injection and ensure correct data types.
                        command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                        command.Parameters.AddWithValue("@EmployeeCode", txtEmployeeID.Text);
                        
                        command.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@Gender", genderr); // Added Gender
                        command.Parameters.AddWithValue("@EmployeeID", txtID.Text); // EmployeeID to identify which record to update
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("تم التعديل بنجاح", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtOpeningBalance_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                string deleteQuery = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                using (SqlConnection cn = new SqlConnection(DataAccessLayer.Con()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, cn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", txtID.Text);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                }

                MessageBox.Show("تم الحذف بنجاح.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لا يمكن حزف هذا الموظف لانه يوجد له سجل خدمات.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void BStartCapture_Click(object sender, EventArgs e)
        {
           

        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeScreen Employees = new EmployeeScreen();
            Employees.lblSet.Text = "Employee Entry";
            Employees.ShowDialog();
        }

        private void AddEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employee_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
