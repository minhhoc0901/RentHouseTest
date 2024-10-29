
using RentHouse_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenHouse_BUS
{
    public class DichVuService
    {
        RentHouseContextDB context = new RentHouseContextDB();
        public List<DichVu> GetAllDichVu()
        {
            return context.DichVus.ToList();
        }
        public DichVu GetDichVuById(int id)
        {
            return context.DichVus.Find(id);
        }
        public void AddDichVu(DichVu dv)
        {
            context.DichVus.Add(dv);
            context.SaveChanges();
        }
        public void UpdateDichVu(DichVu dv)
        {
            DichVu dvUpdate = context.DichVus.Find(dv.MaDV);
            dvUpdate.TenDV = dv.TenDV;
            dvUpdate.SoTien = dv.SoTien;
            context.SaveChanges();
        }
        public void DeleteDichVu(DichVu dv)
        {
            DichVu dvDelete = context.DichVus.Find(dv.MaDV);
            if (dvDelete != null)
            {
                context.DichVus.Remove(dvDelete);
                context.SaveChanges();
            }
        }

    }
}
