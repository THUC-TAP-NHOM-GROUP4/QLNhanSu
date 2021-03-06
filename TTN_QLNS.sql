
CREATE PROC [dbo].[DSNHANVIEN]
 AS
   BEGIN
      SELECT NV_PB.ma,NV_PB.ten,NV_PB.diachi,NV_PB.dienthoai,NV_PB.email,NV_PB.gioitinh,NV_PB.ngaysinh,NV_PB.socmnd,NV_PB.TD,NV_PB.PHONGBAN,CV.ten,NV_PB.maluong
	  FROM ChucVu CV
	       INNER JOIN(SELECT  NV_L.ma,NV_L.ten,NV_L.diachi,NV_L.dienthoai,NV_L.email,NV_L.gioitinh,NV_L.maChucVu,NV_L.maluong,NV_L.TD,PB.ten AS [PHONGBAN],NV_L.ngaysinh,NV_L.socmnd
		              FROM    PhongBan PB
					          INNER JOIN (SELECT NV_T.ma,NV_T.ten,NV_T.diachi,NV_T.dienthoai,NV_T.email,NV_T.gioitinh,NV_T.maChucVu,NV_T.maluong,NV_T.maphongban,NV_T.TD,NV_T.ngaysinh,NV_T.socmnd
							              FROM      Luong L
										           INNER JOIN(SELECT NV.ma,NV.ten,NV.diachi,NV.dienthoai,NV.email,NV.gioitinh,NV.maChucVu,NV.maluong,NV.maphongban,TDHV.ten AS TD,NV.socmnd,NV.ngaysinh
												              FROM   TrinhDoHocVan TDHV INNER JOIN NhanVien NV ON TDHV.ma = NV.maTDHV
															   GROUP BY NV.ma,NV.ten,NV.diachi,NV.dienthoai,NV.email,NV.socmnd,NV.gioitinh,NV.socmnd,NV.ngaysinh,NV.maChucVu,NV.maluong,NV.maphongban,TDHV.ten )
												   AS NV_T ON NV_T.maluong = L.ma
										  GROUP BY NV_T.ma,NV_T.ten,NV_T.diachi,NV_T.dienthoai,NV_T.email,NV_T.gioitinh,NV_T.maChucVu,NV_T.maluong,NV_T.maphongban,NV_T.TD,NV_T.ngaysinh,NV_T.socmnd
							 ) AS NV_L ON PB.ma = NV_L.maphongban
					  GROUP BY NV_L.ma,NV_L.ten,NV_L.diachi,NV_L.dienthoai,NV_L.email,NV_L.gioitinh,NV_L.ngaysinh,NV_L.socmnd,NV_L.maChucVu,NV_L.maluong,NV_L.TD,PB.ten
		  )AS NV_PB ON CV.ma = NV_PB.maChucVu
   END
