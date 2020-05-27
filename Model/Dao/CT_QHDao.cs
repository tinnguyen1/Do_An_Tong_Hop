using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CT_QHDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public CT_QHDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public IEnumerable<ChiTiet_QuyenHan> LayTatCaDS(int page, int pagesize)
        {
            //lay ds nguoi dung
            List<DanhSachNguoiDung> nguoidung = new NguoiDungDao().ListAll();
            //tao ds phan quyen rong
            List<ChiTiet_QuyenHan> quyenhan = new List<ChiTiet_QuyenHan>();
            //so sanh va tao ds
            for (int i = 0; i < nguoidung.Count; i++)
            {
                var tim = Tim(nguoidung[i].MaNguoiDung);
                if (tim.Count == 1)
                {
                    //them vao ds
                    ChiTiet_QuyenHan tam = tim[0];
                    quyenhan.Add(tim[0]);
                }
            }

            var model = quyenhan;

            return model.OrderBy(x => x.MaNguoiDung).ToPagedList(page, pagesize);
        }

        public List<ChiTiet_QuyenHan> ListAll()
        {
            return db.ChiTiet_QuyenHan.ToList();
        }

        public List<ChiTiet_QuyenHan> Tim(string ma)
        {
            return db.ChiTiet_QuyenHan
                .Where(x => x.MaNguoiDung == ma)
                .OrderByDescending(x => x.NgayPhan).Take(1).ToList();
        }

        public ChiTiet_QuyenHan ViewDentail(string Ma)
        {
            var kq = db.ChiTiet_QuyenHan.Where(x => x.MaNguoiDung == Ma)
                  .OrderByDescending(x => x.NgayPhan).Take(1).ToList();
            ChiTiet_QuyenHan tam = kq[0];
            return tam;
        }

        public int ThemMoi(ChiTiet_QuyenHan ma)
        {
            db.ChiTiet_QuyenHan.Add(ma);
            db.SaveChanges();
            return ma.MaQuyenHan;
        }

        public bool ChinhSua(ChiTiet_QuyenHan entity)
        {
            try
            {
                var nhom = ViewDentail(entity.MaNguoiDung);
                nhom.MaQuyenHan = entity.MaQuyenHan;
                nhom.NgayPhan = entity.NgayPhan;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Search(string ma)
        {
            var tim = db.ChiTiet_QuyenHan.SingleOrDefault(x => x.MaNguoiDung == ma);
            if (tim == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<DanhSachNguoiDung> DanhSachCanThem(string searchString, int page, int pagesize)
        {
            var dao = new NguoiDungDao().ListAll();
            List<DanhSachNguoiDung> DScanthem = new List<DanhSachNguoiDung>();
            for (int i = 0; i < dao.Count; i++)
            {
                bool tim = Search(dao[i].MaNguoiDung);
                if (tim == true)
                {
                    DScanthem.Add(dao[i]);
                }
            }
            return DScanthem.OrderBy(x => x.MaNguoiDung).ToPagedList(page, pagesize);

        }

        public bool Delete(string mand)
        {
            try
            {
                var qh = ViewDentail(mand);
                db.ChiTiet_QuyenHan.Remove(qh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ChiTiet_QuyenHan> NguoiQuanLy()
        {
            List<ChiTiet_QuyenHan> nguoiql = new List<ChiTiet_QuyenHan>();

            var ds = ListAll();

            for(int i=0; i<ds.Count;i++)
            {
                if (ds[i].MaQuyenHan == 2)
                {
                    ChiTiet_QuyenHan tam = ds[i];
                    nguoiql.Add(tam);
                }
            }
            return nguoiql;
        }

    }
}
