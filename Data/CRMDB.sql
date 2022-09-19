USE [master]
GO
/****** Object:  Database [CRMDB]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE DATABASE [CRMDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CRMDB', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\CRMDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CRMDB_log', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\CRMDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CRMDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CRMDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CRMDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CRMDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CRMDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CRMDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CRMDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CRMDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CRMDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CRMDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CRMDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CRMDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CRMDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CRMDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CRMDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CRMDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CRMDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CRMDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CRMDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CRMDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CRMDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CRMDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CRMDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CRMDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CRMDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CRMDB] SET  MULTI_USER 
GO
ALTER DATABASE [CRMDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CRMDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CRMDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CRMDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CRMDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CRMDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CRMDB] SET QUERY_STORE = OFF
GO
USE [CRMDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accessories]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DateIn] [datetime2](7) NOT NULL,
	[IsBooked] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ImageId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Accessories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AccessoryBooks]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessoryBooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccessoryId] [int] NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AccessoryBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttachedFiles]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachedFiles](
	[Id] [uniqueidentifier] NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileType] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AttachedFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendances]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendances](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CallerId] [uniqueidentifier] NOT NULL,
	[AttendeeId] [uniqueidentifier] NOT NULL,
	[CheckAt] [datetime2](7) NOT NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_Attendances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendees]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MeetingId] [uniqueidentifier] NOT NULL,
	[AttendeeId] [uniqueidentifier] NOT NULL,
	[JoinAt] [datetime2](7) NOT NULL,
	[LeaveAt] [datetime2](7) NOT NULL,
	[LastLeaveAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Attendees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversations]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[HostId] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[HostFullname] [nvarchar](max) NULL,
	[MemberFullname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Conversations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTasks]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogAt] [datetime2](7) NOT NULL,
	[Duration] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TaskId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LogTasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meetings]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meetings](
	[Id] [uniqueidentifier] NOT NULL,
	[HostId] [uniqueidentifier] NOT NULL,
	[StartAt] [datetime2](7) NOT NULL,
	[EndAt] [datetime2](7) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[TeacherSubjectId] [int] NULL,
	[SubjectName] [nvarchar](max) NULL,
	[TeacherFullname] [nvarchar](max) NULL,
	[IsStarted] [bit] NOT NULL,
 CONSTRAINT [PK_Meetings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[ProjectId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[MemberFullname] [nvarchar](max) NULL,
	[StudentID] [nvarchar](max) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [uniqueidentifier] NOT NULL,
	[ReceiverId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[SentAt] [datetime2](7) NOT NULL,
	[IsSeen] [bit] NOT NULL,
	[ConversationId] [int] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[XPosition] [int] NOT NULL,
	[YPosition] [int] NOT NULL,
	[Color] [nvarchar](max) NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifies]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsSeen] [bit] NOT NULL,
 CONSTRAINT [PK_Notifies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Start] [datetime2](7) NOT NULL,
	[End] [datetime2](7) NOT NULL,
	[LeaderId] [uniqueidentifier] NULL,
	[OwnerId] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[LeaderFullname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferenceReceivers]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceReceivers](
	[Id] [uniqueidentifier] NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
	[ReceiverId] [uniqueidentifier] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ReferenceReceivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomBooks]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomBooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_RoomBooks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [uniqueidentifier] NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[IsLab] [bit] NOT NULL,
	[TotalSeat] [int] NOT NULL,
	[TotalTV] [int] NOT NULL,
	[TotalAirCondition] [int] NOT NULL,
	[IsFree] [bit] NOT NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAbsents]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAbsents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[OffDate] [datetime2](7) NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_StudentAbsents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [uniqueidentifier] NOT NULL,
	[TaskName] [nvarchar](max) NULL,
	[AssigneeId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SupervisorId] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[StartAt] [datetime2](7) NOT NULL,
	[DueTo] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[ProjectId] [uniqueidentifier] NULL,
	[DoneAt] [datetime2](7) NOT NULL,
	[AssigneeFullname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketComments]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TicketId] [uniqueidentifier] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
 CONSTRAINT [PK_TicketComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 6/29/2022 9:18:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[OwnerUsername] [nvarchar](max) NOT NULL,
	[TicketType] [int] NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[Detail] [nvarchar](max) NULL,
	[SupervisorId] [uniqueidentifier] NOT NULL,
	[Status] [nvarchar](max) NOT NULL,
	[IsHistory] [bit] NOT NULL,
	[IsRoot] [bit] NOT NULL,
	[RootId] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[OwnerClass] [nvarchar](max) NULL,
	[OwnerCurrentClass] [nvarchar](max) NULL,
	[OwnerFullname] [nvarchar](max) NULL,
	[OwnerYourClass] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220515135548_init', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520151746_update1', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220520152534_update2', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521022913_update4', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220521170833_updateproject', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220522110116_updateticket', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220522125555_updatetask1', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220522144741_addstickynote', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220604024809_addconversation', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220604025142_updateconversation', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220615022505_updatenotify', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220616124735_updateproject1', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220616175127_updateonlinemeeting', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220616175421_updateonlinemeeting2', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220625131822_updateonlinemeeting3', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220625143154_updateonlinemeeting4', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220626021142_updatetaskandproject', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220626033755_updatemember', N'5.0.14')
GO
SET IDENTITY_INSERT [dbo].[Attendees] ON 

INSERT [dbo].[Attendees] ([Id], [MeetingId], [AttendeeId], [JoinAt], [LeaveAt], [LastLeaveAt]) VALUES (4, N'59061128-6f81-4f2e-010e-08da56af7c27', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Attendees] OFF
GO
SET IDENTITY_INSERT [dbo].[Conversations] ON 

INSERT [dbo].[Conversations] ([Id], [DomainId], [Title], [HostId], [MemberId], [HostFullname], [MemberFullname]) VALUES (1, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'Cô Châu', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'Trần Liễu Nhựt Anh', N'Lê Thị Minh Châu')
INSERT [dbo].[Conversations] ([Id], [DomainId], [Title], [HostId], [MemberId], [HostFullname], [MemberFullname]) VALUES (4, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, N'e234b73c-d762-403e-6b73-08da3503ce41', N'606a2908-0b44-4f83-b30d-372ad8d0fc12', N'Lê Thị Minh Châu', N'Nguyễn Huy Thế')
SET IDENTITY_INSERT [dbo].[Conversations] OFF
GO
SET IDENTITY_INSERT [dbo].[LogTasks] ON 

INSERT [dbo].[LogTasks] ([Id], [LogAt], [Duration], [Description], [TaskId]) VALUES (1002, CAST(N'2022-06-18T19:47:05.9494200' AS DateTime2), 1, NULL, N'12e6f0a0-db40-4b01-662b-08da367bbf1a')
INSERT [dbo].[LogTasks] ([Id], [LogAt], [Duration], [Description], [TaskId]) VALUES (1003, CAST(N'2022-06-18T19:54:27.4486087' AS DateTime2), 2, N'Test', N'12e6f0a0-db40-4b01-662b-08da367bbf1a')
INSERT [dbo].[LogTasks] ([Id], [LogAt], [Duration], [Description], [TaskId]) VALUES (1004, CAST(N'2022-06-26T09:31:27.2611943' AS DateTime2), 1, N'tét', N'12e6f0a0-db40-4b01-662b-08da367bbf1a')
SET IDENTITY_INSERT [dbo].[LogTasks] OFF
GO
INSERT [dbo].[Meetings] ([Id], [HostId], [StartAt], [EndAt], [Title], [TeacherSubjectId], [SubjectName], [TeacherFullname], [IsStarted]) VALUES (N'59061128-6f81-4f2e-010e-08da56af7c27', N'e234b73c-d762-403e-6b73-08da3503ce41', CAST(N'2022-06-27T13:33:11.2040000' AS DateTime2), CAST(N'2022-06-27T15:33:11.2040000' AS DateTime2), N'Hoc online', 1, N'Hệ quản trị CSDL', N'Lê Thị Minh Châu', 0)
GO
INSERT [dbo].[Members] ([ProjectId], [AccountId], [MemberFullname], [StudentID]) VALUES (N'a0aa8732-24cf-4000-abb5-08da3ca2566e', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Trần Liễu Nhựt Anh', N'18110001')
INSERT [dbo].[Members] ([ProjectId], [AccountId], [MemberFullname], [StudentID]) VALUES (N'e10ef91c-d63f-4e78-1d4b-08da5729291e', N'606a2908-0b44-4f83-b30d-372ad8d0fc12', N'Nguyễn Huy Thế', N'18110002')
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (8, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'Em chào cô ạ', CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (9, N'e234b73c-d762-403e-6b73-08da3503ce41', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Chào em', CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (12, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'cô cho em hỏi cái này với', CAST(N'2022-06-04T13:49:21.6906690' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (13, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'bài kia khó quá cô', CAST(N'2022-06-04T13:50:42.1941305' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (14, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'chỉ giúp em phần này với ạ', CAST(N'2022-06-04T13:51:49.4689060' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (15, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'câu 3 á cô', CAST(N'2022-06-04T13:54:51.0134337' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (17, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'chỉ em với ạ', CAST(N'2022-06-04T13:55:33.0465226' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (62, N'e234b73c-d762-403e-6b73-08da3503ce41', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'câu 3 chương nào em', CAST(N'2022-06-05T13:55:33.0000000' AS DateTime2), 1, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (63, N'e234b73c-d762-403e-6b73-08da3503ce41', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'abc', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 1)
INSERT [dbo].[Messages] ([Id], [SenderId], [ReceiverId], [Content], [SentAt], [IsSeen], [ConversationId]) VALUES (64, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', N'Dạ chương 2', CAST(N'2022-06-20T05:24:50.5262758' AS DateTime2), 1, 1)
SET IDENTITY_INSERT [dbo].[Messages] OFF
GO
SET IDENTITY_INSERT [dbo].[Notes] ON 

INSERT [dbo].[Notes] ([Id], [AccountId], [Content], [XPosition], [YPosition], [Color]) VALUES (4, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'<p>M<strong>ai làm bài kiểm tra</strong></p>', 1564, 102, N'red')
SET IDENTITY_INSERT [dbo].[Notes] OFF
GO
SET IDENTITY_INSERT [dbo].[Notifies] ON 

INSERT [dbo].[Notifies] ([Id], [AccountId], [Content], [CreatedAt], [IsSeen]) VALUES (1, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Môn hệ QTCSL vừa được thêm bài học mới', CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Notifies] ([Id], [AccountId], [Content], [CreatedAt], [IsSeen]) VALUES (5, N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Lê Thị Minh Châu vừa tạo buổi học online cho môn Hệ quản trị CSDL vào ngày 27-06-2022 với thời lượng 2 tiếng.', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Notifies] OFF
GO
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Start], [End], [LeaderId], [OwnerId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SubjectId], [LeaderFullname]) VALUES (N'a0aa8732-24cf-4000-abb5-08da3ca2566e', N'Nghiên cứu ngành CNTT', N'Tìm hiểu về ngành CNTT', CAST(N'2022-05-23T09:51:26.0810000' AS DateTime2), CAST(N'2022-06-30T09:51:26.0810000' AS DateTime2), N'3fa85f64-5717-4562-b3fc-2c963f66afa6', N'e234b73c-d762-403e-6b73-08da3503ce41', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, NULL)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Start], [End], [LeaderId], [OwnerId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SubjectId], [LeaderFullname]) VALUES (N'bf74cc9f-d1d5-42b5-c17c-08da3cb74f14', N'Bài tập lớn 1', N'1313131232', CAST(N'2022-05-23T09:51:26.0810000' AS DateTime2), CAST(N'2022-05-23T09:51:26.0810000' AS DateTime2), N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'e234b73c-d762-403e-6b73-08da3503ce41', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 2, NULL)
INSERT [dbo].[Projects] ([Id], [Name], [Description], [Start], [End], [LeaderId], [OwnerId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SubjectId], [LeaderFullname]) VALUES (N'e10ef91c-d63f-4e78-1d4b-08da5729291e', N'123123', N'123123', CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-22T00:00:00.0000000' AS DateTime2), N'6fac68f5-8582-45e8-8d09-4857be01c46d', N'e234b73c-d762-403e-6b73-08da3503ce41', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, N'Lê Trung Nghĩa')
GO
INSERT [dbo].[Tasks] ([Id], [TaskName], [AssigneeId], [Description], [SupervisorId], [Status], [StartAt], [DueTo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProjectId], [DoneAt], [AssigneeFullname]) VALUES (N'7a311221-4bd3-47cc-662a-08da367bbf1a', N'Research', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Tìm hiểu về CNTT', N'e234b73c-d762-403e-6b73-08da3503ce41', N'TODO', CAST(N'2022-05-23T10:39:57.6310000' AS DateTime2), CAST(N'2022-05-23T10:39:57.6310000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'a0aa8732-24cf-4000-abb5-08da3ca2566e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Tasks] ([Id], [TaskName], [AssigneeId], [Description], [SupervisorId], [Status], [StartAt], [DueTo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProjectId], [DoneAt], [AssigneeFullname]) VALUES (N'12e6f0a0-db40-4b01-662b-08da367bbf1a', N'Viết tài liệu', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Viết báo cáo', N'e234b73c-d762-403e-6b73-08da3503ce41', N'PROCESS', CAST(N'2022-05-15T14:03:34.4850000' AS DateTime2), CAST(N'2022-05-15T14:03:34.4850000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'a0aa8732-24cf-4000-abb5-08da3ca2566e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Tasks] ([Id], [TaskName], [AssigneeId], [Description], [SupervisorId], [Status], [StartAt], [DueTo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProjectId], [DoneAt], [AssigneeFullname]) VALUES (N'0b587b72-5630-41d6-662c-08da367bbf1a', N'Báo cáo', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Báo cáo với GVHD', N'e234b73c-d762-403e-6b73-08da3503ce41', N'DONE', CAST(N'2022-05-15T14:03:34.4850000' AS DateTime2), CAST(N'2022-05-15T14:03:34.4850000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'a0aa8732-24cf-4000-abb5-08da3ca2566e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Tasks] ([Id], [TaskName], [AssigneeId], [Description], [SupervisorId], [Status], [StartAt], [DueTo], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [ProjectId], [DoneAt], [AssigneeFullname]) VALUES (N'ce62cead-3ffb-4d9e-d3a8-08da573a1692', N'Báo cáo', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Báo cáo với GVHD', N'00000000-0000-0000-0000-000000000000', N'TODO', CAST(N'2022-06-27T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'a0aa8732-24cf-4000-abb5-08da3ca2566e', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Tickets] ([Id], [Title], [OwnerId], [OwnerUsername], [TicketType], [ToDate], [Detail], [SupervisorId], [Status], [IsHistory], [IsRoot], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsApproved], [FromDate], [OwnerClass], [OwnerCurrentClass], [OwnerFullname], [OwnerYourClass]) VALUES (N'aec6b039-2161-40f4-20fd-08da3bda78ad', N'Xin nghỉ học ngày 25/5/2022', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'string', 0, CAST(N'2022-05-22T00:00:00.0000000' AS DateTime2), N'<p>Do em bận việc gia đình nên em xin phép nghỉ học.</p>', N'e234b73c-d762-403e-6b73-08da3503ce41', N'APPROVED', 0, 0, NULL, NULL, CAST(N'2022-06-16T11:44:00.4388853' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'2022-05-22T10:04:18.5280000' AS DateTime2), NULL, NULL, NULL, NULL)
INSERT [dbo].[Tickets] ([Id], [Title], [OwnerId], [OwnerUsername], [TicketType], [ToDate], [Detail], [SupervisorId], [Status], [IsHistory], [IsRoot], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [IsApproved], [FromDate], [OwnerClass], [OwnerCurrentClass], [OwnerFullname], [OwnerYourClass]) VALUES (N'65ba569f-b9a2-40dc-7fe1-08da4c01a5d4', N'xin phép nghỉ học', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'nhutanh', 0, CAST(N'2022-06-16T00:00:00.0000000' AS DateTime2), N'<p>13131232131</p>', N'e234b73c-d762-403e-6b73-08da3503ce41', N'DECLINED', 0, 0, NULL, NULL, CAST(N'2022-06-16T11:44:00.4388853' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL)
GO
/****** Object:  Index [IX_AccessoryBooks_AccessoryId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_AccessoryBooks_AccessoryId] ON [dbo].[AccessoryBooks]
(
	[AccessoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AccessoryBooks_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_AccessoryBooks_TicketId] ON [dbo].[AccessoryBooks]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_AttachedFiles_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_AttachedFiles_TicketId] ON [dbo].[AttachedFiles]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attendees_MeetingId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_Attendees_MeetingId] ON [dbo].[Attendees]
(
	[MeetingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_LogTasks_TaskId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_LogTasks_TaskId] ON [dbo].[LogTasks]
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Messages_ConversationId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_Messages_ConversationId] ON [dbo].[Messages]
(
	[ConversationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReferenceReceivers_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_ReferenceReceivers_TicketId] ON [dbo].[ReferenceReceivers]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoomBooks_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_RoomBooks_TicketId] ON [dbo].[RoomBooks]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentAbsents_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_StudentAbsents_TicketId] ON [dbo].[StudentAbsents]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tasks_ProjectId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tasks_ProjectId] ON [dbo].[Tasks]
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TicketComments_TicketId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_TicketComments_TicketId] ON [dbo].[TicketComments]
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tickets_RootId]    Script Date: 6/29/2022 9:18:13 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tickets_RootId] ON [dbo].[Tickets]
(
	[RootId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accessories] ADD  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ImageId]
GO
ALTER TABLE [dbo].[Meetings] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsStarted]
GO
ALTER TABLE [dbo].[Messages] ADD  DEFAULT ((0)) FOR [ConversationId]
GO
ALTER TABLE [dbo].[Notifies] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsSeen]
GO
ALTER TABLE [dbo].[Projects] ADD  DEFAULT ((0)) FOR [SubjectId]
GO
ALTER TABLE [dbo].[Tasks] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [DoneAt]
GO
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT (N'') FOR [Title]
GO
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT (N'') FOR [OwnerUsername]
GO
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Tickets] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FromDate]
GO
ALTER TABLE [dbo].[AccessoryBooks]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryBooks_Accessories_AccessoryId] FOREIGN KEY([AccessoryId])
REFERENCES [dbo].[Accessories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccessoryBooks] CHECK CONSTRAINT [FK_AccessoryBooks_Accessories_AccessoryId]
GO
ALTER TABLE [dbo].[AccessoryBooks]  WITH CHECK ADD  CONSTRAINT [FK_AccessoryBooks_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AccessoryBooks] CHECK CONSTRAINT [FK_AccessoryBooks_Tickets_TicketId]
GO
ALTER TABLE [dbo].[AttachedFiles]  WITH CHECK ADD  CONSTRAINT [FK_AttachedFiles_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AttachedFiles] CHECK CONSTRAINT [FK_AttachedFiles_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Attendees]  WITH CHECK ADD  CONSTRAINT [FK_Attendees_Meetings_MeetingId] FOREIGN KEY([MeetingId])
REFERENCES [dbo].[Meetings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attendees] CHECK CONSTRAINT [FK_Attendees_Meetings_MeetingId]
GO
ALTER TABLE [dbo].[LogTasks]  WITH CHECK ADD  CONSTRAINT [FK_LogTasks_Tasks_TaskId] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LogTasks] CHECK CONSTRAINT [FK_LogTasks_Tasks_TaskId]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Projects_ProjectId]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Conversations_ConversationId] FOREIGN KEY([ConversationId])
REFERENCES [dbo].[Conversations] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Conversations_ConversationId]
GO
ALTER TABLE [dbo].[ReferenceReceivers]  WITH CHECK ADD  CONSTRAINT [FK_ReferenceReceivers_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReferenceReceivers] CHECK CONSTRAINT [FK_ReferenceReceivers_Tickets_TicketId]
GO
ALTER TABLE [dbo].[RoomBooks]  WITH CHECK ADD  CONSTRAINT [FK_RoomBooks_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoomBooks] CHECK CONSTRAINT [FK_RoomBooks_Tickets_TicketId]
GO
ALTER TABLE [dbo].[StudentAbsents]  WITH CHECK ADD  CONSTRAINT [FK_StudentAbsents_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAbsents] CHECK CONSTRAINT [FK_StudentAbsents_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Projects_ProjectId] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Projects_ProjectId]
GO
ALTER TABLE [dbo].[TicketComments]  WITH CHECK ADD  CONSTRAINT [FK_TicketComments_Tickets_TicketId] FOREIGN KEY([TicketId])
REFERENCES [dbo].[Tickets] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TicketComments] CHECK CONSTRAINT [FK_TicketComments_Tickets_TicketId]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Tickets_RootId] FOREIGN KEY([RootId])
REFERENCES [dbo].[Tickets] ([Id])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Tickets_RootId]
GO
USE [master]
GO
ALTER DATABASE [CRMDB] SET  READ_WRITE 
GO
