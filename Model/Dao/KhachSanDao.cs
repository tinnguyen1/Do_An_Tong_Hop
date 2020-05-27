using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachSanDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public KhachSanDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<KhachSan> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<KhachSan> model = db.KhachSans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhachSan.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKhachSan).ToPagedList(page, pagesize);
        }
        public KhachSan ViewDentail(int Ma)
        {
            return db.KhachSans.Find(Ma);
        }

        public int ThemMoi(KhachSan ma)
        {
            db.KhachSans.Add(ma);
            db.SaveChanges();
            return ma.MaKhachSan;
        }

        public bool ChinhSua(KhachSan entity)
        {
            try
            {
                var nhom = db.KhachSans.Find(entity.MaKhachSan);
                nhom.TenKhachSan = entity.TenKhachSan;
                nhom.DiaChi = entity.DiaChi;
                nhom.Email = entity.Email;
                nhom.SDT = entity.SDT;
                nhom.GhiChu = entity.GhiChu;
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
                var qh = db.KhachSans.Find(id);
                db.KhachSans.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<KhachSan> ListAll()
        {
            return db.KhachSans.ToList();
        }
    }
}
