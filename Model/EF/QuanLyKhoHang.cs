namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanLyKhoHang")]
    public partial class QuanLyKhoHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuanLyKhoHang()
        {
            DS_XuatKho = new HashSet<DS_XuatKho>();
        }

        [Key]
        [DisplayName("Số thứ tự")]
        public int STT { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mã người dùng")]
        public string MaNguoiDung { get; set; }
        [DisplayName("Mã kho")]
        public int MaKho { get; set; }
        [DisplayName("Ngày phân")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayPhan { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_XuatKho> DS_XuatKho { get; set; }

        public virtual KhoHang KhoHang { get; set; }
    }
}
