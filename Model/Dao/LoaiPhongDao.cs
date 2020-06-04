using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class LoaiPhongDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public LoaiPhongDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }
        public IEnumerable<LoaiPhong> LayTatCaDS(string searchString, int page, int pagesize)
        {
            IQueryable<LoaiPhong> model = db.LoaiPhongs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLoaiPhong.Contains(searchString));
                //model = model.Where(x => x.MoTaPhong.Contains(searchString));
            }
            return model.OrderBy(x => x.MaLoaiPhong).ToPagedList(page, pagesize);
        }
        public LoaiPhong ViewDentail(int Ma)
        {
            return db.LoaiPhongs.Find(Ma);
        }

        public int ThemMoi(LoaiPhong ma)
        {
            db.LoaiPhongs.Add(ma);
            db.SaveChanges();
            return ma.MaLoaiPhong;
        }

        public bool ChinhSua(LoaiPhong entity)
        {
            try
            {
                var nhom = db.LoaiPhongs.Find(entity.MaLoaiPhong);
                nhom.TenLoaiPhong = entity.TenLoaiPhong;
               
                if (entity.Anh != null)
                {
                    nhom.Anh = entity.Anh;
                }
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
                var qh = db.LoaiPhongs.Find(id);
                db.LoaiPhongs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
