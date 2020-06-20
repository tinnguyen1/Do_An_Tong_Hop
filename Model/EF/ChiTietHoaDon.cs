namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTietHoaDon()
        {
            HoaDon_DichVu = new HashSet<HoaDon_DichVu>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã phòng")]
        public int MaPhong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã hóa đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Số người")]
        public int? SoNguoi { get; set; }
        [DisplayName("Ngày bắt đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayBatDau { get; set; }
        [DisplayName("Ngày kết thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayKetThuc { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }
        [DisplayName("Ngày lập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayLap { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon_DichVu> HoaDon_DichVu { get; set; }
    }
}
