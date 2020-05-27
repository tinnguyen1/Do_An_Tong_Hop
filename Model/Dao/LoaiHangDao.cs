using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoaiHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public LoaiHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<LoaiHang> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<LoaiHang> model = db.LoaiHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLoaiHang.Contains(searchString));
            }
            return model.OrderBy(x => x.MaLoaiHang).ToPagedList(page, pagesize);
        }
        public LoaiHang ViewDentail(int Ma)
        {
            return db.LoaiHangs.Find(Ma);
        }

        public int ThemMoi(LoaiHang ma)
        {
            db.LoaiHangs.Add(ma);
            db.SaveChanges();
            return ma.MaLoaiHang;
        }

        public bool ChinhSua(LoaiHang entity)
        {
            try
            {
                var nhom = db.LoaiHangs.Find(entity.MaLoaiHang);
                nhom.TenLoaiHang = entity.TenLoaiHang;
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
                var qh = db.LoaiHangs.Find(id);
                db.LoaiHangs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<LoaiHang> ListAll()
        {
            return db.LoaiHangs.OrderBy(x => x.MaLoaiHang).ToList();
        }
    }
}
