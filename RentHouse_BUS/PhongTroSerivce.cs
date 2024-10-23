using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentHouse_BUS
{
    public class PhongTroService
    {
        RentHouseContextDB db = new RentHouseContextDB();
        public List<PhongTro> GetAllPhongTro()
        {
            return db.PhongTroes.ToList();
        }
        public List<PhongTro> GetAllNoDaThue() 
        {
            return db.PhongTroes.Where(pt =>!( pt.TrangThai == "Phòng đã cho thuê")).ToList();
        }
        public void AddPhongTro(PhongTro phongTro)
        {
            db.PhongTroes.Add(phongTro);
            db.SaveChanges();
        }
        public void UpdatePhongTro(PhongTro phongTro)
        {
            db.SaveChanges();
        }
        public void DelPhongTro(string maPhong)
        {
            var phongTro = db.PhongTroes.FirstOrDefault(p => p.MaPhong == maPhong);
            if (phongTro == null)
            {
                throw new Exception("Phòng không tồn tại hoặc đã bị xóa");
            }
            db.PhongTroes.Remove(phongTro);
            db.SaveChanges();
        }
        public void CapNhatTrangThaiPhong(string maPhong, string tinhTrang)
        {
            var phongTro = db.PhongTroes.FirstOrDefault(p => p.MaPhong == maPhong);
            if (phongTro != null)
            {
                phongTro.TrangThai = tinhTrang;
                db.SaveChanges();
            }
        }
    }
}
