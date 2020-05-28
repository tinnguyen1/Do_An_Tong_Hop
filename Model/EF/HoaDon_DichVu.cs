namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_DichVu
    {
        [Key]
        public int Stt { get; set; }

        public int MaDichVu { get; set; }

        public int MaPhong { get; set; }

        public int MaHoaDon { get; set; }

        [StringLength(50)]
        public string NguoiSuDung { get; set; }

        public DateTime? NgaySuDung { get; set; }

        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
