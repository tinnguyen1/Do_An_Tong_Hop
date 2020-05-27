namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSuDungDichVu")]
    public partial class ChiTietSuDungDichVu
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Phòng")]
        public int MaPhong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Dịch Vụ")]
        public int MaDichVu { get; set; }
        [DisplayName("Số Lần")]
        public int? SoLan { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }

        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
