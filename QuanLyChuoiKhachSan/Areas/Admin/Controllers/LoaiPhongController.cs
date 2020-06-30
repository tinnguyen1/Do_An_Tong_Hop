using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using System.IO;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class LoaiPhongController : BaseController
    {
        // GET: Admin/LoaiPhong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiPhongDao();
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
        [ValidateInput(false)]
        public ActionResult ThemMoi(LoaiPhong loaiphong)
        {
            if (loaiphong.imageFileks == null)
            {
                SetAlert("Bạn chưa chọn ảnh cho khách sạn", "error");
                return RedirectToAction("ThemMoi", "KhachSan");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    string fileName = Path.GetFileNameWithoutExtension(loaiphong.imageFileks.FileName);
                    string extension = Path.GetExtension(loaiphong.imageFileks.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    loaiphong.Anh = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    loaiphong.imageFileks.SaveAs(fileName);

                    var dao = new LoaiPhongDao();

                    int id = dao.ThemMoi(loaiphong);
                    if (id > 0)
                    {
                        SetAlert("Thêm mới thành công", "success");
                        return RedirectToAction("Index", "LoaiPhong");
                    }
                    else
                    {
                        SetAlert("Thêm mới thất bại", "error");
                        return RedirectToAction("ThemMoi", "LoaiPhong");
                    }
                }
            }
            //if (loaiphong.TenLoaiPhong != null)
            //{
            //    var dao = new LoaiPhongDao();
            //    int id = dao.ThemMoi(loaiphong);
            //    if (id > 0)
            //    {
            //        return RedirectToAction("Index", "LoaiPhong");
            //    }
            //    else
            //    {
            //        return RedirectToAction("ThemMoi", "LoaiPhong");
            //    }
            //}
            return View();
        }
        public ActionResult ChiTiet(int id)
        {
            var dao = new LoaiPhongDao();
            var loaiphong = dao.ViewDentail(id);
            return View(loaiphong);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        { 
        var dao = new LoaiPhongDao();
        var loaiphong = dao.ViewDentail(id);
        return View(loaiphong);
    }
        [HttpPost]
        public ActionResult Edit(LoaiPhong loaiphong)
        {
            if (ModelState.IsValid)
            {
                if (loaiphong.imageFileks != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(loaiphong.imageFileks.FileName);
                    string extension = Path.GetExtension(loaiphong.imageFileks.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    loaiphong.Anh = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    loaiphong.imageFileks.SaveAs(fileName);
                }

                var dao = new LoaiPhongDao();
                var result = dao.ChinhSua(loaiphong);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "LoaiPhong");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "error");
                    return RedirectToAction("Edit", "LoaiPhong");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiPhongDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}