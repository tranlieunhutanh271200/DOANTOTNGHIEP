USE [master]
GO
/****** Object:  Database [IdentityDb]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE DATABASE [IdentityDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IdentityDb', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\IdentityDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IdentityDb_log', FILENAME = N'D:\Programs Files\SQL Server 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\IdentityDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IdentityDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IdentityDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IdentityDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IdentityDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IdentityDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IdentityDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IdentityDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [IdentityDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IdentityDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IdentityDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IdentityDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IdentityDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IdentityDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IdentityDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IdentityDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IdentityDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IdentityDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IdentityDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IdentityDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IdentityDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IdentityDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IdentityDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IdentityDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [IdentityDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IdentityDb] SET RECOVERY FULL 
GO
ALTER DATABASE [IdentityDb] SET  MULTI_USER 
GO
ALTER DATABASE [IdentityDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IdentityDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IdentityDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IdentityDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IdentityDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IdentityDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [IdentityDb] SET QUERY_STORE = OFF
GO
USE [IdentityDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/29/2022 9:18:44 PM ******/
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
/****** Object:  Table [dbo].[Accounts]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PhotoImage] [nvarchar](max) NULL,
	[BackgroundImage] [nvarchar](max) NULL,
	[HashPassword] [nvarchar](max) NULL,
	[Salt] [nvarchar](max) NULL,
	[IsDisabled] [bit] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[ManageDomainId] [uniqueidentifier] NULL,
	[LastLockUntil] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[RefreshToken] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Components]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Components](
	[Id] [uniqueidentifier] NOT NULL,
	[ComponentName] [nvarchar](max) NULL,
	[ComponentEndpoint] [nvarchar](max) NULL,
	[ComponentLogo] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomainComponents]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainComponents](
	[DomainId] [uniqueidentifier] NOT NULL,
	[ComponentId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DomainComponents] PRIMARY KEY CLUSTERED 
(
	[DomainId] ASC,
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomainProcess]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainProcess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DomainId] [uniqueidentifier] NOT NULL,
	[ToEmail] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[SenderId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_DomainProcess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domains]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domains](
	[Id] [uniqueidentifier] NOT NULL,
	[Abbreviation] [nvarchar](max) NULL,
	[SchoolName] [nvarchar](max) NULL,
	[SchoolEmail] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[SchoolUrl] [nvarchar](max) NULL,
	[SchoolLogoId] [uniqueidentifier] NOT NULL,
	[SchoolLogoPath] [nvarchar](max) NULL,
	[DomainComponents] [nvarchar](max) NULL,
	[DomainStatus] [nvarchar](max) NOT NULL,
	[DomainAdminId] [uniqueidentifier] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[SchoolAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Domains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderAuths]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderAuths](
	[Id] [uniqueidentifier] NOT NULL,
	[Provider] [nvarchar](max) NULL,
	[Key] [nvarchar](max) NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProviderAuths] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/29/2022 9:18:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220513052746_init', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220513150632_updatedomain', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220525150926_addrefreshtoken', N'5.0.14')
GO
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'eafa1d90-7a6f-4f27-6b70-08da3503ce41', N'admin', N'admin@admin.com', NULL, NULL, N'nWwiiB3Uu17TCD9YV0Ne+Opi/ovX9zYrjoTAJj8nzI8=', N'mqseatRTVZLXNpQ8NZpWVg==', 0, 0, N'859b420e-5832-4252-8bc2-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-14T00:12:48.8650291' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'b5c92ac0-d0d2-456d-6b71-08da3503ce41', N'test', N'test@test.com', N'https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D', NULL, N'LqNEXw6NdeaJiezUuaJnOs2gb5Nw8ThCKovYlSzPObU=', N'y/FI6CEXZ8l1Zsus1zly7A==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-14T00:12:49.0551040' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'b36c2a83-aabd-40c3-6b72-08da3503ce41', N'nhutanh', N'test1@test.com', N'https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D', NULL, N'LqNEXw6NdeaJiezUuaJnOs2gb5Nw8ThCKovYlSzPObU=', N'y/FI6CEXZ8l1Zsus1zly7A==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-14T00:12:49.0551011' AS DateTime2), NULL, CAST(N'2022-06-26T22:08:02.3989765' AS DateTime2), N'UsjTYhqQXSs66AK+0qBRJKks6LRWtVlUzZN0QsgHrpo=')
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'e234b73c-d762-403e-6b73-08da3503ce41', N'minhchau', N'minhchau@hcmute.com', N'https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D', NULL, N'fxm1T7r+fPhq4y05EovX28tob+g/FHEvxT3RmVyJSHE=', N'ELn0df3kXBE3X+rx/4X3Mw==', 0, 0, N'3845f612-9037-4cce-8bc0-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-14T00:12:49.2000404' AS DateTime2), NULL, CAST(N'2022-06-29T20:17:05.9412333' AS DateTime2), N'Egr2FeObFJdHK2jcFk6gF7GhWCJ8ik2ctFFkLVzbqr4=')
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'7196aff7-06c1-4a2d-a13b-08da3702e04e', N'18110001', N'18110001@test.edu.vn', NULL, NULL, N'+NYiDEyVuBmvE+m8IeOUi6Fp4HWe9lgZGPH/KkEocZU=', N'TzmeHFp3CyKQ4tHy7YDGSg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3143174' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'7b4fbed5-5e77-48f1-a13c-08da3702e04e', N'18110002', N'18110002@test.edu.vn', NULL, NULL, N'8suPB334IKtBTKR9fU2HhbnW9vObiGL4j7M/5koAtf4=', N'x/eXOKlg3vSC7eY89j89Jg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3146973' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'7ff1ec3d-c08d-471b-a13d-08da3702e04e', N'18110003', N'18110003@test.edu.vn', NULL, NULL, N'TKsVHUcLeCH9TIkoU5YjrB6WkSW7HXRJNRj2d8cFnmw=', N'FUIA+eP92Xv9hZuTxTUc0A==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147004' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'428da28f-6c85-491f-a13e-08da3702e04e', N'18110004', N'18110004@test.edu.vn', NULL, NULL, N'2IftqBcoZiOfyVXIZZ3yCpxDTjeNgJGwvmkhYeU2iO0=', N'2r13ZtV0rYY2C2LLCEBErw==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147026' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'f469ea1a-bce0-4717-a13f-08da3702e04e', N'18110005', N'18110005@test.edu.vn', NULL, NULL, N'w1g1NjxAmJXdJHRqBMe4pYxWWkZNNjPNS70H0G+iglw=', N'PhUrhwmlxmsRSHmhuZEuJg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147032' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'fc174219-9ed1-4fdb-a140-08da3702e04e', N'18110006', N'18110006@test.edu.vn', NULL, NULL, N'HQ5lZxDb7ooZbzQq0eA8oO0TnNUyTJ8FaTMGczjwNTo=', N'BrMlQEixA+ifLREWiWAxbg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147036' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'705cccd5-1794-402e-a141-08da3702e04e', N'18110007', N'18110007@test.edu.vn', NULL, NULL, N'zwXYJUv7+CWuSsECzvMD+bIQDVU8prpaTge7fX2xqAg=', N'9rXiMZ6QrrNe0nucFXGkTA==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147042' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'f7197545-4d20-4274-a142-08da3702e04e', N'18110008', N'18110008@test.edu.vn', NULL, NULL, N'uJtYXsHkYwR+v+2sIU4DV17NIo+m7MRbg6CJ0GDWKAw=', N'HxedNplZ1gLvcw1YPZ5AMA==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147046' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'6fca5a99-d1a9-44cf-a143-08da3702e04e', N'18110009', N'18110009@test.edu.vn', NULL, NULL, N'aBttDq+cfbr/4YhSlzoAo+RgKudwZCLnTCNIkiC3Etk=', N'wX9mYm9SSk5W5YhT1i86iw==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147051' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'6d1eb1c8-f58b-49f3-a144-08da3702e04e', N'18110010', N'18110010@test.edu.vn', NULL, NULL, N'ZHVzwJCcZOF4xlP/hWZofjxHbXtQMLQN4prsAHw1JVg=', N'f/I/ouyrdvCtkPAVJxkYUA==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147055' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'0762c2a7-36b4-485b-a145-08da3702e04e', N'18110011', N'18110011@test.edu.vn', NULL, NULL, N'UPCb14VjicSLpAy71f85oWWyNZgAE5iP6lHDMd6YLxE=', N'eEKyEnGAhsCTAhTBS928Ww==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147061' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'4a86feaf-6a97-42b1-a146-08da3702e04e', N'18110012', N'18110012@test.edu.vn', NULL, NULL, N'YfWkKyvg3KaAO4YQ65XwIvlv/Y3h04LeWKyrrsMSZFE=', N'0wLU+QQ8QgrESs1FtPKxkg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-16T13:11:13.3147065' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'3fbca44f-9e7d-4baa-9452-08da3c01d4a5', N'huythe', N'huythe@gmail.com', NULL, NULL, N'tQSuiSXmxEdHA7NZUzyKhOwQSMoEQ5z6IQPDm+PdGAk=', N'To631L92TzxPtP05PePQ1w==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-05-22T21:46:18.7100905' AS DateTime2), NULL, CAST(N'2022-06-18T21:14:21.5421911' AS DateTime2), N'Trrrv87TLqzalrRUp1Xph0XcWfxM4JKgGG8AzUNQ7Zw=')
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'178e660f-2d6b-4bc1-7171-08da4b8efe14', N'hcmute-admin', N'admin@hcmute.edu.vn', N'https://scontent.fsgn5-7.fna.fbcdn.net/v/t1.6435-9/120960769_2682880555286997_5800137656267775041_n.jpg?_nc_cat=101&ccb=1-5&_nc_sid=8bfeb9&_nc_ohc=-vzvsulFD5cAX-xt_oz&_nc_ht=scontent.fsgn5-7.fna&oh=00_AT86ytrPEsH7oRM6rfAzzAX3VbtB23nxxeDnZb23mMFHGg&oe=627AD09D', NULL, N'hF01A94nyVxWsYYoiR5YsOvWXTo+3EJcUsA8+oKmCPg=', N'jnBzT6S6F0yYadLP4cgm2w==', 0, 0, N'e9b3b533-36e8-43f1-8bbe-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-11T16:44:34.7699865' AS DateTime2), NULL, CAST(N'2022-06-29T20:49:31.0070605' AS DateTime2), N'lU6xFmZD2fR/QV1Uj/Nh5YblKENcoYRWKRu0l6N+C7I=')
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'b0dc8c28-f289-4893-a474-1f30724f1b61', N'minh444444', N'minh444444@hcmute.edu.vn', NULL, NULL, N'p6PRRrH4GKkyUGONuHT2HhUsctsBCEBrlQ5/Htwfulk=', N'8sz5Zf5NWbUXJ1je4XnO4Q==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-29T21:11:57.3334280' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'6fac68f5-8582-45e8-8d09-4857be01c46d', N'nghial000007', N'nghial000007@admin@hcmute.edu.vn', NULL, NULL, N'pADTB9Ip4Yxsy7jzlw2JsYHG0nc3+TQ9yNsZ7eAgxEM=', N'WsCVyzJc0t17lHK7YEBfLA==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-15T01:03:06.3404501' AS DateTime2), NULL, CAST(N'2022-06-20T07:53:11.3664601' AS DateTime2), N'ckqNwkEkDpHpVfuv3dudcCkv3RrQPj4C4OFMVyzJEPA=')
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'225375f8-bc3b-4336-80d6-8036b8ec0b2d', N'anh444442', N'anh444442@hcmute.edu.vn', NULL, NULL, N'rAB0dpvFFPij5o/C94HM88sxO7EV1ZbYFyOHqwPgGuQ=', N'gBniCm8o7RalmY+ipoLjkg==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-29T21:07:01.8605855' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'd1487c56-73da-4e35-a3f4-93edbec37774', N'minh000008', N'minh000008@hcmute.edu.vn', NULL, NULL, N'UHp2sfA4U+uWvIK5LUucpy+CpbJW2e6uusChIH1l8wg=', N'h9+ki+dbmasXhK5f4a0w5g==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-20T07:55:23.1253523' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Accounts] ([Id], [Username], [Email], [PhotoImage], [BackgroundImage], [HashPassword], [Salt], [IsDisabled], [IsLocked], [RoleId], [DomainId], [ManageDomainId], [LastLockUntil], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RefreshToken]) VALUES (N'bfed3591-3053-41a4-913d-d7ae49aff9a2', N'tu444443', N'tu444443@hcmute.edu.vn', NULL, NULL, N'VyQpBbHXfw9C+W8jN5G/DVU+EB8dGnjsRl8PPB4HsAA=', N'LLqUMNPjuEODYReElXGI6A==', 0, 0, N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'System', CAST(N'2022-06-29T21:09:48.2923527' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
GO
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'39d9e1c1-97a9-4176-e960-08da3503cc9d', N'Quản lý nguồn lực', N'/manage-hr', N'people-outline', 0, N'System', CAST(N'2022-05-14T00:12:47.9831648' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'af8bf9d8-ec27-4682-e961-08da3503cc9d', N'Quản lý phiếu', N'/manage-ticket', N'ticket-outline', 0, N'System', CAST(N'2022-05-14T00:12:47.9866284' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'f6d14052-e2df-4a8f-e962-08da3503cc9d', N'Quản lý công việc', N'/manage-task', N'clipboard-outline', 0, N'System', CAST(N'2022-05-14T00:12:47.9866361' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'51b21c9f-a87a-416e-e963-08da3503cc9d', N'Quản lý học TT', N'/manage-online', N'rocket-outline', 0, N'System', CAST(N'2022-05-14T00:12:47.9866371' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'3f041019-2877-4d6e-fbc7-08da4b8efcb7', N'Quản lý nguồn lực', N'/manage-hr', N'people-outline', 0, N'System', CAST(N'2022-06-11T16:44:34.7686782' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'42f1e204-cf1d-46d7-fbc8-08da4b8efcb7', N'Quản lý phiếu', N'/manage-ticket', N'ticket-outline', 0, N'System', CAST(N'2022-06-11T16:44:34.7699782' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'be8a7684-ce5f-4f48-fbc9-08da4b8efcb7', N'Quản lý công việc', N'/manage-task', N'clipboard-outline', 0, N'System', CAST(N'2022-06-11T16:44:34.7699839' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Components] ([Id], [ComponentName], [ComponentEndpoint], [ComponentLogo], [Price], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (N'f287be35-02ab-41d4-fbca-08da4b8efcb7', N'Quản lý học TT', N'/manage-online', N'rocket-outline', 0, N'System', CAST(N'2022-06-11T16:44:34.7699847' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[DomainComponents] ([DomainId], [ComponentId]) VALUES (N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'39d9e1c1-97a9-4176-e960-08da3503cc9d')
INSERT [dbo].[DomainComponents] ([DomainId], [ComponentId]) VALUES (N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'af8bf9d8-ec27-4682-e961-08da3503cc9d')
INSERT [dbo].[DomainComponents] ([DomainId], [ComponentId]) VALUES (N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'f6d14052-e2df-4a8f-e962-08da3503cc9d')
INSERT [dbo].[DomainComponents] ([DomainId], [ComponentId]) VALUES (N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'51b21c9f-a87a-416e-e963-08da3503cc9d')
GO
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'32dd8d3b-fc61-4050-9e14-08da3503ccc0', N'hcmut', N'Trường đại học sư phạm TP.HCM', N'@hcmut.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, N'System.Collections.Generic.List`1[DomainComponentDTO]', N'APPROVED', NULL, N'System', CAST(N'2022-05-14T00:12:47.9866384' AS DateTime2), NULL, CAST(N'2022-06-10T01:25:08.1106805' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'7d83f62b-0170-43de-9e15-08da3503ccc0', N'hutech', N'Trường đại học Hutech TP.HCM', N'@hutech.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'NEW', NULL, N'System', CAST(N'2022-05-14T00:12:47.9866394' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'63c8b6fd-bb8e-4558-9e16-08da3503ccc0', N'ut-hcmc', N'Trường đại học giao thông vận tải TP.HCM', N'@uth-hcmc.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'DECLINED', NULL, N'System', CAST(N'2022-05-14T00:12:47.9866402' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'46e9c6d1-e0dc-482e-9e17-08da3503ccc0', N'admin', NULL, N'@test.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'APPROVED', NULL, N'System', CAST(N'2022-05-14T00:12:48.3764776' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'b70d4057-ee17-4ff8-9e18-08da3503ccc0', N'hcmute', N'Trường đại học sư phạm kĩ thuật TP.HCM', N'@hcmute.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'APPROVED', NULL, N'System', CAST(N'2022-05-14T00:12:48.4319619' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'8d997f20-e465-4784-a113-08da4b8efcd0', N'hcmut', N'Trường đại học sư phạm TP.HCM', N'@hcmut.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'REVIEW', NULL, N'System', CAST(N'2022-06-11T16:44:34.7699852' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'ddba1f30-6d3b-461b-a114-08da4b8efcd0', N'hutech', N'Trường đại học Hutech TP.HCM', N'@hutech.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'NEW', NULL, N'System', CAST(N'2022-06-11T16:44:34.7699856' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
INSERT [dbo].[Domains] ([Id], [Abbreviation], [SchoolName], [SchoolEmail], [IsActive], [SchoolUrl], [SchoolLogoId], [SchoolLogoPath], [DomainComponents], [DomainStatus], [DomainAdminId], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [SchoolAddress]) VALUES (N'5cb4231d-76e2-4947-a115-08da4b8efcd0', N'ut-hcmc', N'Trường đại học giao thông vận tải TP.HCM', N'@uth-hcmc.edu.vn', 1, NULL, N'00000000-0000-0000-0000-000000000000', NULL, NULL, N'DECLINED', NULL, N'System', CAST(N'2022-06-11T16:44:34.7699862' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'So 1 vo van ngan')
GO
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'7fd460fb-665c-456c-8bbd-08da3503cdb7', N'school_student')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'e9b3b533-36e8-43f1-8bbe-08da3503cdb7', N'school_admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'679dac48-0315-4fb6-8bbf-08da3503cdb7', N'school_head')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'3845f612-9037-4cce-8bc0-08da3503cdb7', N'school_teacher')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'57ea1ad3-444d-4f4b-8bc1-08da3503cdb7', N'school_parent')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'859b420e-5832-4252-8bc2-08da3503cdb7', N'domain_admin')
INSERT [dbo].[Roles] ([Id], [RoleName]) VALUES (N'a7f63317-6a6a-46ca-8bc3-08da3503cdb7', N'domain_supervisor')
GO
/****** Object:  Index [IX_Accounts_DomainId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_DomainId] ON [dbo].[Accounts]
(
	[DomainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Accounts_RoleId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Accounts_RoleId] ON [dbo].[Accounts]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DomainComponents_ComponentId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_DomainComponents_ComponentId] ON [dbo].[DomainComponents]
(
	[ComponentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DomainProcess_DomainId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_DomainProcess_DomainId] ON [dbo].[DomainProcess]
(
	[DomainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_DomainProcess_SenderId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_DomainProcess_SenderId] ON [dbo].[DomainProcess]
(
	[SenderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Domains_DomainAdminId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Domains_DomainAdminId] ON [dbo].[Domains]
(
	[DomainAdminId] ASC
)
WHERE ([DomainAdminId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProviderAuths_AccountId]    Script Date: 6/29/2022 9:18:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProviderAuths_AccountId] ON [dbo].[ProviderAuths]
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Domains_DomainId] FOREIGN KEY([DomainId])
REFERENCES [dbo].[Domains] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Domains_DomainId]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Roles_RoleId]
GO
ALTER TABLE [dbo].[DomainComponents]  WITH CHECK ADD  CONSTRAINT [FK_DomainComponents_Components_ComponentId] FOREIGN KEY([ComponentId])
REFERENCES [dbo].[Components] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomainComponents] CHECK CONSTRAINT [FK_DomainComponents_Components_ComponentId]
GO
ALTER TABLE [dbo].[DomainComponents]  WITH CHECK ADD  CONSTRAINT [FK_DomainComponents_Domains_DomainId] FOREIGN KEY([DomainId])
REFERENCES [dbo].[Domains] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DomainComponents] CHECK CONSTRAINT [FK_DomainComponents_Domains_DomainId]
GO
ALTER TABLE [dbo].[DomainProcess]  WITH CHECK ADD  CONSTRAINT [FK_DomainProcess_Accounts_SenderId] FOREIGN KEY([SenderId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[DomainProcess] CHECK CONSTRAINT [FK_DomainProcess_Accounts_SenderId]
GO
ALTER TABLE [dbo].[DomainProcess]  WITH CHECK ADD  CONSTRAINT [FK_DomainProcess_Domains_DomainId] FOREIGN KEY([DomainId])
REFERENCES [dbo].[Domains] ([Id])
GO
ALTER TABLE [dbo].[DomainProcess] CHECK CONSTRAINT [FK_DomainProcess_Domains_DomainId]
GO
ALTER TABLE [dbo].[Domains]  WITH CHECK ADD  CONSTRAINT [FK_Domains_Accounts_DomainAdminId] FOREIGN KEY([DomainAdminId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[Domains] CHECK CONSTRAINT [FK_Domains_Accounts_DomainAdminId]
GO
ALTER TABLE [dbo].[ProviderAuths]  WITH CHECK ADD  CONSTRAINT [FK_ProviderAuths_Accounts_AccountId] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Accounts] ([Id])
GO
ALTER TABLE [dbo].[ProviderAuths] CHECK CONSTRAINT [FK_ProviderAuths_Accounts_AccountId]
GO
USE [master]
GO
ALTER DATABASE [IdentityDb] SET  READ_WRITE 
GO
