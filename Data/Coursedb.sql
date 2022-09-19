USE [master]
GO
/****** Object:  Database [Coursedb]    Script Date: 6/29/2022 9:17:37 PM ******/
CREATE DATABASE [Coursedb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Coursedb', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Coursedb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Coursedb_log', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\Coursedb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Coursedb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coursedb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coursedb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Coursedb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Coursedb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Coursedb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Coursedb] SET ARITHABORT OFF 
GO
ALTER DATABASE [Coursedb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Coursedb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Coursedb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Coursedb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Coursedb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Coursedb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Coursedb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Coursedb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Coursedb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Coursedb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Coursedb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Coursedb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Coursedb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Coursedb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Coursedb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Coursedb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Coursedb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Coursedb] SET RECOVERY FULL 
GO
ALTER DATABASE [Coursedb] SET  MULTI_USER 
GO
ALTER DATABASE [Coursedb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Coursedb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Coursedb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Coursedb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Coursedb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Coursedb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Coursedb] SET QUERY_STORE = OFF
GO
USE [Coursedb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/29/2022 9:17:37 PM ******/
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
/****** Object:  Table [dbo].[Answers]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [uniqueidentifier] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[IsCorrectAnswer] [bit] NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[Format] [int] NOT NULL,
	[AnswerType] [nvarchar](max) NOT NULL,
	[AudioPath] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaremScores]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaremScores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Percent] [int] NOT NULL,
	[TeacherSubjectId] [int] NOT NULL,
 CONSTRAINT [PK_BaremScores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExamResult]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamResult](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamId] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ExamResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exams]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exams](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AutoStartDate] [datetime2](7) NOT NULL,
	[Duration] [int] NOT NULL,
	[TotalAttempts] [int] NOT NULL,
	[IsRandomize] [bit] NOT NULL,
	[TotalScore] [int] NOT NULL,
	[OwnerId] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periods]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periods](
	[DomainId] [uniqueidentifier] NOT NULL,
	[PeriodName] [nvarchar](max) NULL,
	[TotalMinute] [int] NOT NULL,
	[StartHour] [int] NOT NULL,
	[StartMin] [int] NOT NULL,
	[EndHour] [int] NOT NULL,
	[EndMin] [int] NOT NULL,
 CONSTRAINT [PK_Periods] PRIMARY KEY CLUSTERED 
(
	[DomainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionAllocation]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionAllocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [uniqueidentifier] NOT NULL,
	[ExamId] [uniqueidentifier] NULL,
	[QuizId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_QuestionAllocation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[IsCountdown] [bit] NOT NULL,
	[TotalSeconds] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[Format] [int] NOT NULL,
	[QuestionType] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quizzes]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quizzes](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsCountdown] [bit] NOT NULL,
	[TotalSeconds] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Quizzes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[Id] [uniqueidentifier] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StartTime] [datetime2](7) NOT NULL,
	[TotalPeriod] [int] NOT NULL,
	[EndTime] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Schedules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scores]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BaremId] [int] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[Value] [float] NOT NULL,
 CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Order] [int] NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[TeacherSubjectId] [int] NOT NULL,
	[RootId] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SectionScripts]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SectionScripts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SectionId] [uniqueidentifier] NOT NULL,
	[Order] [int] NOT NULL,
	[ScriptType] [nvarchar](max) NOT NULL,
	[AssignmentScript_Title] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[AssignmentScript_Description] [nvarchar](max) NULL,
	[AssignmentScript_OpenAt] [datetime2](7) NULL,
	[AssignmentScript_DueTo] [datetime2](7) NULL,
	[IsReopen] [bit] NULL,
	[Heading] [nvarchar](max) NULL,
	[Body] [nvarchar](max) NULL,
	[Footer] [nvarchar](max) NULL,
	[DocumentTitle] [nvarchar](max) NULL,
	[DocumentPassword] [nvarchar](max) NULL,
	[DocumentUrl] [nvarchar](max) NULL,
	[FileId] [uniqueidentifier] NULL,
	[FileType] [nvarchar](max) NULL,
	[ExamId] [uniqueidentifier] NULL,
	[ExamScript_Title] [nvarchar](max) NULL,
	[ExamScript_Description] [nvarchar](max) NULL,
	[Duration] [int] NULL,
	[TotalAttempt] [int] NULL,
	[IsShuffle] [bit] NULL,
	[OpenAt] [datetime2](7) NULL,
	[DueTo] [datetime2](7) NULL,
	[QuizId] [uniqueidentifier] NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[IsOnetimeQuiz] [bit] NULL,
	[VideoId] [uniqueidentifier] NULL,
	[VideoPath] [nvarchar](max) NULL,
	[VideoScript_Description] [nvarchar](max) NULL,
	[VideoScript_Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_SectionScripts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semesters]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semesters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[Year] [int] NOT NULL,
	[SemesterName] [nvarchar](450) NULL,
	[SemesterStart] [datetime2](7) NOT NULL,
	[SemesterEnd] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentAssignments]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAssignments](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentId] [uniqueidentifier] NOT NULL,
	[AssigmentId] [int] NOT NULL,
	[FileId] [uniqueidentifier] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[AbsolutePath] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StudentAssignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClasses]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClasses](
	[StudentId] [uniqueidentifier] NOT NULL,
	[SemesterId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StartAt] [datetime2](7) NOT NULL,
	[EndAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StudentClasses] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC,
	[StudentId] ASC,
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[Id] [uniqueidentifier] NOT NULL,
	[StudentID] [nvarchar](450) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[IdentityNo] [nvarchar](max) NULL,
	[AvatarId] [uniqueidentifier] NOT NULL,
	[Gender] [int] NOT NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PermanentAddress] [nvarchar](max) NULL,
	[CurrentAddress] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[LeaveDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[Id] [uniqueidentifier] NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[CoverImageUrl] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Credit] [int] NOT NULL,
	[PricePerCredit] [float] NOT NULL,
	[TotalPeriod] [int] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[Id] [uniqueidentifier] NOT NULL,
	[TeacherID] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[Salary] [float] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[Fullname] [nvarchar](max) NULL,
	[IdentityNo] [nvarchar](max) NULL,
	[AvatarId] [uniqueidentifier] NOT NULL,
	[Gender] [int] NOT NULL,
	[AvatarUrl] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PermanentAddress] [nvarchar](max) NULL,
	[CurrentAddress] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[JoinDate] [datetime2](7) NOT NULL,
	[LeaveDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherSubjects]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[SemesterId] [int] NULL,
	[SubjectId] [uniqueidentifier] NULL,
	[Code] [nvarchar](450) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TeacherSubjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeachingHistory]    Script Date: 6/29/2022 9:17:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachingHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [uniqueidentifier] NOT NULL,
	[Start] [int] NOT NULL,
	[Summary] [nvarchar](max) NULL,
	[Detail] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TeachingHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619135847_init', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619160042_updateteachersubject', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220625232016_addvideoscript', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220625233055_updatevideoscript', N'5.0.14')
GO
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'8d09a116-62c3-4869-c735-08da362d87ab', N'Dog', 1, N'799119e7-4ad1-4b7e-dd09-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'590ca998-b2ee-472d-c736-08da362d87ab', N'Cat', 0, N'799119e7-4ad1-4b7e-dd09-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'aa3056b5-c0a4-4617-c737-08da362d87ab', N'Duck', 0, N'799119e7-4ad1-4b7e-dd09-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'8243d4e4-a1d9-407a-c738-08da362d87ab', N'Dog', 0, N'105f92aa-542a-44e0-dd0a-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'e57c4480-6816-41cd-c739-08da362d87ab', N'Cat', 0, N'105f92aa-542a-44e0-dd0a-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'728fa0bf-79d5-4cd6-c73a-08da362d87ab', N'Duck', 1, N'105f92aa-542a-44e0-dd0a-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'a7f8264b-a96d-46bf-c73b-08da362d87ab', N'Dog', 0, N'68cb78fb-d401-464e-dd0b-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'd0204853-b5c9-402b-c73c-08da362d87ab', N'Cat', 1, N'68cb78fb-d401-464e-dd0b-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Answers] ([Id], [Content], [IsCorrectAnswer], [QuestionId], [Format], [AnswerType], [AudioPath], [ImagePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'36eb323b-e8f2-4222-c73d-08da362d87ab', N'Duck', 0, N'68cb78fb-d401-464e-dd0b-08da362d87a1', 0, N'BasicAnswer', NULL, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Exams] ([Id], [Title], [Description], [AutoStartDate], [Duration], [TotalAttempts], [IsRandomize], [TotalScore], [OwnerId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'2642828a-489e-4066-38ad-08da362d8797', N'Test exam', N'Test exam', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, 0, 0, 0, N'66e96229-14cf-4955-1b13-08da362d8767', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[QuestionAllocation] ON 

INSERT [dbo].[QuestionAllocation] ([Id], [QuestionId], [ExamId], [QuizId]) VALUES (1, N'799119e7-4ad1-4b7e-dd09-08da362d87a1', N'2642828a-489e-4066-38ad-08da362d8797', NULL)
INSERT [dbo].[QuestionAllocation] ([Id], [QuestionId], [ExamId], [QuizId]) VALUES (2, N'105f92aa-542a-44e0-dd0a-08da362d87a1', N'2642828a-489e-4066-38ad-08da362d8797', NULL)
INSERT [dbo].[QuestionAllocation] ([Id], [QuestionId], [ExamId], [QuizId]) VALUES (3, N'68cb78fb-d401-464e-dd0b-08da362d87a1', N'2642828a-489e-4066-38ad-08da362d8797', NULL)
SET IDENTITY_INSERT [dbo].[QuestionAllocation] OFF
GO
INSERT [dbo].[Questions] ([Id], [Title], [Content], [IsCountdown], [TotalSeconds], [Score], [Format], [QuestionType], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'799119e7-4ad1-4b7e-dd09-08da362d87a1', N'Chọn đáp án đúng', N'Con chó trong tiếng Anh là gì', 0, 0, 0, 0, N'MultichoiceQuestion', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Questions] ([Id], [Title], [Content], [IsCountdown], [TotalSeconds], [Score], [Format], [QuestionType], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'105f92aa-542a-44e0-dd0a-08da362d87a1', N'Chọn đáp án đúng', N'Con vịt trong tiếng Anh là gì', 0, 0, 0, 0, N'MultichoiceQuestion', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Questions] ([Id], [Title], [Content], [IsCountdown], [TotalSeconds], [Score], [Format], [QuestionType], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'68cb78fb-d401-464e-dd0b-08da362d87a1', N'Chọn đáp án đúng', N'Con mèo trong tiếng Anh là gì', 0, 0, 0, 0, N'MultichoiceQuestion', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Schedules] ([Id], [SubjectId], [StartTime], [TotalPeriod], [EndTime], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'8145eaaa-9389-4333-6233-08da362d87bb', 1, CAST(N'2022-05-15T11:44:00.4393442' AS DateTime2), 0, CAST(N'2022-05-15T13:14:00.4394377' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Schedules] ([Id], [SubjectId], [StartTime], [TotalPeriod], [EndTime], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'8ec218d8-7341-4288-6234-08da362d87bb', 2, CAST(N'2022-05-15T12:29:00.4396163' AS DateTime2), 0, CAST(N'2022-05-15T13:59:00.4396173' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'8c984930-bd2a-4538-0b87-08da362d878f', N'Tuần 1', 1, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-14T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'73312dfb-7736-4233-0b8a-08da362d878f', N'Chương 1', 1, CAST(N'2022-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-20T00:00:00.0000000' AS DateTime2), 1, N'8c984930-bd2a-4538-0b87-08da362d878f', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'baadddac-9e48-44d1-0b8b-08da362d878f', N'Chương 2', 2, CAST(N'2022-05-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), 1, N'8c984930-bd2a-4538-0b87-08da362d878f', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'eab23f61-8316-40bd-05e4-08da51d76deb', N'Tuần 2', 2, CAST(N'2022-06-15T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-30T00:00:00.0000000' AS DateTime2), 1, NULL, N'System', CAST(N'2022-06-19T16:42:26.5626577' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'901e9d8a-282c-4f88-ba07-08da51da7c57', N'Chương 3', 3, CAST(N'2022-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), 1, N'eab23f61-8316-40bd-05e4-08da51d76deb', N'System', CAST(N'2022-06-19T17:00:05.7309362' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'7a846cb1-97cf-400a-16a9-08da59d32a51', N'Chương 4', 3, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-05T00:00:00.0000000' AS DateTime2), 1, N'eab23f61-8316-40bd-05e4-08da51d76deb', N'System', CAST(N'2022-06-29T20:27:50.9386807' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'4a0dee2b-f08c-4e9c-16aa-08da59d32a51', N'Tuần 3', 3, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-05T00:00:00.0000000' AS DateTime2), 1, NULL, N'System', CAST(N'2022-06-29T20:37:38.0842570' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'2883e4f0-b01d-4377-16ab-08da59d32a51', N'Chương 5', 4, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), 1, N'4a0dee2b-f08c-4e9c-16aa-08da59d32a51', N'System', CAST(N'2022-06-29T20:39:04.6994834' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'f7e98839-9c5b-4672-16af-08da59d32a51', N'Tuần 1', 1, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-05T00:00:00.0000000' AS DateTime2), 2, NULL, N'System', CAST(N'2022-06-29T20:47:19.9692696' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'c97d0024-6e75-427c-16b0-08da59d32a51', N'Chương 1', 2, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), 2, N'f7e98839-9c5b-4672-16af-08da59d32a51', N'System', CAST(N'2022-06-29T20:47:35.8228815' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Sections] ([Id], [Title], [Order], [FromDate], [ToDate], [TeacherSubjectId], [RootId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'1c999015-5685-4acb-16b1-08da59d32a51', N'Chương 2', 2, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-06T00:00:00.0000000' AS DateTime2), 2, N'f7e98839-9c5b-4672-16af-08da59d32a51', N'System', CAST(N'2022-06-29T20:47:47.0291987' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[SectionScripts] ON 

INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (5, N'baadddac-9e48-44d1-0b8b-08da362d878f', 1, N'AssignmentScript', N'Nộp bài tập', N'Làm theo file hướng dẫn', N'File Câu hỏi và bài tập', CAST(N'2022-05-17T11:44:00.4388839' AS DateTime2), CAST(N'2022-05-19T11:44:00.4388853' AS DateTime2), 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1014, N'73312dfb-7736-4233-0b8a-08da362d878f', 0, N'ContextScript', NULL, NULL, NULL, NULL, NULL, NULL, N'<p>- Các em tải tài liệu môn học, đề cương chi tiết và các quy định đánh giá về xem trước</p>', N'- Buổi học đầu tiên chúng ta chủ yếu làm quen, giới thiệu môn học và giải đáp các thắc mắc', N'- Mỗi sinh viên làm một file word nêu những gì đã tìm hiểu hoặc đã biết về môn học này', NULL, NULL, NULL, NULL, N'pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1018, N'73312dfb-7736-4233-0b8a-08da362d878f', 10, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Tài liệu môn học', N'', N'http://localhost:8080/assets\Database Management Systems Raghu 3Rd Edition (1).pdf', N'7039fc27-cc70-47a8-07d6-08da523de105', N'pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1020, N'baadddac-9e48-44d1-0b8b-08da362d878f', 2, N'ContextScript', NULL, NULL, NULL, NULL, NULL, NULL, N'<p>- Các nhóm làm bài tập trong file Câu hỏi và bài tập</p>', N'<p>- Lập nhóm, chọn đề tài và làm một file word đặc tả về đề tài đó</p>', N'<p>- Xem trước tài liệu chương này và cài đặt SQL server</p>', NULL, NULL, NULL, NULL, N'pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1030, N'baadddac-9e48-44d1-0b8b-08da362d878f', 5, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Câu hỏi và bài tập', N'', N'http://localhost:8080/assets\Assigment_Chapter 01.docx', N'c73ea1a2-d2f8-4a04-07dc-08da523de105', N'docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1034, N'73312dfb-7736-4233-0b8a-08da362d878f', 15, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Đề cương chi tiết', N'', N'http://localhost:8080/assets\02.DeCuongHeQTCSDL (1).doc', N'b733ba7c-4d21-4d19-07d9-08da523de105', N'doc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1040, N'73312dfb-7736-4233-0b8a-08da362d878f', 18, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Các quy định và đánh giá', N'', N'http://localhost:8080/assets\CÁC QUI ĐỊNH VÀ CÁCH ĐÁNH GIÁ mon hoc (2).pptx', N'f0db35aa-a4c4-48f3-07da-08da523de105', N'pptx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1046, N'73312dfb-7736-4233-0b8a-08da362d878f', 19, N'AssignmentScript', N'Nộp bài tập', N'', N'', CAST(N'2022-06-13T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-21T00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1048, N'73312dfb-7736-4233-0b8a-08da362d878f', 20, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Báo cáo mẫu', N'', N'http://localhost:8080/assets\Nhom1_DoAn_PhanMemQuanLyKhachSan.pdf', N'ea5baeda-7842-4846-07db-08da523de105', N'pdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1049, N'baadddac-9e48-44d1-0b8b-08da362d878f', 6, N'AssignmentScript', N'Nộp đề tài cuối kì', N'Đặc tả đề tài', N'', CAST(N'2022-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-23T00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1061, N'73312dfb-7736-4233-0b8a-08da362d878f', 21, N'VideoScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'6dfae546-93bc-48fe-0e35-08da57441ea0', N'http://localhost:8080/assets\DBMS.mp4', N'', N'Giới thiệu môn học')
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1068, N'901e9d8a-282c-4f88-ba07-08da51da7c57', 0, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Bài tập chương 3', N'', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'f9169a37-7388-4a9a-5891-08da59cdc3f6', N'docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1069, N'901e9d8a-282c-4f88-ba07-08da51da7c57', 1, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Constraints, Triggers and Views', N'', N'http://localhost:8080/assets\Ch02_Constraints_Triggers_View (2).ppt', N'88b2b207-50ab-4b21-5892-08da59cdc3f6', N'ppt', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1070, N'901e9d8a-282c-4f88-ba07-08da51da7c57', 2, N'AssignmentScript', N'Nộp bài tập chương 3', N'', N'', CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-05T00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1071, N'901e9d8a-282c-4f88-ba07-08da51da7c57', 3, N'ContextScript', NULL, NULL, NULL, NULL, NULL, NULL, N'<p>- Tải và xem trước tài liệu chương 3</p>', N'<p>- Làm bài tập trong Câu hỏi bài tập</p>', N'<p>- Xem bài giảng</p>', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1080, N'901e9d8a-282c-4f88-ba07-08da51da7c57', 4, N'VideoScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'9c3131fa-81ad-4fdf-3a0c-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'', N'Constraints, Triggers and Views')
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1081, N'7a846cb1-97cf-400a-16a9-08da59d32a51', 0, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Database programming', N'', N'http://localhost:8080/assets\Chapter03- Database_Programming.ppt', N'188b2f02-f3dc-4548-3a0d-08da59d29f38', N'ppt', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1082, N'7a846cb1-97cf-400a-16a9-08da59d32a51', 1, N'DocumentScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'BT Trigger, thủ tục và hàm', N'', N'http://localhost:8080/assets\BT Trigger Thu tuc va ham.docx', N'394db12c-1d8d-4e30-3a0e-08da59d29f38', N'docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1083, N'7a846cb1-97cf-400a-16a9-08da59d32a51', 2, N'ContextScript', NULL, NULL, NULL, NULL, NULL, NULL, N'<p>- Xem bài giảng</p>', N'<p>- Làm và nộp bài tập trong BT Trigger, thủ tục và hàm</p>', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1084, N'7a846cb1-97cf-400a-16a9-08da59d32a51', 3, N'VideoScript', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'6a393f3d-4709-492e-3a0f-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'', N'')
INSERT [dbo].[SectionScripts] ([Id], [SectionId], [Order], [ScriptType], [AssignmentScript_Title], [Detail], [AssignmentScript_Description], [AssignmentScript_OpenAt], [AssignmentScript_DueTo], [IsReopen], [Heading], [Body], [Footer], [DocumentTitle], [DocumentPassword], [DocumentUrl], [FileId], [FileType], [ExamId], [ExamScript_Title], [ExamScript_Description], [Duration], [TotalAttempt], [IsShuffle], [OpenAt], [DueTo], [QuizId], [Title], [Description], [IsOnetimeQuiz], [VideoId], [VideoPath], [VideoScript_Description], [VideoScript_Title]) VALUES (1085, N'7a846cb1-97cf-400a-16a9-08da59d32a51', 4, N'AssignmentScript', N'Bài tập Trigger, thủ tục và hàm', N'', N'', CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-07-09T00:00:00.0000000' AS DateTime2), 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SectionScripts] OFF
GO
SET IDENTITY_INSERT [dbo].[Semesters] ON 

INSERT [dbo].[Semesters] ([Id], [DomainId], [Year], [SemesterName], [SemesterStart], [SemesterEnd]) VALUES (1, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', 2022, N'Học kỳ 1', CAST(N'2022-05-15T11:43:57.6941941' AS DateTime2), CAST(N'2022-10-15T11:43:57.6967798' AS DateTime2))
INSERT [dbo].[Semesters] ([Id], [DomainId], [Year], [SemesterName], [SemesterStart], [SemesterEnd]) VALUES (2, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', 2022, N'Học kỳ 2', CAST(N'2022-06-20T00:00:00.0000000' AS DateTime2), CAST(N'2022-06-06T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Semesters] OFF
GO
INSERT [dbo].[StudentAssignments] ([Id], [StudentId], [AssigmentId], [FileId], [FilePath], [FileName], [AbsolutePath], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'cb9bc226-3334-4641-af15-08da52422eb5', N'21c378ad-69f8-4a78-a1bc-08da362d8756', 1046, N'74589783-c53c-4519-07dd-08da523de105', N'http://localhost:8080/assets\SRS.docx', N'SRS.docx', N'', N'System', CAST(N'2022-06-20T05:22:23.1771341' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'21c378ad-69f8-4a78-a1bc-08da362d8756', 1, 1, CAST(N'2022-06-29T21:14:13.0088049' AS DateTime2), CAST(N'2022-06-29T21:14:13.0091394' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'21c378ad-69f8-4a78-a1bc-08da362d8756', 1, 2, CAST(N'2022-06-20T01:26:08.6627699' AS DateTime2), CAST(N'2022-06-20T01:26:08.6627710' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'21c378ad-69f8-4a78-a1bc-08da362d8756', 1, 6, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b57f0d3f-948b-4d6f-d722-08da4c0f9790', 1, 1, CAST(N'2022-06-29T21:14:13.0095335' AS DateTime2), CAST(N'2022-06-29T21:14:13.0095368' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b57f0d3f-948b-4d6f-d722-08da4c0f9790', 1, 2, CAST(N'2022-06-20T01:26:08.6627760' AS DateTime2), CAST(N'2022-06-20T01:26:08.6627762' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b57f0d3f-948b-4d6f-d722-08da4c0f9790', 1, 6, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b7c560ad-0440-46f2-d723-08da4c0f9790', 1, 1, CAST(N'2022-06-29T21:14:13.0095386' AS DateTime2), CAST(N'2022-06-29T21:14:13.0095388' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b7c560ad-0440-46f2-d723-08da4c0f9790', 1, 6, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'b2ed83e1-8f5e-4f99-d724-08da4c0f9790', 1, 1, CAST(N'2022-06-29T21:14:13.0095401' AS DateTime2), CAST(N'2022-06-29T21:14:13.0095403' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'e4223229-2033-4791-d725-08da4c0f9790', 1, 1, CAST(N'2022-06-29T21:14:13.0095413' AS DateTime2), CAST(N'2022-06-29T21:14:13.0095451' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'f8a79a6f-09ca-4546-d727-08da4c0f9790', 1, 6, CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[StudentClasses] ([StudentId], [SemesterId], [SubjectId], [StartAt], [EndAt]) VALUES (N'cc22284d-9fcc-4267-2156-08da4e3021bf', 1, 1, CAST(N'2022-06-29T21:14:13.0095507' AS DateTime2), CAST(N'2022-06-29T21:14:13.0095509' AS DateTime2))
GO
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'21c378ad-69f8-4a78-a1bc-08da362d8756', N'18110101', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T05:33:28.4582584' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'Trần Liễu Nhựt Anh', N'7264728124', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0944707123', N'TP.HCM', N'TP.HCM', CAST(N'2000-12-27T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-15T11:43:59.8325772' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'b57f0d3f-948b-4d6f-d722-08da4c0f9790', N'18110202', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:21:06.8355865' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'606a2908-0b44-4f83-b30d-372ad8d0fc12', N'Nguyễn Huy Thế', N'381859032', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0901024536', N'Cà Mau', N'TPHCM', CAST(N'2000-06-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'b7c560ad-0440-46f2-d723-08da4c0f9790', N'18110205', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T07:42:26.5942134' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'f4093e70-3c94-44dd-b8b6-c37e276695fd', N'Nguyễn Văn A', N'9836125235', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0944707505', N'Sóc Trăng', N'TPHCM', CAST(N'2000-07-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'b2ed83e1-8f5e-4f99-d724-08da4c0f9790', N'18110209', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:22:31.8449112' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'c7201888-4f1e-4fed-ad97-f3ef237b0909', N'Nguyễn Văn B', N'500983271752', N'00000000-0000-0000-0000-000000000000', 0, N'', N'09430212932', N'Vũng Tàu', N'TPHCM', CAST(N'2000-09-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'e4223229-2033-4791-d725-08da4c0f9790', N'18110222', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:23:09.2833920' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'674c40f9-543a-4726-af9b-8bc3513ed3da', N'Nguyễn Văn C', N'9064728124', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0913912345', N'Cà Mau', N'TPHCM', CAST(N'2000-06-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'a0119615-4dd0-4d61-d726-08da4c0f9790', N'18110204', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:23:43.5410691' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'06149cc3-18b6-474a-9b08-9fc37d7c9be7', N'Nguyễn Văn D', N'82748102842', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0901024536', N'Vũng Tàu', N'TPHCM', CAST(N'2000-06-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'f8a79a6f-09ca-4546-d727-08da4c0f9790', N'18110299', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:24:30.4704620' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'0a10dae6-ddda-4eed-a5a5-d40b0ec8e30e', N'Nguyễn Văn E', N'381982502', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0944707123', N'Bà Rịa', N'TPHCM', CAST(N'1999-06-06T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'cc22284d-9fcc-4267-2156-08da4e3021bf', N'000007', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:25:03.4168962' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'6fac68f5-8582-45e8-8d09-4857be01c46d', N'Lê Trung Nghĩa', N'381999024', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0940929012', N'TPHCM', N'TPHCM', CAST(N'1998-06-21T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Students] ([Id], [StudentID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'1d34eeb1-f132-44bd-a0b8-08da52578df8', N'000008', N'System', CAST(N'2022-06-20T07:55:23.1986732' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'd1487c56-73da-4e35-a3f4-93edbec37774', N'Nguyên Minh', N'9836125235', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0913912345', N'Vũng Tàu', N'TPHCM', CAST(N'2000-02-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'988b9ada-852c-4722-c52a-08da362d8773', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'QTCSDL-001', N'Hệ quản trị CSDL', N'Môn hệ quản trị cơ sở dữ liệu', 3, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-29T20:51:24.7094165' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'12ba0be7-5b60-43ff-c52b-08da362d8773', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'NMLT-001', N'Nhập môn lập trình', N'Hướng dẫn căn bản về môn lập trình', 3, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T06:38:37.5808927' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'52928175-54d5-4ee9-4796-08da42c97a80', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'f133a6a0-bfb3-4534-4797-08da42c97a80', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello 12', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'f4b41f7b-4e16-4e68-4798-08da42c97a80', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello 1332', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'25f05819-08e1-4576-1bd0-08da430609db', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello 1332444', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'd1bb06e6-e8ec-4172-1bd1-08da430609db', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello 111233', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'45fc2664-bb1b-481b-e2de-08da43067cef', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello', NULL, N'Hello 111233212133', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'bbc644ab-1808-403d-e2df-08da43067cef', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello123131', NULL, N'Hello 1112332121331231313', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'4b311ea6-c42e-48af-e2e0-08da43067cef', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello123131', NULL, N'Hello1 123 sa231313', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'bdde01c8-f0c1-4429-e2e1-08da43067cef', N'dbf46470-2b63-405a-a52b-15c7402a78b0', N'Hello123131', NULL, N'Hello1 123 sa2313 adfafasf3', N'Hello', 10, 1.4, 10, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'89197a50-9b63-4248-8338-08da59d69c3d', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'CSDL-001', N'Cơ sở dữ liệu', N'Môn cơ sở dữ liệu', 3, 0, 0, N'System', CAST(N'2022-06-29T20:52:30.5545112' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'65cb633d-7826-497e-8339-08da59d69c3d', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'LTW-001', N'Lập trình website', N'Môn lập trình website', 3, 0, 0, N'System', CAST(N'2022-06-29T20:54:36.7987287' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'bc5b7dc8-bab8-4ade-833a-08da59d69c3d', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'KTLT-001', N'Kỹ thuật lập trình', N'Môn kỹ thuật lập trình', 3, 0, 0, N'System', CAST(N'2022-06-29T20:57:47.8293802' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Subjects] ([Id], [DomainId], [CoverImageUrl], [Code], [Title], [Description], [Credit], [PricePerCredit], [TotalPeriod], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'0762a8de-0941-4127-833b-08da59d69c3d', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'', N'TRR-001', N'Toán rời rạc và lý thuyết đô thị', N'Môn toán rời rạc và lý thuyết đô thị', 3, 0, 0, N'System', CAST(N'2022-06-29T20:58:52.1773819' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[Teachers] ([Id], [TeacherID], [Title], [Salary], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'66e96229-14cf-4955-1b13-08da362d8767', N'IT100001', N'', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T05:32:05.6422951' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'e234b73c-d762-403e-6b73-08da3503ce41', N'Lê Thị Minh Châu', N'381941052', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0913912345', N'TP.HCM', N'TP.HCM', CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-29T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teachers] ([Id], [TeacherID], [Title], [Salary], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'81e958a8-795c-4753-7f1a-08da4187dff9', N'IT100002', N'', 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2022-06-20T05:32:45.4811621' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'Nguyễn Trần Thi Văn', N'381845028', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0942021838', N'Tp.HCM', N'TPHCM', CAST(N'1988-08-05T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-29T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teachers] ([Id], [TeacherID], [Title], [Salary], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'1cf3016d-c881-4c59-5bdc-08da59d8a325', N'444442', N'', 0, N'System', CAST(N'2022-06-29T21:07:01.8859316' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'225375f8-bc3b-4336-80d6-8036b8ec0b2d', N'Nguyễn Anh', N'7264728124', N'00000000-0000-0000-0000-000000000000', 0, N'', N'09430212932', N'Sóc Trăng', N'TPHCM', CAST(N'1983-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2009-10-29T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teachers] ([Id], [TeacherID], [Title], [Salary], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'75e07b96-afcb-4d59-5bdd-08da59d8a325', N'444443', N'', 0, N'System', CAST(N'2022-06-29T21:09:48.3225577' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'bfed3591-3053-41a4-913d-d7ae49aff9a2', N'Nguyễn Tú', N'500983271752', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0944707123', N'Vũng Tàu', N'TPHCM', CAST(N'1989-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2016-10-29T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teachers] ([Id], [TeacherID], [Title], [Salary], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DomainId], [AccountId], [Fullname], [IdentityNo], [AvatarId], [Gender], [AvatarUrl], [PhoneNumber], [PermanentAddress], [CurrentAddress], [BirthDate], [JoinDate], [LeaveDate]) VALUES (N'742cc3a3-86ef-4447-5bde-08da59d8a325', N'444444', N'', 0, N'System', CAST(N'2022-06-29T21:11:57.4067647' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'b0dc8c28-f289-4893-a474-1f30724f1b61', N'Nguyên Minh', N'84892836737', N'00000000-0000-0000-0000-000000000000', 0, N'', N'0913912345', N'TPHCM', N'TPHCM', CAST(N'1986-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2010-05-29T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[TeacherSubjects] ON 

INSERT [dbo].[TeacherSubjects] ([Id], [TeacherId], [SemesterId], [SubjectId], [Code], [StartDate], [EndDate]) VALUES (1, N'66e96229-14cf-4955-1b13-08da362d8767', 1, N'988b9ada-852c-4722-c52a-08da362d8773', N'CSDL-001', CAST(N'2022-06-29T21:14:13.0027641' AS DateTime2), CAST(N'2022-06-29T21:14:13.0028895' AS DateTime2))
INSERT [dbo].[TeacherSubjects] ([Id], [TeacherId], [SemesterId], [SubjectId], [Code], [StartDate], [EndDate]) VALUES (2, N'66e96229-14cf-4955-1b13-08da362d8767', 1, N'12ba0be7-5b60-43ff-c52b-08da362d8773', N'KTLT-001', CAST(N'2022-06-20T01:26:08.6606902' AS DateTime2), CAST(N'2022-06-20T01:26:08.6613360' AS DateTime2))
INSERT [dbo].[TeacherSubjects] ([Id], [TeacherId], [SemesterId], [SubjectId], [Code], [StartDate], [EndDate]) VALUES (6, N'1cf3016d-c881-4c59-5bdc-08da59d8a325', 1, N'65cb633d-7826-497e-8339-08da59d69c3d', N'QTCSDL-001', CAST(N'2022-06-29T00:00:00.0000000' AS DateTime2), CAST(N'2022-08-29T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TeacherSubjects] OFF
GO
/****** Object:  Index [IX_Answers_QuestionId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_QuestionId] ON [dbo].[Answers]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BaremScores_TeacherSubjectId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_BaremScores_TeacherSubjectId] ON [dbo].[BaremScores]
(
	[TeacherSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExamResult_ExamId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_ExamResult_ExamId] ON [dbo].[ExamResult]
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ExamResult_StudentId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_ExamResult_StudentId] ON [dbo].[ExamResult]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Exams_OwnerId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Exams_OwnerId] ON [dbo].[Exams]
(
	[OwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionAllocation_ExamId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionAllocation_ExamId] ON [dbo].[QuestionAllocation]
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionAllocation_QuestionId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionAllocation_QuestionId] ON [dbo].[QuestionAllocation]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionAllocation_QuizId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionAllocation_QuizId] ON [dbo].[QuestionAllocation]
(
	[QuizId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Schedules_SubjectId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Schedules_SubjectId] ON [dbo].[Schedules]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Scores_BaremId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Scores_BaremId] ON [dbo].[Scores]
(
	[BaremId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Scores_StudentId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Scores_StudentId] ON [dbo].[Scores]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sections_RootId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Sections_RootId] ON [dbo].[Sections]
(
	[RootId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sections_TeacherSubjectId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_Sections_TeacherSubjectId] ON [dbo].[Sections]
(
	[TeacherSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SectionScripts_ExamId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SectionScripts_ExamId] ON [dbo].[SectionScripts]
(
	[ExamId] ASC
)
WHERE ([ExamId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SectionScripts_QuizId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SectionScripts_QuizId] ON [dbo].[SectionScripts]
(
	[QuizId] ASC
)
WHERE ([QuizId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SectionScripts_SectionId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_SectionScripts_SectionId] ON [dbo].[SectionScripts]
(
	[SectionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Semesters_DomainId_Year_SemesterName]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Semesters_DomainId_Year_SemesterName] ON [dbo].[Semesters]
(
	[DomainId] ASC,
	[Year] ASC,
	[SemesterName] ASC
)
WHERE ([SemesterName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentAssignments_AssigmentId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentAssignments_AssigmentId] ON [dbo].[StudentAssignments]
(
	[AssigmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentAssignments_StudentId_AssigmentId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_StudentAssignments_StudentId_AssigmentId] ON [dbo].[StudentAssignments]
(
	[StudentId] ASC,
	[AssigmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentClasses_StudentId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentClasses_StudentId] ON [dbo].[StudentClasses]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_StudentClasses_SubjectId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_StudentClasses_SubjectId] ON [dbo].[StudentClasses]
(
	[SubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Students_Id_AccountId_StudentID]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Students_Id_AccountId_StudentID] ON [dbo].[Students]
(
	[Id] ASC,
	[AccountId] ASC,
	[StudentID] ASC
)
WHERE ([StudentID] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherSubjects_SemesterId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherSubjects_SemesterId] ON [dbo].[TeacherSubjects]
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TeacherSubjects_SubjectId_SemesterId_Code_TeacherId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherSubjects_SubjectId_SemesterId_Code_TeacherId] ON [dbo].[TeacherSubjects]
(
	[SubjectId] ASC,
	[SemesterId] ASC,
	[Code] ASC,
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeacherSubjects_TeacherId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeacherSubjects_TeacherId] ON [dbo].[TeacherSubjects]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TeachingHistory_TeacherId]    Script Date: 6/29/2022 9:17:38 PM ******/
CREATE NONCLUSTERED INDEX [IX_TeachingHistory_TeacherId] ON [dbo].[TeachingHistory]
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_QuestionId]
GO
ALTER TABLE [dbo].[BaremScores]  WITH CHECK ADD  CONSTRAINT [FK_BaremScores_TeacherSubjects_TeacherSubjectId] FOREIGN KEY([TeacherSubjectId])
REFERENCES [dbo].[TeacherSubjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaremScores] CHECK CONSTRAINT [FK_BaremScores_TeacherSubjects_TeacherSubjectId]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_SectionScripts_ExamId] FOREIGN KEY([ExamId])
REFERENCES [dbo].[SectionScripts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_SectionScripts_ExamId]
GO
ALTER TABLE [dbo].[ExamResult]  WITH CHECK ADD  CONSTRAINT [FK_ExamResult_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExamResult] CHECK CONSTRAINT [FK_ExamResult_Students_StudentId]
GO
ALTER TABLE [dbo].[Exams]  WITH CHECK ADD  CONSTRAINT [FK_Exams_Teachers_OwnerId] FOREIGN KEY([OwnerId])
REFERENCES [dbo].[Teachers] ([Id])
GO
ALTER TABLE [dbo].[Exams] CHECK CONSTRAINT [FK_Exams_Teachers_OwnerId]
GO
ALTER TABLE [dbo].[QuestionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAllocation_Exams_ExamId] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([Id])
GO
ALTER TABLE [dbo].[QuestionAllocation] CHECK CONSTRAINT [FK_QuestionAllocation_Exams_ExamId]
GO
ALTER TABLE [dbo].[QuestionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAllocation_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuestionAllocation] CHECK CONSTRAINT [FK_QuestionAllocation_Questions_QuestionId]
GO
ALTER TABLE [dbo].[QuestionAllocation]  WITH CHECK ADD  CONSTRAINT [FK_QuestionAllocation_Quizzes_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([Id])
GO
ALTER TABLE [dbo].[QuestionAllocation] CHECK CONSTRAINT [FK_QuestionAllocation_Quizzes_QuizId]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK_Schedules_TeacherSubjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[TeacherSubjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK_Schedules_TeacherSubjects_SubjectId]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_BaremScores_BaremId] FOREIGN KEY([BaremId])
REFERENCES [dbo].[BaremScores] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_BaremScores_BaremId]
GO
ALTER TABLE [dbo].[Scores]  WITH CHECK ADD  CONSTRAINT [FK_Scores_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scores] CHECK CONSTRAINT [FK_Scores_Students_StudentId]
GO
ALTER TABLE [dbo].[Sections]  WITH CHECK ADD  CONSTRAINT [FK_Sections_Sections_RootId] FOREIGN KEY([RootId])
REFERENCES [dbo].[Sections] ([Id])
GO
ALTER TABLE [dbo].[Sections] CHECK CONSTRAINT [FK_Sections_Sections_RootId]
GO
ALTER TABLE [dbo].[Sections]  WITH CHECK ADD  CONSTRAINT [FK_Sections_TeacherSubjects_TeacherSubjectId] FOREIGN KEY([TeacherSubjectId])
REFERENCES [dbo].[TeacherSubjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sections] CHECK CONSTRAINT [FK_Sections_TeacherSubjects_TeacherSubjectId]
GO
ALTER TABLE [dbo].[SectionScripts]  WITH CHECK ADD  CONSTRAINT [FK_SectionScripts_Exams_ExamId] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Exams] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SectionScripts] CHECK CONSTRAINT [FK_SectionScripts_Exams_ExamId]
GO
ALTER TABLE [dbo].[SectionScripts]  WITH CHECK ADD  CONSTRAINT [FK_SectionScripts_Quizzes_QuizId] FOREIGN KEY([QuizId])
REFERENCES [dbo].[Quizzes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SectionScripts] CHECK CONSTRAINT [FK_SectionScripts_Quizzes_QuizId]
GO
ALTER TABLE [dbo].[SectionScripts]  WITH CHECK ADD  CONSTRAINT [FK_SectionScripts_Sections_SectionId] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Sections] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SectionScripts] CHECK CONSTRAINT [FK_SectionScripts_Sections_SectionId]
GO
ALTER TABLE [dbo].[StudentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignments_SectionScripts_AssigmentId] FOREIGN KEY([AssigmentId])
REFERENCES [dbo].[SectionScripts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAssignments] CHECK CONSTRAINT [FK_StudentAssignments_SectionScripts_AssigmentId]
GO
ALTER TABLE [dbo].[StudentAssignments]  WITH CHECK ADD  CONSTRAINT [FK_StudentAssignments_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAssignments] CHECK CONSTRAINT [FK_StudentAssignments_Students_StudentId]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentClasses_Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [FK_StudentClasses_Semesters_SemesterId]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentClasses_Students_StudentId] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [FK_StudentClasses_Students_StudentId]
GO
ALTER TABLE [dbo].[StudentClasses]  WITH CHECK ADD  CONSTRAINT [FK_StudentClasses_TeacherSubjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[TeacherSubjects] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentClasses] CHECK CONSTRAINT [FK_StudentClasses_TeacherSubjects_SubjectId]
GO
ALTER TABLE [dbo].[TeacherSubjects]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjects_Semesters_SemesterId] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semesters] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubjects] CHECK CONSTRAINT [FK_TeacherSubjects_Semesters_SemesterId]
GO
ALTER TABLE [dbo].[TeacherSubjects]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjects_Subjects_SubjectId] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([Id])
GO
ALTER TABLE [dbo].[TeacherSubjects] CHECK CONSTRAINT [FK_TeacherSubjects_Subjects_SubjectId]
GO
ALTER TABLE [dbo].[TeacherSubjects]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubjects_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeacherSubjects] CHECK CONSTRAINT [FK_TeacherSubjects_Teachers_TeacherId]
GO
ALTER TABLE [dbo].[TeachingHistory]  WITH CHECK ADD  CONSTRAINT [FK_TeachingHistory_Teachers_TeacherId] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teachers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TeachingHistory] CHECK CONSTRAINT [FK_TeachingHistory_Teachers_TeacherId]
GO
USE [master]
GO
ALTER DATABASE [Coursedb] SET  READ_WRITE 
GO
