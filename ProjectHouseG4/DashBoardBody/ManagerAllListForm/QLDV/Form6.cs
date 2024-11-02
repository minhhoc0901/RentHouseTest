using RenHouse_BUS;
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

namespace RentHouse.DashBoardBody.ManagerAllListForm
{
    public partial class Form6 : Form
    {
        private readonly DichVuService dichVuService = new DichVuService();

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            var dichVus = dichVuService.GetAllDichVu();
            BindGridDV(dichVus);
        }

        private void BindGridDV(List<DichVu> dichVus)
        {
            dgvDV.Rows.Clear();
            foreach (var dv in dichVus)
            {
                int index = dgvDV.Rows.Add();
                dgvDV.Rows[index].Cells[0].Value = dv.MaDV;
                dgvDV.Rows[index].Cells[1].Value = dv.TenDV;
                dgvDV.Rows[index].Cells[2].Value = dv.SoTien;
                dgvDV.Rows[index].Cells[3].Value = dv.GhiChu;
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            try
            {
                var dv = new DichVu
                { 
                    MaDV = int.Parse(txtMaDV.Text),
                    TenDV = txtTenDV.Text,
                    SoTien = double.Parse(txtGiaTien.Text),
                    GhiChu = txtGhiChu.Text
                };

                dichVuService.AddDichVu(dv);

                BindGridDV(dichVuService.GetAllDichVu());

                MessageBox.Show("Thêm dịch vụ thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatDV_Click(object sender, EventArgs e)
        {
            try
            {
                var dv = new DichVu
                {
                    MaDV = int.Parse(txtMaDV.Text),
                    TenDV = txtTenDV.Text,
                    SoTien = double.Parse(txtGiaTien.Text),
                    GhiChu = txtGhiChu.Text
                };

                dichVuService.UpdateDichVu(dv);

                BindGridDV(dichVuService.GetAllDichVu());

                MessageBox.Show("Cập nhật dịch vụ thành công");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaDV.Text = dgvDV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenDV.Text = dgvDV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtGiaTien.Text = dgvDV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtGhiChu.Text = dgvDV.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            try
            {
                var maDV = int.Parse(txtMaDV.Text);
                var dv = dichVuService.GetDichVuById(maDV);
                if (dv != null)
                {
                    var result = MessageBox.Show("Bạn có muốn xoá không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        dichVuService.DeleteDichVu(dv);
                        BindGridDV(dichVuService.GetAllDichVu());
                        MessageBox.Show("Xóa dịch vụ thành công");
                    }
                }
                else
                {
                    MessageBox.Show("Dịch vụ không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
