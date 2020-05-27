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
        [DisplayName("Mã Người Dùng")]
        public string MaNguoiDung { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Người Dùng")]
        public string TenNguoiDung { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }
        [DisplayName("Ngày Sinh")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(500)]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [StringLength(15)]
        [DisplayName("Mật Khẩu")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        [DisplayName("Giới Tính")]
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
