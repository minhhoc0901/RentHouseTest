using BUS;
using RenHouse_BUS;
using RentHouse_BUS;

using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace RentHouse.DashBoardBody.ManagerAllListForm.HOADON
{
    public partial class FormThem : Form
    {
        private readonly HoaDonService hoaDonService = new HoaDonService();
        private readonly ChiTietHoaDonService chiTiethoadon = new ChiTietHoaDonService();
        private readonly ChiTietHopDongService chiTietHopDongService = new ChiTietHopDongService();
        private readonly DichVuService dichVuService = new DichVuService();
        public FormThem()
        {
            InitializeComponent();
        }
        private void rabDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rabDV.Checked)
            {
                // Lấy dữ liệu từ bảng DichVu
                var dichVuService = new DichVuService();
                var dichVus = dichVuService.GetAllDichVu();
                BindGridDV(dichVus);
            }
        }
        private void BindGridDV(List<DichVu> dichVus)
        {
            dgvThongtin.Columns.Clear();
            dgvThongtin.Rows.Clear();

            dgvThongtin.Columns.Add("MaDV", "Mã DV");
            dgvThongtin.Columns.Add("TenDV", "Tên DV");
            dgvThongtin.Columns.Add("SoTien", "Giá tiền dịch vụ");
            dgvThongtin.Columns.Add("Ghichu", "Ghi chú");

            foreach (var item in dichVus)
            {
                int index = dgvThongtin.Rows.Add();
                dgvThongtin.Rows[index].Cells[0].Value = item.MaDV;
                dgvThongtin.Rows[index].Cells[1].Value = item.TenDV;
                dgvThongtin.Rows[index].Cells[2].Value = item.SoTien;
                dgvThongtin.Rows[index].Cells[3].Value = item.GhiChu;
            }
        }
        //BindGridHoaDon
        private void BindGridHoaDon(List<HoaDon> hoaDons)
        {
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Rows.Clear();
            dgvHoaDon.Columns.Add("IDHD", "ID Hóa Đơn");
            dgvHoaDon.Columns.Add("MaCTHD", "Mã CTHD");

            dgvHoaDon.Columns.Add("NgayLap", "Ngày lập");
            dgvHoaDon.Columns.Add("TienGiam", "Tiền giảm");
            dgvHoaDon.Columns.Add("TienPhat", "Tiền phạt");
            dgvHoaDon.Columns.Add("SoTienTra", "Số tiền trả");
            dgvHoaDon.Columns.Add("TongTien", "Tổng tiền");
            dgvHoaDon.Columns.Add("GhiChu", "Ghi chú");
            foreach (var item in hoaDons)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = item.IDHD;
                dgvHoaDon.Rows[index].Cells[1].Value = item.MaCTHD;
                dgvHoaDon.Rows[index].Cells[2].Value = item.NgayLap;
                dgvHoaDon.Rows[index].Cells[3].Value = item.TienGiam;
                dgvHoaDon.Rows[index].Cells[4].Value = item.TienPhat;
                dgvHoaDon.Rows[index].Cells[5].Value = item.SoTienTra;
                dgvHoaDon.Rows[index].Cells[6].Value = item.TongTien;
                dgvHoaDon.Rows[index].Cells[7].Value = item.GhiChu;
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RestData()
        {
            txtMaHopDong.Clear();
            txtPhongTro.Clear();
            txtKhachThue.Clear();
            txtGiaThue.Text = "0";
            dtpNgayLap.Value = DateTime.Now;
            txtTienGiam.Text = "0";
            txtTienPhat.Text = "0";
            txtKhachThue.Clear();
            txtDV.Clear();
            txtMaDV.Clear();
            txtTongtienDV.Text = "0";
            txtSoLuong.Text = "0";
            txtGhiChu.Clear();
            txtTienTra.Text = "0";
            txtTongTien.Text = "0";
            txtIDHD.Text = "0";
            txtTienDV.Text = "0";
        }
        private void rabCTHoaDon_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rabCTHoaDon.Checked)
            {
                KhoaMo(false);
                btnTHemHD.Enabled = false;
                var cTHoaDons = chiTiethoadon.GetAllCTHoaDon();
                BindGridHoaDon(hoaDonService.GetAllHoaDon());
                BindGridCTHoaDon(cTHoaDons);
            }
            else
            {
                KhoaMo(true);
            }
        }
        //bindgridCTHoaDon
        private void BindGridCTHoaDon(List<CTHoaDon> cTHoaDons)
        {
            dgvThongtin.Columns.Clear();
            dgvThongtin.Rows.Clear();
            dgvThongtin.Columns.Add("IDHD", "ID Hóa Đơn");
            dgvThongtin.Columns.Add("MaDV", "Mã dịch vụ");
            dgvThongtin.Columns.Add("SoLuong", "Số lượng");
            dgvThongtin.Columns.Add("GiaTien", "Tổng tiền dịch vụ");
            foreach (var item in cTHoaDons)
            {
                int index = dgvThongtin.Rows.Add();
                dgvThongtin.Rows[index].Cells[0].Value = item.IDHD;
                dgvThongtin.Rows[index].Cells[1].Value = item.MaDV;
                dgvThongtin.Rows[index].Cells[2].Value = item.SoLuong;
                dgvThongtin.Rows[index].Cells[3].Value = item.GiaTien;

            }
        }
        private void rabCTHopDong_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rabCTHopDong.Checked)
            {
                var ChiTietHopDongs = chiTietHopDongService.GetAllChuaketThuc();
                BindGridCTHopDong(ChiTietHopDongs);
            }
        }
        //bindgridCTHopDong
        private void BindGridCTHopDong(List<ChiTietHopDong> ChiTietHopDongs)
        {
            dgvThongtin.Columns.Clear();
            dgvThongtin.Rows.Clear();

            dgvThongtin.Columns.Add("MaCTHD", "Mã CTHD");
            dgvThongtin.Columns.Add("SoHopDong", "Số hợp đồng");
            dgvThongtin.Columns.Add("KhachThue", "Khách thuê");
            dgvThongtin.Columns.Add("MaPhong", "Mã phòng");
            dgvThongtin.Columns.Add("GiaThue", "Giá thuê");


            foreach (var item in ChiTietHopDongs)
            {
                int index = dgvThongtin.Rows.Add();
                dgvThongtin.Rows[index].Cells[0].Value = item.MaCTHD;
                dgvThongtin.Rows[index].Cells[1].Value = item.SoHopDong;
                dgvThongtin.Rows[index].Cells[2].Value = item.HopDong.KhachThue.HoTen;
                dgvThongtin.Rows[index].Cells[3].Value = item.MaPhong;
                dgvThongtin.Rows[index].Cells[4].Value = item.GiaThue;

            }
        }

        private void FormThem_Load(object sender, EventArgs e)
        {
            rabCTHopDong.Checked = true;
            BindGridHoaDon(hoaDonService.GetAllHoaDon());
            KhoaMo(true);
            LoadData();

        }
        private void LoadData()
        {
            txtIDHD.Text = "0";
            txtMaHopDong.Text = "0";
            txtGiaThue.Text = "0";
            txtTienGiam.Text = "0";
            txtTienPhat.Text = "0";
            dtpNgayLap.Value = DateTime.Now;
            txtTienTra.Text = "0";
            txtTongTien.Text = "0";
            txtGhiChu.Text = "";
            txtSoLuong.Text = "0";
            txtTongtienDV.Text = "0";
            txtTienDV.Text = "0";

        }
        public void KhoaMo(bool b)
        {
            btnTHemCTHD.Enabled = !b;
            btnTHemHD.Enabled = !b;
            btnXoa.Enabled = !b;
            btnTinhTien.Enabled = !b;

        }
        private void BindDataToTextBoxes(HoaDon hoaDon)
        {
            txtIDHD.Text = hoaDon.IDHD.ToString();
            dtpNgayLap.Value = hoaDon.NgayLap.Value;
            txtTienGiam.Text = hoaDon.TienGiam.ToString();
            txtTienPhat.Text = hoaDon.TienPhat.ToString();
            txtTongTien.Text = hoaDon.TongTien.ToString();
            txtTienTra.Text = hoaDon.SoTienTra.ToString();
            txtGhiChu.Text = hoaDon.GhiChu;
        }
        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                int hoaDonId = Convert.ToInt32(row.Cells["IDHD"].Value);

                HoaDon hoaDon = hoaDonService.GetByIDHoaDon(hoaDonId);
                if (hoaDon != null)
                {

                    BindDataToTextBoxes(hoaDon);
                }
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            var hoaDons = hoaDonService.GetAllHoaDon()
                   .Where(hd => hd.MaCTHD.ToString().Contains(keyword) ||


                   hd.GhiChu.ToString().Contains(keyword))
                   .ToList();
            if (rabDV.Checked)
            {
                var dichVus = dichVuService.GetAllDichVu()
                    .Where(dv => dv.TenDV.ToLower().Contains(keyword))
                    .ToList();
                BindGridDV(dichVus);
                BindGridHoaDon(hoaDons);
            }
            else if (rabCTHoaDon.Checked)
            {
                var cTHoaDons = chiTiethoadon.GetAllCTHoaDon()
                    .Where(ct => ct.IDHD.ToString().Contains(keyword) ||
                    ct.MaDV.ToString().Contains(keyword))
                    .ToList();
                BindGridCTHoaDon(cTHoaDons);
                BindGridHoaDon(hoaDons);
            }
            else if (rabCTHopDong.Checked)
            {
                var cTHopDongs = chiTietHopDongService.GetAllChiTietHopDong()
                    .Where(ct => ct.SoHopDong.ToLower().Contains(keyword) ||
                    ct.HopDong.KhachThue.HoTen.ToString().Contains(keyword) ||
                    ct.MaPhong.ToString().Contains(keyword))

                    .ToList();
                BindGridCTHopDong(cTHopDongs);
                BindGridHoaDon(hoaDons);
            }

        }
        // Cellcontent
        private void dgvThongtin_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (rabCTHoaDon.Checked)
                {
                    DataGridViewRow row = dgvThongtin.Rows[e.RowIndex];

                    if (int.TryParse(row.Cells["IDHD"].Value?.ToString(), out int cTHoaDonID))
                    {
                        var cTHoaDon = chiTiethoadon.GetAllCTHoaDon().FirstOrDefault(s => s.IDHD == cTHoaDonID);
                        if (cTHoaDon != null)
                        {
                            txtIDHD.Text = cTHoaDon.IDHD.ToString();
                            txtMaHopDong.Text = cTHoaDon.HoaDon.MaCTHD.ToString();
                            dtpNgayLap.Value = cTHoaDon.HoaDon.NgayLap.Value;
                            txtTienGiam.Text = cTHoaDon.HoaDon.TienGiam.ToString();
                            txtTienPhat.Text = cTHoaDon.HoaDon.TienPhat.ToString();
                            txtGhiChu.Text = cTHoaDon.HoaDon.GhiChu;
                            txtTienDV.Text = cTHoaDon.DichVu.SoTien.ToString();
                            txtTienTra.Text = cTHoaDon.HoaDon.SoTienTra.ToString();
                            txtPhongTro.Text = cTHoaDon.HoaDon.ChiTietHopDong.PhongTro.MaPhong;
                            txtKhachThue.Text = cTHoaDon.HoaDon.ChiTietHopDong.HopDong.KhachThue.HoTen;
                            txtSoLuong.Text = cTHoaDon.SoLuong.ToString();
                            txtTongtienDV.Text = cTHoaDon.GiaTien.ToString();
                            txtMaDV.Text = cTHoaDon.MaDV.ToString();
                            txtGiaThue.Text = cTHoaDon.HoaDon.ChiTietHopDong.GiaThue.ToString();
                            txtDV.Text = cTHoaDon.DichVu.TenDV;
                        }
                    }
                }
                else if (rabCTHopDong.Checked)
                {
                    DataGridViewRow selectRow = dgvThongtin.Rows[e.RowIndex];

                    if (int.TryParse(selectRow.Cells["MaCTHD"].Value?.ToString(), out int maCTHD))
                    {
                        var chiTietHopDong = chiTietHopDongService.GetAllChiTietHopDong()
                            .FirstOrDefault(ct => ct.MaCTHD == maCTHD);

                        if (chiTietHopDong != null)
                        {
                            txtMaHopDong.Text = chiTietHopDong.MaCTHD.ToString();
                            txtPhongTro.Text = chiTietHopDong.PhongTro.MaPhong.ToString();
                            txtKhachThue.Text = chiTietHopDong.HopDong.KhachThue.HoTen;
                            txtGiaThue.Text = chiTietHopDong.GiaThue.ToString();
                        }
                    }
                }
                else if (rabDV.Checked)
                {
                    if (e.RowIndex >= 0)
                    {
                        DataGridViewRow selectRow = dgvThongtin.Rows[e.RowIndex];
                        {
                            if (int.TryParse(selectRow.Cells["MaDV"].Value?.ToString(), out int maDV))
                            {
                                var dichVu = dichVuService.GetAllDichVu()
                                    .FirstOrDefault(dv => dv.MaDV == maDV);

                                if (dichVu != null)
                                {
                                    txtMaDV.Text = dichVu.MaDV.ToString();
                                    txtDV.Text = dichVu.TenDV;
                                    txtTienDV.Text = dichVu.SoTien.ToString();
                                }
                            }
                        }
                    }

                }
            }
        }
        private bool IsDataValid()
        {
            if (string.IsNullOrWhiteSpace(txtMaHopDong.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhongTro.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng trọ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtKhachThue.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGiaThue.Text))
            {
                MessageBox.Show("Vui lòng nhập giá thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(txtGiaThue.Text, out double giaThue) || giaThue <= 0)
            {
                MessageBox.Show("Giá thuê phải là một số dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTienGiam.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền giảm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(txtTienGiam.Text, out double tienGiam) || tienGiam < 0)
            {
                MessageBox.Show("Tiền giảm phải là một số không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTienPhat.Text))
            {
                MessageBox.Show("Vui lòng nhập tiền phạt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(txtTienPhat.Text, out double tienPhat) || tienPhat < 0)
            {
                MessageBox.Show("Tiền phạt phải là một số không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTienTra.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!double.TryParse(txtTienTra.Text, out double tienTra) || tienTra < 0)
            {
                MessageBox.Show("Số tiền trả phải là một số không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = int.Parse(dgvHoaDon.SelectedRows[0].Cells[0].Value.ToString());

            var cTHoaDons = chiTiethoadon.GetAllCTHoaDon().Where(s => s.IDHD == maHD).ToList();
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn " + maHD + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var item in cTHoaDons)
                {
                    chiTiethoadon.DeleteCTHoaDon(item);
                }
                hoaDonService.DeleteHoaDon(maHD);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RestData();
            }
            BindGridHoaDon(hoaDonService.GetAllHoaDon());
            BindGridCTHoaDon(chiTiethoadon.GetAllCTHoaDon());
        }
        //hàm tính tổng tiền dịch vụ
        private double CalculateTotalServiceAmount(int idHD)
        {
            double totalServiceAmount = 0;
            var cTHoaDons = chiTiethoadon.GetAllCTHoaDon().Where(ct => ct.IDHD == idHD).ToList();
            foreach (var ct in cTHoaDons)
            {
                totalServiceAmount += (ct.GiaTien ?? 0);
            }
            return totalServiceAmount;
        }
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            btnTHemHD.Enabled = true;
            if (rabCTHoaDon.Checked)
            {
                int idHD = int.Parse(txtIDHD.Text);
                double totalServiceAmount = CalculateTotalServiceAmount(idHD);
                txtTongtienDV.Text = totalServiceAmount.ToString();
            }
            txtTongTien.Text = (double.Parse(txtTongtienDV.Text) + double.Parse(txtTienPhat.Text) + double.Parse(txtGiaThue.Text) - double.Parse(txtTienGiam.Text) - double.Parse(txtTienTra.Text)).ToString();
        }
        //Thêm chi tiết hóa đơn
        private void btnTHemCTHD_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDataValid())
                {
                    return;
                }
                int idHD = int.Parse(txtIDHD.Text);
                int maDV = int.Parse(txtMaDV.Text);
                var cTHoaDonss = chiTiethoadon.GetAllCTHoaDon().FirstOrDefault(s => s.IDHD == idHD && s.MaDV == maDV);
                var idhoadon = hoaDonService.GetAllHoaDon().FirstOrDefault(s => s.IDHD == idHD);

                if (idhoadon != null)
                {
                    if (cTHoaDonss != null)
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn cập nhật dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            cTHoaDonss.MaDV = maDV;
                            cTHoaDonss.SoLuong = int.Parse(txtSoLuong.Text);
                            cTHoaDonss.GiaTien = double.Parse(txtSoLuong.Text) * double.Parse(txtTienDV.Text);
                            chiTiethoadon.UpdateCTHoaDon(cTHoaDonss);
                            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            CTHoaDon cTHoaDon = new CTHoaDon()
                            {
                                IDHD = idHD,
                                MaDV = maDV,
                                SoLuong = int.Parse(txtSoLuong.Text),
                                GiaTien = double.Parse(txtSoLuong.Text) * double.Parse(txtTienDV.Text),
                            };
                            chiTiethoadon.AddCTHoaDon(cTHoaDon);
                            MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hóa đơn không tồn tại");
                }
                BindGridCTHoaDon(chiTiethoadon.GetAllCTHoaDon());
                txtSoLuong.Text = "0";
                txtTongtienDV.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnTHemHD_Click(object sender, EventArgs e)
        {

            try
            {
                if (!IsDataValid())
                {
                    return;
                }
                var idhoadon = hoaDonService.GetAllHoaDon().FirstOrDefault(s => s.IDHD == int.Parse(txtIDHD.Text));
                var hoaDons = hoaDonService.GetAllHoaDon().FirstOrDefault(s => s.MaCTHD == int.Parse(txtMaHopDong.Text) && s.IDHD == int.Parse(txtIDHD.Text));

                if (hoaDons != null)
                {
                    if (idhoadon != null)
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn cập nhật dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            hoaDons.NgayLap = dtpNgayLap.Value;
                            hoaDons.TienGiam = double.Parse(txtTienGiam.Text);
                            hoaDons.TienPhat = double.Parse(txtTienPhat.Text);
                            hoaDons.SoTienTra = double.Parse(txtTienTra.Text);
                            hoaDons.TongTien = double.Parse(txtTongTien.Text);
                            hoaDons.GhiChu = txtGhiChu.Text;
                            hoaDonService.UpdateHoaDon(hoaDons);
                            MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            HoaDon hoaDon = new HoaDon
                            {
                                SoTienTra = double.Parse(txtTienTra.Text),
                                TongTien = double.Parse(txtTongTien.Text),
                                NgayLap = dtpNgayLap.Value,
                                TienGiam = double.Parse(txtTienGiam.Text),
                                TienPhat = double.Parse(txtTienPhat.Text),
                                GhiChu = txtGhiChu.Text
                            };
                            hoaDonService.AddHoaDon(hoaDon);
                            MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn thêm dữ liệu không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {

                        HoaDon hoaDon = new HoaDon
                        {
                            MaCTHD = int.Parse(txtMaHopDong.Text),
                            SoTienTra = double.Parse(txtTienTra.Text),
                            TongTien = double.Parse(txtTongTien.Text),
                            NgayLap = dtpNgayLap.Value,
                            TienGiam = double.Parse(txtTienGiam.Text),
                            TienPhat = double.Parse(txtTienPhat.Text),
                            GhiChu = txtGhiChu.Text
                        };
                        hoaDonService.AddHoaDon(hoaDon);
                        MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                BindGridHoaDon(hoaDonService.GetAllHoaDon());
                txtTienGiam.Text = "0";
                txtTienPhat.Text = "0";
                txtTienTra.Text = "0";
                txtTongTien.Text = "0";
                txtIDHD.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void rabCTHopDong_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
