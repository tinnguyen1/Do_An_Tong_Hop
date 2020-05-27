using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class KhoHangController : BaseController
    {
        // GET: Admin/KhoHang
        public ActionResult DanhSachKhoHang(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhoHangDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new KhachSanDao();
            ViewBag.MaKhachSan = new SelectList(dao.ListAll(), "MaKhachSan", "TenKhachSan", selectedMa);
        }


        [HttpGet]
        public ActionResult ThemMoi()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(KhoHang lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhoHangDao();
                int id = dao.ThemMoi(lh);
                if (id > 0)
                {
                    SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("DanhSachKhoHang", "KhoHang");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "KhoHang");
                }
            }
            SetViewBag();
            return View("DanhSachKhoHang");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KhoHangDao();
            var khoHang = dao.ViewDentail(id);
            SetViewBag(khoHang.MaKhachSan);
            return View(khoHang);
        }
        [HttpPost]
        public ActionResult Edit(KhoHang qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhoHangDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachKhoHang", "KhoHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            SetViewBag(qh.MaKhachSan);
            return View("DanhSachKhoHang");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhoHangDao().Delete(id);
            return RedirectToAction("DanhSachKhoHang");
        }
    }
}