USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'CiberCafeDB')
BEGIN
    ALTER DATABASE [CiberCafeDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [CiberCafeDB];
END
GO

CREATE DATABASE [CiberCafeDB]
GO

USE [CiberCafeDB]
GO

-- =============================================
-- 1. CREACIÓN DE TABLAS (ESTRUCTURA)
-- =============================================
CREATE TABLE [dbo].[Users](
	[Username] [varchar](20) NOT NULL PRIMARY KEY,
	[Password] [varchar](40) NOT NULL, -- OJO: Aquí se guardará tal cual lo maneje tu app
	[Admin] [bit] NOT NULL,
	[UserID] [int] IDENTITY(1,1) NOT NULL UNIQUE
)
GO

CREATE TABLE [dbo].[Clients](
	[ClientID] [varchar](10) NOT NULL PRIMARY KEY,
	[ClientMemStatus] [bit] NOT NULL,
	[ClientName] [varchar](20) NOT NULL,
	[ClientBirthDate] [date] NOT NULL,
	[ClientPhone] [varchar](10) NULL,
	[ClientAddress] [varchar](30) NULL
)
GO

CREATE TABLE [dbo].[Computers](
	[PcIp] [varchar](15) NOT NULL PRIMARY KEY, -- La IP es la clave primaria
	[PcNumber] [varchar](3) NOT NULL,
	[PcStatus] [varchar](20) NOT NULL,
	[PcInfo] [varchar](100) NULL
)
GO

CREATE TABLE [dbo].[Services_Products](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ServiceName] [varchar](20) NOT NULL,
	[ServicePrice] [smallmoney] NOT NULL
)
GO

CREATE TABLE [dbo].[Membership](
	[MembershipID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[MembershipName] [varchar](20) NOT NULL,
	[MemDay] [int] NOT NULL,
	[MemMonth] [int] NOT NULL,
	[MemYear] [int] NOT NULL,
	[Discount] [float] NULL
)
GO

CREATE TABLE [dbo].[Caja](
	[IdCaja] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FechaApertura] [datetime] NOT NULL,
	[MontoApertura] [decimal](18, 2) NOT NULL,
	[IdUsuarioApertura] [int] NOT NULL,
	[FechaCierre] [datetime] NULL,
	[MontoCierre] [decimal](18, 2) NULL,
	[IdUsuarioCierre] [int] NULL,
	[Estado] [int] NOT NULL, -- 1: Abierta, 0: Cerrada
	[TotalIngresos] [decimal](18, 2) NOT NULL DEFAULT 0,
	[TotalGastos] [decimal](18, 2) NOT NULL DEFAULT 0,
	[Notas] [varchar](200) NULL
)
GO

CREATE TABLE [dbo].[ClientComputer](
	[CC_ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[CC_PcID] [int] NOT NULL, 
	[CC_ClientID] [varchar](10) NOT NULL,
	[CC_StartTime] [datetime] NOT NULL,
	[CC_EndTime] [datetime] NULL,
    FOREIGN KEY([CC_ClientID]) REFERENCES [dbo].[Clients] ([ClientID])
)
GO

CREATE TABLE [dbo].[Transactions](
	[TransID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TransClientID] [varchar](10) NOT NULL,
	[TransServicesID] [int] NULL,
	[TransDescrip] [varchar](100) NULL,
	[TransPaidMoney] [smallmoney] NULL,
	[TransDiscount] [smallmoney] NOT NULL,
	[TransQuantity] [int] NOT NULL,
	[TransDateTime] [datetime] NOT NULL,
	[TransUsername] [varchar](20) NULL,
	[IdCaja] [int] NULL,
	FOREIGN KEY([TransClientID]) REFERENCES [dbo].[Clients] ([ClientID]),
	FOREIGN KEY([TransServicesID]) REFERENCES [dbo].[Services_Products] ([ServiceID]),
	FOREIGN KEY([IdCaja]) REFERENCES [dbo].[Caja] ([IdCaja])
)
GO

-- ESTA ES LA NUEVA QUE AGREGAMOS
CREATE TABLE [dbo].[Auditoria](
	[IdLog] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Fecha] [datetime] DEFAULT GETDATE(),
	[UsuarioActor] [varchar](20),
	[Accion] [varchar](50),
	[Detalle] [varchar](200)
)
GO

-- =============================================
-- 2. SEED DATA (DATOS DE PRUEBA)
-- =============================================

-- A. Usuarios
INSERT INTO [dbo].[Users] ([Username], [Password], [Admin]) 
VALUES ('admin', '1234', 1);

INSERT INTO [dbo].[Users] ([Username], [Password], [Admin]) 
VALUES ('empleado', '1234', 0);

-- B. Servicios Básicos
INSERT INTO [dbo].[Services_Products] ([ServiceName], [ServicePrice])
VALUES 
('Hora Internet', 0.50),
('Impresión B/N', 0.10),
('Impresión Color', 0.25),
('Escaneo', 0.15),
('Cola', 0.75),
('Snack', 0.50);

-- C. Computadoras
INSERT INTO [dbo].[Computers] ([PcIp], [PcNumber], [PcStatus], [PcInfo])
VALUES 
('192.168.1.101', '01', 'Disponible', 'Ryzen 5 - Cerca Ventana'),
('192.168.1.102', '02', 'Disponible', 'Intel i3 - Pasillo'),
('192.168.1.103', '03', 'Mantenimiento', 'Sin Teclado'),
('192.168.1.104', '04', 'Ocupada', 'Gamer Zone');

-- D. Clientes
INSERT INTO [dbo].[Clients] ([ClientID], [ClientMemStatus], [ClientName], [ClientBirthDate], [ClientPhone], [ClientAddress])
VALUES 
('9999999999', 0, 'CONSUMIDOR FINAL', '2000-01-01', NULL, NULL),
('1205487963', 1, 'Teilor Piloso', '2002-05-15', '0991234567', 'Centro');

-- E. Caja Inicial
INSERT INTO [dbo].[Caja] ([FechaApertura], [MontoApertura], [IdUsuarioApertura], [Estado], [TotalIngresos], [TotalGastos])
VALUES (GETDATE(), 20.00, 1, 1, 0, 0);

GO