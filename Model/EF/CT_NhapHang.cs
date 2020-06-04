namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_NhapHang
    {
        [Key]
        public int STT { get; set; }

        public int MaHang { get; set; }

        public int MaNhaCungCap { get; set; }

        public int MaKho { get; set; }

        [StringLength(50)]
        public string NguoiNhap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual KhoHang KhoHang { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
