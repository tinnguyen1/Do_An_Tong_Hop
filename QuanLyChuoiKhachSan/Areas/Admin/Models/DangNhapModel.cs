using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyChuoiKhachSan.Areas.Admin.Models
{
    public class DangNhapModel
    {
        [Required(ErrorMessage = "Mời nhập mã đăng nhập")]
        public string MaNguoiDung { set; get; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string MatKhau { set; get; }

        public string RemembreMe { set; get; }
    }
}