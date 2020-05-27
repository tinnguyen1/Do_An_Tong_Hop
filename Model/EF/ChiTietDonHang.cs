namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đơn Hàng")]
        public int MaDonHang { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Nhà Cung Cấp")]
        public int MaNhaCungCap { get; set; }

        [StringLength(50)]
        [DisplayName("Loại Hàng Hóa")]
        public string LoaiHangHoa { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Hàng Hóa")]
        public string TenLoaiHang { get; set; }
        [DisplayName("Số Lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
