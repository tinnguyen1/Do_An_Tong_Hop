using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class HoaDonDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public HoaDonDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<HoaDon> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<HoaDon> model = db.HoaDons;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.KhachHang.TenKhachHang.Contains(searchString)|| x.KhachHang.SDT.Contains(searchString));
            }
            return model.OrderBy(x => x.MaHoaDon).ToPagedList(page, pagesize);
        }

        public HoaDon ViewDentail(int Ma)
        {
            return db.HoaDons.Find(Ma);
        }


    }
}
