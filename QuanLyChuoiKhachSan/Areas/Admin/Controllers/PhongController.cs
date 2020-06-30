using Model.EF;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class PhongController : BaseController
    {
        // GET: Admin/Phong
        public ActionResult DanhSachPhong(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DanhSachPhongDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public void SetViewBag(int? selectedMa = null)
        {

            var dao = new DanhSachPhongDao();
            var da1 = new KhachSanDao();
            ViewBag.MaKhachSan = new SelectList(dao.ListAll(), "MaKhachSan", "TenKhachSan", selectedMa);

            ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Tang", selectedMa);
            ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllLoai(), "MaBangGiaPhong", "MaLoaiPhong", selectedMa);
            ViewBag.MaLoaiPhong = new SelectList(dao.ListAllLoai(), "MaLoaiPhong", "Anh", selectedMa);

            ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Gia", selectedMa);


        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(PhongKhachSan lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new DanhSachPhongDao();
                int id = dao.ThemMoi(lh);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("DanhSachPhong", "Phong");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "Phong");
                }
            }
            SetViewBag();
            return View("DanhSachPhong");
        }

        public ActionResult ChonPhong(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DanhSachPhongDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new DanhSachPhongDao();
            var Phong = dao.ViewDentail(id);
            SetViewBag(Phong.MaKhachSan);
            return View(Phong);
        }
        [HttpPost]
        public ActionResult Edit(PhongKhachSan qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new DanhSachPhongDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachPhong", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            SetViewBag(qh.MaKhachSan);
            return View("DanhSachPhong");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DanhSachPhongDao().Delete(id);
            return RedirectToAction("DanhSachPhong");
        }
    }
}