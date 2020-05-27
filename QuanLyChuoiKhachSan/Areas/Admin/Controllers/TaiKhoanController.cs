using Model.Dao;
using Model.EF;
using QuanLyChuoiKhachSan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ThongTinCaNhan()
        {
            var laythongtin = Session[CommonConstants.MaND_SESSTION];
            string id = Convert.ToString(laythongtin);
            var dao = new NguoiDungDao();
            var nguoidung = dao.LayThongTin(id);
            return View(nguoidung);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new NguoiDungDao();
            var Nguoidung = dao.ViewDentail(id);
            return View(Nguoidung);
        }
        [HttpPost]
        public ActionResult Edit(DanhSachNguoiDung nd)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDao();
                var result = dao.CapNhatThongTin(nd);
                if (result)
                {
                    SetAlert("Cập nhật thông tin thành công", "success");
                    return RedirectToAction("ThongTinCaNhan", "TaiKhoan");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View("ThongTinCaNhan");
        }
        [HttpGet]
        public ActionResult DoiMk()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMk(DanhSachNguoiDung nd, string mkCu)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDao();

                //kiem tra mat khau cu
                var laythongtin = Session[CommonConstants.MaND_SESSTION];
                string id = Convert.ToString(laythongtin);
                var Nguoidung = dao.ViewDentail(id);
                nd.MaNguoiDung = Nguoidung.MaNguoiDung;

                if(mkCu!=Nguoidung.MatKhau)
                {
                    SetAlert("Mật khẩu cũ không khớp", "error");
                    return RedirectToAction("DoiMk", "TaiKhoan");
                }

                else if (mkCu==nd.MatKhau)
                {
                    SetAlert("Mật khẩu cũ và mật khẩu mới trùng nhau", "warning");
                    return RedirectToAction("DoiMk", "TaiKhoan");
                }
                else
                {
                    var result = dao.DoiMk(nd);
                    if (result)
                    {
                        SetAlert("Đổi mật khẩu thành công", "success");
                        return RedirectToAction("DoiMk", "TaiKhoan");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật thất bại");
                    }
                }
            }
            return View();
        }
    }
}