USE [master]
GO
/****** Object:  Database [DichVuMotCua]    Script Date: 23/12/2019 1:34:53 AM ******/
CREATE DATABASE [DichVuMotCua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DichVuMotCua', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DichVuMotCua.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DichVuMotCua_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\DichVuMotCua_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DichVuMotCua] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DichVuMotCua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DichVuMotCua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DichVuMotCua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DichVuMotCua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DichVuMotCua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DichVuMotCua] SET ARITHABORT OFF 
GO
ALTER DATABASE [DichVuMotCua] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DichVuMotCua] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DichVuMotCua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DichVuMotCua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DichVuMotCua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DichVuMotCua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DichVuMotCua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DichVuMotCua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DichVuMotCua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DichVuMotCua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DichVuMotCua] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DichVuMotCua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DichVuMotCua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DichVuMotCua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DichVuMotCua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DichVuMotCua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DichVuMotCua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DichVuMotCua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DichVuMotCua] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DichVuMotCua] SET  MULTI_USER 
GO
ALTER DATABASE [DichVuMotCua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DichVuMotCua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DichVuMotCua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DichVuMotCua] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DichVuMotCua]
GO
/****** Object:  Table [dbo].[chitiethoso]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitiethoso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[noidung] [nvarchar](255) NULL,
	[hoso] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chitietthutuc]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chitietthutuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[noidung] [nvarchar](255) NULL,
	[thutuc] [int] NULL,
	[value] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[hoso]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoso](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[noidung] [nvarchar](255) NULL,
	[nguoitao] [int] NULL,
	[nguoiduyet] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[loaithutuc]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaithutuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[loai] [int] NULL,
	[name] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[taikhoan]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](100) NULL,
	[name] [nvarchar](255) NULL,
	[password] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[thutuc]    Script Date: 23/12/2019 1:34:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thutuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[nguoitao] [int] NULL,
	[nguoiduyet] [int] NULL,
	[loaithutuc] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[chitiethoso] ON 

INSERT [dbo].[chitiethoso] ([id], [noidung], [hoso]) VALUES (1, N'1', 1)
INSERT [dbo].[chitiethoso] ([id], [noidung], [hoso]) VALUES (2, N'dddd', 1)
SET IDENTITY_INSERT [dbo].[chitiethoso] OFF
SET IDENTITY_INSERT [dbo].[chitietthutuc] ON 

INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (1, N'q', 1, N'q')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (2, N'fdfdfdfdf', 0, NULL)
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (3, N'11111111111111111111', 4, NULL)
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (4, N'1', 5, N'11111111111111111111111111111')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (5, N'1', 6, N'dddddddd')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (6, N'Email', 6, N'dddddddddddd')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (7, NULL, 7, N'ggggggggggggggg')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (8, NULL, 8, N'ggggggggggggggg')
INSERT [dbo].[chitietthutuc] ([id], [noidung], [thutuc], [value]) VALUES (9, NULL, 9, N'fffffffffffff')
SET IDENTITY_INSERT [dbo].[chitietthutuc] OFF
SET IDENTITY_INSERT [dbo].[hoso] ON 

INSERT [dbo].[hoso] ([id], [noidung], [nguoitao], [nguoiduyet]) VALUES (1, N'z', 1, 1)
SET IDENTITY_INSERT [dbo].[hoso] OFF
SET IDENTITY_INSERT [dbo].[loaithutuc] ON 

INSERT [dbo].[loaithutuc] ([id], [loai], [name]) VALUES (1, 1, N'1')
INSERT [dbo].[loaithutuc] ([id], [loai], [name]) VALUES (3, 1, N'Email')
SET IDENTITY_INSERT [dbo].[loaithutuc] OFF
SET IDENTITY_INSERT [dbo].[thutuc] ON 

INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (1, N'q', 1, 1, N'aa')
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (2, N'QuanLyHS', NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (3, N'QuanLyHS', NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (4, N'QuanLyHS1111111111', NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (5, N'QuanLyHS', NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (6, N'QuanLyHS', NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (7, NULL, NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (8, NULL, NULL, NULL, NULL)
INSERT [dbo].[thutuc] ([id], [name], [nguoitao], [nguoiduyet], [loaithutuc]) VALUES (9, N'QuanLyHS', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[thutuc] OFF
USE [master]
GO
ALTER DATABASE [DichVuMotCua] SET  READ_WRITE 
GO
