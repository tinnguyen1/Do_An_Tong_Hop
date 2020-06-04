namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("KhuyenMai")]
    public partial class KhuyenMai
    {
        [Key]
        public int MaKhuyenMai { get; set; }

        [StringLength(100)]
        public string TenKhuyenMai { get; set; }

        [Column(TypeName = "text")]
        [AllowHtml]
        public string MoTa { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayBD { get; set; }

        public DateTime? NgayKT { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNguoiDung { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }
    }
}
