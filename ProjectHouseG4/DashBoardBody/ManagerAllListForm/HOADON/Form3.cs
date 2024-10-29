
using RentHouse_BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentHouse_DAL.Entity;
using BUS;
using RenHouse_BUS;
using RentHouse.DashBoardBody.ManagerAllListForm.HOADON;

namespace RentHouse.DashBoardBody.ManagerAllListForm
{
    public partial class Form3 : Form
    {
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly ChiTietHoaDonService chiTietHoaDonService = new ChiTietHoaDonService();
        private readonly DichVuService dichVuService = new DichVuService();
        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            var cTiethoadons = chiTietHoaDonService.GetAllCTHoaDon();
            var dichVus = dichVuService.GetAllDichVu();

            BindGridCTHD(cTiethoadons);

        }
        private void BindGridCTHD(List<CTHoaDon> cTHoaDons)
        {
            dgvHD.Rows.Clear();
            var uniqueIDHDs = cTHoaDons.Select(ct => ct.IDHD).Distinct();
            foreach (var idHD in uniqueIDHDs)
            {
                var item = cTHoaDons.FirstOrDefault(ct => ct.IDHD == idHD);
                int index = dgvHD.Rows.Add();
                dgvHD.Rows[index].Cells[0].Value = item.IDHD;
                dgvHD.Rows[index].Cells[1].Value = item.HoaDon.MaCTHD;
                dgvHD.Rows[index].Cells[2].Value = item.HoaDon.ChiTietHopDong.HopDong.KhachThue.HoTen;
                dgvHD.Rows[index].Cells[3].Value = item.HoaDon.ChiTietHopDong.PhongTro.MaPhong;
                dgvHD.Rows[index].Cells[4].Value = item.HoaDon.ChiTietHopDong.PhongTro.GiaPhong;
                dgvHD.Rows[index].Cells[5].Value = item.HoaDon.NgayLap;
                dgvHD.Rows[index].Cells[6].Value = item.HoaDon.TienGiam;
                dgvHD.Rows[index].Cells[7].Value = item.HoaDon.TienPhat;
                dgvHD.Rows[index].Cells[8].Value = item.HoaDon.SoTienTra;
                dgvHD.Rows[index].Cells[9].Value = CalculateTotalServiceAmount(item.IDHD);
                dgvHD.Rows[index].Cells[10].Value = item.HoaDon.TongTien;
                dgvHD.Rows[index].Cells[11].Value = item.HoaDon.GhiChu;
            }
        }
        private double CalculateTotalServiceAmount(int idHD)
        {
            double totalServiceAmount = 0;
            var cTHoaDons = chiTietHoaDonService.GetAllCTHoaDon().Where(ct => ct.IDHD == idHD).ToList();
            foreach (var ct in cTHoaDons)
            {
                totalServiceAmount += (ct.GiaTien ?? 0);
            }
            return totalServiceAmount;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            FormThem formThem = new FormThem();
            formThem.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            FormThem formThem = new FormThem();
            formThem.ShowDialog();
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();
            var CTHoaDon = chiTietHoaDonService.GetAllCTHoaDon()
                .Where(ct => ct.HoaDon.ChiTietHopDong.HopDong.KhachThue.HoTen.ToLower().Contains(keyword) ||
                ct.IDHD.ToString().Contains(keyword) ||
                ct.HoaDon.MaCTHD.ToString().Contains(keyword) ||
                ct.HoaDon.ChiTietHopDong.MaPhong.ToString().Contains(keyword) ||
                ct.HoaDon.GhiChu.ToString().Contains(keyword))

                .ToList();
            BindGridCTHD(CTHoaDon);

        }
    }
}