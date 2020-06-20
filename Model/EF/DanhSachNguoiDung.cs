namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("Mã người dùng")]
        public string MaNguoiDung { get; set; }

        [StringLength(50)]
        [DisplayName("Tên người dùng")]
        public string TenNguoiDung { get; set; }
        [DisplayName("Địa chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        [StringLength(15)]
        public string SDT { get; set; }
        [DisplayName("Ngày sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgaySinh { get; set; }
        [DisplayName("Ảnh")]
        [StringLength(500)]
        public string Anh { get; set; }
        [DisplayName("Mật khẩu")]
        [StringLength(15)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        [DisplayName("Giới tính")]
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
