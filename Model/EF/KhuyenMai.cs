namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        [DisplayName("Mã Khuyến Mãi")]
        public int MaKhuyenMai { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Khuyến Mãi")]
        public string TenKhuyenMai { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Mô Tả")]
        [AllowHtml]
        public string MoTa { get; set; }
        [DisplayName("Ngày Tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayTao { get; set; }
        [DisplayName("Ngày Bắt Đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayBD { get; set; }
        [DisplayName("Ngày Kết Thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayKT { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã Người Dùng")]
        public string MaNguoiDung { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }
    }
}
