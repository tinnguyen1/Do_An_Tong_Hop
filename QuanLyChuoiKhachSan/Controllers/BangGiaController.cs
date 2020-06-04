using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;

namespace QuanLyChuoiKhachSan.Controllers
{
    public class BangGiaController : Controller
    {
        QuanLyChuoiKhachSanDBContext db = new QuanLyChuoiKhachSanDBContext();
        // GET: BangGia
        public ActionResult Index()
        {
            return View();
        }


        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new DanhSachPhongDao();
            ViewBag.MaKhachSan = new SelectList(dao.ListAll(), "MaLoaiPhong", "TenLoaiPhong", selectedMa);
            ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Gia", selectedMa);

            ViewBag.MaLoaiPhong = new SelectList(dao.ListAllLoai(), "MaLoaiPhong", "Anh", selectedMa);



        }

        public ActionResult BangGiaPhong(string searchString, int page = 1, int pageSize = 10)
        {
            return View(db.BangGiaPhongs.ToList());
        }

        public ActionResult BangGiaDichVu(string searchString, int page = 1, int pageSize = 10)
        {
            return View(db.DichVus.ToList());
        }

    }
}