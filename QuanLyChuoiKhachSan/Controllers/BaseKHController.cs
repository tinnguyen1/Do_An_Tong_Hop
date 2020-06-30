
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuanLyChuoiKhachSan.Common;

namespace QuanLyChuoiKhachSan.Controllers
{
    public class BaseKHController : Controller
    {
       

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessager"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }

    }
}