using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyChuoiKhachSan.Areas.Admin.Models
{
    [Serializable]//Tuần tự hóa
    public class CartItem
    {
        public HangHoa Hang_Hoa { set; get; }
        public int SoLuong { set; get; }
    }
}