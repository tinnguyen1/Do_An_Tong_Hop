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
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult DanhSachDonHang(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DonHangDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new KhachSanDao();
            ViewBag.MaKhachSan = new SelectList(dao.ListAll(), "MaKhachSan", "TenKhachSan", selectedMa);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(DonHang quyenhan)
        {
            if (quyenhan.TenDonHang != null)
            {
                if (quyenhan.NgayGiao>DateTime.Now)
                {
                    var dao = new DonHangDao();
                    quyenhan.NgayTao = DateTime.Now;
                    var id = dao.ThemMoi(quyenhan);
                    if (id)
                    {
                        // SetAlert("Thêm quyền thành công", "success");
                        return RedirectToAction("NhaCungcap", "Cart1");
                    }
                    else
                    {
                        return RedirectToAction("ThemMoi", "DonHang");
                    }
                }
                else
                {
                    //SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("ThemMoi", "DonHang");
                }
                
            }
            return RedirectToAction("ThemMoi", "DonHang");
        }

        //chon hang cho don hang
        public ActionResult SanPham(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HangHoaDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new DonHangDao();
            var quyenhan = dao.ViewDentail(id);
            SetViewBag(quyenhan.MaKhachSan);
            return View(quyenhan);
        }
        [HttpPost]
        public ActionResult Edit(DonHang qh)
        {
            if (ModelState.IsValid)
            {
                var dao = new DonHangDao();
                var result = dao.Edit(qh);
                if (result)
                {
                   // SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("DanhSachDonHang", "DonHang");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
            }
            return View("DanhSachDonHang");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DonHangDao().Delete(id);
            return RedirectToAction("DanhSachDonHang");
        }
    }
}