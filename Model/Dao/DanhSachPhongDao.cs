using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;


namespace Model.Dao
{
    public class DanhSachPhongDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public DanhSachPhongDao()
        {
            db = new QuanLyChuoiKhachSanDBContext() ;
        }
            
        public IEnumerable<PhongKhachSan> LayTatCaDS(string searchString, int page, int pagesize)
        {
            IQueryable<PhongKhachSan> model = db.PhongKhachSans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenPhong.Contains(searchString));
            }
            return model.OrderBy(x => x.MaPhong).ToPagedList(page, pagesize); 
        }

      

        public PhongKhachSan ViewDentail(int Ma)
        {
            return db.PhongKhachSans.Find(Ma);
        }

        public int ThemMoi(PhongKhachSan ma)
        {
            db.PhongKhachSans.Add(ma);
            db.SaveChanges();
            return ma.MaPhong;
        }

        public bool ChinhSua(PhongKhachSan entity)
        {
            try
            {
                var nhom = db.PhongKhachSans.Find(entity.MaPhong);
                nhom.MaKhachSan = entity.MaKhachSan;
                nhom.MaBangGiaPhong = entity.MaBangGiaPhong;
                nhom.TenPhong = entity.TenPhong;
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
                var qh = db.PhongKhachSans.Find(id);
                db.PhongKhachSans.Remove(qh);
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
        public List<BangGiaPhong> ListAllGia()
        {
            return db.BangGiaPhongs.ToList();
        }
        public List<LoaiPhong> ListAllLoai()
        {
            return db.LoaiPhongs.ToList();
        }

        public List<PhongKhachSan> PhongTaoMoi()
        {

            return db.PhongKhachSans.OrderByDescending(x => x.MaPhong).Take(1).ToList();
        }

    }
}
