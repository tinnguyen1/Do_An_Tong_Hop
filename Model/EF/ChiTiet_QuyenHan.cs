namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTiet_QuyenHan
    {
        [Key]
        [DisplayName("Số thứ tự")]
        public int STT { get; set; }
        [DisplayName("Mã Quyền Hạn")]
        public int MaQuyenHan { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã người dùng")]
        public string MaNguoiDung { get; set; }
        [DisplayName("Ngày Phân")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayPhan { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }

        public virtual QuyenHan QuyenHan { get; set; }
    }
}
