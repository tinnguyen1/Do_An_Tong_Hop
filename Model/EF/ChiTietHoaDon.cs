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
            ChiTietSuDungDichVus = new HashSet<ChiTietSuDungDichVu>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Phòng")]
        public int MaPhong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Số Người")]
        public int? SoNguoi { get; set; }
        [DisplayName("Ngày Bắt Đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayBatDau { get; set; }
        [DisplayName("Ngày Kết Thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayKetThuc { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }
        [DisplayName("Ngày Lập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayLap { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDichVu> ChiTietSuDungDichVus { get; set; }
    }
}
