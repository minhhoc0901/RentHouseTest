namespace RentHouse.DashBoardBody.ManagerAllListForm.HOADON
{
    partial class frmInHoaDon
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
            this.reportHoaDonBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongTro2DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyPhongTro2DataSet1 = new RentHouse.QuanLyPhongTro2DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportHoaDonTableAdapter = new RentHouse.QuanLyPhongTro2DataSet1TableAdapters.ReportHoaDonTableAdapter();
            this.ReportHoaDonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportHoaDonBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHoaDonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportHoaDonBindingSource1
            // 
            this.reportHoaDonBindingSource1.DataMember = "ReportHoaDon";
            this.reportHoaDonBindingSource1.DataSource = this.quanLyPhongTro2DataSet1BindingSource;
            // 
            // quanLyPhongTro2DataSet1BindingSource
            // 
            this.quanLyPhongTro2DataSet1BindingSource.DataSource = this.quanLyPhongTro2DataSet1;
            this.quanLyPhongTro2DataSet1BindingSource.Position = 0;
            // 
            // quanLyPhongTro2DataSet1
            // 
            this.quanLyPhongTro2DataSet1.DataSetName = "QuanLyPhongTro2DataSet1";
            this.quanLyPhongTro2DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.DocumentMapWidth = 1;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReportHoaDonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RentHouse.DashBoardBody.ManagerAllListForm.HOADON.ReportHoaDon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1085, 565);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // reportHoaDonTableAdapter
            // 
            this.reportHoaDonTableAdapter.ClearBeforeFill = true;
            // 
            // ReportHoaDonBindingSource
            // 
            this.ReportHoaDonBindingSource.DataMember = "ReportHoaDon";
            this.ReportHoaDonBindingSource.DataSource = this.quanLyPhongTro2DataSet1;
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 559);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInHoaDon";
            this.Text = "frmInHoaDon";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportHoaDonBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongTro2DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportHoaDonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QuanLyPhongTro2DataSet1 quanLyPhongTro2DataSet1;
        private System.Windows.Forms.BindingSource quanLyPhongTro2DataSet1BindingSource;
        private QuanLyPhongTro2DataSet1TableAdapters.ReportHoaDonTableAdapter reportHoaDonTableAdapter;
        private System.Windows.Forms.BindingSource reportHoaDonBindingSource1;
        private System.Windows.Forms.BindingSource ReportHoaDonBindingSource;
    }
}