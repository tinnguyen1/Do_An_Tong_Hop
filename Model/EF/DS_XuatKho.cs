namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DS_XuatKho
    {
        [Key]
        [DisplayName("Mã hàng xuất kho")]
        public int MaHangXuatKho { get; set; }

        [DisplayName("Mã hàng")]
        public int MaHang { get; set; }

        [DisplayName("Ngày xuất")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayXuat { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Đơn giá")]
        public double? DonGia { get; set; }
        [DisplayName("Số thứ tự")]
        public int STT { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual QuanLyKhoHang QuanLyKhoHang { get; set; }
    }
}
