namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_QuyenHan
    {
        [Key]
        public int STT { get; set; }

        public int MaQuyenHan { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNguoiDung { get; set; }

        public DateTime? NgayPhan { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }

        public virtual QuyenHan QuyenHan { get; set; }
    }
}
