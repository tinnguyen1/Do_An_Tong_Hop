namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BangGiaPhong")]
    public partial class BangGiaPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BangGiaPhong()
        {
            PhongKhachSans = new HashSet<PhongKhachSan>();
        }

        [Key]
        [DisplayName("Mã bảng giá phòng")]
        public int MaBangGiaPhong { get; set; }
        [DisplayName("Mã phòng")]
        public int MaLoaiPhong { get; set; }
        [DisplayName("Tầng")]
        public int? Tang { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }
        [DisplayName("Loại Phòng")]
        public virtual LoaiPhong LoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongKhachSan> PhongKhachSans { get; set; }
    }
}
