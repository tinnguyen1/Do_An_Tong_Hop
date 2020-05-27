namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            ChiTietSuDungDichVus = new HashSet<ChiTietSuDungDichVu>();
        }

        [Key]
        [DisplayName("Mã Dịch Vụ")]
        public int MaDichVu { get; set; }

        [StringLength(50)]
        [DisplayName("Tên Dịch Vụ")]
        public string TenDichVu { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSuDungDichVu> ChiTietSuDungDichVus { get; set; }
    }
}
