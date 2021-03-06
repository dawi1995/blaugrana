USE [master]
GO
/****** Object:  Database [footcam]    Script Date: 29.12.2017 17:23:50 ******/
CREATE DATABASE [footcam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'footcam', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\footcam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'footcam_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\footcam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [footcam] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [footcam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [footcam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [footcam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [footcam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [footcam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [footcam] SET ARITHABORT OFF 
GO
ALTER DATABASE [footcam] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [footcam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [footcam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [footcam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [footcam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [footcam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [footcam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [footcam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [footcam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [footcam] SET  DISABLE_BROKER 
GO
ALTER DATABASE [footcam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [footcam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [footcam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [footcam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [footcam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [footcam] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [footcam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [footcam] SET RECOVERY FULL 
GO
ALTER DATABASE [footcam] SET  MULTI_USER 
GO
ALTER DATABASE [footcam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [footcam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [footcam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [footcam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [footcam] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'footcam', N'ON'
GO
ALTER DATABASE [footcam] SET QUERY_STORE = OFF
GO
USE [footcam]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [footcam]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 29.12.2017 17:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[A_Id] [int] IDENTITY(1,1) NOT NULL,
	[A_FieldId] [int] NOT NULL,
	[A_City] [nvarchar](50) NULL,
	[A_District] [nvarchar](50) NULL,
	[A_Street] [nvarchar](50) NULL,
	[A_Number] [int] NULL,
	[A_ZipCode] [nvarchar](6) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[A_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingOptions]    Script Date: 29.12.2017 17:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingOptions](
	[BO_Id] [int] IDENTITY(1,1) NOT NULL,
	[BO_IdField] [int] NOT NULL,
	[BO_MonFrom] [time](0) NULL,
	[BO_MonTo] [time](0) NULL,
	[BO_TuesFrom] [time](0) NULL,
	[BO_TuesTo] [time](0) NULL,
	[BO_WedFrom] [time](0) NULL,
	[BO_WedTo] [time](0) NULL,
	[BO_ThursFrom] [time](0) NULL,
	[BO_ThursTo] [time](0) NULL,
	[BO_FriFrom] [time](0) NULL,
	[BO_FriTo] [time](0) NULL,
	[BO_SatFrom] [time](0) NULL,
	[BO_SatTo] [time](0) NULL,
	[BO_SunFrom] [time](0) NULL,
	[BO_SunTo] [time](0) NULL,
	[BO_MaxHourBook] [int] NULL,
 CONSTRAINT [PK_BookingOptions] PRIMARY KEY CLUSTERED 
(
	[BO_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 29.12.2017 17:23:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[B_Id] [int] IDENTITY(1,1) NOT NULL,
	[B_IdField] [int] NOT NULL,
	[B_BookDTFrom] [datetime] NULL,
	[B_BookDTTo] [datetime] NULL,
	[B_PersonName] [nvarchar](50) NULL,
	[B_PersonSurname] [nvarchar](50) NULL,
	[B_ConfirmedByUser] [bit] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[B_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 29.12.2017 17:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[F_Id] [int] IDENTITY(1,1) NOT NULL,
	[F_Name] [nvarchar](50) NULL,
	[F_IdAddress] [int] NULL,
	[F_Light] [bit] NULL,
	[F_Rental] [bit] NULL,
	[F_BookingPossibility] [bit] NULL,
	[F_PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[F_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpenDaysHours]    Script Date: 29.12.2017 17:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenDaysHours](
	[ODH_Id] [int] IDENTITY(1,1) NOT NULL,
	[ODH_IdField] [int] NOT NULL,
	[ODH_MonFrom] [time](0) NULL,
	[ODH_MonTo] [time](0) NULL,
	[ODH_TuesFrom] [time](0) NULL,
	[ODH_TuesTo] [time](0) NULL,
	[ODH_WedFrom] [time](0) NULL,
	[ODH_WedTo] [time](0) NULL,
	[ODH_ThursFrom] [time](0) NULL,
	[ODH_ThursTo] [time](0) NULL,
	[ODH_FriFrom] [time](0) NULL,
	[ODH_FriTo] [time](0) NULL,
	[ODH_SatFrom] [time](0) NULL,
	[ODH_SatTo] [time](0) NULL,
	[ODH_SunFrom] [time](0) NULL,
	[ODH_SunTo] [time](0) NULL,
 CONSTRAINT [PK_OpenDaysHours] PRIMARY KEY CLUSTERED 
(
	[ODH_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([A_Id], [A_FieldId], [A_City], [A_District], [A_Street], [A_Number], [A_ZipCode]) VALUES (3, 1, N'Warszawa', N'Wilanów', N'ul. św. Urszuli Ledóchowskiej', 2, N'02-972')
INSERT [dbo].[Addresses] ([A_Id], [A_FieldId], [A_City], [A_District], [A_Street], [A_Number], [A_ZipCode]) VALUES (4, 2, N'Warszawa', N'Mokotów', N'ul. Puławska', 12, N'02-548')
INSERT [dbo].[Addresses] ([A_Id], [A_FieldId], [A_City], [A_District], [A_Street], [A_Number], [A_ZipCode]) VALUES (5, 3, N'Warszawa', N'Wilanów', N'ul. Syta', 123, N'02-987')
INSERT [dbo].[Addresses] ([A_Id], [A_FieldId], [A_City], [A_District], [A_Street], [A_Number], [A_ZipCode]) VALUES (6, 4, N'Warszawa', N'Mokotów', N'ul. Dominika Merliniego', 4, N'02-511')
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([B_Id], [B_IdField], [B_BookDTFrom], [B_BookDTTo], [B_PersonName], [B_PersonSurname], [B_ConfirmedByUser]) VALUES (1, 1, CAST(N'2017-12-09T09:00:00.000' AS DateTime), CAST(N'2017-12-09T10:00:00.000' AS DateTime), N'Test', N'Testowicz', 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Fields] ON 

INSERT [dbo].[Fields] ([F_Id], [F_Name], [F_IdAddress], [F_Light], [F_Rental], [F_BookingPossibility], [F_PhotoPath]) VALUES (1, N'Ledóchowskiej', 3, 0, 1, 1, N'../../Resources/Images/orlikPhoto.jpg')
INSERT [dbo].[Fields] ([F_Id], [F_Name], [F_IdAddress], [F_Light], [F_Rental], [F_BookingPossibility], [F_PhotoPath]) VALUES (2, N'Puławska', 4, 1, 0, 0, NULL)
INSERT [dbo].[Fields] ([F_Id], [F_Name], [F_IdAddress], [F_Light], [F_Rental], [F_BookingPossibility], [F_PhotoPath]) VALUES (3, N'Syta', 5, 1, 1, 1, N'../../Resources/Images/orlikPhoto.jpg')
INSERT [dbo].[Fields] ([F_Id], [F_Name], [F_IdAddress], [F_Light], [F_Rental], [F_BookingPossibility], [F_PhotoPath]) VALUES (4, N'Merliniego', 6, 1, 0, 1, NULL)
SET IDENTITY_INSERT [dbo].[Fields] OFF
SET IDENTITY_INSERT [dbo].[OpenDaysHours] ON 

INSERT [dbo].[OpenDaysHours] ([ODH_Id], [ODH_IdField], [ODH_MonFrom], [ODH_MonTo], [ODH_TuesFrom], [ODH_TuesTo], [ODH_WedFrom], [ODH_WedTo], [ODH_ThursFrom], [ODH_ThursTo], [ODH_FriFrom], [ODH_FriTo], [ODH_SatFrom], [ODH_SatTo], [ODH_SunFrom], [ODH_SunTo]) VALUES (1, 1, CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'22:00:00' AS Time))
INSERT [dbo].[OpenDaysHours] ([ODH_Id], [ODH_IdField], [ODH_MonFrom], [ODH_MonTo], [ODH_TuesFrom], [ODH_TuesTo], [ODH_WedFrom], [ODH_WedTo], [ODH_ThursFrom], [ODH_ThursTo], [ODH_FriFrom], [ODH_FriTo], [ODH_SatFrom], [ODH_SatTo], [ODH_SunFrom], [ODH_SunTo]) VALUES (2, 2, CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time))
INSERT [dbo].[OpenDaysHours] ([ODH_Id], [ODH_IdField], [ODH_MonFrom], [ODH_MonTo], [ODH_TuesFrom], [ODH_TuesTo], [ODH_WedFrom], [ODH_WedTo], [ODH_ThursFrom], [ODH_ThursTo], [ODH_FriFrom], [ODH_FriTo], [ODH_SatFrom], [ODH_SatTo], [ODH_SunFrom], [ODH_SunTo]) VALUES (3, 3, CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'09:00:00' AS Time), CAST(N'21:00:00' AS Time))
INSERT [dbo].[OpenDaysHours] ([ODH_Id], [ODH_IdField], [ODH_MonFrom], [ODH_MonTo], [ODH_TuesFrom], [ODH_TuesTo], [ODH_WedFrom], [ODH_WedTo], [ODH_ThursFrom], [ODH_ThursTo], [ODH_FriFrom], [ODH_FriTo], [ODH_SatFrom], [ODH_SatTo], [ODH_SunFrom], [ODH_SunTo]) VALUES (5, 4, CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time), CAST(N'10:00:00' AS Time), CAST(N'21:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[OpenDaysHours] OFF
USE [master]
GO
ALTER DATABASE [footcam] SET  READ_WRITE 
GO
