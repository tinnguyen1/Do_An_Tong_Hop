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
        [DisplayName("Số thứ tự")]
        public int Stt { get; set; }
        [DisplayName("Mã đơn hàng")]
        public int MaDonHang { get; set; }
        [DisplayName("Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }
        [DisplayName("Tên hàng")]
        [StringLength(50)]
        public string TenHang { get; set; }
        [DisplayName("Loại hàng hóa")]
        [StringLength(50)]
        public string LoaiHangHoa { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
