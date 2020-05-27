using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhoHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public KhoHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<KhoHang> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<KhoHang> model = db.KhoHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.DiaChi.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKho).ToPagedList(page, pagesize);
        }
        public KhoHang ViewDentail(int Ma)
        {
            return db.KhoHangs.Find(Ma);
        }

        public int ThemMoi(KhoHang ma)
        {
            db.KhoHangs.Add(ma);
            db.SaveChanges();
            return ma.MaKho;
        }

        public bool ChinhSua(KhoHang entity)
        {
            try
            {
                var nhom = db.KhoHangs.Find(entity.MaKho);
                nhom.MaKhachSan = entity.MaKhachSan;
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
                var qh = db.KhoHangs.Find(id);
                db.KhoHangs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<KhoHang> ListAll()
        {
            return db.KhoHangs.OrderByDescending(x => x.MaKho).ToList();
        }

    }
}
