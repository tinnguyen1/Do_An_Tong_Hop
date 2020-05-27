using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class QuanLyKhoHangController : BaseController
    {
        // GET: Admin/QuanLyKhoHang
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new QuanLyKhoHangDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new KhoHangDao();
            ViewBag.MaKho = new SelectList(dao.ListAll(), "MaKho", "KhachSan.TenKhachSan", selectedMa);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            SetViewBag();
            ViewBag.MaNguoiDung = new CT_QHDao().NguoiQuanLy();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(QuanLyKhoHang ql)
        {
            if (ql.MaNguoiDung != null)
            {
                ql.NgayPhan = DateTime.Now;
                var dao = new QuanLyKhoHangDao();
                var id = dao.ThemMoi(ql);
                if (id > 0)
                {
                    SetAlert("Thêm quyền thành công", "success");
                    return RedirectToAction("Index", "QuanLyKhoHang");
                }
                else
                {
                    return RedirectToAction("ThemMoi", "QuanLyKhoHang");
                }
            }
            SetAlert("Chưa chọn người quản lý", "error");
            return RedirectToAction("ThemMoi", "QuanLyKhoHang");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dao = new QuanLyKhoHangDao().ViewDentail(id);
            SetViewBag(dao.MaKho);
            return View(dao);
        }

        [HttpGet]
        public ActionResult CapNhat(int id)
        {
            var dao = new QuanLyKhoHangDao();
            ViewBag.MaNguoiDung = new CT_QHDao().NguoiQuanLy();
            var quyenhan = dao.ViewDentail(id);
            SetViewBag(quyenhan.MaKho);
            return View(quyenhan);
        }
        [HttpPost]
        public ActionResult CapNhat(QuanLyKhoHang qh)
        {
            qh.NgayPhan = DateTime.Now;
            var dao = new QuanLyKhoHangDao();
            var cq = dao.ChinhSua(qh);
            if (cq == true)
            {
                SetAlert("Cap nhat thanh cong", "success");
                return RedirectToAction("Index", "QuanLyKhoHang");
            }
            else
            {
                return RedirectToAction("CapNhat", "QuanLyKhoHang");
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new QuanLyKhoHangDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}