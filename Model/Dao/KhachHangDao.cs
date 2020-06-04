using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

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
                model = model.Where(y => y.SDT.Contains(searchString));
                //model = model.Where(x => x.GioiTinh.Contains(searchString));
                //model = model.Where(x => x.DiaChi.Contains(searchString));
                //model = model.Where(x => x.Email.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKhachHang ).ToPagedList(page, pagesize);
        }
        public KhachHang ViewDentail(int Ma)
        {
            return db.KhachHangs.Find(Ma);
        }

        public int ThemMoi(KhachHang ma)
        {
            db.KhachHangs.Add(ma);
            db.SaveChanges();
            return ma.MaKhachHang;
        }

        public bool ChinhSua(KhachHang entity)
        {
            try
            {
                var nhom = db.KhachHangs.Find(entity.MaKhachHang);
                nhom.TenKhachHang = entity.TenKhachHang;
                nhom.SDT = entity.SDT;
                nhom.GioiTinh = entity.GioiTinh;
                nhom.DiaChi = entity.DiaChi;
                nhom.Email = entity.Email;
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
    }
}
    

