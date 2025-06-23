namespace Accounting_System
{
    partial class ProceduresScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProceduresScreen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblSet = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label4 = new System.Windows.Forms.Label();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.Panel6 = new System.Windows.Forms.Panel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.Panel5.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1BindingSource)).BeginInit();
            this.Panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Panel2.Controls.Add(this.Label1);
            this.Panel2.Controls.Add(this.lblSet);
            this.Panel2.Location = new System.Drawing.Point(12, 9);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1136, 76);
            this.Panel2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(499, 18);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(180, 36);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "قائمة الأجراءات";
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(963, 34);
            this.lblSet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(27, 16);
            this.lblSet.TabIndex = 44;
            this.lblSet.Text = "Set";
            this.lblSet.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.dgw);
            this.Panel1.Controls.Add(this.Panel6);
            this.Panel1.Controls.Add(this.Panel4);
            this.Panel1.Controls.Add(this.Panel5);
            this.Panel1.Controls.Add(this.Panel3);
            this.Panel1.Controls.Add(this.Panel2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1164, 752);
            this.Panel1.TabIndex = 3;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.txtCategory);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel4.Location = new System.Drawing.Point(617, 92);
            this.Panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel4.Name = "Panel4";
            this.Panel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Panel4.Size = new System.Drawing.Size(245, 86);
            this.Panel4.TabIndex = 47;
            // 
            // txtCategory
            // 
            this.txtCategory.BackColor = System.Drawing.Color.White;
            this.txtCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtCategory.Location = new System.Drawing.Point(17, 39);
            this.txtCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(211, 30);
            this.txtCategory.TabIndex = 13;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.DarkBlue;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(17, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(212, 31);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "بحث بالفئة الرئيسية :";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel5
            // 
            this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.btnExportExcel);
            this.Panel5.Controls.Add(this.btnReset);
            this.Panel5.Location = new System.Drawing.Point(12, 94);
            this.Panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(344, 86);
            this.Panel5.TabIndex = 46;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(139, 15);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(196, 49);
            this.btnExportExcel.TabIndex = 6;
            this.btnExportExcel.Text = "تصدير للأكسل";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Firebrick;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(4, 15);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(127, 49);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "إعادة تعيين";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Panel3
            // 
            this.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel3.Controls.Add(this.txtProductName);
            this.Panel3.Controls.Add(this.Label3);
            this.Panel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel3.Location = new System.Drawing.Point(870, 92);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Panel3.Name = "Panel3";
            this.Panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Panel3.Size = new System.Drawing.Size(278, 86);
            this.Panel3.TabIndex = 45;
            // 
            // txtProductName
            // 
            this.txtProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtProductName.Location = new System.Drawing.Point(17, 38);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(241, 30);
            this.txtProductName.TabIndex = 13;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged_1);
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.BackColor = System.Drawing.Color.DarkBlue;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(17, 7);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(243, 31);
            this.Label3.TabIndex = 12;
            this.Label3.Text = "بحث باسم الاجراء :";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.DarkBlue;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(17, 7);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(212, 31);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "بحث بالفئة الفرعية :";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.BackColor = System.Drawing.Color.White;
            this.txtSubCategory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.txtSubCategory.Location = new System.Drawing.Point(17, 38);
            this.txtSubCategory.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.Size = new System.Drawing.Size(211, 30);
            this.txtSubCategory.TabIndex = 13;
            // 
            // Panel6
            // 
            this.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel6.Controls.Add(this.txtSubCategory);
            this.Panel6.Controls.Add(this.Label4);
            this.Panel6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Panel6.Location = new System.Drawing.Point(364, 92);
            this.Panel6.Margin = new System.Windows.Forms.Padding(4);
            this.Panel6.Name = "Panel6";
            this.Panel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Panel6.Size = new System.Drawing.Size(245, 86);
            this.Panel6.TabIndex = 48;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.PowderBlue;
            this.dgw.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgw.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgw.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgw.ColumnHeadersHeight = 35;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column8,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column19,
            this.dataGridViewTextBoxColumn8,
            this.Column18});
            this.dgw.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgw.EnableHeadersVisualStyles = false;
            this.dgw.GridColor = System.Drawing.Color.Gray;
            this.dgw.Location = new System.Drawing.Point(17, 199);
            this.dgw.Margin = new System.Windows.Forms.Padding(4);
            this.dgw.MultiSelect = false;
            this.dgw.Name = "dgw";
            this.dgw.ReadOnly = true;
            this.dgw.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgw.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgw.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.dgw.RowHeadersWidth = 25;
            this.dgw.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            this.dgw.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.dgw.RowTemplate.Height = 30;
            this.dgw.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.Size = new System.Drawing.Size(1131, 539);
            this.dgw.TabIndex = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "PID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 7;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "SID";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 9.352825F;
            this.dataGridViewTextBoxColumn2.HeaderText = "كود الاجراء";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 9.352825F;
            this.dataGridViewTextBoxColumn3.HeaderText = " الاجراء";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column19
            // 
            this.Column19.FillWeight = 20.52054F;
            this.Column19.HeaderText = "الخدمة الرئيسية";
            this.Column19.MinimumWidth = 3;
            this.Column19.Name = "Column19";
            this.Column19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 9.352825F;
            this.dataGridViewTextBoxColumn8.HeaderText = "الخدمة الفرعية";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // Column18
            // 
            dataGridViewCellStyle21.NullValue = null;
            this.Column18.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column18.FillWeight = 13.72957F;
            this.Column18.HeaderText = "التاريخ";
            this.Column18.MinimumWidth = 6;
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            // 
            // ProceduresScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1164, 752);
            this.Controls.Add(this.Panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ProceduresScreen";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.productRecord_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.Panel5.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1BindingSource)).EndInit();
            this.Panel6.ResumeLayout(false);
            this.Panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblSet;
        internal System.Windows.Forms.BindingSource DataSet1BindingSource;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.TextBox txtCategory;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.Button btnExportExcel;
        internal System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.TextBox txtProductName;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel6;
        internal System.Windows.Forms.TextBox txtSubCategory;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
    }
}