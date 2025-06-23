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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting_System
{
    public partial class basic : Form
    {
        
        public static TimeZoneInfo egyptTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
        public static DateTime egyptTime = TimeZoneInfo.ConvertTime(DateTime.Now, egyptTimeZone);
        public static basic instance;
        public basic()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(frmMain_FormClosed);
            instance = this;
        }
        
        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {

        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void gunaGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton9_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton5_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton6_Click(object sender, EventArgs e)
        {

        }

        private void gunaImageButton7_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void gunaAdvenceButton28_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }




        private void basic_Load(object sender, EventArgs e)
        {
            timer5.Start();
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);

        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            // Check if tabPage2 is already added
            if (!tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Add(tabPage1); // Add tabPage2 if it’s not already added
            }

            tabControl1.SelectedTab = tabPage1; // Select tabPage2

        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
        }

        private void btnProductMaster_Click(object sender, EventArgs e)
        {
            /*// Check if tabPage2 is already added
            if (!tabControl1.TabPages.Contains(tabPage2))
            {
                tabControl1.TabPages.Add(tabPage2); // Add tabPage2 if it’s not already added
            }

            tabControl1.SelectedTab = tabPage2; // Select tabPage2*/
            services services = new services();
            services.Show();
        
        }


        private void btnBankReconciliation_Click(object sender, EventArgs e)
        {

        }

        private void btnBarcodeLabelPrinting_Click(object sender, EventArgs e)
        {
           
        }



        private void btnPayment_Click(object sender, EventArgs e)
        {

        }

        private void btnStockTransfer_Issue_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountingReports_Click(object sender, EventArgs e)
        {


        }

        private void btnPOSReport_Click(object sender, EventArgs e)
        {

        }

        private void BtnVoucher_Click(object sender, EventArgs e)
        {
         
        }

        private void btnPOSReport_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPayment_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnBankReconciliation_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btnStockTransfer_Issue_Click_1(object sender, EventArgs e)
        {
        
        }

        private void btnAccountingReports_Click_1(object sender, EventArgs e)
        {
          
        }

        private void btnWorkPeriod_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPOSRecord_Click(object sender, EventArgs e)
        {
         
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();


            customer.Show();

        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();


            customer.Show();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {

        }

        private void قائمةعروضالاسعارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountsScreen accounts = new AccountsScreen();
            accounts.Show();
        }

        private void مبيعاتكلصنفToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void احصائياتعامةToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Logs logs = new Logs();
            logs.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
          
        }

        private void المشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeServicesReport employeeServicesReport = new EmployeeServicesReport();
            employeeServicesReport.Show();

        }

        private void الأرباحToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void ارصدةالزبائنالجميعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DebtorsReport debtorsReport = new DebtorsReport();
            debtorsReport.Show();
        }

        private void التقريرالعامToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void كشفحسابمندوبToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void حالةالمخزونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServicesReport servicesReport = new ServicesReport();
            servicesReport.Show();
        }

        private void المصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeVoucherReport employeeVoucherReport = new EmployeeVoucherReport();
            employeeVoucherReport.Show();   
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void يوميةالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void كشفحسابتاجرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoucherReport voucherReport = new VoucherReport();
            voucherReport.Show();
        }

        private void كشفحسابعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerLedger customerLedger = new CustomerLedger();
            customerLedger.Show();

        }

        private void كشفمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void التقريرالعامToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void جهاتالاتصالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            company.Show();

        }

        private void الشركىToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void عنالشركهToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void المبرمجينToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void الالهالحاسبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\calc.exe");
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {


        }

        private void btnCreditCustomer_Click(object sender, EventArgs e)
        {

            Customer customer = new Customer() ;


            customer.Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnSalesmanMaster_Click(object sender, EventArgs e)
        {

        }

        private void btnWallet_Click(object sender, EventArgs e)
        {
        
            if (!tabControl1.TabPages.Contains(tabPage3))
            {
                tabControl1.TabPages.Add(tabPage3); // Add tabPage2 if it’s not already added
            }

            tabControl1.SelectedTab = tabPage3; // Select tabPage2

            // Check if the Products control is already added to panel1
            if (!panel1.Controls.OfType<Employee>().Any())
            {

                Employee productsControl = new Employee() { TopLevel = false, TopMost = true };

                // Clear existing controls in panel1 if needed
                panel5.Controls.Clear();

                // Add the productsControl to panel1 and set its Dock property to fill the panel
                productsControl.Dock = DockStyle.Fill;
                productsControl.FormBorderStyle = FormBorderStyle.None;
                panel5.Controls.Add(productsControl); // Add the control to the 
                productsControl.Show();
            }

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
         
        }

        private void btnSalesReturn_Click(object sender, EventArgs e)
        {
           

        }

        private void btnPurchaseReturn_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem23_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
           
        }

        private void مرتجعمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerList customerList = new CustomerList();
            customerList.Show();

        }

        private void قائمةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void استيردظتصديرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            CustomerList customerList = new CustomerList();
            customerList.Show();

        }

        private void قائمةمناديبالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeScreen employeeScreen = new EmployeeScreen();   
            employeeScreen.Show();
        }

        private void قائمةالاصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            servicesRecord servicesRecord = new servicesRecord();
            servicesRecord.Show();  
        }

        private void قائمةالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProceduresScreen proceduresScreen = new ProceduresScreen();
            proceduresScreen.Show();    
        }

        private void قائمةدفعاتالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcedureTrackinggScreen procedureTrackinggScreen = new ProcedureTrackinggScreen();
            procedureTrackinggScreen.Show();
        }

        private void قائمةفواتيرالشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void قائمةفواتيرالبيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
 
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            users users = new users();
            users.Show();

        }

        private void دفتراليوميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralDayBook generalDayBook = new GeneralDayBook();
            generalDayBook.Show();
        }

        private void الاشعاراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void نسخاحطياتيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }
        public void Backup()
        {
            try
            {
                string backupDirectory = @"C:\Backups";
                if (!Directory.Exists(backupDirectory))
                {
                    Directory.CreateDirectory(backupDirectory);
                }

                string fileName = $"{Accounting_System.Properties.Settings.Default.Database}_{DateTime.Now:dd-MM-yyyy}.bak";
                string destPath = Path.Combine(backupDirectory, fileName);

                using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
                {
                    con.Open();
                    string cb = $@"BACKUP DATABASE [{Accounting_System.Properties.Settings.Default.Database}] TO DISK = '{destPath}' WITH INIT, STATS=10";
                    using (SqlCommand cmd = new SqlCommand(cb, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Backup created successfully at {destPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void نسخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string backupPath = "";

            // استخدام OpenFileDialog لاختيار ملف النسخة الاحتياطية
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
                openFileDialog.Title = "اختر ملف النسخة الاحتياطية";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    backupPath = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("لم يتم تحديد ملف النسخة الاحتياطية.");
                    return;
                }
            }

            // أمر الاستعادة
            string restoreQuery = $@"
            RESTORE DATABASE [sa]
            FROM DISK = '{backupPath}'
            WITH REPLACE;
        ";

            try
            {
                // الاتصال وتنفيذ أمر الاستعادة
                using (SqlConnection connection = new SqlConnection(DataAccessLayer.Con()))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(restoreQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("تم استعادة النسخة الاحتياطية بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء استعادة النسخة الاحتياطية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void LogFunc(string st1, string st2)
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                string cb = "INSERT INTO Logs(UserID, Date, Operation) VALUES (@d1, @d2, @d3)";
                using (var cmd = new SqlCommand(cb, con))
                {
                    cmd.Parameters.AddWithValue("@d1", st1);
                    cmd.Parameters.AddWithValue("@d2", DateTime.Now);
                    cmd.Parameters.AddWithValue("@d3", st2);
                    cmd.ExecuteReader();
                }
            }
        }

        private void وتسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        

        private void النقلبينالمخازنToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            var dt = DateTime.Today;
            lblDateTime.Text = dt.ToString("dd/MM/yyyy");
            lblTime.Text = DateAndTime.TimeOfDay.ToString("h:mm:ss tt");
            ShowLogs();
        }
        public void ShowLogs()
        {
            using (SqlConnection con = new SqlConnection(DataAccessLayer.Con()))
            {
                con.Open();
                // Query to get the most recent log entry
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 RTRIM(Operation) FROM Logs ORDER BY Date DESC", con))
                {
                    using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (rdr.Read()) // Move to the first record
                        {
                            Notification.Text = rdr[0].ToString(); // Access the first column value
                        }
                        else
                        {
                            Notification.Text = "No logs found"; // Handle the case where there are no records
                        }
                    }
                }
            }

        }


        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void اصنافالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void اصنافالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Voucher voucher = new Voucher();
            voucher.Show();
        }

        private void ميزاالمراجعةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void شروطالائتمانللزبائنToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void lblDateTime_Click(object sender, EventArgs e)
        {

        }

        private void basic_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Show a confirmation dialog when attempting to close the program
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user chooses 'No', cancel the close event
            if (result == DialogResult.No)
            {
                e.Cancel = true; // This cancels the close
            }
        }

        private void مباعاتكلعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void اصنافمبيعاتكلعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            Procedures procedures = new Procedures();
            procedures.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ProceduresScreen procedures = new ProceduresScreen();
            procedures.Show();
        }

        private void ارصدةالمخزنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ProcedureTrackingg procedureTrackingg = new ProcedureTrackingg();
            procedureTrackingg.Show();
        }

        private void تسجيلخدمةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            services services = new services();
            services.Show();
        }

        private void قائمةالخدماتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            servicesRecord servicesRecord = new servicesRecord();   
            servicesRecord.Show();  
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Procedures procedures = new Procedures();
            procedures.Show();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            EmployeeVoucher employeevoucher = new EmployeeVoucher();
            employeevoucher.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Accounts accounts = new Accounts();
            accounts.Show();    
        }

        private void متابعةالاجراءاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcedureTrackingg ProcedureTrackingg = new ProcedureTrackingg();
            ProcedureTrackingg.Show();
        }

        private void قائمةالخدماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeVoucherScreen emp=new EmployeeVoucherScreen();
            emp.Show();
        }

        private void قائمةفواتيرالخدماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoucherRecord voucherRecord = new VoucherRecord();
            voucherRecord.Show();   
        }
    }
}