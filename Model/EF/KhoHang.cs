namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoHang")]
    public partial class KhoHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoHang()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
            CT_NhapHang = new HashSet<CT_NhapHang>();
            QuanLyKhoHangs = new HashSet<QuanLyKhoHang>();
        }

        [Key]
        [DisplayName("Mã kho")]
        public int MaKho { get; set; }
        [DisplayName("Mã khách sạn")]
        public int MaKhachSan { get; set; }
        [DisplayName("Địa chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        [StringLength(15)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_NhapHang> CT_NhapHang { get; set; }

        public virtual KhachSan KhachSan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuanLyKhoHang> QuanLyKhoHangs { get; set; }
    }
}
