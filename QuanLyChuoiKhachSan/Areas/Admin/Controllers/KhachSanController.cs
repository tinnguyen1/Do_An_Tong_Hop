using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class KhachSanController : BaseController
    {
        // GET: Admin/KhachSan
        public ActionResult DanhSachKhachSan(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new KhachSanDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemMoiKhachSan()
        {
            return View();
        }
        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult ThemMoiKhachSan(KhachSan ks)
        {
            if(ks.imageFileks==null)
            {
                SetAlert("Bạn chưa chọn ảnh cho khách sạn", "error");
                return RedirectToAction("ThemMoiKhachSan", "KhachSan");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    string fileName = Path.GetFileNameWithoutExtension(ks.imageFileks.FileName);
                    string extension = Path.GetExtension(ks.imageFileks.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    ks.Anh = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    ks.imageFileks.SaveAs(fileName);

                    var dao = new KhachSanDao();

                    int id = dao.ThemMoi(ks);
                    if (id > 0)
                    {
                        SetAlert("Thêm mới thành công", "success");
                        return RedirectToAction("DanhSachKhachSan", "KhachSan");
                    }
                    else
                    {
                        SetAlert("Thêm mới thất bại", "error");
                        return RedirectToAction("ThemMoiKhachSan", "KhachSan");
                    }
                }
            }
            return View();
        }

        public ActionResult ChiTiet(int id)
        {
            var dao = new KhachSanDao();
            var khachsan = dao.ViewDentail(id);
            return View(khachsan);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KhachSanDao();
            var khachsan = dao.ViewDentail(id);
            return View(khachsan);
        }

        [HttpPost]
        public ActionResult Edit(KhachSan ks)
        {
            if (ModelState.IsValid)
            {
                if (ks.imageFileks != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ks.imageFileks.FileName);
                    string extension = Path.GetExtension(ks.imageFileks.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    ks.Anh = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    ks.imageFileks.SaveAs(fileName);
                }

                var dao = new KhachSanDao();
                var result = dao.ChinhSua(ks);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachKhachSan", "KhachSan");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "error");
                    return RedirectToAction("Edit", "KhachSan");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhachSanDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}