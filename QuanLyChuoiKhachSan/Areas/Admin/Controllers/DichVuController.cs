using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class DichVuController : Controller
    {
        // GET: Admin/DichVu
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DichVuDao();
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
        public ActionResult ThemMoi(DichVu DichVu)
        {
            if (DichVu.TenDichVu != null)
            {
                var dao = new DichVuDao();
                int id = dao.ThemMoi(DichVu);
                if (id > 0)
                {
                    //SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("Index", "DichVu");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "DichVu");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new DichVuDao();
            var DichVu = dao.ViewDentail(id);
            return View(DichVu);
        }
        [HttpPost]
        public ActionResult Edit(DichVu qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new DichVuDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    //SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "DichVu");
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
            new DichVuDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}