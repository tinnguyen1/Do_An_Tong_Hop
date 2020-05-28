namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyChuoiKhachSanDBContext : DbContext
    {
        public QuanLyChuoiKhachSanDBContext()
            : base("name=QuanLyChuoiKhachSanDBContext")
        {
        }

        public virtual DbSet<Bang_DS_DatPhong> Bang_DS_DatPhong { get; set; }
        public virtual DbSet<BangGiaPhong> BangGiaPhongs { get; set; }
        public virtual DbSet<ChiTiet_QuyenHan> ChiTiet_QuyenHan { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietHangHoa> ChiTietHangHoas { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<CT_DatPhong> CT_DatPhong { get; set; }
        public virtual DbSet<CT_NhapHang> CT_NhapHang { get; set; }
        public virtual DbSet<DanhSachNguoiDung> DanhSachNguoiDungs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DS_XuatKho> DS_XuatKho { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HoaDon_DichVu> HoaDon_DichVu { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhachSan> KhachSans { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<PhongKhachSan> PhongKhachSans { get; set; }
        public virtual DbSet<QuanLyKhoHang> QuanLyKhoHangs { get; set; }
        public virtual DbSet<QuyenHan> QuyenHans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.SoNguoi)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .HasOptional(e => e.CT_DatPhong)
                .WithRequired(e => e.Bang_DS_DatPhong);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .HasOptional(e => e.CT_DatPhong1)
                .WithRequired(e => e.Bang_DS_DatPhong1);

            modelBuilder.Entity<BangGiaPhong>()
                .HasMany(e => e.PhongKhachSans)
                .WithRequired(e => e.BangGiaPhong)
                .HasForeignKey(e => e.MaBangGiaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BangGiaPhong>()
                .HasMany(e => e.PhongKhachSans1)
                .WithRequired(e => e.BangGiaPhong1)
                .HasForeignKey(e => e.MaBangGiaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTiet_QuyenHan>()
                .Property(e => e.MaNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.TenHang)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasMany(e => e.HoaDon_DichVu)
                .WithRequired(e => e.ChiTietHoaDon)
                .HasForeignKey(e => new { e.MaPhong, e.MaHoaDon })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CT_NhapHang>()
                .Property(e => e.NguoiNhap)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.MaNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.ChiTiet_QuyenHan)
                .WithRequired(e => e.DanhSachNguoiDung)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.ChiTiet_QuyenHan1)
                .WithRequired(e => e.DanhSachNguoiDung1)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.KhuyenMais)
                .WithRequired(e => e.DanhSachNguoiDung)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.KhuyenMais1)
                .WithRequired(e => e.DanhSachNguoiDung1)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.QuanLyKhoHangs)
                .WithRequired(e => e.DanhSachNguoiDung)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.QuanLyKhoHangs1)
                .WithRequired(e => e.DanhSachNguoiDung1)
                .HasForeignKey(e => e.MaNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.HoaDon_DichVu)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .HasForeignKey(e => e.MaDonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs1)
                .WithRequired(e => e.DonHang1)
                .HasForeignKey(e => e.MaDonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietHangHoas)
                .WithRequired(e => e.HangHoa)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietHangHoas1)
                .WithRequired(e => e.HangHoa1)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.HangHoa)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.CT_NhapHang1)
                .WithRequired(e => e.HangHoa1)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.DS_XuatKho)
                .WithRequired(e => e.HangHoa)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.DS_XuatKho1)
                .WithRequired(e => e.HangHoa1)
                .HasForeignKey(e => e.MaHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
                .HasForeignKey(e => e.MaHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons1)
                .WithRequired(e => e.HoaDon1)
                .HasForeignKey(e => e.MaHoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon_DichVu>()
                .Property(e => e.NguoiSuDung)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.KhachHang)
                .HasForeignKey(e => e.MaKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDons1)
                .WithRequired(e => e.KhachHang1)
                .HasForeignKey(e => e.MaKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.KhachSan)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.DonHangs1)
                .WithRequired(e => e.KhachSan1)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.KhoHangs)
                .WithRequired(e => e.KhachSan)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.KhoHangs1)
                .WithRequired(e => e.KhachSan1)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.PhongKhachSans)
                .WithRequired(e => e.KhachSan)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.PhongKhachSans1)
                .WithRequired(e => e.KhachSan1)
                .HasForeignKey(e => e.MaKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.ChiTietHangHoas)
                .WithRequired(e => e.KhoHang)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.ChiTietHangHoas1)
                .WithRequired(e => e.KhoHang1)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.KhoHang)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.CT_NhapHang1)
                .WithRequired(e => e.KhoHang1)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.QuanLyKhoHangs)
                .WithRequired(e => e.KhoHang)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.QuanLyKhoHangs1)
                .WithRequired(e => e.KhoHang1)
                .HasForeignKey(e => e.MaKho)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<KhuyenMai>()
                .Property(e => e.MaNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.HangHoas)
                .WithRequired(e => e.LoaiHang)
                .HasForeignKey(e => e.MaLoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiHang>()
                .HasMany(e => e.HangHoas1)
                .WithRequired(e => e.LoaiHang1)
                .HasForeignKey(e => e.MaLoaiHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.MoTaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.BangGiaPhongs)
                .WithRequired(e => e.LoaiPhong)
                .HasForeignKey(e => e.MaLoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.BangGiaPhongs1)
                .WithRequired(e => e.LoaiPhong1)
                .HasForeignKey(e => e.MaLoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasOptional(e => e.ChiTietDonHang)
                .WithRequired(e => e.NhaCungCap);

            modelBuilder.Entity<NhaCungCap>()
                .HasOptional(e => e.ChiTietDonHang1)
                .WithRequired(e => e.NhaCungCap1);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.NhaCungCap)
                .HasForeignKey(e => e.MaNhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.CT_NhapHang1)
                .WithRequired(e => e.NhaCungCap1)
                .HasForeignKey(e => e.MaNhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKhachSan>()
                .Property(e => e.TenPhong)
                .IsUnicode(false);

            modelBuilder.Entity<PhongKhachSan>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.PhongKhachSan)
                .HasForeignKey(e => e.MaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.ChiTietHoaDons1)
                .WithRequired(e => e.PhongKhachSan1)
                .HasForeignKey(e => e.MaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.CT_DatPhong)
                .WithRequired(e => e.PhongKhachSan)
                .HasForeignKey(e => e.MaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.CT_DatPhong1)
                .WithRequired(e => e.PhongKhachSan1)
                .HasForeignKey(e => e.MaPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanLyKhoHang>()
                .Property(e => e.MaNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<QuanLyKhoHang>()
                .HasMany(e => e.DS_XuatKho)
                .WithRequired(e => e.QuanLyKhoHang)
                .HasForeignKey(e => e.STT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanLyKhoHang>()
                .HasMany(e => e.DS_XuatKho1)
                .WithRequired(e => e.QuanLyKhoHang1)
                .HasForeignKey(e => e.STT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenHan>()
                .HasMany(e => e.ChiTiet_QuyenHan)
                .WithRequired(e => e.QuyenHan)
                .HasForeignKey(e => e.MaQuyenHan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenHan>()
                .HasMany(e => e.ChiTiet_QuyenHan1)
                .WithRequired(e => e.QuyenHan1)
                .HasForeignKey(e => e.MaQuyenHan)
                .WillCascadeOnDelete(false);
        }
    }
}
