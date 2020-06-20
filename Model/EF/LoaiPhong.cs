namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhong()
        {
            BangGiaPhongs = new HashSet<BangGiaPhong>();
        }

        [Key]
        [DisplayName("Mã loại phòng")]
        public int MaLoaiPhong { get; set; }

        [StringLength(50)]
        [DisplayName("Tên loại phòng")]
        public string TenLoaiPhong { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Mô tả phòng")]
        public string MoTaPhong { get; set; }

        [Column(TypeName = "text")]
        [DisplayName("Ảnh")]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BangGiaPhong> BangGiaPhongs { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageFileks { get; set; }
    }
}
