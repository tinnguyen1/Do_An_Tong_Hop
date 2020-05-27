using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class QuyenHanController : BaseController
    {
        // GET: Admin/QuyenHan
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new QuyenhanDao();
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
        public ActionResult ThemMoi(QuyenHan quyenhan)
        {
            if (quyenhan.TenQuyenHan != null)
            {
                var dao = new QuyenhanDao();
                int id = dao.ThemMoi(quyenhan);
                if (id > 0)
                {
                    SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("Index", "QuyenHan");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "QuyenHan");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new QuyenhanDao();
            var quyenhan = dao.ViewDentail(id);
            return View(quyenhan);
        }
        [HttpPost]
        public ActionResult Edit(QuyenHan qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuyenhanDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "QuyenHan");
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
            new QuyenhanDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}