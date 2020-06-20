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
    public class ConFirmDatPhongController : Controller
    {
        public const string DatPhongSesstion = "DatPhongSesstion";
        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[DatPhongSesstion];
            var list = new List<PhieuDatPhong>();
            if (cart != null)
            {
                list = (List<PhieuDatPhong>)cart;
            }
            return View(list);
        }

        public void SetViewBag(int? selectedMa = null)
        {
            //var dao = new NhaCungCapDao();
            //ViewBag.MaNhaCungCap = new SelectList(dao.ListAll(), "MaNhaCungCap", "TenNhaCungCap", selectedMa);
            var dao = new DatPhongDao();
            ViewBag.MaDatPhong = new SelectList(dao.ListAll1(), "MaDatPhong", "HoTen", selectedMa);
            var giaphong = new DanhSachPhongDao();
            ViewBag.MaBangGia = new SelectList(giaphong.ListAllGia(), "MaBangGiaPhong", "Gia", selectedMa);

        }
        public ActionResult AddItem(int MaPhong)
        {
            var phong = new DanhSachPhongDao().ViewDentail(MaPhong);
            var cart = Session[DatPhongSesstion];
            if (cart != null)
            {
                var list = (List<PhieuDatPhong>)cart;
                if (list.Exists(x => x.Phong.MaPhong == MaPhong))
                {
                    foreach (var item in list)
                    {
                        if (item.Phong.MaPhong == MaPhong)
                        {
                            ModelState.AddModelError("", "Phòng đã Có");
                        }
                        else
                        {
                            //trong
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng
                    var item = new PhieuDatPhong();
                    item.Phong = phong;
                    list.Add(item);
                }
                //Gán vào Session
                Session[DatPhongSesstion] = list;
            }
            else
            {
                //tạo mới đối tượng
                var item = new PhieuDatPhong();
                item.Phong = phong;

                var list = new List<PhieuDatPhong>();
                list.Add(item);
                //Gán vào session
                Session[DatPhongSesstion] = list;
            }
            return RedirectToAction("Index");
        }

        //update gio hang
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<PhieuDatPhong>>(cartModel);
            //danh sach hang trong cart
            var sessionCart = (List<PhieuDatPhong>)Session[DatPhongSesstion];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Phong.MaPhong == item.Phong.MaPhong);

                if (jsonItem != null && jsonItem.SoLuong > 0)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }

            Session[DatPhongSesstion] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[DatPhongSesstion] = null;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Xoa(int maPhong)
        {
            //===========tự làm================
            var sessionCart = (List<PhieuDatPhong>)Session[DatPhongSesstion];
            PhieuDatPhong sanpham = sessionCart.SingleOrDefault(x => x.Phong.MaPhong == maPhong);
            if (sanpham != null)
            {
                sessionCart.RemoveAll(x => x.Phong.MaPhong == maPhong);
                return RedirectToAction("Index");
            }

            if (sessionCart.Count == 0)
            {
                return RedirectToAction("Index", "ConFirmDatPhong");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Bang_DS_DatPhong()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Bang_DS_DatPhong(Bang_DS_DatPhong  dp)
        {
            Session[CommonConstants.BangDPSesstion] = dp.MaDatPhong;

            return RedirectToAction("ChonPhong", "Phong");
        }

        public ActionResult DanhSachDatPhong()
        {
            //khai Bao
            var sessionCart = (List<PhieuDatPhong>)Session[DatPhongSesstion];// danh sach cart
            var lathongtin = Session[CommonConstants.BangDPSesstion];
            var mand = Convert.ToInt32(lathongtin);
            //var datphong = new DatPhongDao().ViewDentail(mand);
            var dp = new DatPhongDao().ViewDentail(mand);
            var phongks = new DanhSachPhongDao().PhongTaoMoi();
            var dao = new CT_DatPhongDao();

            CT_DatPhong BienTam = new CT_DatPhong();
            BienTam.MaDatPhong = dp.MaDatPhong;
            BienTam.MaPhong = phongks[0].MaPhong;


            //foreach (var item in sessionCart)
            //{
            //    if (item.SoLuong > 0)
            //    {
            //        BienTam.LoaiHangHoa = item.Hang_Hoa.LoaiHang.TenLoaiHang;
            //        BienTam.TenHang = item.Hang_Hoa.TenHang;
            //        BienTam.SoLuong = item.SoLuong;
            //        BienTam.Gia = item.Hang_Hoa.DonGia;
            //        var id = dao.Add(BienTam);

            //    }
            //}
            //var result = ExportData(Ncc, donhang);
            Session[DatPhongSesstion] = null;
            return RedirectToAction("Index", "ConFirmDatPhong");
        }

        //private bool ExportData(NhaCungCap ncc, List<DonHang> dh)
        //{
        //    bool result = false;
        //    try
        //    {

        //        ExcelPackage pck = new ExcelPackage();

        //        var ws = pck.Workbook.Worksheets.Add("Danh sách đơn hàng ngày "
        //            + DateTime.Now.ToString("hh:mm:ss_ddMMyy"));//Student sheet

        //        var sessionCart = (List<CartItem>)Session[NhapHangSesstion];
        //        var lathongtin = Session[CommonConstants.MaND_SESSTION]; //lay ma quan ly tu session
        //        var mand = Convert.ToString(lathongtin);//chuyen ma thanh string
        //        var dao2 = new NguoiDungDao().ViewDentail(mand);

        //        var student = sessionCart;
        //        int startRow = 1;
        //        foreach (var item in student)
        //        {
        //            if (startRow == 1)
        //            {
        //                ws.Cells[startRow, 1].Value = "Người Tạo";
        //                ws.Cells[startRow, 2].Value = dao2.TenNguoiDung;
        //                ws.Cells[startRow, 3].Value = dao2.MaNguoiDung;
        //                ws.Cells[startRow + 1, 1].Value = "Ngày tạo";
        //                ws.Cells[startRow + 1, 2].Value = DateTime.Now.ToString("dd_MM_yyy");
        //                ws.Cells[startRow + 1, 4].Value = "Ngày Giao";
        //                ws.Cells[startRow + 1, 5].Value = dh[0].NgayGiao;
        //                ws.Cells[startRow + 1, 5].Style.Numberformat.Format = "dd/MM/yyyy";
        //                ws.Cells[startRow + 2, 1].Value = "Nhà Cung cấp";
        //                ws.Cells[startRow + 2, 2].Value = ncc.TenNhaCungCap;
        //                ws.Cells[startRow + 2, 3].Value = "Mã Nhà Cung cấp";
        //                ws.Cells[startRow + 2, 4].Value = ncc.MaNhaCungCap;
        //                startRow = startRow + 4;
        //            }

        //            if (startRow == 5)
        //            {
        //                ws.Cells[startRow, 1].Value = "Mã Hàng";
        //                ws.Cells[startRow, 2].Value = "Tên Hàng";
        //                ws.Cells[startRow, 3].Value = "Loại Hàng";
        //                ws.Cells[startRow, 4].Value = "Số lượng";
        //                ws.Cells[startRow, 5].Value = "Đơn giá";
        //                ws.Cells[startRow, 6].Value = "Thành tiền";
        //                startRow++;
        //            }
        //            if (startRow > 5)
        //            {
        //                ws.Cells[startRow, 1].Value = item.Hang_Hoa.MaHang;
        //                ws.Cells[startRow, 2].Value = item.Hang_Hoa.TenHang;
        //                ws.Cells[startRow, 3].Value = item.Hang_Hoa.LoaiHang.TenLoaiHang;
        //                ws.Cells[startRow, 4].Value = item.SoLuong;
        //                ws.Cells[startRow, 5].Value = item.Hang_Hoa.DonGia;
        //                ws.Cells[startRow, 6].Value = (item.Hang_Hoa.DonGia * item.SoLuong);
        //                startRow++;
        //            }

        //        }
        //        ws.Cells[startRow + 1, 5].Value = "Tổng tiền: ";
        //        ws.Cells[startRow + 1, 6].Value = Sum();

        //        Response.Clear();
        //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //        Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
        //        Response.BinaryWrite(pck.GetAsByteArray());
        //        Response.End();
        //        return result = true;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return result;
        //}

        //public double? Sum()
        //{
        //    var sessionCart = (List<PhieuDatPhong>)Session[DatPhongSesstion];
        //    double? TongGia = 0;

        //    foreach (var item in sessionCart)
        //    {
        //        var bien = item.Phong.MaBangGiaPhong * item.Hang_Hoa.DonGia;
        //        TongGia = TongGia + bien;
        //    }
        //    return TongGia;
        //}
    }
}