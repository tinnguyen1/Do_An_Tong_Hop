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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã đặt Phòng")]
        public int MaDatPhong { get; set; }
        [DisplayName("Mã Phòng")]
        public int MaPhong { get; set; }
        [DisplayName("Tổng giá")]
        public double? TongGia { get; set; }

        public virtual Bang_DS_DatPhong Bang_DS_DatPhong { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }
    }
}
