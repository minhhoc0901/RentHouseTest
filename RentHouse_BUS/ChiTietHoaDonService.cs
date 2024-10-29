
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenHouse_BUS
{
    public class ChiTietHoaDonService
    {
        RentHouseContextDB context = new RentHouseContextDB();
        public List<CTHoaDon> GetAllCTHoaDon()
        {
            return context.CTHoaDons.ToList();
        }
        public CTHoaDon GetCTHoaDonById(int id)
        {
            return context.CTHoaDons.Find(id);
        }
        public void AddCTHoaDon(CTHoaDon cthd)
        {
            context.CTHoaDons.Add(cthd);
            context.SaveChanges();
        }
        public void UpdateCTHoaDon(CTHoaDon cthd)
        {
            CTHoaDon cthdUpdate = context.CTHoaDons.Find(cthd.IDHD, cthd.MaDV);
            //cthdUpdate.IDHD = cthd.IDHD;
            cthdUpdate.DichVu = cthd.DichVu;
            cthdUpdate.SoLuong = cthd.SoLuong;
            cthdUpdate.GiaTien = cthd.GiaTien;
            cthdUpdate.HoaDon = cthd.HoaDon;
            context.SaveChanges();
        }
        public void DeleteCTHoaDon(CTHoaDon cthd)
        {
            CTHoaDon cthdDelete = context.CTHoaDons.Find(cthd.IDHD, cthd.MaDV);
            if (cthdDelete != null)
            {
                context.CTHoaDons.Remove(cthdDelete);
                context.SaveChanges();
            }
        }

    }
}
