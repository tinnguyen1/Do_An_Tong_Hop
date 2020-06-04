using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public KhachHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<KhachHang> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhachHang.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKhachHang).ToPagedList(page, pagesize);
        }
        public KhachHang ViewDentail(int Ma)
        {
            return db.KhachHangs.Find(Ma);
        }

        public int ThemMoi(KhachHang ma)
        {
            try
            {
                var bientam = db.KhachHangs.Find(ma.SDT);
                if (bientam != null)
                {
                    db.KhachHangs.Add(ma);
                    db.SaveChanges();
                    return ma.MaKhachHang;
                }
                else
                {
                    return 0;
                }
                
            }
            catch(Exception ex)
            {
                return -1;
            }
            
        }

        public bool ChinhSua(KhachHang entity)
        {
            try
            {
                var nhom = db.KhachHangs.Find(entity.MaKhachHang);
                nhom.TenKhachHang = entity.TenKhachHang;
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
                var qh = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KhachHang> ListAll()
        {
            return db.KhachHangs.OrderByDescending(x => x.MaKhachHang).ToList();
        }
    }
}
