USE [BlackBird.TicketManagement.DB]
GO

--Drop Table
 ALTER TABLE [dbo].[Tickets]
    SET (SYSTEM_VERSIONING = OFF);

DROP TABLE [dbo].[Tickets]
DROP TABLE [dbo].[TicketsHistory]
     
GO

--Create Table

USE [BlackBird.TicketManagement.DB]
GO

/****** Object:  Table [dbo].[Tickets]    Script Date: 10/16/2025 3:56:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tickets](
	[TicketId] [bigint] PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
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
    ValidFrom DATETIME2 GENERATED ALWAYS AS ROW START NOT NULL,
    ValidTo DATETIME2 GENERATED ALWAYS AS ROW END NOT NULL,
    PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
)
WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.TicketsHistory));
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


