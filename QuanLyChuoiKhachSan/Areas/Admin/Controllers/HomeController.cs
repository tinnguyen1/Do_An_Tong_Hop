using Model.Dao;
using Model.EF;
using QuanLyChuoiKhachSan.Areas.Admin.Models;
using QuanLyChuoiKhachSan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ColumnChart()
        {
            return View();
        }

        public ActionResult VisuaResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
            //return View();
        }

        public List<DonHang> Result()
        {
            var dao = new DonHangDao();
            var list = dao.LayDS();
            return list;
        }

    }
}