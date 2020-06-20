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
            CT_NhapHang = new HashSet<CT_NhapHang>();
        }

        [Key]
        [DisplayName("Mã nhà cung cấp")]
        public int MaNhaCungCap { get; set; }

        [StringLength(100)]
        [DisplayName("Tên nhà cung cấp")]
        public string TenNhaCungCap { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_NhapHang> CT_NhapHang { get; set; }
    }
}
