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
        [DisplayName("Mã hóa đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Mã khách hàng")]
        public int MaKhachHang { get; set; }
        [DisplayName("Tên hóa đơn")]
        [StringLength(50)]
        public string TenHoaDon { get; set; }
        [DisplayName("Ngày lập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayLap { get; set; }
        [DisplayName("Tổng tiền")]
        public double? TongTien { get; set; }
        [DisplayName("Tình trạng")]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
