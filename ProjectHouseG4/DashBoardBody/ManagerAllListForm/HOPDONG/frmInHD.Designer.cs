namespace RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG
{
    partial class frmInHD
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReportViewHDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongTro2DataSet = new RentHouse.QuanLyPhongTro2DataSet();
            this.quanLyPhongTro2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewHDTableAdapter = new RentHouse.QuanLyPhongTro2DataSetTableAdapters.ReportViewHDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ReportViewHDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportViewHDBindingSource
            // 
            this.ReportViewHDBindingSource.DataMember = "ReportViewHD";
            this.ReportViewHDBindingSource.DataSource = this.quanLyPhongTro2DataSet;
            // 
            // quanLyPhongTro2DataSet
            // 
            this.quanLyPhongTro2DataSet.DataSetName = "QuanLyPhongTro2DataSet";
            this.quanLyPhongTro2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyPhongTro2DataSetBindingSource
            // 
            this.quanLyPhongTro2DataSetBindingSource.DataSource = this.quanLyPhongTro2DataSet;
            this.quanLyPhongTro2DataSetBindingSource.Position = 0;
            // 
            // rptHD
            // 
            this.rptHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rptHD.DocumentMapWidth = 1;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportViewHDBindingSource;
            this.rptHD.LocalReport.DataSources.Add(reportDataSource1);
            this.rptHD.LocalReport.ReportEmbeddedResource = "RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG.ReportHD.rdlc";
            this.rptHD.Location = new System.Drawing.Point(0, 0);
            this.rptHD.Name = "rptHD";
            this.rptHD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rptHD.ServerReport.BearerToken = null;
            this.rptHD.Size = new System.Drawing.Size(1194, 1053);
            this.rptHD.TabIndex = 0;
            this.rptHD.Load += new System.EventHandler(this.rptHD_Load);
            // 
            // reportViewHDTableAdapter
            // 
            this.reportViewHDTableAdapter.ClearBeforeFill = true;
            // 
            // frmInHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 1055);
            this.Controls.Add(this.rptHD);
            this.Name = "frmInHD";
            this.Text = "In Hợp Đồng";
            this.Load += new System.EventHandler(this.frmInHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportViewHDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptHD;
        private System.Windows.Forms.BindingSource quanLyPhongTro2DataSetBindingSource;
        private QuanLyPhongTro2DataSet quanLyPhongTro2DataSet;
        private System.Windows.Forms.BindingSource ReportViewHDBindingSource;
        private QuanLyPhongTro2DataSetTableAdapters.ReportViewHDTableAdapter reportViewHDTableAdapter;
    }
}