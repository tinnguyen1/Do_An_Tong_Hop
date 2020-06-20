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
        [DisplayName("Mã khuyến mãi")]
        public int MaKhuyenMai { get; set; }

        [StringLength(100)]
        [DisplayName("Tên khuyến mãi")]
        public string TenKhuyenMai { get; set; }

        [Column(TypeName = "text")]
        [AllowHtml]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime? NgayTao { get; set; }
        [DisplayName("Ngày bắt đầu")]
        public DateTime? NgayBD { get; set; }
        [DisplayName("Ngày kết thúc")]
        public DateTime? NgayKT { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã người dùng")]
        public string MaNguoiDung { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }
    }
}
