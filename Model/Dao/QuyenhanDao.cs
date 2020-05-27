using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class QuyenhanDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public QuyenhanDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<QuyenHan> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<QuyenHan> model = db.QuyenHans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenQuyenHan.Contains(searchString));
            }
            return model.OrderBy(x => x.MaQuyenHan).ToPagedList(page, pagesize);
        }
        public QuyenHan ViewDentail(int Ma)
        {
            return db.QuyenHans.Find(Ma);
        }

        public int ThemMoi(QuyenHan ma)
        {
            db.QuyenHans.Add(ma);
            db.SaveChanges();
            return ma.MaQuyenHan;
        }

        public bool ChinhSua(QuyenHan entity)
        {
            try
            {
                var nhom = db.QuyenHans.Find(entity.MaQuyenHan);
                nhom.TenQuyenHan = entity.TenQuyenHan;
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
                var qh = db.QuyenHans.Find(id);
                db.QuyenHans.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<QuyenHan> ListAll()
        {
            return db.QuyenHans.OrderByDescending(x=>x.MaQuyenHan).ToList();
        }
    }
}
