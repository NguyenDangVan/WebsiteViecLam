
IF NOT exists (SELECT * FROM sys.databases WHERE name = N'WebsiteViecLam')
CREATE DATABASE WebsiteViecLam
GO
USE [WebsiteViecLam]
GO
CREATE TABLE [CongTy](
	[ID_CongTy] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenCongTy] [nvarchar](255) NULL,
	[TenDangNhap] [varchar](150) NULL,
	[MatKhau] [varchar](50) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[QuyMo] [int] NULL,
	[SDT] [varchar](50) NULL,
	[Website] [varchar](50) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NguoiDaiDien] [nvarchar](150) NULL,
	[Email] [varchar](150) NULL,
	[ID_ThanhPho] [int] NULL,
)
GO
CREATE TABLE [CV_UngVien](
	[ID_CV] [int] IDENTITY(1,1) PRIMARY KEY,
	[ID_UngVien] [int] NULL,
	[TieuDe] [nvarchar](255) NULL,
	[ID_NganhNghe] [int] NULL,
	[KyNang] [nvarchar](max) NULL,
	[ID_ViTri] [int] NULL,
	[ID_TrinhDo] [int] NULL,
	[ID_KinhNghiem] [int] NULL,
	[NgoaiNgu] [nvarchar](255) NULL,
	[MucLuong] [nvarchar](100) NULL,
	[BangCap] [nvarchar](200) NULL,
	[TrangThai] [bit] NULL,
)
GO

CREATE TABLE [DangKy](
	[ID_DangKy] [int] IDENTITY(1,1) PRIMARY KEY,
	[ID_CV] [int] NULL,
	[ID_ViecLam] [int] NULL,
	[NgayXem] [date] NULL,
	[NgayUngTuyen] [date] NULL,
	[TrangThai] [bit] NULL,
)
GO

CREATE TABLE [KinhNghiem](
 	[ID_KinhNghiem] [int] IDENTITY(1,1) PRIMARY KEY,
 	[TenKinhNghiem] [nvarchar](255) NULL,
 )

GO

CREATE TABLE [LoaiTaiKhoan](
	[ID_LoaiTaiKhoan] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenLoai] [nvarchar](255) NULL,
)
GO

CREATE TABLE [NganhNghe](
	[ID_NganhNghe] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenNganhNghe] [nvarchar](250) NULL,
)
GO

CREATE TABLE [TaiKhoan](
	[ID_TaiKhoan] [int] IDENTITY(1,1) PRIMARY KEY,
	[ID_LoaiTaiKhoan] [int] NULL,
	[TenDangNhap] [varchar](150) NULL,
	[MatKhau] [varchar](50) NULL,
	[HoTen] [nvarchar](250) NULL,
	[Email] [varchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[ID_Vung] [int] NULL,
)
GO

CREATE TABLE [TinViecLam](
	[ID_ViecLam] [int] IDENTITY(1,1) PRIMARY KEY,
	[TieuDeViecLam] [nvarchar](250) NULL,
	[MoTa] [nvarchar](max) NULL,
	[ID_NganhNghe] [int] NULL,
	[ID_ViTri] [int] NULL,
	[GioiTinh] [nvarchar](100) NULL,
	[YeuCauKyNang] [nvarchar](max) NULL,
	[ThoiGianThuViec] [nvarchar](100) NULL,
	[ID_KinhNghiem] [int] NULL,
	[ID_TrinhDo] [int] NULL,
	[MucLuong] [nvarchar](50) NULL,
	[NgayDang] [date] NULL,
	[NgayHetHan] [date] NULL,
	[TrangThai] [bit] NULL,
	[ID_CongTy] [int] NULL,
	[SoLuong] [int] NULL,
	[YeuCauHoSo] [nvarchar](max) NULL,
)
GO

CREATE TABLE [ThanhPho](
	[ID_ThanhPho] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenThanhPho] [nvarchar](50) NULL,
	[ID_Vung] [int] NULL,
)
GO

CREATE TABLE [TrinhDo](
	[ID_TrinhDo] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenTrinhDo] [nvarchar](250) NULL,
)
GO

CREATE TABLE [UngVien](
	[ID_UngVien] [int] IDENTITY(1,1) PRIMARY KEY,
	[HoTen] [nvarchar](150) NULL,
	[MatKhau] [varchar](100) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[Email] [varchar](150) NULL,
	[SDT] [varchar](50) NULL,
	[ID_ThanhPho] [int] NULL,
)
GO

CREATE TABLE [ViTriUngTuyen](
	[ID_ViTri] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenViTri] [nvarchar](255) NULL,
)

CREATE TABLE [VungMien](
	[ID_Vung] [int] IDENTITY(1,1) PRIMARY KEY,
	[TenVung] [nvarchar](150) NULL,
 )
