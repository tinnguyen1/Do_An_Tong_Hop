namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang_DS_DatPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bang_DS_DatPhong()
        {
            CT_DatPhong = new HashSet<CT_DatPhong>();
        }

        [Key]
        [DisplayName("Mã Đặt Phòng")]
        public int MaDatPhong { get; set; }

        [StringLength(50)]
        [DisplayName("Họ Và Tên")]
        public string HoTen { get; set; }

        [StringLength(15)]
        [DisplayName("Số Điện Thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        [DisplayName("Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(3)]
        [DisplayName("Số Người")]
        public string SoNguoi { get; set; }
        [DisplayName("Ngày Bắt Đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayBD { get; set; }
        [DisplayName("Ngày Kết Thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayKT { get; set; }
        [DisplayName("Ngày Đặt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayDat { get; set; }

        [StringLength(15)]
        [DisplayName("Tình Trạng")]
        public string TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatPhong> CT_DatPhong { get; set; }
    }
}
