using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class LoaiHangController : BaseController
    {
        public ActionResult DanhSachLoaiMatHang(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiHangDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiHang lh)
        {
            if (lh.TenLoaiHang != null)
            {
                var dao = new LoaiHangDao();
                int id = dao.ThemMoi(lh);
                if (id > 0)
                {
                    SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("DanhSachLoaiMatHang", "LoaiHang");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "LoaiHang");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new LoaiHangDao();
            var loaihang = dao.ViewDentail(id);
            return View(loaihang);
        }
        [HttpPost]
        public ActionResult Edit(LoaiHang qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiHangDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachLoaiMatHang", "LoaiHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiHangDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}