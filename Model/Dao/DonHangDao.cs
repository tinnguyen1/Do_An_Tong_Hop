using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DonHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public DonHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<DonHang> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDonHang.Contains(searchString));
            }
            return model.OrderBy(x => x.MaDonHang).ToPagedList(page, pagesize);
        }

        public bool ThemMoi(DonHang ma)
        {
            try
            {
                db.DonHangs.Add(ma);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        public DonHang ViewDentail(int hh)
        {
            return db.DonHangs.Find(hh);
        }

        public bool Edit(DonHang hh)
        {
            try
            {
                var dao = ViewDentail(hh.MaDonHang);
                dao.TenDonHang = hh.TenDonHang;
                dao.NgayGiao = hh.NgayGiao;

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
                var dao = ViewDentail(id);
                db.DonHangs.Remove(dao);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public List<DonHang> LayDS()
        {
            return db.DonHangs.ToList();
        }
        public List<DonHang> DonHangMoiTao()
        {
            return db.DonHangs.OrderByDescending(x => x.MaDonHang).Take(1).ToList();
        }

    }
}
