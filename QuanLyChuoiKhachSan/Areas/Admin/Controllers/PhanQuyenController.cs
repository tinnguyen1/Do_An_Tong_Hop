using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class PhanQuyenController : BaseController
    {
        // GET: Admin/PhanQuyen
        public ActionResult DanhSachQuyenHan( int page = 1, int pageSize = 10)
        {
            var dao = new CT_QHDao();
            var model = dao.LayTatCaDS( page, pageSize);
            return View(model);
        }

        // phân quyền
        public ActionResult DanhSachCanThem(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CT_QHDao().DanhSachCanThem(searchString, page, pageSize);
            return View(dao);
        }

        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new QuyenhanDao();
            ViewBag.MaQuyenHan = new SelectList(dao.ListAll(), "MaQuyenHan", "TenQuyenHan", selectedMa);
        }
        //thong tin nguoi dung
        [HttpGet]
        public ActionResult ThongTin(string id)
        {
            var dao = new NguoiDungDao();
            var quyenhan = dao.ViewDentail(id);
            return View(quyenhan);
        }

        [HttpGet]
        public ActionResult CapQuyen(string id)
        {
            var dao = new NguoiDungDao();
            var quyenhan = dao.ViewDentail(id);
            SetViewBag();
            return View(quyenhan);
        }

        [HttpPost]
        public ActionResult CapQuyen(ChiTiet_QuyenHan ctqh)
        {
            ctqh.NgayPhan = DateTime.Now;
            var dao = new CT_QHDao();
            var cq = dao.ThemMoi(ctqh);
            if (cq > 0)
            {
                SetAlert("Thêm quyền thành công", "success");
                return RedirectToAction("DanhSachCanThem", "PhanQuyen");
            }
            else
            {
                return RedirectToAction("CapQuyen", "PhanQuyen");
            }
        }

        //chi tiet nguoi da duoc cap quyen
        [HttpGet]
        public ActionResult Details(string id)
        {
            var dao = new CT_QHDao().ViewDentail(id);
            SetViewBag(dao.MaQuyenHan);
            return View(dao);
        }

        [HttpGet]
        public ActionResult CapNhat(string id)
        {
            var dao = new CT_QHDao();
            var quyenhan = dao.ViewDentail(id);
            SetViewBag(quyenhan.MaQuyenHan);
            return View(quyenhan);
        }
        [HttpPost]
        public ActionResult CapNhat(ChiTiet_QuyenHan qh)
        {
            qh.NgayPhan = DateTime.Now;
            var dao = new CT_QHDao();
            var cq = dao.ChinhSua(qh);
            if (cq ==true)
            {
                SetAlert("Cap nhat thanh cong", "success");
                return RedirectToAction("DanhSachQuyenHan", "PhanQuyen");
            }
            else
            {
                return RedirectToAction("CapQuyen", "PhanQuyen");
            }
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new CT_QHDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}