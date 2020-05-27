using Model.Dao;
using QuanLyChuoiKhachSan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class XuatHangController : BaseController
    {
        // GET: Admin/XuatHang
        public ActionResult Index( int page = 1, int pageSize = 10)
        {
            var dao = new ChiTiet_HangHoaDao();

            // lấy mã người dùng
            var lathongtin = Session[CommonConstants.MaND_SESSTION];
            var mand = Convert.ToString(lathongtin);
            string maNguoiDung = mand;

            //Tim nguoi quan ly kho
            var dao1 = new QuanLyKhoHangDao().TimNguoiDungTheoMa(maNguoiDung);
            if(dao1 != null)
            {
                int maKho = dao1.MaKho;
                var model = dao.LayTatCaDSTheoMaKho(page, pageSize, maKho);
                return View(model);
            }
            else
            {
                return RedirectToAction("Trangloi");
            }
           
        }

        public ActionResult TrangLoi()
        {
            return View();
        }
    }
}