using Model.Dao;
using Model.EF;
using OfficeOpenXml;
using QuanLyChuoiKhachSan.Areas.Admin.Models;
using QuanLyChuoiKhachSan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class CartController : BaseController
    {

        public const string CartSesstion = "CartSession";
        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[CartSesstion];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public ActionResult AddItem(int MaHang, int SoLuong)
        {
            var hanghoa = new HangHoaDao().ViewDentail(MaHang);
            var cart = Session[CartSesstion];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Hang_Hoa.MaHang == MaHang))
                {
                    foreach (var item in list)
                    {
                        if (item.Hang_Hoa.MaHang == MaHang)
                        {
                            item.SoLuong += SoLuong;
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng
                    var item = new CartItem();
                    item.Hang_Hoa = hanghoa;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                //Gán vào Session
                Session[CartSesstion] = list;
            }
            else
            {
                //tạo mới đối tượng
                var item = new CartItem();
                item.Hang_Hoa = hanghoa;
                item.SoLuong = SoLuong;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSesstion] = list;
            }
            return RedirectToAction("Index");
        }

        //update gio hang
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            //danh sach hang trong cart
            var sessionCart = (List<CartItem>)Session[CartSesstion];

            //=======danh sach hang nguoi quan ly kho======
            //lay ma nguoi quan ly
            var lathongtin = Session[CommonConstants.MaND_SESSTION];
            var mand = Convert.ToString(lathongtin);
            string maNguoiDung = mand;
            //Tim nguoi quan ly kho
            var dao1 = new QuanLyKhoHangDao().TimNguoiDungTheoMa(maNguoiDung);
            int maKho = dao1.MaKho;
            // danh sach trong kho
            var dao = new ChiTiet_HangHoaDao().LayDStheoManguoiDung(maKho);

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Hang_Hoa.MaHang == item.Hang_Hoa.MaHang);
                var HangTrongKho = dao.SingleOrDefault(x => x.MaHang == item.Hang_Hoa.MaHang);
                if (jsonItem != null && jsonItem.SoLuong > 0 && jsonItem.SoLuong <= HangTrongKho.Soluong)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
                else if (jsonItem != null && jsonItem.SoLuong > 0 && jsonItem.SoLuong > HangTrongKho.Soluong)
                {
                    item.SoLuong = Convert.ToInt32(HangTrongKho.Soluong);
                }
            }
            Session[CartSesstion] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CartSesstion] = null;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Xoa(int maHang)
        {
            //===========tự làm================
            var sessionCart = (List<CartItem>)Session[CartSesstion];
            CartItem sanpham = sessionCart.SingleOrDefault(x => x.Hang_Hoa.MaHang == maHang);
            if (sanpham != null)
            {
                sessionCart.RemoveAll(x => x.Hang_Hoa.MaHang == maHang);
                return RedirectToAction("Index");
            }

            if (sessionCart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }

            return RedirectToAction("Index");
        }

        public ActionResult TaoDonHang()
        {
            //khai Bao
            var sessionCart = (List<CartItem>)Session[CartSesstion];// danh sach cart
            var dao = new DS_XuatKhoDao();
            var dao1 = new ChiTiet_HangHoaDao();
            DS_XuatKho BienTam = new DS_XuatKho(); //khai bao bien tam

            //ma nguoi dung
            var lathongtin = Session[CommonConstants.MaND_SESSTION]; //lay ma quan ly tu session
            var mand = Convert.ToString(lathongtin);//chuyen ma thanh string
            var dao2 = new QuanLyKhoHangDao().TimNguoiDungTheoMa(mand); //tim ma nguoi dung trong bang quan ly kho hang
            int Stt = dao2.STT;//gan gia tri cho stt
            int maKho = dao2.MaKho;

            foreach (var item in sessionCart)
            {
                if (item.SoLuong > 0)
                {
                    BienTam.MaHang = item.Hang_Hoa.MaHang;
                    BienTam.NgayXuat = DateTime.Now;
                    BienTam.SoLuong = item.SoLuong;
                    BienTam.DonGia = item.Hang_Hoa.DonGia;
                    BienTam.STT = Stt;

                    var id = dao.ThemMoi(BienTam);
                    if (id > 0)
                    {
                        dao1.ChinhSua(BienTam, maKho);
                    }
                }
            }

            Session[CartSesstion] = null;

            SetAlert("Đã tạo xong Hàng Xuất Kho", "success");
            return RedirectToAction("Index", "Cart");
        }
    }
}