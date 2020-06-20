using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using PagedList;
using QuanLyChuoiKhachSan.Areas.Admin.Controllers;
using System.Data;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class DatPhongController : BaseController
    {
        private QuanLyChuoiKhachSanDBContext db = new QuanLyChuoiKhachSanDBContext();

        // GET: Admin/DatPhong
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachDatPhong(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DatPhongDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }



        [HttpGet]
        public ActionResult DatPhongMoi()
        {

            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult DatPhongMoi(Bang_DS_DatPhong lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new DatPhongDao();
                int id = dao.DatPhongMoi(lh);
                lh.NgayBD = DateTime.Now;
                lh.NgayDat = DateTime.Now;



                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    return RedirectToAction("Bang_DS_DatPhong", "ConFirmDatPhong"); 
                }
                else
                {
                    return RedirectToAction("DatPhongMoi", "DatPhong");
                }
            }
            SetViewBag();
            return View("XacNhanDatPhong");
        }
        //[HttpGet]
        //public ActionResult XacNhanDatPhong(int id)
        //{
        //    var dao = new DatPhongDao ();
        //    var Bang_DS_DatPhong = dao.ViewDentail(id);
        //    SetViewBag(Bang_DS_DatPhong.MaDatPhong);
        //    return View(Bang_DS_DatPhong);
        //}


        //[HttpPost]
        //public ActionResult XacNhanDatPhong(CT_DatPhong qh)
        //{
        //    var dao = new CT_DatPhongDao();
        //    var result = dao.XacNhanDatPhong(qh);
        //    if (result)
        //    {
        //        SetAlert("Cập nhật thành công", "success");
        //        return RedirectToAction("DanhSachDatPhong", "DatPhong");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Cập nhật thất bại");
        //    }

        //    SetViewBag(qh.MaDatPhong);
        //    return View("DanhSachDatPhong");
        //}
      





        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new DanhSachPhongDao();

            ViewBag.MaPhong = new SelectList(dao.ListAll(), "MaPhong", "TenPhong", selectedMa);
            



            //ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Gia", selectedMa);
            //ViewBag.MaBangGiaPhong = new SelectList(dao.ListAllGia(), "MaBangGiaPhong", "Tang", selectedMa);
            //ViewBag.MaLoaiPhong = new SelectList(dao.ListAllLoai(), "MaLoaiPhong", "Anh", selectedMa);



        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DatPhongDao().Delete(id);
            return RedirectToAction("DanhSachDatPhong");
        }


    }
}