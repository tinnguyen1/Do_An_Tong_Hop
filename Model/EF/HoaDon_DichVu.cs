namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoaDon_DichVu
    {
        [Key]
        [DisplayName("Số thứ tự")]
        public int Stt { get; set; }
        [DisplayName("Mã dịch vụ")]
        public int MaDichVu { get; set; }
        [DisplayName("Mã Phòng")]
        public int MaPhong { get; set; }
        [DisplayName("Mã hóa đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Người sử dụng")]
        [StringLength(50)]
        public string NguoiSuDung { get; set; }
        [DisplayName("Ngày sử dụng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgaySuDung { get; set; }

        public virtual ChiTietHoaDon ChiTietHoaDon { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
