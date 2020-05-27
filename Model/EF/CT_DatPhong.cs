namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DatPhong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Phòng")]
        public int MaPhong { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã Đặt Phòng")]
        public int MaDatPhong { get; set; }
        [DisplayName("Tổng Giá")]
        public double? TongGia { get; set; }

        public virtual Bang_DS_DatPhong Bang_DS_DatPhong { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }
    }
}
