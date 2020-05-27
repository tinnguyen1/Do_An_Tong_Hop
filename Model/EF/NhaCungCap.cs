namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietNhapHangs = new HashSet<ChiTietNhapHang>();
        }

        [Key]
        [DisplayName("Mã Nhà Cung Cấp")]
        public int MaNhaCungCap { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Nhà Cung Cấp")]
        public string TenNhaCungCap { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }
    }
}
