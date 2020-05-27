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
        [DisplayName("Mã Hàng Xuất Kho")]
        public int MaHangXuatKho { get; set; }
        [DisplayName("Mã Hàng")]
        public int MaHang { get; set; }
        [DisplayName("Ngày Nhập")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayXuat { get; set; }
        [DisplayName("Số Lượng")]
        public int? SoLuong { get; set; }
        [DisplayName("Đơn Giá")]
        public double? DonGia { get; set; }
        [DisplayName("Số Thứ Tự")]
        public int STT { get; set; }

        public virtual HangHoa HangHoa { get; set; }

        public virtual QuanLyKhoHang QuanLyKhoHang { get; set; }
    }
}
