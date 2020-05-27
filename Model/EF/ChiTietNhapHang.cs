namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietNhapHang")]
    public partial class ChiTietNhapHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Kho")]
        public int MaKho { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Nhà Cung Cấp")]
        public int MaNhaCungCap { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hàng")]
        public int MaHang { get; set; }
        [DisplayName("Số Lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Ngày Nhập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayNhap { get; set; }
        [DisplayName("Đơn Giá")]
        public double? DonGia { get; set; }

        [StringLength(50)]
        [DisplayName("Người Nhập")]
        public string NguoiNhap { get; set; }

        [StringLength(50)]
        [DisplayName("Người Chuyển Hàng")]
        public string NguoiChuyenHang { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual KhoHang KhoHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
