namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        public int MaDonHang { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNhaCungCap { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        [StringLength(50)]
        public string LoaiHangHoa { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual DonHang DonHang1 { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaCungCap NhaCungCap1 { get; set; }
    }
}
