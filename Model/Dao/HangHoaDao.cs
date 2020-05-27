using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class HangHoaDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public HangHoaDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<HangHoa> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<HangHoa> model = db.HangHoas;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenHang.Contains(searchString));
            }
            return model.OrderBy(x => x.MaHang).ToPagedList(page, pagesize);
        }
        public HangHoa ViewDentail(int hh)
        {
            return db.HangHoas.Find(hh);
        }

        public int ThemMoi(HangHoa ma)
        {
            db.HangHoas.Add(ma);
            db.SaveChanges();
            return ma.MaHang;
        }

        public bool Edit(HangHoa hh)
        {
            try
            {
                var dao = ViewDentail(hh.MaHang);
                dao.MaLoaiHang = hh.MaLoaiHang;
                dao.TenHang = hh.TenHang;
                dao.DonGia = hh.DonGia;
                dao.NgayNhap = hh.NgayNhap;

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
            var dao = ViewDentail(id);
            db.HangHoas.Remove(dao);
            db.SaveChanges();
            return true;
        }

    }
}
