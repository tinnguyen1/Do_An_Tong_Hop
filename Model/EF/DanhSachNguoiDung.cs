namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("DanhSachNguoiDung")]
    public partial class DanhSachNguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSachNguoiDung()
        {
            ChiTiet_QuyenHan = new HashSet<ChiTiet_QuyenHan>();
            KhuyenMais = new HashSet<KhuyenMai>();
            QuanLyKhoHangs = new HashSet<QuanLyKhoHang>();
        }

        [Key]
        [StringLength(10)]
        public string MaNguoiDung { get; set; }

        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(500)]
        public string Anh { get; set; }

        [StringLength(15)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_QuyenHan> ChiTiet_QuyenHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhuyenMai> KhuyenMais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuanLyKhoHang> QuanLyKhoHangs { get; set; }
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }
    }
}
