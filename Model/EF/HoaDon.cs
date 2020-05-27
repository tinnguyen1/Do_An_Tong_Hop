namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [DisplayName("Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Mã Khách Hàng")]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Hóa Đơn")]
        public string TenHoaDon { get; set; }
        [DisplayName("Ngày Lập")]
        public DateTime? NgayLap { get; set; }
        [DisplayName("Tổng Tiền")]
        public double? TongTien { get; set; }

        [StringLength(20)]
        [DisplayName("Tình Trạng")]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
