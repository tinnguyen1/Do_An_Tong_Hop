using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using Model.Dao;


namespace Model.Dao
{
    public class DatPhongDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public DatPhongDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }
        public IEnumerable<Bang_DS_DatPhong> LayTatCaDS(string searchString, int page, int pagesize)
        {
            IQueryable<Bang_DS_DatPhong> model = db.Bang_DS_DatPhongs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.HoTen.Contains(searchString));

            }
            return model.OrderBy(x => x.MaDatPhong).ToPagedList(page, pagesize);
        }
        public Bang_DS_DatPhong ViewDentail(int Ma)
        {
            return db.Bang_DS_DatPhongs.Find(Ma);
        }
        public int DatPhongMoi(Bang_DS_DatPhong ma)
        {
            db.Bang_DS_DatPhongs.Add(ma);


            ma.NgayBD = DateTime.Now;
            ma.NgayDat = DateTime.Now;
            db.SaveChanges();
            return ma.MaDatPhong;
        }
        public bool XacNhanDatPhong(CT_DatPhong entity)
        {
            try
            {
                var nhom = db.CT_DatPhong.Find(entity.MaDatPhong);
                
                nhom.Bang_DS_DatPhong.HoTen = entity.Bang_DS_DatPhong.HoTen;
                nhom.Bang_DS_DatPhong.NgayKT = entity.Bang_DS_DatPhong.NgayKT;
                nhom.Bang_DS_DatPhong.SDT = entity.Bang_DS_DatPhong.SDT;
                nhom.Bang_DS_DatPhong.SoNguoi = entity.Bang_DS_DatPhong.SoNguoi;
                nhom.Bang_DS_DatPhong.DiaChi = entity.Bang_DS_DatPhong.DiaChi;
                nhom.Bang_DS_DatPhong.Email = entity.Bang_DS_DatPhong.Email;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
        public bool Delete(int id)
        {
            try
            {
                var qh = db.Bang_DS_DatPhongs.Find(id);
                db.Bang_DS_DatPhongs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<PhongKhachSan> ListAll()
        {
            return db.PhongKhachSans.ToList();
        }

    }
}
