using Microsoft.Reporting.WinForms;
using RenHouse_BUS;
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

namespace RentHouse.DashBoardBody.ManagerAllListForm.HOADON
{
    public partial class frmInHoaDon : Form
    {
        ChiTietHoaDonService busHoaDon = new ChiTietHoaDonService();
        public int IDHD;
        public frmInHoaDon(int iDHD)
        {
            InitializeComponent();
            IDHD = iDHD;
        }

        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyPhongTro2DataSet1.ReportHoaDon' table. You can move, or remove it, as needed.
            this.reportHoaDonTableAdapter.Fill(this.quanLyPhongTro2DataSet1.ReportHoaDon);

            // TODO: This line of code loads data into the 'quanLyPhongTro2DataSet1.ReportHoaDon' table. You can move, or remove it, as needed.
            //this.reportHoaDonTableAdapter.Fill(this.quanLyPhongTro2DataSet1.ReportHoaDon);


            // Áp dụng thuộc tính trang cho báo cáo
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = new PaperSize("A", 900, 1000); // Kích thước 
            pageSettings.Margins = new Margins(25, 25, 25, 15); // Lề: 50px

            // Áp dụng thuộc tính trang cho báo cáo
            this.reportViewer1.SetPageSettings(pageSettings);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            var ds = busHoaDon.GetAllCTHoaDon();
            var groupedCTHoaDon = ds
                .Where(hoadon => hoadon.IDHD.Equals(IDHD))
                .GroupBy(hoadon => hoadon.IDHD)
                .Select(group => new
                {
                    IDHD = group.Key,
                    MaCTHD = group.First().HoaDon.MaCTHD,
                    HoTen = group.First().HoaDon.ChiTietHopDong.HopDong.KhachThue.HoTen,
                    MaPhong = group.First().HoaDon.ChiTietHopDong.PhongTro.MaPhong,
                    GiaPhong = group.First().HoaDon.ChiTietHopDong.PhongTro.GiaPhong,
                    GiaTien = string.Join("\n", group.Select(ct => ct.GiaTien)),
                    NgayLap = group.First().HoaDon.NgayLap,
                    TienGiam = group.First().HoaDon.TienGiam,
                    TienPhat = group.First().HoaDon.TienPhat,
                    GiaThue = group.First().HoaDon.ChiTietHopDong.GiaThue,
                    SoTienTra = group.First().HoaDon.SoTienTra,
                    TongTien = group.First().HoaDon.TongTien,
                    MaDV = string.Join("\n", group.Select(ct => ct.DichVu.MaDV)),
                    TenDV = string.Join("\n", group.Select(ct => ct.DichVu.TenDV))
                });

            reportViewer1.LocalReport.ReportPath = @"C:\\Users\\admin\\Desktop\\HG4\\RentHouseTest\\ProjectHouseG4\\DashBoardBody\\ManagerAllListForm\\HOADON\\ReportHoaDon.rdlc";
            var sourceCTHoaDon = new ReportDataSource("DataSet1", groupedCTHoaDon);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(sourceCTHoaDon);
            reportViewer1.RefreshReport();
        }
    }
}
