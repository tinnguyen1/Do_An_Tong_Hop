using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using PagedList;
using QuanLyChuoiKhachSan.Areas.Admin.Controllers;
using System.Data;
using Newtonsoft.Json;
using System.Data.Entity;


namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class ConFirmDatPhongController : BaseController
    {
        private QuanLyChuoiKhachSanDBContext db = new QuanLyChuoiKhachSanDBContext();
        // GET: Admin/ConFirmDatPhong

        public ActionResult DanhSach(string searchString, int page = 1, int pageSize = 10)
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
        public void SetViewBag(int? selectedMa = null)
        {
            var dao = new DanhSachPhongDao();
            ViewBag.MaPhong = new SelectList(dao.ListAll(), "MaPhong", "TenPhong", selectedMa);
        }
        [HttpGet]
        public ActionResult XacNhanDatPhong()
        {

            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult XacNhanDatPhong(Bang_DS_DatPhong lh)
        {
            if (ModelState.IsValid)
            {
                var dao = new CT_DatPhongDao();
                int id = dao.XacNhanDatPhong(lh);
               



                if (id > 0)
                {
                    SetAlert("Thêm thành công", "success");
                    
                }
                else
                {
                   
                }
            }
            SetViewBag();
            return View("XacNhanDatPhong");
        }

        //[HttpGet]
        //public ActionResult XacNhanDatPhong(int id)
        //{
        //    var dao = new CT_DatPhongDao().ViewDentail(id);
        //    var CT_DatPhong = dao.Bang_DS_DatPhong;
        //    SetViewBag(dao.MaDatPhong);
        //    return View(CT_DatPhong);
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

        //    //SetViewBag(qh.MaDatPhong);
        //    return View("DanhSachDatPhong");
        //}


    }
}