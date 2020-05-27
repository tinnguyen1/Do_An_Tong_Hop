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
            ChiTietNhapHangs = new HashSet<ChiTietNhapHang>();
            QuanLyKhoHangs = new HashSet<QuanLyKhoHang>();
        }

        [Key]
        [DisplayName("Mã Kho")]
        public int MaKho { get; set; }
        [DisplayName("Mã Khách Sạn")]
        public int MaKhachSan { get; set; }
        [DisplayName("Địa Chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [DisplayName("Số Điện Thoại")]
        [StringLength(15)]
        public string SDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }

        public virtual KhachSan KhachSan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuanLyKhoHang> QuanLyKhoHangs { get; set; }
    }
}
