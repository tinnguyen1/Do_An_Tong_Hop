using System;
using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChuoiKhachSan.Areas.Admin.Models
{
    [Serializable]//Tuần tự hóa
    public class PhieuDatPhong
    {
        public PhongKhachSan Phong { set; get; }
        public int SoLuong { set; get; }
        //public Bang_DS_DatPhong datphong { set; get; }
    }
}