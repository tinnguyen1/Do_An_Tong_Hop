namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHangHoa")]
    public partial class ChiTietHangHoa
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã kho")]
        public int MaKho { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã hàng")]
        public int MaHang { get; set; }
        [DisplayName("Số lượng")]
        public int? Soluong { get; set; }
        [DisplayName("Đơn giá")]
        public double? DonGia { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual KhoHang KhoHang { get; set; }
    }
}
