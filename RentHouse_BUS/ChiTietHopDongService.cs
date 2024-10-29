﻿using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class ChiTietHopDongService
    {
        RentHouseContextDB contextDB = new RentHouseContextDB();
        public List<ChiTietHopDong> GetAllChiTietHopDong()
        {
            return contextDB.ChiTietHopDongs.ToList();
        }
        public ChiTietHopDong GetChiTietHDById(int id)
        {
            return contextDB.ChiTietHopDongs.Find(id);
        }
        public List<ChiTietHopDong> GetAllChuaketThuc()
        {
            return contextDB.ChiTietHopDongs.Where(pt => !(pt.TinhTrangKetThuc == "Đã kết thúc")).ToList();
        }
        public void addChiTietHD(ChiTietHopDong chiTietHD)
        {
            
            contextDB.ChiTietHopDongs.Add(chiTietHD);
            contextDB.SaveChanges();
        }
        public void UpdateChiTietHD(ChiTietHopDong chiTietHD)
        {
            var chiTietHDUpdate = contextDB.ChiTietHopDongs.Find(chiTietHD.MaCTHD);
            if (chiTietHDUpdate != null)
            {
                chiTietHDUpdate.SoHopDong = chiTietHD.SoHopDong;
                chiTietHDUpdate.MaPhong = chiTietHD.MaPhong;
                chiTietHDUpdate.NgayBatDau = chiTietHD.NgayBatDau;
                chiTietHDUpdate.NgayKetThuc = chiTietHD.NgayKetThuc;
                chiTietHDUpdate.GiaThue = chiTietHD.GiaThue;
                chiTietHDUpdate.TinhTrangKetThuc = chiTietHD.TinhTrangKetThuc;
                chiTietHDUpdate.GhiChu = chiTietHD.GhiChu;
                contextDB.SaveChanges();
            }
        }

        public void DeleteChiTietHD(int id)
        {

            var chiTietHD = contextDB.ChiTietHopDongs.Find(id);
            if (chiTietHD != null)
            {
                contextDB.ChiTietHopDongs.Remove(chiTietHD);
                contextDB.SaveChanges();
            }
        }
        public void CapNhatTrangThaiHopDong(string maPhong, string tinhTrangHopDong)
        {
            var phongTro = contextDB.PhongTroes.FirstOrDefault(p => p.MaPhong == maPhong);

            if (phongTro == null)
            {
                throw new Exception("Phòng không tồn tại");
            }

            if (tinhTrangHopDong == "Đã kết thúc")
            {
                phongTro.TrangThai = "Phòng trống";
            }
            else if (tinhTrangHopDong == "Chưa kết thúc")
            {
                phongTro.TrangThai = "Phòng đã cho thuê";
            }
            contextDB.SaveChanges();
        }
    }
}
