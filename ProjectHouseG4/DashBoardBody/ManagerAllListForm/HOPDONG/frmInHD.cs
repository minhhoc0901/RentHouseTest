using Microsoft.Reporting.WinForms;
using RentHouse_BUS;
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //this.reportViewHDTableAdapter.Fill(this.quanLyPhongTro2DataSet.ReportViewHD);

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
            rptHD.LocalReport.ReportPath = @"C:\\Users\\admin\\Desktop\\G4\\RentHouseTest\\ProjectHouseG4\\DashBoardBody\\ManagerAllListForm\\HOPDONG\\ReportHD.rdlc";
            var sourcecthd = new ReportDataSource("DataSet1", CTHD);
            rptHD.LocalReport.DataSources.Clear();
            rptHD.LocalReport.DataSources.Add(sourcecthd);
            
            rptHD.RefreshReport();

        }

    }
}
