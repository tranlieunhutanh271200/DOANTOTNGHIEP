USE [master]
GO
/****** Object:  Database [ResourceDb]    Script Date: 6/29/2022 9:19:17 PM ******/
CREATE DATABASE [ResourceDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResourceDb', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\ResourceDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ResourceDb_log', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\ResourceDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ResourceDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResourceDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResourceDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResourceDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResourceDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResourceDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResourceDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResourceDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ResourceDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResourceDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResourceDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResourceDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResourceDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResourceDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResourceDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResourceDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResourceDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ResourceDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResourceDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResourceDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResourceDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResourceDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResourceDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ResourceDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResourceDb] SET RECOVERY FULL 
GO
ALTER DATABASE [ResourceDb] SET  MULTI_USER 
GO
ALTER DATABASE [ResourceDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResourceDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResourceDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResourceDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ResourceDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ResourceDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ResourceDb] SET QUERY_STORE = OFF
GO
USE [ResourceDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/29/2022 9:19:17 PM ******/
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
/****** Object:  Table [dbo].[DomainDirectories]    Script Date: 6/29/2022 9:19:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainDirectories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[OwnerId] [uniqueidentifier] NOT NULL,
	[FolderName] [nvarchar](max) NULL,
	[ParentDirectoryId] [int] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DomainDirectories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Files]    Script Date: 6/29/2022 9:19:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[Id] [uniqueidentifier] NOT NULL,
	[FilePath] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[DirectoryId] [int] NULL,
	[AbsolutePath] [nvarchar](max) NULL,
	[FileType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Files] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220514100333_init', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609140351_adddomaindirectory', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609141413_updatedomaindirectory', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609150744_updatedomaindirectorycreated', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609151226_updatev2', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220614154254_updatefilemodel', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220619064108_updatefiletype', N'5.0.14')
GO
SET IDENTITY_INSERT [dbo].[DomainDirectories] ON 

INSERT [dbo].[DomainDirectories] ([Id], [DomainId], [OwnerId], [FolderName], [ParentDirectoryId], [CreatedDate]) VALUES (1, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'Root', NULL, CAST(N'2022-06-09T23:34:06.9471264' AS DateTime2))
INSERT [dbo].[DomainDirectories] ([Id], [DomainId], [OwnerId], [FolderName], [ParentDirectoryId], [CreatedDate]) VALUES (2, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'New Folder', 1, CAST(N'2022-06-09T23:38:56.2763732' AS DateTime2))
INSERT [dbo].[DomainDirectories] ([Id], [DomainId], [OwnerId], [FolderName], [ParentDirectoryId], [CreatedDate]) VALUES (3, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'New Folder', 2, CAST(N'2022-06-09T23:40:41.7305438' AS DateTime2))
INSERT [dbo].[DomainDirectories] ([Id], [DomainId], [OwnerId], [FolderName], [ParentDirectoryId], [CreatedDate]) VALUES (4, N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'New Folder', 3, CAST(N'2022-06-09T23:43:29.5906375' AS DateTime2))
INSERT [dbo].[DomainDirectories] ([Id], [DomainId], [OwnerId], [FolderName], [ParentDirectoryId], [CreatedDate]) VALUES (7, N'32dd8d3b-fc61-4050-9e14-08da3503ccc0', N'00000000-0000-0000-0000-000000000000', N'Root', NULL, CAST(N'2022-06-10T01:25:08.7202595' AS DateTime2))
SET IDENTITY_INSERT [dbo].[DomainDirectories] OFF
GO
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'1567c157-8547-401b-1cae-08da370ab28f', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\files/5859.jpg', N'5859.jpg', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'0ffa6a76-c954-42a5-731a-08da375373e5', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\files/freh.png', N'freh.png', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'1f1c42d8-fb87-4ee5-0ab5-08da47bce961', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/Poster-Gian.pdf', N'Poster-Gian.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'69af413b-b00e-4a5d-e4cd-08da4d811c49', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/L490.pdf', N'L490.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'98266d18-5b87-48bd-1126-08da4d97fd25', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'b408382b-8a6d-4c08-1127-08da4d97fd25', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'e4d727a4-fc8a-417b-8edc-08da4d9863e3', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'7fb34c5d-15d0-4379-8edd-08da4d9863e3', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'fb478851-a88a-47a9-7b30-08da4d98d12c', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'2ff2d54a-7f7e-42dc-5034-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'549bcc18-fd30-4dd0-5035-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'4b933102-178d-4866-5036-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'5185a768-6a6d-47f0-5037-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'30dfd7fc-f5e1-4521-5038-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'4d25b8b7-3816-4efc-5039-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'f3671eac-a1c9-4393-503a-08da4d98f70a', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/crmt.sql', N'crmt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'ec9c0d3b-5968-4bfd-c964-08da4f923332', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/identityt.sql', N'identityt.sql', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\identityt.sql', NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'edc1cb40-470f-4c56-ce9a-08da50d64b06', N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets/Untitled.pdf', N'Untitled.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Untitled.pdf', NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'2f9930fd-a0fe-46e0-61f4-08da512bf0ba', N'http://localhost:8080/api/file/stream?filename=Session-Tracking.pdf', N'Session-Tracking.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Session-Tracking.pdf', NULL)
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'df31051b-e9ad-4c68-ec7e-08da51c28706', N'http://localhost:8080/api/file/stream?filename=Bai tap so 06b.doc', N'Bai tap so 06b.doc', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Bai tap so 06b.doc', N'doc')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'70faaebe-f24a-4e56-ec7f-08da51c28706', N'http://localhost:8080/api/file/stream?filename=Poster-Gian.pdf', N'Poster-Gian.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Poster-Gian.pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'765e4dd4-3844-4e02-187d-08da51c36d3c', N'http://localhost:8080/api/file/stream?filename=poster.png', N'poster.png', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\poster.png', N'png')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'cd0f2f1c-da38-4a07-346d-08da51c55c41', N'http://localhost:8080/Clust.pdf', N'Clust.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Clust.pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'b754fd87-2060-4da0-bb70-08da51c5b19f', N'http://localhost:8080/assets\Untitled.pdf', N'Untitled.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Untitled.pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'73feb31d-e032-4db3-bb71-08da51c5b19f', N'http://localhost:8080/assets\Meal.xlsx', N'Meal.xlsx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Meal.xlsx', N'xlsx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'2d534943-c877-4c06-75a2-08da51ca4567', N'http://localhost:8080/assets\note.docx', N'note.docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\note.docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'b9cbb0ff-00fa-4901-f444-08da51caca6d', N'http://localhost:8080/assets\Meal.xlsx', N'Meal.xlsx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Meal.xlsx', N'xlsx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'658f1f80-d982-44ad-6c73-08da51d9b8e8', N'http://localhost:8080/assets\Flow.docx', N'Flow.docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Flow.docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'504618bb-cf04-4353-6c74-08da51d9b8e8', N'http://localhost:8080/assets\Meal.xlsx', N'Meal.xlsx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Meal.xlsx', N'xlsx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'fe74aaba-1bff-43f8-ce38-08da51da7480', N'http://localhost:8080/assets\Meal.xlsx', N'Meal.xlsx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Meal.xlsx', N'xlsx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'818e95f2-fb57-4e6e-07d5-08da523de105', N'http://localhost:8080/assets\Database Management Systems Raghu 3Rd Edition (1).pdf', N'Database Management Systems Raghu 3Rd Edition (1).pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Database Management Systems Raghu 3Rd Edition (1).pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'7039fc27-cc70-47a8-07d6-08da523de105', N'http://localhost:8080/assets\Database Management Systems Raghu 3Rd Edition (1).pdf', N'Database Management Systems Raghu 3Rd Edition (1).pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Database Management Systems Raghu 3Rd Edition (1).pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'e929b4f2-4c85-41d3-07d7-08da523de105', N'http://localhost:8080/assets\02.DeCuongHeQTCSDL (1).doc', N'02.DeCuongHeQTCSDL (1).doc', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\02.DeCuongHeQTCSDL (1).doc', N'doc')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'e366143b-790b-42bd-07d8-08da523de105', N'http://localhost:8080/assets\02.DeCuongHeQTCSDL (1) (1).docx', N'02.DeCuongHeQTCSDL (1) (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\02.DeCuongHeQTCSDL (1) (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'b733ba7c-4d21-4d19-07d9-08da523de105', N'http://localhost:8080/assets\02.DeCuongHeQTCSDL (1).doc', N'02.DeCuongHeQTCSDL (1).doc', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\02.DeCuongHeQTCSDL (1).doc', N'doc')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'f0db35aa-a4c4-48f3-07da-08da523de105', N'http://localhost:8080/assets\CÁC QUI ĐỊNH VÀ CÁCH ĐÁNH GIÁ mon hoc (2).pptx', N'CÁC QUI ĐỊNH VÀ CÁCH ĐÁNH GIÁ mon hoc (2).pptx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\CÁC QUI ĐỊNH VÀ CÁCH ĐÁNH GIÁ mon hoc (2).pptx', N'pptx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'ea5baeda-7842-4846-07db-08da523de105', N'http://localhost:8080/assets\Nhom1_DoAn_PhanMemQuanLyKhachSan.pdf', N'Nhom1_DoAn_PhanMemQuanLyKhachSan.pdf', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Nhom1_DoAn_PhanMemQuanLyKhachSan.pdf', N'pdf')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'c73ea1a2-d2f8-4a04-07dc-08da523de105', N'http://localhost:8080/assets\Assigment_Chapter 01.docx', N'Assigment_Chapter 01.docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\Assigment_Chapter 01.docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'74589783-c53c-4519-07dd-08da523de105', N'http://localhost:8080/assets\SRS.docx', N'SRS.docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\NewCode\BE\src\Services\Resource\Resource.API\assets\SRS.docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'7ddd5b03-2fc7-4ea4-0e33-08da57441ea0', N'http://localhost:8080/assets\280591128_153239853864423_1389192014539436453_n.mp4', N'280591128_153239853864423_1389192014539436453_n.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\280591128_153239853864423_1389192014539436453_n.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'55bdec3e-e92f-4d8a-0e34-08da57441ea0', N'http://localhost:8080/assets\280591128_153239853864423_1389192014539436453_n.mp4', N'280591128_153239853864423_1389192014539436453_n.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\280591128_153239853864423_1389192014539436453_n.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'6dfae546-93bc-48fe-0e35-08da57441ea0', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'852c4dba-edc7-4f6e-801b-08da574656d7', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'739d6b97-38d5-4d55-588d-08da59cdc3f6', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'Assignment chapter 2 (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Assignment chapter 2 (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'67e1e50e-5b09-4fc2-588e-08da59cdc3f6', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'Assignment chapter 2 (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Assignment chapter 2 (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'65c61c33-712b-40d8-588f-08da59cdc3f6', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'Assignment chapter 2 (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Assignment chapter 2 (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'8308ede4-cd95-4344-5890-08da59cdc3f6', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'Assignment chapter 2 (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Assignment chapter 2 (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'f9169a37-7388-4a9a-5891-08da59cdc3f6', N'http://localhost:8080/assets\Assignment chapter 2 (1).docx', N'Assignment chapter 2 (1).docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Assignment chapter 2 (1).docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'88b2b207-50ab-4b21-5892-08da59cdc3f6', N'http://localhost:8080/assets\Ch02_Constraints_Triggers_View (2).ppt', N'Ch02_Constraints_Triggers_View (2).ppt', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Ch02_Constraints_Triggers_View (2).ppt', N'ppt')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'816498fe-50bf-4065-3a04-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'aba4d894-99fc-4a21-3a05-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'aec1bc00-a34e-4088-3a06-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'c2b3df54-d0a2-40d4-3a07-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'c4f2e84e-27cb-4855-3a08-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'dae5d065-89e1-411f-3a09-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'11b2cc50-01c1-4b3d-3a0a-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'672435bc-09be-4611-3a0b-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'9c3131fa-81ad-4fdf-3a0c-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'188b2f02-f3dc-4548-3a0d-08da59d29f38', N'http://localhost:8080/assets\Chapter03- Database_Programming.ppt', N'Chapter03- Database_Programming.ppt', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\Chapter03- Database_Programming.ppt', N'ppt')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'394db12c-1d8d-4e30-3a0e-08da59d29f38', N'http://localhost:8080/assets\BT Trigger Thu tuc va ham.docx', N'BT Trigger Thu tuc va ham.docx', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\BT Trigger Thu tuc va ham.docx', N'docx')
INSERT [dbo].[Files] ([Id], [FilePath], [FileName], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [DirectoryId], [AbsolutePath], [FileType]) VALUES (N'6a393f3d-4709-492e-3a0f-08da59d29f38', N'http://localhost:8080/assets\DBMS.mp4', N'DBMS.mp4', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'D:\Desktop\LMS\BE\src\Services\Resource\Resource.API\assets\DBMS.mp4', N'mp4')
GO
/****** Object:  Index [IX_DomainDirectories_ParentDirectoryId]    Script Date: 6/29/2022 9:19:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_DomainDirectories_ParentDirectoryId] ON [dbo].[DomainDirectories]
(
	[ParentDirectoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Files_DirectoryId]    Script Date: 6/29/2022 9:19:17 PM ******/
CREATE NONCLUSTERED INDEX [IX_Files_DirectoryId] ON [dbo].[Files]
(
	[DirectoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DomainDirectories] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreatedDate]
GO
ALTER TABLE [dbo].[DomainDirectories]  WITH CHECK ADD  CONSTRAINT [FK_DomainDirectories_DomainDirectories_ParentDirectoryId] FOREIGN KEY([ParentDirectoryId])
REFERENCES [dbo].[DomainDirectories] ([Id])
GO
ALTER TABLE [dbo].[DomainDirectories] CHECK CONSTRAINT [FK_DomainDirectories_DomainDirectories_ParentDirectoryId]
GO
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_DomainDirectories_DirectoryId] FOREIGN KEY([DirectoryId])
REFERENCES [dbo].[DomainDirectories] ([Id])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_DomainDirectories_DirectoryId]
GO
USE [master]
GO
ALTER DATABASE [ResourceDb] SET  READ_WRITE 
GO
