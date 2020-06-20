namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Mvc;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachSan()
        {
            DonHangs = new HashSet<DonHang>();
            KhoHangs = new HashSet<KhoHang>();
            PhongKhachSans = new HashSet<PhongKhachSan>();
        }

        [Key]
        [DisplayName("Mã khách sạn")]
        public int MaKhachSan { get; set; }

        [StringLength(100)]
        [DisplayName("Tên khách sạn")]
        public string TenKhachSan { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        [DisplayName("Ảnh")]
        [StringLength(500)]
        public string Anh { get; set; }
        [DisplayName("Số điện thoại")]
        [StringLength(15)]
        public string SDT { get; set; }

        [Column(TypeName = "text")]
        [AllowHtml]
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoHang> KhoHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongKhachSan> PhongKhachSans { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageFileks { get; set; }
    }
}
