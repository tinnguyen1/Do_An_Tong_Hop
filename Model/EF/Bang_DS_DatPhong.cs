namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bang_DS_DatPhong
    {
        [Key]
        [DisplayName("Mã đặt phòng")]
        public int MaDatPhong { get; set; }

        [StringLength(50)]
        [DisplayName("Họ và tên")]
        public string HoTen { get; set; }

        [StringLength(15)]
        [DisplayName("Số điện thoại")]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(3)]
        [DisplayName("Số người")]
        public string SoNguoi { get; set; }
        [DisplayName("Ngày Bắt đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayBD { get; set; }
        [DisplayName("Ngày kết thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayKT { get; set; }
        [DisplayName("Ngày đặt")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? NgayDat { get; set; }

        [StringLength(15)]
        [DisplayName("Tình trạng")]
        public string TinhTrang { get; set; }

        [StringLength(15)]
        [DisplayName("Giới Tính")]
        public string GioiTinh { get; set; }
        
        public virtual CT_DatPhong CT_DatPhong { get; set; }
    }
}
