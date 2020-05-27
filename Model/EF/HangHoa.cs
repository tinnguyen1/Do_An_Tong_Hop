namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangHoa")]
    public partial class HangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangHoa()
        {
            ChiTietHangHoas = new HashSet<ChiTietHangHoa>();
            ChiTietNhapHangs = new HashSet<ChiTietNhapHang>();
            DS_XuatKho = new HashSet<DS_XuatKho>();
        }

        [Key]
        [DisplayName("Mã Hàng Hóa")]
        public int MaHang { get; set; }

        [DisplayName("Mã Loại Hàng")]
        public int MaLoaiHang { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Hàng")]
        public string TenHang { get; set; }
        [DisplayName("Đơn Giá")]
        public double? DonGia { get; set; }
        [DisplayName("Ngày Tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHangHoa> ChiTietHangHoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhapHang> ChiTietNhapHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DS_XuatKho> DS_XuatKho { get; set; }

        public virtual LoaiHang LoaiHang { get; set; }
    }
}
