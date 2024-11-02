using Microsoft.Reporting.WinForms;
using RentHouse_BUS;
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentHouse.DashBoardBody.ManagerAllListForm.HOPDONG
{
    public partial class frmInHD : Form
    {
        ChiTietHopDongService busHD = new ChiTietHopDongService();
        public string SoHopDong;
        public frmInHD(string soHopDong)
        {
            InitializeComponent();
            SoHopDong = soHopDong;
        }

        private void frmInHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyPhongTro2DataSet.ReportViewHD' table. You can move, or remove it, as needed.
            this.reportViewHDTableAdapter.Fill(this.quanLyPhongTro2DataSet.ReportViewHD);
            // TODO: This line of code loads data into the 'quanLyPhongTro2DataSet.ReportViewHD' table. You can move, or remove it, as needed.
            //this.reportViewHDTableAdapter.Fill(this.quanLyPhongTro2DataSet.ReportViewHD);
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = new PaperSize("A4", 940, 1800); // Kích thước A4
            pageSettings.Margins = new Margins(10, 25, 25, 25); // Lề: 50px

            // Áp dụng thuộc tính trang cho báo cáo
            this.rptHD.SetPageSettings(pageSettings);

            this.rptHD.RefreshReport();
        }

        private void rptHD_Load(object sender, EventArgs e)
        {
            var ds = busHD.GetAllChiTietHopDong();
            var CTHD = from hd in ds
                       where hd.SoHopDong .Equals(SoHopDong)
                       select new
                       {
                           hd.SoHopDong,
                           hd.HopDong.NgayLapHD,
                           hd.PhongTro.MaPhong,
                           hd.HopDong.TienCoc,
                           hd.HopDong.KhachThue.MaKH,
                           hd.HopDong.KhachThue.HoTen,
                           hd.HopDong.KhachThue.CCCD,
                           hd.HopDong.KhachThue.DiaChi,
                           hd.HopDong.KhachThue.SDT,
                           hd.NgayBatDau,
                           hd.NgayKetThuc,
                           hd.GiaThue,


                       };
            rptHD.LocalReport.ReportPath = @"C:\Users\admin\Desktop\HG4\RentHouseTest\ProjectHouseG4\DashBoardBody\ManagerAllListForm\HOPDONG\ReportHD.rdlc";
            var sourcecthd = new ReportDataSource("DataSet1", CTHD);
            rptHD.LocalReport.DataSources.Clear();
            rptHD.LocalReport.DataSources.Add(sourcecthd);
            
            rptHD.RefreshReport();

        }



    }
}
