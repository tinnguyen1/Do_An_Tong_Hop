using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class QuanLyKhoHangDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public QuanLyKhoHangDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<QuanLyKhoHang> LayTatCaDS(string searchString, int page, int pagesize)
        {
            IQueryable<QuanLyKhoHang> model = db.QuanLyKhoHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.DanhSachNguoiDung.TenNguoiDung.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKho).ToPagedList(page, pagesize);
        }

        public QuanLyKhoHang ViewDentail(int Ma)
        {
            return db.QuanLyKhoHangs.Find(Ma); 
        }
        public QuanLyKhoHang TimNguoiDungTheoMa(string Ma)
        {
            return db.QuanLyKhoHangs.SingleOrDefault(x => x.MaNguoiDung == Ma); 
        }


        public List<QuanLyKhoHang> ListAll()
        {
            return db.QuanLyKhoHangs.ToList();
        }

        public int ThemMoi(QuanLyKhoHang ma)
        {
            db.QuanLyKhoHangs.Add(ma);
            db.SaveChanges();
            return ma.STT;
        }
        public bool ChinhSua(QuanLyKhoHang entity)
        {
            try
            {
                var nhom = db.QuanLyKhoHangs.Find(entity.STT);
                nhom.MaNguoiDung = entity.MaNguoiDung;
                nhom.NgayPhan = entity.NgayPhan;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Delete(int mand)
        {
            try
            {
                var qh = ViewDentail(mand);
                db.QuanLyKhoHangs.Remove(qh);
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
