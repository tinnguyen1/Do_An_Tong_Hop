using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DichVuDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public DichVuDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<DichVu> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<DichVu> model = db.DichVus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDichVu.Contains(searchString));
            }
            return model.OrderBy(x => x.MaDichVu).ToPagedList(page, pagesize);
        }
        public DichVu ViewDentail(int Ma)
        {
            return db.DichVus.Find(Ma);
        }

        public int ThemMoi(DichVu ma)
        {
            db.DichVus.Add(ma);
            db.SaveChanges();
            return ma.MaDichVu;
        }

        public bool ChinhSua(DichVu entity)
        {
            try
            {
                var nhom = db.DichVus.Find(entity.MaDichVu);
                nhom.TenDichVu = entity.TenDichVu;
                nhom.Gia = entity.Gia;
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
                var qh = db.DichVus.Find(id);
                db.DichVus.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DichVu> ListAll()
        {
            return db.DichVus.OrderByDescending(x => x.MaDichVu).ToList();
        }
    }
}
