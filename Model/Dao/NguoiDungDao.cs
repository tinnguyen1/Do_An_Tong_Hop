using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class NguoiDungDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public NguoiDungDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }
        public IEnumerable<DanhSachNguoiDung> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<DanhSachNguoiDung> model = db.DanhSachNguoiDungs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNguoiDung.Contains(searchString)|| x.MaNguoiDung.Contains(searchString));
            }
            return model.OrderBy(x => x.MaNguoiDung).ToPagedList(page, pagesize);
        }
        public string ThemMoi(DanhSachNguoiDung ma)
        {
            db.DanhSachNguoiDungs.Add(ma);
            db.SaveChanges();
            return ma.MaNguoiDung;
        }
         
        public int DangNhap(string maND, string mkND)
        {
            if (maND.Length<7||mkND.Length<7)
            {
                return -2;
            }
            else
            {
                var result = db.DanhSachNguoiDungs.SingleOrDefault(x => x.MaNguoiDung == maND);
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    if (result.MatKhau == mkND)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            
        }

        public DanhSachNguoiDung LayThongTinTheoMa(string ma)
        {
            return db.DanhSachNguoiDungs.SingleOrDefault(x => x.MaNguoiDung == ma);
        }
        public List<DanhSachNguoiDung> LayThongTin(string ma)
        {
            var list = db.DanhSachNguoiDungs.Where(x => x.MaNguoiDung == ma).OrderBy(x => x.MaNguoiDung).ToList();
            return list;
        }

        public DanhSachNguoiDung ViewDentail(string Ma)
        {
            return db.DanhSachNguoiDungs.Find(Ma);
        }

        public bool ChinhSua(DanhSachNguoiDung entity)
        {
            try
            {
                var nhom = db.DanhSachNguoiDungs.Find(entity.MaNguoiDung);
                nhom.TenNguoiDung = entity.TenNguoiDung;
                nhom.DiaChi = entity.DiaChi;
                nhom.SDT = entity.SDT;
                nhom.NgaySinh = entity.NgaySinh;
                nhom.Email = entity.Email;
                nhom.GioiTinh = entity.GioiTinh;
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
        public bool Delete(string id)
        {
            try
            {
                var qh = db.DanhSachNguoiDungs.Find(id);
                db.DanhSachNguoiDungs.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CapNhatThongTin(DanhSachNguoiDung entity)
        {
            try
            {
                var nhom = db.DanhSachNguoiDungs.Find(entity.MaNguoiDung);
                nhom.DiaChi = entity.DiaChi;
                nhom.SDT = entity.SDT;
                nhom.Email = entity.Email;
                nhom.GioiTinh = entity.GioiTinh;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DoiMk(DanhSachNguoiDung mk)
        {
            try
            {
                var nhom = db.DanhSachNguoiDungs.Find(mk.MaNguoiDung);
                nhom.MatKhau = mk.MatKhau;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DanhSachNguoiDung> ListAll()
        {
            return db.DanhSachNguoiDungs.OrderByDescending(x => x.MaNguoiDung).ToList();
        }
    }
}