GO
ALTER TABLE [CongTy]  WITH CHECK ADD  CONSTRAINT [FK_CongTy_ThanhPho] FOREIGN KEY([ID_ThanhPho])
REFERENCES [ThanhPho] ([ID_ThanhPho])
GO
ALTER TABLE [CongTy] CHECK CONSTRAINT [FK_CongTy_ThanhPho]
GO
ALTER TABLE [CV_UngVien]  WITH CHECK ADD  CONSTRAINT [FK_CV_UngVien_KinhNghiem] FOREIGN KEY([ID_KinhNghiem])
REFERENCES [KinhNghiem] ([ID_KinhNghiem])
GO
ALTER TABLE [CV_UngVien] CHECK CONSTRAINT [FK_CV_UngVien_KinhNghiem]
GO
ALTER TABLE [CV_UngVien]  WITH CHECK ADD  CONSTRAINT [FK_CV_UngVien_NganhNghe] FOREIGN KEY([ID_NganhNghe])
REFERENCES [NganhNghe] ([ID_NganhNghe])
GO
ALTER TABLE [CV_UngVien] CHECK CONSTRAINT [FK_CV_UngVien_NganhNghe]
GO
ALTER TABLE [CV_UngVien]  WITH CHECK ADD  CONSTRAINT [FK_CV_UngVien_TrinhDo] FOREIGN KEY([ID_TrinhDo])
REFERENCES [TrinhDo] ([ID_TrinhDo])
GO
ALTER TABLE [CV_UngVien] CHECK CONSTRAINT [FK_CV_UngVien_TrinhDo]
GO
ALTER TABLE [CV_UngVien]  WITH CHECK ADD  CONSTRAINT [FK_CV_UngVien_UngVien] FOREIGN KEY([ID_UngVien])
REFERENCES [UngVien] ([ID_UngVien])
GO
ALTER TABLE [CV_UngVien] CHECK CONSTRAINT [FK_CV_UngVien_UngVien]
GO
ALTER TABLE [CV_UngVien]  WITH CHECK ADD  CONSTRAINT [FK_CV_UngVien_ViTri] FOREIGN KEY([ID_ViTri])
REFERENCES [ViTri] ([ID_ViTri])
GO
ALTER TABLE [CV_UngVien] CHECK CONSTRAINT [FK_CV_UngVien_ViTri]
GO
ALTER TABLE [DangKy]  WITH CHECK ADD  CONSTRAINT [FK_DangKy_CV_UngVien] FOREIGN KEY([ID_CV])
REFERENCES [CV_UngVien] ([ID_CV])
GO
ALTER TABLE [DangKy] CHECK CONSTRAINT [FK_DangKy_CV_UngVien]
GO
ALTER TABLE [DangKy]  WITH CHECK ADD  CONSTRAINT [FK_DangKy_ViecLam] FOREIGN KEY([ID_ViecLam])
REFERENCES [ViecLam] ([ID_ViecLam])
GO
ALTER TABLE [DangKy] CHECK CONSTRAINT [FK_DangKy_ViecLam]
GO
ALTER TABLE [TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan] FOREIGN KEY([ID_LoaiTaiKhoan])
REFERENCES [LoaiTaiKhoan] ([ID_LoaiTaiKhoan])
GO
ALTER TABLE [TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_LoaiTaiKhoan]
GO
ALTER TABLE [TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_VungMien] FOREIGN KEY([ID_Vung])
REFERENCES [VungMien] ([ID_Vung])
GO
ALTER TABLE [TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_VungMien]
GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD  CONSTRAINT [FK_ViecLam_CongTy] FOREIGN KEY([ID_CongTy])
REFERENCES [CongTy] ([ID_CongTy])
GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_CongTy]
GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD  CONSTRAINT [FK_ViecLam_KinhNghiem] FOREIGN KEY([ID_KinhNghiem])
REFERENCES [KinhNghiem] ([ID_KinhNghiem])
GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_KinhNghiem]
GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD  CONSTRAINT [FK_ViecLam_NganhNghe] FOREIGN KEY([ID_NganhNghe])
REFERENCES [NganhNghe] ([ID_NganhNghe])

GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD  CONSTRAINT [FK_ViecLam_KinhNghiem] FOREIGN KEY([ID_KinhNghiem])
REFERENCES [KinhNghiem] ([ID_KinhNghiem])
GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_KinhNghiem]

GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_NganhNghe]
GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD CONSTRAINT [FK_ViecLam_TrinhDo] FOREIGN KEY([ID_TrinhDo])
REFERENCES [TrinhDo] ([ID_TrinhDo])
GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_TrinhDo]
GO
ALTER TABLE [TinViecLam]  WITH CHECK ADD CONSTRAINT [FK_ViecLam_ViTri] FOREIGN KEY([ID_ViTri])
REFERENCES [ViTri] ([ID_ViTri])
GO
ALTER TABLE [TinViecLam] CHECK CONSTRAINT [FK_ViecLam_ViTri]
GO
ALTER TABLE [UngVien] WITH CHECK ADD CONSTRAINT [FK_UngVien_ThanhPho] FOREIGN KEY([ID_ThanhPho])
REFERENCES [ThanhPho] ([ID_ThanhPho])
GO
ALTER TABLE [UngVien] CHECK CONSTRAINT [FK_UngVien_ThanhPho]

GO
ALTER TABLE [ThanhPho] WITH CHECK ADD CONSTRAINT [FK_ThanhPho_VungMien] FOREIGN KEY([ID_Vung])
REFERENCES [VungMien] ([ID_Vung])
GO
ALTER TABLE [ThanhPho] CHECK CONSTRAINT [FK_ThanhPho_VungMien]


 