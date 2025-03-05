USE [master]
GO
/****** Object:  Database [CiberCafeDB]    Script Date: 5/3/2025 1:42:42 ******/
CREATE DATABASE [CiberCafeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CiberCafeDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CiberCafeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CiberCafeDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\CiberCafeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CiberCafeDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CiberCafeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CiberCafeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CiberCafeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CiberCafeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CiberCafeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CiberCafeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CiberCafeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CiberCafeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CiberCafeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CiberCafeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CiberCafeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CiberCafeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CiberCafeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CiberCafeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CiberCafeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CiberCafeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CiberCafeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CiberCafeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CiberCafeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CiberCafeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CiberCafeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CiberCafeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CiberCafeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CiberCafeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CiberCafeDB] SET  MULTI_USER 
GO
ALTER DATABASE [CiberCafeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CiberCafeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CiberCafeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CiberCafeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CiberCafeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CiberCafeDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CiberCafeDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [CiberCafeDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CiberCafeDB]
GO
/****** Object:  User [teilor]    Script Date: 5/3/2025 1:42:42 ******/
CREATE USER [teilor] FOR LOGIN [teilor] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [teilor]
GO
/****** Object:  Table [dbo].[ClientComputer]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientComputer](
	[CC_ID] [int] IDENTITY(1,1) NOT NULL,
	[CC_PcID] [int] NOT NULL,
	[CC_ClientID] [varchar](10) NOT NULL,
	[CC_StartTime] [datetime] NOT NULL,
	[CC_EndTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientMembership]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientMembership](
	[CMID] [int] IDENTITY(1,1) NOT NULL,
	[CMClientID] [varchar](10) NOT NULL,
	[CMMembershipID] [int] NOT NULL,
	[CMStartDate] [date] NOT NULL,
	[CMEndDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CMID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [varchar](10) NOT NULL,
	[ClientMemStatus] [bit] NOT NULL,
	[ClientName] [varchar](20) NOT NULL,
	[ClientBirthDate] [date] NOT NULL,
	[ClientPhone] [varchar](10) NULL,
	[ClientAddress] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[PcID] [int] IDENTITY(1,1) NOT NULL,
	[PcNumber] [varchar](3) NOT NULL,
	[PcStatus] [varchar](20) NOT NULL,
	[PcInfo] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[PcID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Membership]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Membership](
	[MembershipID] [int] IDENTITY(1,1) NOT NULL,
	[MembershipName] [varchar](20) NOT NULL,
	[MemDay] [int] NOT NULL,
	[MemMonth] [int] NOT NULL,
	[MemYear] [int] NOT NULL,
	[Discount] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MembershipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services_Products]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services_Products](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](20) NOT NULL,
	[ServicePrice] [smallmoney] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransID] [int] IDENTITY(1,1) NOT NULL,
	[TransUserID] [int] NOT NULL,
	[TransClientID] [varchar](10) NOT NULL,
	[TransServicesID] [int] NOT NULL,
	[TransDescrip] [varchar](100) NULL,
	[TransPaidMoney] [smallmoney] NOT NULL,
	[TransDiscount] [smallmoney] NOT NULL,
	[TransQuantity] [int] NOT NULL,
	[TransDateTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TransID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/3/2025 1:42:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](40) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clients] ([ClientID], [ClientMemStatus], [ClientName], [ClientBirthDate], [ClientPhone], [ClientAddress]) VALUES (N'10', 0, N'Ben!0', CAST(N'2001-11-10' AS Date), N'1', N'')
INSERT [dbo].[Clients] ([ClientID], [ClientMemStatus], [ClientName], [ClientBirthDate], [ClientPhone], [ClientAddress]) VALUES (N'1643324324', 0, N'Alejo', CAST(N'2001-01-09' AS Date), N'0993299313', N'')
INSERT [dbo].[Clients] ([ClientID], [ClientMemStatus], [ClientName], [ClientBirthDate], [ClientPhone], [ClientAddress]) VALUES (N'444', 1, N'Peppa', CAST(N'2004-07-10' AS Date), N'911', N'Peppas House pipi')
GO
SET IDENTITY_INSERT [dbo].[Computers] ON 

INSERT [dbo].[Computers] ([PcID], [PcNumber], [PcStatus], [PcInfo]) VALUES (8, N'1', N'Disponible', N'Ultra grafica')
INSERT [dbo].[Computers] ([PcID], [PcNumber], [PcStatus], [PcInfo]) VALUES (9, N'2', N'Disponible', N'Intel i5')
INSERT [dbo].[Computers] ([PcID], [PcNumber], [PcStatus], [PcInfo]) VALUES (10, N'4', N'Bloqueada', N'Intel Inside')
SET IDENTITY_INSERT [dbo].[Computers] OFF
GO
SET IDENTITY_INSERT [dbo].[Services_Products] ON 

INSERT [dbo].[Services_Products] ([ServiceID], [ServiceName], [ServicePrice]) VALUES (2, N'Precioxhora PC', 0.6000)
SET IDENTITY_INSERT [dbo].[Services_Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([TransID], [TransUserID], [TransClientID], [TransServicesID], [TransDescrip], [TransPaidMoney], [TransDiscount], [TransQuantity], [TransDateTime]) VALUES (4, 1, N'10', 2, N'Uso de PC', 0.2000, 0.0000, 1, CAST(N'2025-02-26T06:55:25.700' AS DateTime))
INSERT [dbo].[Transactions] ([TransID], [TransUserID], [TransClientID], [TransServicesID], [TransDescrip], [TransPaidMoney], [TransDiscount], [TransQuantity], [TransDateTime]) VALUES (5, 1, N'10', 2, N'Uso de PC', 0.2000, 0.0000, 1, CAST(N'2025-02-26T06:59:45.727' AS DateTime))
INSERT [dbo].[Transactions] ([TransID], [TransUserID], [TransClientID], [TransServicesID], [TransDescrip], [TransPaidMoney], [TransDiscount], [TransQuantity], [TransDateTime]) VALUES (7, 1, N'10', 2, N'Uso de PC', 0.2000, 0.0000, 1, CAST(N'2025-02-26T07:13:03.310' AS DateTime))
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[Users] ([UserID], [Username], [Password]) VALUES (4, N'user', N'user')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[ClientComputer]  WITH CHECK ADD FOREIGN KEY([CC_ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[ClientComputer]  WITH CHECK ADD FOREIGN KEY([CC_PcID])
REFERENCES [dbo].[Computers] ([PcID])
GO
ALTER TABLE [dbo].[ClientMembership]  WITH CHECK ADD FOREIGN KEY([CMClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[ClientMembership]  WITH CHECK ADD FOREIGN KEY([CMMembershipID])
REFERENCES [dbo].[Membership] ([MembershipID])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([TransUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([TransClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD FOREIGN KEY([TransServicesID])
REFERENCES [dbo].[Services_Products] ([ServiceID])
GO
USE [master]
GO
ALTER DATABASE [CiberCafeDB] SET  READ_WRITE 
GO
