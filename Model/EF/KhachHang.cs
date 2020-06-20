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
        [DisplayName("Mã khách hàng")]
        public int MaKhachHang { get; set; }

        [StringLength(50)]
        [DisplayName("Tên khách hàng")]
        public string TenKhachHang { get; set; }

        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(5)]
        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
