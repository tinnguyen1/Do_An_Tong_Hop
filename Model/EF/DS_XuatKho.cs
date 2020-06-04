namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_XuatKho
    {
        [Key]
        public int MaHangXuatKho { get; set; }

        public int MaHang { get; set; }

        public DateTime? NgayXuat { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public int STT { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual QuanLyKhoHang QuanLyKhoHang { get; set; }
    }
}
