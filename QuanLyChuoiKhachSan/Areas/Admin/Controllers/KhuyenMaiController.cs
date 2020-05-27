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
    public class KhuyenMaiController : BaseController
    {
        // GET: Admin/KhuyenMai
        public ActionResult DanhSachKhuyenMai(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new KhuyenMaiDao();
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
        public ActionResult ThemMoi(KhuyenMai quyenhan)
        {
            if (quyenhan.TenKhuyenMai != null)
            {
                // lấy mã người dùng
                var lathongtin = Session[CommonConstants.MaND_SESSTION];
                var mand = Convert.ToString(lathongtin);
                quyenhan.MaNguoiDung = mand;

                // láy ngày hiện tại
                quyenhan.NgayTao = DateTime.Now;

                var dao = new KhuyenMaiDao();
                int id = dao.ThemMoi(quyenhan);
                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("DanhSachKhuyenMai", "KhuyenMai");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "KhuyenMai");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dao = new KhuyenMaiDao();
            var thongtin = dao.ViewDentail(id);
            return View(thongtin);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new KhuyenMaiDao();
            var thongtin = dao.ViewDentail(id);
            return View(thongtin);
        }

        [HttpPost]
        //[ValidateInput(false)]
        public ActionResult Edit(KhuyenMai km)
        {
            if (km.NgayKT < km.NgayBD)
            {
                SetAlert("Mời chọn lại ngày", "error");
                return RedirectToAction("Edit", "KhuyenMai");
            }
            else
            {
                // lấy mã người dùng
                var lathongtin = Session[CommonConstants.MaND_SESSTION];
                var mand = Convert.ToString(lathongtin);
                km.MaNguoiDung = mand;

                // láy ngày hiện tại
                km.NgayTao = DateTime.Now;


                var dao = new KhuyenMaiDao();
                var id = dao.ChinhSua(km);
                if (id == true)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachKhuyenMai", "KhuyenMai");
                }
                else
                {
                    return RedirectToAction("Edit", "KhuyenMai");
                }
            }
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KhuyenMaiDao().Delete(id);
            return RedirectToAction("DanhSachKhuyenMai");
        }


    }
}