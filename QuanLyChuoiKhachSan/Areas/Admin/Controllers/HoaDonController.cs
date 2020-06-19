using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        // GET: Admin/HoaDon
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new HoaDonDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
    }
}