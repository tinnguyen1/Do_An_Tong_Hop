using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ChiTiet_HangHoaDao
    {
        QuanLyChuoiKhachSanDBContext db = null;
        public ChiTiet_HangHoaDao()
        {
            db = new QuanLyChuoiKhachSanDBContext();
        }

        public int ThemMoi(ChiTietHangHoa ma)
        {
            try
            {
                var tim = TimKiem(ma.MaKho, ma.MaHang);
                if (tim!=null)
                {
                    tim.Soluong = tim.Soluong + ma.Soluong;
                    tim.DonGia = ma.DonGia;
                    db.SaveChanges();
                    return 0;
                }
                else
                {
                    db.ChiTietHangHoas.Add(ma);
                    db.SaveChanges();
                    return 1;
                }
                
            }
            catch (Exception ex)
            {
                return -1;
            }

            
        }

        public List<ChiTietHangHoa> ListHangTheoMaHang(int mh)
        {
            return db.ChiTietHangHoas.Where(x=>x.MaHang==mh).ToList();
        }

        public List<ChiTietHangHoa> ThongTinTimTheoMaHang_MaKho(int mh, int mk)
        {
            return db.ChiTietHangHoas.Where(x => x.MaHang == mh && x.MaKho==mk).Take(1).ToList();
        }

        public IEnumerable<ChiTietHangHoa> LayTatCaDSTheoMaKho(int page, int pagesize,int maKho)
        {
            //lay ds hang theo nguoi quan ly
            var DanhSachHHTheoKho = db.ChiTietHangHoas.Where(x => x.MaKho == maKho).OrderBy(x=>x.MaHang).ToList();

            return DanhSachHHTheoKho.OrderBy(x => x.MaHang).ToPagedList(page, pagesize);
        }

        public List<ChiTietHangHoa> LayDStheoManguoiDung(int maKho)
        {
            //lay ds hang theo nguoi quan ly
            var DanhSachHHTheoKho = db.ChiTietHangHoas.Where(x => x.MaKho == maKho).OrderBy(x => x.MaHang).ToList();

            return DanhSachHHTheoKho;
        }
        public bool ChinhSua(DS_XuatKho entity, int maKho)
        {
            try
            {
                var nhom = TimKiem(maKho, entity.MaHang);
                nhom.Soluong = nhom.Soluong-entity.SoLuong;
                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ChiTietHangHoa TimKiem(int maKho, int maHang)
        {
            return db.ChiTietHangHoas.SingleOrDefault(x => x.MaKho == maKho && x.MaHang==maHang);
        }
    }
}
