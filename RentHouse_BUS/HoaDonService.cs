
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonService
    {
        RentHouseContextDB context = new RentHouseContextDB();
        public List<HoaDon> GetAllHoaDon()
        {
            return context.HoaDons.ToList();
        }
        public HoaDon GetByIDHoaDon(int id)
        {
            return context.HoaDons.Find(id);
        }
        public void AddHoaDon(HoaDon hoaDon)
        {
            var existingCTHD = context.ChiTietHopDongs.Find(hoaDon.MaCTHD);
            if (existingCTHD == null)
            {
                throw new Exception("The specified MaCTHD does not exist in the ChiTietHopDong table.");
            }
            context.HoaDons.Add(hoaDon);
            context.SaveChanges();
        }
        public void UpdateHoaDon(HoaDon hoaDon)
        {
            var item = GetByIDHoaDon(hoaDon.IDHD);
            item.NgayLap = hoaDon.NgayLap;
            item.TienPhat = hoaDon.TienPhat;
            item.TienGiam = hoaDon.TienGiam;
            item.TongTien = hoaDon.TongTien;
            item.SoTienTra = hoaDon.SoTienTra;
            item.GhiChu = hoaDon.GhiChu;
            context.SaveChanges();
        }

        public void DeleteHoaDon(int id)
        {
            var hoaDon = GetByIDHoaDon(id);
            if (hoaDon != null)
            {
                context.HoaDons.Remove(hoaDon);
                context.SaveChanges();
            }
        }
    }
}
