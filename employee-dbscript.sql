USE [master]
GO
/****** Object:  Database [EmployeeManagement]    Script Date: 5/3/2022 4:07:18 PM ******/
CREATE DATABASE [EmployeeManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmployeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmployeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EmployeeManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmployeeManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmployeeManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmployeeManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmployeeManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmployeeManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmployeeManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmployeeManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmployeeManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmployeeManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmployeeManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmployeeManagement] SET  MULTI_USER 
GO
ALTER DATABASE [EmployeeManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmployeeManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmployeeManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmployeeManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmployeeManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmployeeManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmployeeManagement] SET QUERY_STORE = OFF
GO
USE [EmployeeManagement]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 5/3/2022 4:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/3/2022 4:07:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[Salary] [decimal](18, 2) NULL,
	[PhotoUrl] [nvarchar](max) NULL,
	[Biodata] [nvarchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [Name], [Description], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (2, N'Sales', N'This is a sales department', NULL, NULL, CAST(N'2022-05-03T15:46:11.433' AS DateTime), NULL)
INSERT [dbo].[Department] ([DepartmentId], [Name], [Description], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (5, N'Development', N'Web development department', NULL, NULL, CAST(N'2022-05-03T15:33:04.250' AS DateTime), NULL)
INSERT [dbo].[Department] ([DepartmentId], [Name], [Description], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (6, N'Audit', N'Audit department', NULL, NULL, CAST(N'2022-05-03T15:36:36.583' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [DepartmentId], [Firstname], [Lastname], [Email], [Phone], [Salary], [PhotoUrl], [Biodata], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (2, 2, N'Jay', N'Deep', N'jay@gmail.com', N'5643210789', CAST(101.20 AS Decimal(18, 2)), N'/images/dummy220715370.png', N'Hi, I''m jaydeep, I have 5years of experience in finance department', NULL, NULL, CAST(N'2022-05-03T15:07:20.143' AS DateTime), NULL)
INSERT [dbo].[Employee] ([EmployeeId], [DepartmentId], [Firstname], [Lastname], [Email], [Phone], [Salary], [PhotoUrl], [Biodata], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (9, 6, N'John', N'Darkey', N'John@gmail.com', N'9874646544', CAST(10000.00 AS Decimal(18, 2)), N'/images/fake-profile223737747.png', N'John''s bio', NULL, NULL, CAST(N'2022-05-03T15:37:37.780' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
USE [master]
GO
ALTER DATABASE [EmployeeManagement] SET  READ_WRITE 
GO
