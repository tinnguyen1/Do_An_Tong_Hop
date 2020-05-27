using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhuyenMaiDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public KhuyenMaiDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<KhuyenMai> LayTatCaDS(string searchString, int page, int pagesize)
        {

            IQueryable<KhuyenMai> model = db.KhuyenMais;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhuyenMai.Contains(searchString));
            }
            return model.OrderBy(x => x.MaKhuyenMai).ToPagedList(page, pagesize);
        }

        public KhuyenMai ViewDentail(int Ma)
        {
            return db.KhuyenMais.Find(Ma);
        }

        public int ThemMoi(KhuyenMai ma)
        {
            db.KhuyenMais.Add(ma);
            db.SaveChanges();
            return ma.MaKhuyenMai;
        }

        public bool ChinhSua(KhuyenMai entity)
        {
            try
            {
                var nhom = db.KhuyenMais.Find(entity.MaKhuyenMai);
                nhom.TenKhuyenMai = entity.TenKhuyenMai;
                nhom.MoTa = entity.MoTa;
                nhom.NgayBD = entity.NgayBD;
                nhom.NgayKT = entity.NgayKT;
                nhom.NgayTao = entity.NgayTao;
                nhom.MaNguoiDung = entity.MaNguoiDung;
                
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
                var qh = db.KhuyenMais.Find(id);
                db.KhuyenMais.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<KhuyenMai> ListAll()
        {
            return db.KhuyenMais.OrderByDescending(x => x.MaKhuyenMai).ToList();
        }
    }
}
