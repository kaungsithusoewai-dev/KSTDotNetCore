USE [master]
GO
/****** Object:  Database [KSTDotNet]    Script Date: 6/19/2024 1:14:53 PM ******/
CREATE DATABASE [KSTDotNet] ON  PRIMARY 
( NAME = N'KSTDotNet', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KSTDotNet.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KSTDotNet_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\KSTDotNet_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KSTDotNet].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KSTDotNet] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KSTDotNet] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KSTDotNet] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KSTDotNet] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KSTDotNet] SET ARITHABORT OFF 
GO
ALTER DATABASE [KSTDotNet] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KSTDotNet] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KSTDotNet] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KSTDotNet] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KSTDotNet] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KSTDotNet] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KSTDotNet] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KSTDotNet] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KSTDotNet] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KSTDotNet] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KSTDotNet] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KSTDotNet] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KSTDotNet] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KSTDotNet] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KSTDotNet] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KSTDotNet] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KSTDotNet] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KSTDotNet] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KSTDotNet] SET  MULTI_USER 
GO
ALTER DATABASE [KSTDotNet] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KSTDotNet] SET DB_CHAINING OFF 
GO
USE [KSTDotNet]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 6/19/2024 1:14:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [nvarchar](50) NOT NULL,
	[BlogAuthor] [nvarchar](50) NOT NULL,
	[BlogContent] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Tbl_Blog] PRIMARY KEY CLUSTERED 
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (11, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (12, N'Test Title', N'Test Author', N'Test Content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (14, N'test title2', N'test author2', N'test content2')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (15, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (16, N'title', N'author', N'content')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [KSTDotNet] SET  READ_WRITE 
GO
