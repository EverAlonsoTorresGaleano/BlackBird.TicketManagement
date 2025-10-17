USE [master]
GO
/****** Object:  Database [BlackBird.TicketManagement.DB]    Script Date: 10/17/2025 12:14:38 AM ******/
CREATE DATABASE [BlackBird.TicketManagement.DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlackBird.TicketManagement.DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BlackBird.TicketManagement.DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlackBird.TicketManagement.DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BlackBird.TicketManagement.DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlackBird.TicketManagement.DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET RECOVERY FULL 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET  MULTI_USER 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlackBird.TicketManagement.DB', N'ON'
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BlackBird.TicketManagement.DB]
GO
/****** Object:  Table [dbo].[TicketsHistory]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketsHistory](
	[TicketId] [bigint] NOT NULL,
	[TicketTypeFk] [bigint] NOT NULL,
	[TicketStateFk] [bigint] NOT NULL,
	[CreatedByUserFk] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Details] [varchar](max) NULL,
	[Audience] [varchar](max) NULL,
	[Localization] [varchar](max) NULL,
	[EventDate] [datetime] NULL,
	[UpdatedByUserFk] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[AsignedToUserFk] [bigint] NULL,
	[ValidFrom] [datetime2](7) NOT NULL,
	[ValidTo] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
DATA_COMPRESSION = PAGE
)
GO
/****** Object:  Index [ix_TicketsHistory]    Script Date: 10/17/2025 12:14:39 AM ******/
CREATE CLUSTERED INDEX [ix_TicketsHistory] ON [dbo].[TicketsHistory]
(
	[ValidTo] ASC,
	[ValidFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF, DATA_COMPRESSION = PAGE) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[TicketId] [bigint] IDENTITY(1,1) NOT NULL,
	[TicketTypeFk] [bigint] NOT NULL,
	[TicketStateFk] [bigint] NOT NULL,
	[CreatedByUserFk] [bigint] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Details] [varchar](max) NULL,
	[Audience] [varchar](max) NULL,
	[Localization] [varchar](max) NULL,
	[EventDate] [datetime] NULL,
	[UpdatedByUserFk] [bigint] NULL,
	[UpdatedDate] [datetime] NULL,
	[AsignedToUserFk] [bigint] NULL,
	[ValidFrom] [datetime2](7) GENERATED ALWAYS AS ROW START NOT NULL,
	[ValidTo] [datetime2](7) GENERATED ALWAYS AS ROW END NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
	PERIOD FOR SYSTEM_TIME ([ValidFrom], [ValidTo])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
