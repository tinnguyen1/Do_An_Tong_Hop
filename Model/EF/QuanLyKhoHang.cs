namespace Model.EF
{
    using System;
    using System.Collections.Generic;
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
            DS_XuatKho1 = new HashSet<DS_XuatKho>();
        }

        [Key]
        public int STT { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNguoiDung { get; set; }

        public int MaKho { get; set; }

        public DateTime? NgayPhan { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung { get; set; }

        public virtual DanhSachNguoiDung DanhSachNguoiDung1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_XuatKho> DS_XuatKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_XuatKho> DS_XuatKho1 { get; set; }

        public virtual KhoHang KhoHang { get; set; }

        public virtual KhoHang KhoHang1 { get; set; }
    }
}
