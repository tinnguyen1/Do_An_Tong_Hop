using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using QuanLyChuoiKhachSan.Areas.Admin.Models;
using Model.Dao;
using Model.EF;

namespace QuanLyChuoiKhachSan.Areas.Admin.Controllers
{
    public class NhapHangController : BaseController
    {
        // GET: Admin/NhapHang
        public ActionResult DanhSachNhapHang(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new CT_NhapHangDao();
            var model = dao.LayTatCaDS(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import(HttpPostedFileBase excelfile)
        {
            if (excelfile == null || excelfile.ContentLength == 0)
            {
                ViewBag.Error = "Hãy chọn một file excel<br>";
                return View("Index");
            }
            else
            {

                if (excelfile.FileName.EndsWith("xls") || excelfile.FileName.EndsWith("xlsx"))
                {
                    try
                    {
                        string path = Server.MapPath("~/Content/Excelfile/" + excelfile.FileName);
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        excelfile.SaveAs(path);
                        Excel.Application application = new Excel.Application();
                        Excel.Workbook workbook = application.Workbooks.Open(path);
                        Excel.Worksheet worksheet = workbook.ActiveSheet;
                        Excel.Range range = worksheet.UsedRange;

                        List<Excel_hanghoa> hanghoa = new List<Excel_hanghoa>();
                        Excel_thongtin tt = new Excel_thongtin();

                        //chèn vào model với các giá trị trong excelfile
                        for (int row = 3; row < range.Rows.Count; row++)
                        {
                            if (row < 4)
                            {
                                tt.MaNguoiTao = ((Excel.Range)range.Cells[row - 2, 3]).Text;
                                tt.TenNguoiTao = ((Excel.Range)range.Cells[row - 2, 2]).Text;
                                tt.MaNhaCungCap = int.Parse(((Excel.Range)range.Cells[row, 4]).Text);
                                tt.TenNhaCungCap = ((Excel.Range)range.Cells[row, 2]).Text;
                            }
                            else
                            {
                                if (row > 5)
                                {
                                    if (row <= range.Rows.Count - 2)
                                    {
                                        Excel_hanghoa hh = new Excel_hanghoa();
                                        hh.Mahang = int.Parse(((Excel.Range)range.Cells[row, 1]).Text);
                                        hh.TenHang = ((Excel.Range)range.Cells[row, 2]).Text;
                                        hh.TenLoaihang = ((Excel.Range)range.Cells[row, 3]).Text;
                                        hh.SoLuong = int.Parse(((Excel.Range)range.Cells[row, 4]).Text);
                                        hh.DonGia = double.Parse(((Excel.Range)range.Cells[row, 5]).Text);
                                        hanghoa.Add(hh);
                                    }
                                }
                            }
                        }

                        //=============Xử lý thông tin nhập vào bảng giá trị================
                        //tìm người mã mã kho bằng mã người tạo
                        var dao = new QuanLyKhoHangDao();
                        var thongtin = dao.TimNguoiDungTheoMa(tt.MaNguoiTao);
                        var dao1 = new CT_NhapHangDao();

                        //nhap hang vao table CT_NhapHang
                        for (int i = 0; i < hanghoa.Count; i++)
                        {
                            CT_NhapHang bientam = new CT_NhapHang();
                            bientam.MaHang = hanghoa[i].Mahang;
                            bientam.MaNhaCungCap = tt.MaNhaCungCap;
                            bientam.MaKho = thongtin.MaKho;
                            bientam.NguoiNhap = thongtin.DanhSachNguoiDung.TenNguoiDung + "(" + tt.MaNguoiTao + ")";
                            bientam.NgayNhap = DateTime.Now;
                            var id = dao1.ThemMoi(bientam);
                        }

                        //Nhập hàng vào chi tiết hàng hóa
                        var dao2 = new ChiTiet_HangHoaDao();
                        for (int i = 0; i < hanghoa.Count; i++)
                        {
                            ChiTietHangHoa bientam = new ChiTietHangHoa();

                            bientam.MaKho = thongtin.MaKho;
                            bientam.MaHang = hanghoa[i].Mahang;
                            bientam.Soluong = hanghoa[i].SoLuong;
                            bientam.DonGia = hanghoa[i].DonGia;

                            var id = dao2.ThemMoi(bientam);
                        }

                        ViewBag.ListHang = hanghoa;
                        return View("ThanhCong");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "file đã tồn tại, Bạn có thể chọn tên khác";
                        return View("Index");
                    }

                }
                else
                {
                    ViewBag.Error = "File không hợp lệ";
                    return View("Index");
                }
            }
        }
    }
}