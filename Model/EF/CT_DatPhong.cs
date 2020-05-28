namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DatPhong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDatPhong { get; set; }

        public int MaPhong { get; set; }

        public double? TongGia { get; set; }

        public virtual Bang_DS_DatPhong Bang_DS_DatPhong { get; set; }

        public virtual Bang_DS_DatPhong Bang_DS_DatPhong1 { get; set; }

        public virtual PhongKhachSan PhongKhachSan { get; set; }

        public virtual PhongKhachSan PhongKhachSan1 { get; set; }
    }
}
