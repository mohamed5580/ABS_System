using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Pharmacy.DL;
using System.Xml.Linq;

namespace Accounting_System
{
    public partial class VoucherReport : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public VoucherReport()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    
        public void Reset()
        {
            dtpDateFrom.Text = DateTime.Today.ToString();
            dtpDateTo.Text = DateTime.Today.ToString();
            // FillSalesman();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
          

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            try
            {


                rptVoucher2 rpt = new rptVoucher2(); // The report you created.
                using (SqlConnection myConnection = new SqlConnection(DataAccessLayer.Con()))
                {
                    SqlCommand MyCommand = new SqlCommand();
                    SqlCommand MyCommand1 = new SqlCommand();
                    SqlDataAdapter myDA = new SqlDataAdapter();
                    SqlDataAdapter myDA1 = new SqlDataAdapter();
                    DataSet myDS = new DataSet(); // The DataSet you created.

                    MyCommand.Connection = myConnection;
                    MyCommand1.Connection = myConnection;

                    MyCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID, Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID WHERE Name = @Name";
                    MyCommand1.CommandText = "SELECT * FROM Company";

                    MyCommand.CommandType = CommandType.Text;
                    MyCommand1.CommandType = CommandType.Text;


                    myDA.SelectCommand = MyCommand;
                    myDA1.SelectCommand = MyCommand1;

                    myConnection.Open();
                    myDA.Fill(myDS, "Voucher");
                    myDA.Fill(myDS, "Voucher_OtherDetails");
                    myDA1.Fill(myDS, "Company");

                    rpt.SetDataSource(myDS);

                    frmReport reportForm = new frmReport();
                    reportForm.crystalReportViewer1.ReportSource = rpt;
                    reportForm.ShowDialog();
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
                string query = @"
        SELECT 
            v.Id ,
            v.VoucherNo AS VCode,
            v.Name AS AccountName ,
            v.Code AS AccountCode,
            v.Date AS Status,
            v.Details AS AccountDetiles,
            v.GrandTotal AS Total
        FROM 
            [dbo].[Voucher] v
        WHERE 
            v.Date BETWEEN @d1 AND @d2
        ORDER BY v.Date";

                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@d1", dtpDateFrom.Value.Date);  // Replace with your date picker controls
                    cmd.Parameters.AddWithValue("@d2", dtpDateTo.Value.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable("AccountVoucher");
                    da.Fill(dt);

                    connection.Close();

                    // Set up the report
                    rptAccountsVoucherReport rpt = new rptAccountsVoucherReport();
                    rpt.SetDataSource(dt);

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
             
        }

        private void cmbVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
