USE [master]
GO
/****** Object:  Database [BookStore]    Script Date: 9/10/2017 8:27:49 PM ******/
CREATE DATABASE [BookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookStore.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\BookStore_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BookStore] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BookStore] SET  MULTI_USER 
GO
ALTER DATABASE [BookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookStore] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BookStore] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BookStore]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 9/10/2017 8:27:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
	[AuthorImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Book]    Script Date: 9/10/2017 8:27:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Prices] [int] NULL,
	[AuthorID] [int] NULL,
	[Description] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 9/10/2017 8:27:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 9/10/2017 8:27:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 9/10/2017 8:27:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[IDRole] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([ID], [AuthorName], [Birthday], [AuthorImage]) VALUES (8, N'ABC', CAST(N'1990-08-12' AS Date), N'001.jpg')
INSERT [dbo].[Author] ([ID], [AuthorName], [Birthday], [AuthorImage]) VALUES (9, N'XYZ', CAST(N'1960-07-21' AS Date), N'002.jpg')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([ID], [Name], [Prices], [AuthorID], [Description], [Image]) VALUES (6, N'Dac Nhan Tam', 10000, 8, N'asdasfasfaf', N'001.png')
INSERT [dbo].[Book] ([ID], [Name], [Prices], [AuthorID], [Description], [Image]) VALUES (7, N'asdasdasd', 20000, 8, N'sadasdasd', N'002.jpg')
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Login] ON 

INSERT [dbo].[Login] ([id], [username], [password]) VALUES (1, N'admin', N'123456')
SET IDENTITY_INSERT [dbo].[Login] OFF
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([ID], [RoleName]) VALUES (1, N'ADMIN')
INSERT [dbo].[PhanQuyen] ([ID], [RoleName]) VALUES (2, N'MOD')
INSERT [dbo].[PhanQuyen] ([ID], [RoleName]) VALUES (3, N'MEMBER')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [UserName], [Password], [IDRole]) VALUES (2, N'admin', N'e10adc3949ba59abbe56e057f20f883e', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([ID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_PhanQuyen] FOREIGN KEY([IDRole])
REFERENCES [dbo].[PhanQuyen] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_PhanQuyen]
GO
/****** Object:  StoredProcedure [dbo].[LoginByUsernamePassword]    Script Date: 9/10/2017 8:27:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Author: <Author,,Asma Khalid>  
-- Create date: <Create Date,,15-Mar-2016>  
-- Description: <Description,,You are Allow to Distribute this Code>  
-- =============================================   
CREATE PROCEDURE [dbo].[LoginByUsernamePassword]   
@username varchar(50),   
@password varchar(50)   
AS   
BEGIN   
SELECT id, username, password   
FROM Login   
WHERE username = @username   
AND password = @password   
END   

GO
USE [master]
GO
ALTER DATABASE [BookStore] SET  READ_WRITE 
GO
