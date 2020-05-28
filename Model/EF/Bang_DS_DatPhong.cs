namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang_DS_DatPhong
    {
        [Key]
        public int MaDatPhong { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(15)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(3)]
        public string SoNguoi { get; set; }

        public DateTime? NgayBD { get; set; }

        public DateTime? NgayKT { get; set; }

        public DateTime? NgayDat { get; set; }

        [StringLength(15)]
        public string TinhTrang { get; set; }

        public virtual CT_DatPhong CT_DatPhong { get; set; }

        public virtual CT_DatPhong CT_DatPhong1 { get; set; }
    }
}
