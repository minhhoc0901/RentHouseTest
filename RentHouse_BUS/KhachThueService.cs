using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class KhachThueService
    {
        RentHouseContextDB db = new RentHouseContextDB();
        public List<KhachThue> GetAllKhachThue()
        {
            return db.KhachThues.ToList();
        }
        public void InsertUpdate(KhachThue khach)
        {
            db.KhachThues.AddOrUpdate(khach);
            db.SaveChanges();
        }
        public void Del(int maKhach)
        {
            var khachHang = db.KhachThues.FirstOrDefault(kh => kh.MaKH == maKhach);
            if (khachHang == null)
            {
                throw new Exception("Khách hàng không tồn tại hoặc đã bị xóa");
            }
            db.KhachThues.Remove(khachHang);
            db.SaveChanges();
        }
    }
}
