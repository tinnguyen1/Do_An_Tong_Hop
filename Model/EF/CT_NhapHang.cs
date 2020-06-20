namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_NhapHang
    {
        [Key]
        [DisplayName("Số thứ tự")]
        public int STT { get; set; }
        [DisplayName("Mã hàng")]
        public int MaHang { get; set; }
        [DisplayName("Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }
        [DisplayName("Mã kho")]
        public int MaKho { get; set; }

        [StringLength(50)]
        [DisplayName("Người nhập")]
        public string NguoiNhap { get; set; }
        [DisplayName("Ngày Nhập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayNhap { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual KhoHang KhoHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
