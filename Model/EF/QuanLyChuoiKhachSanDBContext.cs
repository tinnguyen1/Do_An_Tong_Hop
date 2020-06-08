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

        public virtual DbSet<Bang_DS_DatPhong> Bang_DS_DatPhongs { get; set; }
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
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.SoNguoi)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Bang_DS_DatPhong>()
                .HasOptional(e => e.CT_DatPhong)
                .WithRequired(e => e.Bang_DS_DatPhong);

            modelBuilder.Entity<BangGiaPhong>()
                .HasMany(e => e.PhongKhachSans)
                .WithRequired(e => e.BangGiaPhong)
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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.KhuyenMais)
                .WithRequired(e => e.DanhSachNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhSachNguoiDung>()
                .HasMany(e => e.QuanLyKhoHangs)
                .WithRequired(e => e.DanhSachNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DichVu>()
                .HasMany(e => e.HoaDon_DichVu)
                .WithRequired(e => e.DichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.ChiTietHangHoas)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HangHoa>()
                .HasMany(e => e.DS_XuatKho)
                .WithRequired(e => e.HangHoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TinhTrang)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithRequired(e => e.HoaDon)
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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.KhoHangs)
                .WithRequired(e => e.KhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachSan>()
                .HasMany(e => e.PhongKhachSans)
                .WithRequired(e => e.KhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.ChiTietHangHoas)
                .WithRequired(e => e.KhoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.KhoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhoHang>()
                .HasMany(e => e.QuanLyKhoHangs)
                .WithRequired(e => e.KhoHang)
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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.NhaCungCap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.CT_NhapHang)
                .WithRequired(e => e.NhaCungCap)
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
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhongKhachSan>()
                .HasMany(e => e.CT_DatPhong)
                .WithRequired(e => e.PhongKhachSan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanLyKhoHang>()
                .Property(e => e.MaNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<QuanLyKhoHang>()
                .HasMany(e => e.DS_XuatKho)
                .WithRequired(e => e.QuanLyKhoHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuyenHan>()
                .HasMany(e => e.ChiTiet_QuyenHan)
                .WithRequired(e => e.QuyenHan)
                .WillCascadeOnDelete(false);
        }
    }
}
