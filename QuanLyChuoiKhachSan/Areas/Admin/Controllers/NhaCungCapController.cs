using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: Admin/NhaCungCap
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NhaCungCapDao();
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
        public ActionResult ThemMoi(NhaCungCap nhacungcap)
        {
            if (nhacungcap.TenNhaCungCap != null)
            {
                var dao = new NhaCungCapDao();
                int id = dao.ThemMoi(nhacungcap);
                if (id > 0)
                {
                    return RedirectToAction("Index", "NhaCungCap");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "NhaCungCap");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new NhaCungCapDao();
            var nhacungcap = dao.ViewDentail(id);
            return View(nhacungcap);
        }
        [HttpPost]
        public ActionResult Edit(NhaCungCap qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new NhaCungCapDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    //SetAlert("Cập nhật giảng viên thành công", "success");
                    return RedirectToAction("Index", "NhaCungCap");
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
            new NhaCungCapDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}