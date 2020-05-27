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
        [DisplayName("Mã Khách Sạn")]
        public int MaKhachSan { get; set; }

        [StringLength(100)]
        [DisplayName("Tên Khách Sạn")]
        public string TenKhachSan { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Ghi Chú")]
        [AllowHtml]
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
