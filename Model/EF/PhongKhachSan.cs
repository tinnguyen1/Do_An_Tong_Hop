﻿namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
            CT_DatPhong = new HashSet<CT_DatPhong>();
        }

        [Key]
        [DisplayName("Mã phòng")]
        public int MaPhong { get; set; }
        [DisplayName("Mã bảng giá phòng")]
        public int MaBangGiaPhong { get; set; }
        [DisplayName("Mã khách sạn")]
        public int MaKhachSan { get; set; }
        [DisplayName("Tên phòng")]
        [StringLength(5)]
        public string TenPhong { get; set; }

        [StringLength(20)]
        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        public virtual BangGiaPhong BangGiaPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DatPhong> CT_DatPhong { get; set; }

        public virtual KhachSan KhachSan { get; set; }
    }
}
