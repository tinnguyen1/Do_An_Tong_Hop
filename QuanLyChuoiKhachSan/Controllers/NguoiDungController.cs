using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using System.Net;

namespace QuanLyChuoiKhachSan.Controllers
{
    public class NguoiDungController : Controller
    {
        private QuanLyChuoiKhachSanDBContext db = new QuanLyChuoiKhachSanDBContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang KhachHang = db.KhachHangs.Find(id);
            if (KhachHang == null)
            {
                return HttpNotFound();
            }
            return View(KhachHang);
        }
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy([Bind(Include = "MaKhachHang,MK,TenKhachHang,SDT,DiaChi,GioiTinh,Email")] KhachHang KhachHang)
        {
            if (ModelState.IsValid)
            {
                if (db.KhachHangs.Find(KhachHang.MaKhachHang) == null)
                {
                    db.KhachHangs.Add(KhachHang);
                    db.SaveChanges();
                    Session["KH"] = KhachHang;
                    return RedirectToAction("HomeKH", "Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản đã được sử dụng !");
                }
            }

            return View(KhachHang);
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(KhachHang objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = db.KhachHangs.Where(a => a.MaKhachHang.Equals(objUser.MaKhachHang) && a.MK.Equals(objUser.MK)).FirstOrDefault();
                if (obj != null)
                {
                    Session["KH"] = obj;
                    return RedirectToAction("HomeKH", "Index");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại !!");
                }
            }
            return View(objUser);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            Session["KH"] = null;
            KhachHang kh = (KhachHang)Session["KH"];
            if (kh != null)
                return RedirectToAction("HomeKH", "Index");
            return View();
        }
    }
}