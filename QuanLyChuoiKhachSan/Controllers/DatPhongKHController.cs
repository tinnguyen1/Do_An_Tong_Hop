

//namespace QuanLyChuoiKhachSan.Controllers
//{
//    public class DatPhongController : Controller
//    {
//        // GET: DatPhong
//        public ActionResult Index()
//        {
//            return View();
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using PagedList;
using QuanLyChuoiKhachSan.Controllers;
using System.Data;

namespace QuanLyChuoiKhachSan.Controllers
{
    public class DatPhongKHController : BaseKHController
    {
        private QuanLyChuoiKhachSanDBContext db = new QuanLyChuoiKhachSanDBContext();

        // GET: Admin/DatPhong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachDatPhong(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DatPhongDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }



        [HttpGet]
        public ActionResult DatPhongMoi()
        {
            ViewBag.DanhSachPhong = new DanhSachPhongDao().LayDSPhong();
            return View();
        }

        [HttpPost]
        public ActionResult DatPhongMoi(Bang_DS_DatPhong lh, int maPhong)
        {
            if (lh.NgayBD >= DateTime.Now.Date && lh.NgayBD <= lh.NgayKT)
            {
                var dao = new DatPhongDao();
                int id = dao.DatPhongMoi(lh);
                var result = dao.ThemGiaTriVaoCT_Phong(id, maPhong);


                if (result)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("DatPhongMoi", "DatPhongKH");
                }
                else
                {
                    SetAlert("Dữ liệu không hợp lý mời xem lại", "error");
                    return RedirectToAction("DatPhongMoi", "DatPhongKH");
                }
            }
            SetAlert("Dữ liệu không hợp lý mời xem lại", "error");
            return RedirectToAction("DatPhongMoi", "DatPhongKH");
        }

        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new DanhSachPhongDao();

            ViewBag.MaPhong = new SelectList(dao.ListAll(), "MaPhong", "TenPhong", selectedMa);




            //ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Gia", selectedMa);
            //ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Tang", selectedMa);
            //ViewBag.MaLoaiPhong = new SelectList(dao.ListAllLoai(), "MaLoaiPhong", "Anh", selectedMa);



        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DatPhongDao().Delete(id);
            return RedirectToAction("DanhSachDatPhong");
        }


    }
}