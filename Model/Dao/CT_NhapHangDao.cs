using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CT_NhapHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public CT_NhapHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<CT_NhapHang> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<CT_NhapHang> model = db.CT_NhapHang;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NguoiNhap.Contains(searchString));
            }
            return model.OrderByDescending(x => x.STT).ToPagedList(page, pagesize);
        }

        public int ThemMoi(CT_NhapHang ma)
        {
            try
            {
                db.CT_NhapHang.Add(ma);
                db.SaveChanges();
                return ma.STT;
            }
            catch (Exception ex)
            {
                return -1;
            }
           
        }
    }
}