WITH
(
SYSTEM_VERSIONING = ON (HISTORY_TABLE = [dbo].[TicketsHistory])
)
GO
/****** Object:  Table [dbo].[GeneralTypeGroups]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTypeGroups](
	[GeneralTypeGroupId] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GeneralTypes] PRIMARY KEY CLUSTERED 
(
	[GeneralTypeGroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GeneralTypeItems]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralTypeItems](
	[GeneralTypeItemId] [bigint] IDENTITY(1,1) NOT NULL,
	[GeneralTypeGroupFk] [bigint] NOT NULL,
	[ItemName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GeneralTypeItems] PRIMARY KEY CLUSTERED 
(
	[GeneralTypeItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[IsEnabled] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/17/2025 12:14:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserSecret] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[LastAccess] [datetime] NULL,
	[RoleFk] [bigint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GeneralTypeGroups] ON 
GO
INSERT [dbo].[GeneralTypeGroups] ([GeneralTypeGroupId], [GroupName]) VALUES (1, N'Solicitud Logistica')
GO
INSERT [dbo].[GeneralTypeGroups] ([GeneralTypeGroupId], [GroupName]) VALUES (2, N'Tipo Tiquete')
GO
INSERT [dbo].[GeneralTypeGroups] ([GeneralTypeGroupId], [GroupName]) VALUES (3, N'Estado Tiquete')
GO
SET IDENTITY_INSERT [dbo].[GeneralTypeGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[GeneralTypeItems] ON 
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (1, 1, N'Montaje')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (2, 1, N'Catering')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (3, 1, N'Montaje')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (4, 2, N'Incidente')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (5, 2, N'Reclamo')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (6, 2, N'Peticion')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (7, 3, N'Abierto')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (8, 3, N'En Proceso')
GO
INSERT [dbo].[GeneralTypeItems] ([GeneralTypeItemId], [GeneralTypeGroupFk], [ItemName]) VALUES (9, 3, N'Cerrado')
GO
SET IDENTITY_INSERT [dbo].[GeneralTypeItems] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 
GO
INSERT [dbo].[Tickets] ([TicketId], [TicketTypeFk], [TicketStateFk], [CreatedByUserFk], [CreatedDate], [Details], [Audience], [Localization], [EventDate], [UpdatedByUserFk], [UpdatedDate], [AsignedToUserFk], [ValidFrom], [ValidTo]) VALUES (7, 4, 7, 2, CAST(N'2025-10-10T00:00:00.000' AS DateTime), N'Detail 1.1', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-10-17T04:15:08.0810179' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2))
GO
INSERT [dbo].[Tickets] ([TicketId], [TicketTypeFk], [TicketStateFk], [CreatedByUserFk], [CreatedDate], [Details], [Audience], [Localization], [EventDate], [UpdatedByUserFk], [UpdatedDate], [AsignedToUserFk], [ValidFrom], [ValidTo]) VALUES (8, 5, 8, 2, CAST(N'2025-10-17T05:00:53.880' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-10-17T05:05:28.9954660' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
INSERT [dbo].[TicketsHistory] ([TicketId], [TicketTypeFk], [TicketStateFk], [CreatedByUserFk], [CreatedDate], [Details], [Audience], [Localization], [EventDate], [UpdatedByUserFk], [UpdatedDate], [AsignedToUserFk], [ValidFrom], [ValidTo]) VALUES (7, 4, 7, 2, CAST(N'2025-10-10T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-10-17T04:14:33.4159940' AS DateTime2), CAST(N'2025-10-17T04:15:03.3794627' AS DateTime2))
GO
INSERT [dbo].[TicketsHistory] ([TicketId], [TicketTypeFk], [TicketStateFk], [CreatedByUserFk], [CreatedDate], [Details], [Audience], [Localization], [EventDate], [UpdatedByUserFk], [UpdatedDate], [AsignedToUserFk], [ValidFrom], [ValidTo]) VALUES (7, 4, 7, 2, CAST(N'2025-10-10T00:00:00.000' AS DateTime), N'Detail 1', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-10-17T04:15:03.3794627' AS DateTime2), CAST(N'2025-10-17T04:15:08.0810179' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [RoleName], [IsEnabled]) VALUES (1, N'Admin', 1)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [RoleName], [IsEnabled]) VALUES (2, N'Supervisor', 1)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [RoleName], [IsEnabled]) VALUES (3, N'Agente', 1)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserName], [UserSecret], [Name], [LastName], [Email], [Phone], [Address], [IsLocked], [LastAccess], [RoleFk]) VALUES (2, N'ever.torresg', N'123', N'Ever Alonso', N'Torres Galeano', N'eeatg844@hotmail.com', N'+573146625684', N'Cra 43A # 49 ', 0, CAST(N'2025-10-17T02:58:55.740' AS DateTime), 1)
GO
INSERT [dbo].[Users] ([UserId], [UserName], [UserSecret], [Name], [LastName], [Email], [Phone], [Address], [IsLocked], [LastAccess], [RoleFk]) VALUES (4, N'api', N'345', N'System ', N'ApiUser', N'api@blackbird.com', N'+576041111111', N'Medellin', 0, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [dbo].[GeneralTypeItems]  WITH CHECK ADD  CONSTRAINT [FK_GeneralTypeItems_GeneralTypeGroups] FOREIGN KEY([GeneralTypeGroupFk])
REFERENCES [dbo].[GeneralTypeGroups] ([GeneralTypeGroupId])
GO
ALTER TABLE [dbo].[GeneralTypeItems] CHECK CONSTRAINT [FK_GeneralTypeItems_GeneralTypeGroups]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_GeneralTypeItems] FOREIGN KEY([TicketTypeFk])
REFERENCES [dbo].[GeneralTypeItems] ([GeneralTypeItemId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_GeneralTypeItems]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_GeneralTypeItems1] FOREIGN KEY([TicketStateFk])
REFERENCES [dbo].[GeneralTypeItems] ([GeneralTypeItemId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_GeneralTypeItems1]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users] FOREIGN KEY([CreatedByUserFk])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users1] FOREIGN KEY([AsignedToUserFk])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users1]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users2] FOREIGN KEY([UpdatedByUserFk])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users2]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserRoles] FOREIGN KEY([RoleFk])
REFERENCES [dbo].[UserRoles] ([UserRoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserRoles]
GO
USE [master]
GO
ALTER DATABASE [BlackBird.TicketManagement.DB] SET  READ_WRITE 
GO
