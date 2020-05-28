namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhongKhachSan")]
    public partial class PhongKhachSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongKhachSan()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietHoaDons1 = new HashSet<ChiTietHoaDon>();
            CT_DatPhong = new HashSet<CT_DatPhong>();
            CT_DatPhong1 = new HashSet<CT_DatPhong>();
        }

        [Key]
        public int MaPhong { get; set; }

        public int MaBangGiaPhong { get; set; }

        public int MaKhachSan { get; set; }

        [StringLength(5)]
        public string TenPhong { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual BangGiaPhong BangGiaPhong { get; set; }

        public virtual BangGiaPhong BangGiaPhong1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatPhong> CT_DatPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatPhong> CT_DatPhong1 { get; set; }

        public virtual KhachSan KhachSan { get; set; }

        public virtual KhachSan KhachSan1 { get; set; }
    }
}
