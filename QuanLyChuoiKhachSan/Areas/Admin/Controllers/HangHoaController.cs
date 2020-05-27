using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class HangHoaController : BaseController
    {
        // GET: Admin/HangHoa
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HangHoaDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new LoaiHangDao();
            ViewBag.MaLoaiHang = new SelectList(dao.ListAll(), "MaLoaiHang", "TenLoaiHang", selectedMa);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(HangHoa hangHoa)
        {
            hangHoa.NgayNhap = DateTime.Now;
            var dao = new HangHoaDao();
            int id = dao.ThemMoi(hangHoa);
            if (id > 0)
            {
                SetAlert("Thêm hàng thành công", "success");
                return RedirectToAction("Index", "HangHoa");
            }
            else
            {
                return RedirectToAction("ThemMoi", "HangHoa");
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dao = new ChiTiet_HangHoaDao().ListHangTheoMaHang(id);
            return View(dao);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new HangHoaDao().ViewDentail(id);
            SetViewBag(dao.MaLoaiHang);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Edit(HangHoa hh)
        {
            var dao = new HangHoaDao();
            hh.NgayNhap = DateTime.Now;
            var id = dao.Edit(hh);
            if(id==true)
            {
                SetAlert("Cập nhật hàng thành công", "success");
                return RedirectToAction("Index", "HangHoa");
            }
            else
            {
                return RedirectToAction("Edit", "HangHoa");
            }
        }
        public ActionResult Delete(int id)
        {
            var dao = new HangHoaDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}