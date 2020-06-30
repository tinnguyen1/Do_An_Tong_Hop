using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
                model = model.Where(x => x.KhachHang.TenKhachHang.Contains(searchString) || x.KhachHang.SDT.Contains(searchString));
            }
            return model.OrderByDescending(x => x.TinhTrang=="Run").ToPagedList(page, pagesize);
        }

        public IEnumerable<Bang_DS_DatPhong> DanhSachDatPhong(int page, int pagesize)
        {

            IQueryable<Bang_DS_DatPhong> model = db.Bang_DS_DatPhongs;
            return model.Where(x => x.TinhTrang == "dang cho").OrderBy(x => x.MaDatPhong).ToPagedList(page, pagesize);
        }

        public Bang_DS_DatPhong TimThongTinTheoMaDatPhong(int maDatPhong)
        {
            return db.Bang_DS_DatPhongs.Find(maDatPhong);
        }

        public int ThemThongTinKhach(Bang_DS_DatPhong thongTin)
        {
            List<KhachHang> TimKiemKhachTheoSDT = db.KhachHangs.Where(x => x.SDT == thongTin.SDT).ToList();
            if (TimKiemKhachTheoSDT.Count!=0)
            {
                var TimPhieuDatPhong = db.Bang_DS_DatPhongs.Find(thongTin.MaDatPhong);
                TimPhieuDatPhong.TinhTrang = "Success";
                db.SaveChanges();
                return TimKiemKhachTheoSDT[0].MaKhachHang;
            }
            else
            {
                KhachHang bienTam = new KhachHang();
                bienTam.TenKhachHang = thongTin.HoTen;
                bienTam.SDT = thongTin.SDT;
                bienTam.GioiTinh = thongTin.GioiTinh;
                bienTam.DiaChi = thongTin.DiaChi;
                bienTam.Email = thongTin.Email;

                db.KhachHangs.Add(bienTam);
                db.SaveChanges();

                var TimPhieuDatPhong = db.Bang_DS_DatPhongs.Find(thongTin.MaDatPhong);
                TimPhieuDatPhong.TinhTrang = "Success";
                db.SaveChanges();

                return bienTam.MaKhachHang;
            }
        }

        public int ThemThongTinVaoHoaDon(Bang_DS_DatPhong phieuDat, int MaKhach)
        {
            try
            {
                HoaDon BienTam = new HoaDon();
                BienTam.MaKhachHang = MaKhach;
                BienTam.NgayLap = DateTime.Now;
                BienTam.TongTien = phieuDat.CT_DatPhong.TongGia;
                BienTam.TinhTrang = "Run";
                db.HoaDons.Add(BienTam);
                db.SaveChanges();

                return BienTam.MaHoaDon;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public bool ThemThongTinVaoCT_HD(int maHoaDon, Bang_DS_DatPhong phieuDat)
        {
            try
            {
                var thongTinCT_DP = db.CT_DatPhong.Find(phieuDat.MaDatPhong);
                ChiTietHoaDon bienTam = new ChiTietHoaDon();

                bienTam.MaPhong = thongTinCT_DP.MaPhong;
                bienTam.MaHoaDon = maHoaDon;
                bienTam.SoNguoi = Convert.ToInt32(phieuDat.SoNguoi);
                bienTam.NgayBatDau = phieuDat.NgayBD;
                bienTam.NgayKetThuc = phieuDat.NgayKT;
                bienTam.Gia = thongTinCT_DP.TongGia;
                bienTam.NgayLap = DateTime.Now;

                db.ChiTietHoaDons.Add(bienTam);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public HoaDon ViewDentail(int Ma)
        {
            return db.HoaDons.Find(Ma);
        }

        public List<ChiTietHoaDon> TimMaHoaDonTrongCTHD(int Mahoadon)
        {
            return db.ChiTietHoaDons.Where(x => x.MaHoaDon == Mahoadon).ToList();
        }

        public bool themThongTinVaoHD_DV(HoaDon_DichVu thongTin)
        {
            try
            {
                List<ChiTietHoaDon> TimMaPhong = db.ChiTietHoaDons.Where(x => x.MaHoaDon == thongTin.MaHoaDon).ToList();
                thongTin.MaPhong = TimMaPhong[0].MaPhong;
                thongTin.NgaySuDung = DateTime.Now;

                db.HoaDon_DichVu.Add(thongTin);
                db.SaveChanges();

                var ThongTinDichVu = db.DichVus.Find(thongTin.MaDichVu);
                var ThongTinHoaDon = db.HoaDons.Find(thongTin.MaHoaDon);
                ThongTinHoaDon.TongTien = ThongTinHoaDon.TongTien + ThongTinDichVu.Gia;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<HoaDon_DichVu> timDichVuTheoMaHoaDon(int maHoaDon)
        {
            return db.HoaDon_DichVu.Where(x => x.MaHoaDon == maHoaDon).ToList();
        }

        public bool HoanThanhThanhToan(int maHoaDon)
        {
            try
            {
                var TimHoaDonTheoMa = db.HoaDons.Find(maHoaDon);
                TimHoaDonTheoMa.TinhTrang = "End";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
