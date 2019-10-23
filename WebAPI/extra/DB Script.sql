USE [master]
GO
/****** Object:  Database [RachitTest]    Script Date: 24-10-2019 01:47:28 ******/
CREATE DATABASE [RachitTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RachitTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RachitTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RachitTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\RachitTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [RachitTest] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RachitTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RachitTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RachitTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RachitTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RachitTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RachitTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [RachitTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RachitTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RachitTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RachitTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RachitTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RachitTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RachitTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RachitTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RachitTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RachitTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RachitTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RachitTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RachitTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RachitTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RachitTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RachitTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RachitTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RachitTest] SET RECOVERY FULL 
GO
ALTER DATABASE [RachitTest] SET  MULTI_USER 
GO
ALTER DATABASE [RachitTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RachitTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RachitTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RachitTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RachitTest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'RachitTest', N'ON'
GO
ALTER DATABASE [RachitTest] SET QUERY_STORE = OFF
GO
USE [RachitTest]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 24-10-2019 01:47:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](25) NOT NULL,
	[LastName] [varchar](25) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 24-10-2019 01:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DEPARTMENT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DEPARTMENT_NAME] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 24-10-2019 01:47:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EMPLOYEE_ID] [int] NULL,
	[NAME] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD FOREIGN KEY([EMPLOYEE_ID])
REFERENCES [dbo].[DEPARTMENT] ([ID])
GO
USE [master]
GO
ALTER DATABASE [RachitTest] SET  READ_WRITE 
GO
