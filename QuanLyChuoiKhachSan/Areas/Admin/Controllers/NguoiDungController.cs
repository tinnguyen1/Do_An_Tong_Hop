using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class NguoiDungController : BaseController
    {
        // GET: Admin/NguoiDung
        public ActionResult Index(string searchString, int page = 1, int pageSize = 20)
        {
            var dao = new NguoiDungDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult ThemMoiNguoiDung()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiNguoiDung(DanhSachNguoiDung ND)
        {
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(ND.imageFile.FileName);
                string extension = Path.GetExtension(ND.imageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                ND.Anh = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                ND.imageFile.SaveAs(fileName);

                DateTime? gv = ND.NgaySinh;
                var st = String.Format("{0:dd/MM/yy}", gv);
                var ngay = st.ToString();
                string[] ngay1 = ngay.Split('-');
                string chuoingay = "";
                for (int i = 0; i < ngay1.Length; i++)
                {
                    string Str1 = ngay1[i].Substring(0);
                    chuoingay += Str1;
                }

                string str = ND.TenNguoiDung;
                string[] arrListStr = str.Split(' ');
                string chuoiten = "";
                for (int i = 0; i < arrListStr.Length; i++)
                {
                    string Str1 = arrListStr[i].Substring(0, 1);
                    Str1 = Str1.ToUpper();
                    chuoiten += Str1;
                }

                ND.MaNguoiDung = chuoiten + chuoingay;
                var dao = new NguoiDungDao();
                ND.MatKhau = ND.MaNguoiDung;
                string id = dao.ThemMoi(ND);
                if (id != null)
                {
                    SetAlert("Thêm người dùng thành công", "success");
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    SetAlert("Thêm người dùng thất bại", "error");
                    return RedirectToAction("ThemMoiNguoiDung", "NguoiDung");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new NguoiDungDao();
            var nguoidung = dao.ViewDentail(id);
            return View(nguoidung);
        }
        [HttpPost]
        public ActionResult Edit(DanhSachNguoiDung ND)
        {
            if (ModelState.IsValid)
            {
                if (ND.imageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ND.imageFile.FileName);
                    string extension = Path.GetExtension(ND.imageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    ND.Anh = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    ND.imageFile.SaveAs(fileName);
                }

                var dao = new NguoiDungDao();
                var result = dao.ChinhSua(ND);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "NguoiDung");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "error");
                    return RedirectToAction("Edit", "NguoiDung");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id, string kt)
        {
            if (id != kt)
            {
                new NguoiDungDao().Delete(id);
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            else
            {
                SetAlert("Đây là tài khoản của bạn không thể xóa", "error");
                return RedirectToAction("Index", "NguoiDung");
            }
            
        }
    }
}