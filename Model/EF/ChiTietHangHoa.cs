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
        [DisplayName("Mã Kho")]
        public int MaKho { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hàng")]
        public int MaHang { get; set; }
        [DisplayName("Số Lượng")]
        public int? Soluong { get; set; }
        [DisplayName("Đơn Giá")]
        public double? DonGia { get; set; }
        public virtual HangHoa HangHoa { get; set; }

        public virtual KhoHang KhoHang { get; set; }
    }
}
