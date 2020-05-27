using Model.Dao;
using QuanLyChuoiKhachSan.Areas.Admin.Models;
using QuanLyChuoiKhachSan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/DangNhap
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangNhap(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new NguoiDungDao();
                var result = dao.DangNhap(model.MaNguoiDung, model.MatKhau);
                if (result == 1)
                {
                    var nguoidung = dao.LayThongTinTheoMa(model.MaNguoiDung);

                    Session["TenND"] = nguoidung.TenNguoiDung;
                    Session["MaND"] = nguoidung.MaNguoiDung;

                    string str = nguoidung.Anh;
                    string[] arrListStr = str.Split('~');
                    string chuoiten = arrListStr[1];

                    Session["Anh"] = chuoiten;

                    var AdminSesstion = new AdminDangNhap();
                    AdminSesstion.TenNguoiDung = nguoidung.TenNguoiDung;
                    AdminSesstion.MaNguoiDung = nguoidung.MaNguoiDung;
                    Session[CommonConstants.MaND_SESSTION] = nguoidung.MaNguoiDung;

                    Session.Add(CommonConstants.TENND_SESSTION, AdminSesstion);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
            }
            return View("Index");
        }

        public ActionResult DangXuat(DangNhapModel model)
        {
            Session.Add(CommonConstants.TENND_SESSTION, null);
            return RedirectToAction("Index", "DangNhap");
        }
    }
}