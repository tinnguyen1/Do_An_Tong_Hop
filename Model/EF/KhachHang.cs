namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [DisplayName("Mã Khách Hàng")]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Khách Hàng")]
        public string TenKhachHang { get; set; }

        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [StringLength(5)]
        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
