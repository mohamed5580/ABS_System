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

namespace Accounting_System
{
    public partial class GeneralDayBook : Form
    {
        SqlConnection con = new SqlConnection(DataAccessLayer.Con());
        public GeneralDayBook()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Reset()
        {
            dtpDateFrom.Text = DateTime.Today.ToString();
            dtpDateTo.Text = DateTime.Today.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal inSum =0;
                decimal outSum = 0;
                decimal inSum1 = 0;
                decimal outSum1 = 0;

                frmReport frmReport = new frmReport();
                DataTable dtable = new DataTable(); 

                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT Date, Name, LedgerNo, Label, Credit, Debit \r\nFROM LedgerBook \r\nWHERE Date BETWEEN @d1 AND @d2 \r\n  AND Credit <> 0 \r\nORDER BY Date;", con);
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dtable); // Fill the declared dtable
                }
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(Credit) AS InSum
                    FROM LedgerBook
                    WHERE Date BETWEEN @d1 AND @d2 AND Credit > 0 ", con);

                    // Set parameters for date range
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                    object result = cmd.ExecuteScalar(); 

 
                    if (result != DBNull.Value)
                    {
                       inSum = Convert.ToDecimal(result);
                    }
                }
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(Credit) AS OutSum
                    FROM LedgerBook
                    WHERE Date BETWEEN @d1 AND @d2 AND Credit < 0", con);

                    // Set parameters for the date range
                    cmd.Parameters.Add("@d1", SqlDbType.DateTime).Value = dtpDateFrom.Value.Date;
                    cmd.Parameters.Add("@d2", SqlDbType.DateTime).Value = dtpDateTo.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                    object result = cmd.ExecuteScalar(); 


                    if (result != DBNull.Value)
                    {
                        outSum = Convert.ToDecimal(result);
                    }
                }
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(Credit) AS InSum
                    FROM LedgerBook WHERE  Credit > 0  ", con);

                    // Set parameters for date range

                    object result = cmd.ExecuteScalar();


                    if (result != DBNull.Value)
                    {
                        inSum1 = Convert.ToDecimal(result);
                    }
                }
                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();


                    SqlCommand cmd = new SqlCommand(@"
                    SELECT SUM(Credit) AS OutSum
                    FROM LedgerBook WHERE  Credit < 0 ", con);

                    // Set parameters for the date range

                    object result = cmd.ExecuteScalar();


                    if (result != DBNull.Value)
                    {
                        outSum1 = Convert.ToDecimal(result);
                    }
                }




                DataSet ds = new DataSet();
                ds.Tables.Add(dtable);
                ds.WriteXmlSchema("GeneralDayBook.xml");

                rptGeneralDayBook rpt = new rptGeneralDayBook();
                rpt.SetDataSource(ds);


                rpt.SetParameterValue("My Parameter", inSum);
                rpt.SetParameterValue("Out", Math.Abs(outSum));
                rpt.SetParameterValue("insum1", inSum1);
                rpt.SetParameterValue("outsum1",Math.Abs(outSum1));
                rpt.SetParameterValue("p1", dtpDateFrom.Value.Date);
                rpt.SetParameterValue("p3", dtpDateTo.Value.Date);

                frmReport.crystalReportViewer1.ReportSource = rpt;
                frmReport.ShowDialog();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void GeneralDayBook_Load(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
