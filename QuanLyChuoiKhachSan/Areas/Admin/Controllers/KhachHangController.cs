﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhachHangDao();
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
        public ActionResult ThemMoi(KhachHang khachhang)
        {
            if (khachhang.TenKhachHang != null)
            {
                var dao = new KhachHangDao();
                int id = dao.ThemMoi(khachhang);
                if (id > 0)
                {
                    return RedirectToAction("Index", "KhachHang");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "KhachHang");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KhachHangDao();
            var khachhang = dao.ViewDentail(id);
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult Edit(KhachHang qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new KhachHangDao();
                var result = dao.ChinhSua(qh);
                if (result)
                {
                    //SetAlert("Cập nhật giảng viên thành công", "success");
                    return RedirectToAction("Index", "KhachHang");
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
            new KhachHangDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
       
        
    