GO
/****** Object:  StoredProcedure [dbo].[Getten]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Getten]
  @ten nvarchar(30)
 as
    begin 
	   select ma 
	   from   dbo.ChucVu
	   where   ten like @ten

end

GO
/****** Object:  StoredProcedure [dbo].[GettenL]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GettenL]
  @luongcoban float
 as
    begin 
	   select ma 
	   from   dbo.Luong 
	   where  luongcoban like @luongcoban

end
GO
/****** Object:  StoredProcedure [dbo].[GettenPB]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GettenPB]
  @ten nvarchar(30)
 as
    begin 
	   select ma 
	   from   dbo.PhongBan
	   where   ten like @ten

end

GO
/****** Object:  StoredProcedure [dbo].[GettenTDHV]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GettenTDHV]
  @ten nvarchar(30)
 as
    begin 
	   select ma 
	   from   dbo.TrinhDoHocVan
	   where   ten like @ten

end

GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ma] [varchar](10) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[phuCap] [varchar](10) NULL,
	[ghiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Luong]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Luong](
	[ma] [varchar](10) NOT NULL,
	[hesoluong] [float] NULL DEFAULT ((0)),
	[luongcoban] [float] NULL DEFAULT ((0)),
	[hesophucap] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[NhanVien](
	[ma] [varchar](10) NULL,
	[ten] [nvarchar](50) NULL,
	[ngaysinh] [date] NULL,
	[gioitinh] [bit] NULL,
	[diachi] [nvarchar](200) NULL,
	[socmnd] [varchar](15) NULL,
	[dienthoai] [varchar](10) NULL,
	[email] [nvarchar](50) NULL,
	[maChucVu] [varchar](10) NULL,
	[maluong] [varchar](10) NULL,
	[maphongban] [varchar](10) NULL,
	[maTDHV] [varchar](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhongBan](
	[ma] [varchar](10) NOT NULL,
	[ten] [nvarchar](50) NULL,
	[dienthoai] [varchar](10) NULL,
	[diachi] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TrinhDoHocVan]    Script Date: 04/22/2017 10:44:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrinhDoHocVan](
	[ma] [varchar](10) NOT NULL,
	[ten] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrinhDoHocVan] PRIMARY KEY CLUSTERED 
(
	[ma] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
-----29/05/2017------------------------------------------


--1.	--mã tự động tăng khi insert vào bảng chức vụ
create function [dbo].[auto_ma_chucvu]() returns varchar(6)
as
begin
	declare @ma varchar(50)
	if(select count(ma) from ChucVu)=0
	set @ma='0'
	else 
		select @ma=max(right(ma,4)) from ChucVu
		set @ma=case
		when
		@ma>=0 and @ma<9 then 'DK000'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=9 and @ma<99then 'DK00'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=99 and @ma<999then 'DK0'+CONVERT(char,CONVERT(int,@ma)+1)
		end
		return @ma
end


create function [dbo].[auto_ma_dangky]() returns varchar(6)
as
begin
	declare @ma varchar(50)
	if(select count(ma) from DangKy)=0
	set @ma='0'
	else 
		select @ma=max(right(ma,4)) from DangKy
		set @ma=case
		when
		@ma>=0 and @ma<9 then 'DK000'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=9 and @ma<99then 'DK00'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=99 and @ma<999then 'DK0'+CONVERT(char,CONVERT(int,@ma)+1)
		end
		return @ma
end

--1.	--mã tự động tăng khi insert vào bảng Lương
create function [dbo].[auto_ma_luong]() returns varchar(6)
as
begin
	declare @ma varchar(50)
	if(select count(ma) from Luong)=0
	set @ma='0'
	else 
		select @ma=max(right(ma,4)) from Luong
		set @ma=case
		when
		@ma>=0 and @ma<9 then 'DK000'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=9 and @ma<99then 'DK00'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=99 and @ma<999then 'DK0'+CONVERT(char,CONVERT(int,@ma)+1)
		end
		return @ma
end

create function [dbo].[auto_ma_nv]() returns varchar(6)
as
begin
	declare @ma varchar(50)
	if(select count(ma) from NhanVien)=0
	set @ma='0'
	else 
		select @ma=max(right(ma,4)) from NhanVien
		set @ma=case
		when
		@ma>=0 and @ma<9 then 'NV000'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=9 and @ma<99then 'NV00'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=99 and @ma<999then 'NV0'+CONVERT(char,CONVERT(int,@ma)+1)
		end
		return @ma
end


create function [dbo].[auto_ma_TDHV]() returns varchar(6)
as
begin
	declare @ma varchar(50)
	if(select count(ma) from TrinhDoHocVan)=0
	set @ma='0'
	else 
		select @ma=max(right(ma,4)) from TrinhDoHocVan
		set @ma=case
		when
		@ma>=0 and @ma<9 then 'DK000'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=9 and @ma<99then 'DK00'+CONVERT(char,CONVERT(int,@ma)+1)
		when @ma>=99 and @ma<999then 'DK0'+CONVERT(char,CONVERT(int,@ma)+1)
		end
		return @ma
end



create proc [dbo].[proc_insertNV](@ten nvarchar(50), @ngaysinh date, @gioitinh int, @diachi nvarchar(200), 
	@socmnd varchar(15), @dienthoai varchar(10), @email nvarchar(50), @maChucVu varchar(10), @maluong varchar(10),
	@maphongban varchar(10), @maTDHV varchar(10))
as
begin
	insert into NhanVien(ma, ten, ngaysinh, gioitinh, diachi, socmnd, dienthoai, email, maChucVu, 
		maluong, maphongban, maTDHV)
	values (dbo.auto_ma_nv(), @ten, @ngaysinh, @gioitinh, @diachi, @socmnd, @dienthoai, @email, @maChucVu, @maluong, @maphongban, @maTDHV)
end











------------------------------------------4/6----------------------------------------
  alter proc SuaThongTinNhanVien
  @ma varchar(20),
  @ten nvarchar(50),
  @diachi nvarchar(50),
  @ngaysinh date,
  @gioitinh bit,
  @sochungminh varchar(20),
  @dienthoai varchar(20),
  @email varchar(30),
  @machucvu varchar(20),
  @maluong varchar(20),
  @maphongban varchar(20),
  @matdhv varchar(20)
  as
   begin
   update NhanVien set ten =@ten, diachi = @diachi,ngaysinh = @ngaysinh,gioitinh= @gioitinh,
                       socmnd=@sochungminh,dienthoai =@dienthoai,email=@email,maChucVu=@machucvu,
					   maluong =@maluong,maphongban =@maphongban,maTDHV =@matdhv where ma =@ma
   end

   exec dbo.SuaThongTinNhanVien 'NV0006','B','afddf','2/2/1998','1','12323322','213232232','fddfg','CV0001','L0001','PB0001','TDHV0001'

   select *from NhanVien