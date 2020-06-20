namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [DisplayName("Mã đơn hàng")]
        public int MaDonHang { get; set; }
        [DisplayName("Mã khách sạn")]
        public int MaKhachSan { get; set; }
        [DisplayName("Tên đơn hàng")]
        [StringLength(100)]
        public string TenDonHang { get; set; }

        [DisplayName("Ngày giao")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayGiao { get; set; }
        [DisplayName("Ngày tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayTao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhachSan KhachSan { get; set; }
    }
}
