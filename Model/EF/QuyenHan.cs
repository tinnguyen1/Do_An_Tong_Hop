namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuyenHan")]
    public partial class QuyenHan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuyenHan()
        {
            ChiTiet_QuyenHan = new HashSet<ChiTiet_QuyenHan>();
            ChiTiet_QuyenHan1 = new HashSet<ChiTiet_QuyenHan>();
        }

        [Key]
        public int MaQuyenHan { get; set; }

        [StringLength(50)]
        public string TenQuyenHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_QuyenHan> ChiTiet_QuyenHan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_QuyenHan> ChiTiet_QuyenHan1 { get; set; }
    }
}
