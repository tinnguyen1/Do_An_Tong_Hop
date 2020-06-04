using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class NhaCungCapDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public NhaCungCapDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }
        public IEnumerable<NhaCungCap> LayTatCaDS(string searchString, int page, int pagesize)
        {
            IQueryable<NhaCungCap> model = db.NhaCungCaps;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNhaCungCap.Contains(searchString));
                model = model.Where(x => x.DiaChi.Contains(searchString));
                model = model.Where(x => x.SDT.Contains(searchString));
            }
            return model.OrderBy(x => x.MaNhaCungCap).ToPagedList(page, pagesize);
        }
        public NhaCungCap ViewDentail(int Ma)
        {
            return db.NhaCungCaps.Find(Ma);
        }

        public int ThemMoi(NhaCungCap ma)
        {
            db.NhaCungCaps.Add(ma);
            db.SaveChanges();
            return ma.MaNhaCungCap;
        }

        public bool ChinhSua(NhaCungCap entity)
        {
            try
            {
                var nhom = db.NhaCungCaps.Find(entity.MaNhaCungCap);
                nhom.TenNhaCungCap = entity.TenNhaCungCap;
                nhom.DiaChi = entity.DiaChi;
                nhom.SDT = entity.SDT;
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
                var qh = db.NhaCungCaps.Find(id);
                db.NhaCungCaps.Remove(qh);
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
    

