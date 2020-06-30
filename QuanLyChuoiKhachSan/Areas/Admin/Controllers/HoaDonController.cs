using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class HoaDonController : BaseController
    {
        // GET: Admin/HoaDon

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult DonDatPhong(int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonDao().DanhSachDatPhong(page, pageSize);
            return View(dao);
        }

        //thêm phiếu đặt phòng vào hóa đơn
        public ActionResult XuLyPhieuDat(int maPhieu)
        {
            var dao = new HoaDonDao();
            var ThongTinBangDatPhong = dao.TimThongTinTheoMaDatPhong(maPhieu);
            var MaKhachHang = dao.ThemThongTinKhach(ThongTinBangDatPhong);
            var MaHoadon = dao.ThemThongTinVaoHoaDon(ThongTinBangDatPhong, MaKhachHang);


            if (MaHoadon >0)
            {
                var result = dao.ThemThongTinVaoCT_HD(MaHoadon, ThongTinBangDatPhong);
                if (result)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    SetAlert("Lỗi sử lý vui lòng kiểm tra lại", "error");
                    return RedirectToAction("DonDatPhong", "HoaDon");
                }
                
            }
            else
            {
                SetAlert("Lỗi sử lý vui lòng kiểm tra lại", "error");
                return RedirectToAction("DonDatPhong", "HoaDon");
            }
        }

        //hiện danh sách dịch vụ
        [HttpGet]
        public ActionResult DanhSachDichVu(int maHoaDon)
        {
            var dao = new HoaDonDao();
            ViewBag.ThongTinHoaDon = dao.TimMaHoaDonTrongCTHD(maHoaDon);
            ViewBag.ThongTinDichVu = new DichVuDao().ListAll();
            return View();
        }
        [HttpPost]
        public ActionResult DanhSachDichVu(HoaDon_DichVu thongTin)
        {
            if (thongTin.NguoiSuDung != null && thongTin.MaDichVu != 0)
            {
                var dao = new HoaDonDao().themThongTinVaoHD_DV(thongTin);
                if (dao)
                {
                    SetAlert("Thông tin đã được lưu thành công", "success");
                    return RedirectToAction("Index", "HoaDon");
                }
                else
                {
                    SetAlert("Thông tin chưa đầy đủ vui lòng kiểm tra lại", "error");
                    return RedirectToAction("index", "HoaDon");
                }
                
            }
            else
            {
                SetAlert("Thông tin chưa đầy đủ vui lòng kiểm tra lại", "error");
                return RedirectToAction("index", "HoaDon");
            }
        }

        [HttpGet]
        public ActionResult ThanhToan(int maHoaDon)
        {
            var dao = new HoaDonDao();
            var model= dao.ViewDentail(maHoaDon);
            ViewBag.ThongTinHoaDon = dao.TimMaHoaDonTrongCTHD(maHoaDon);
            ViewBag.ThongTinDichVu = dao.timDichVuTheoMaHoaDon(maHoaDon);
            return View(model);
        }
        [HttpPost]
        public ActionResult ThanhToan(HoaDon thongtin)
        {
            var dao = new HoaDonDao().HoanThanhThanhToan(thongtin.MaHoaDon);
            return RedirectToAction("Index", "HoaDon");
        }
        public ActionResult ChiTietSauThanhToan(int maHoaDon)
        {
            var dao = new HoaDonDao();
            var model = dao.ViewDentail(maHoaDon);
            ViewBag.ThongTinHoaDon = dao.TimMaHoaDonTrongCTHD(maHoaDon);
            ViewBag.ThongTinDichVu = dao.timDichVuTheoMaHoaDon(maHoaDon);
            return View(model);
        }
    }
}