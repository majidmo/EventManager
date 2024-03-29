USE [EventsManager]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 3/25/2017 12:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varbinary](50) NOT NULL,
	[Location] [varbinary](50) NULL,
	[Date] [smalldatetime] NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Deadline] [smalldatetime] NULL,
	[AllowAnonymous] [bit] NULL,
	[MaxNoOfAttendees] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 3/25/2017 12:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendees](
	[AttendeeId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[EventAttendees]    Script Date: 3/25/2017 12:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventAttendees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NOT NULL,
	[AttendeeId] [int] NOT NULL
) ON [PRIMARY]

GO
