USE [master]
GO

/*Criando DataBase */
CREATE DATABASE [AtivSem03]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AtivSem03', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AtivSem03.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AtivSem03_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AtivSem03_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AtivSem03].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [AtivSem03] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [AtivSem03] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [AtivSem03] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [AtivSem03] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [AtivSem03] SET ARITHABORT OFF 
GO

ALTER DATABASE [AtivSem03] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [AtivSem03] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [AtivSem03] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [AtivSem03] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [AtivSem03] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [AtivSem03] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [AtivSem03] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [AtivSem03] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [AtivSem03] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [AtivSem03] SET  DISABLE_BROKER 
GO

ALTER DATABASE [AtivSem03] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [AtivSem03] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [AtivSem03] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [AtivSem03] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [AtivSem03] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [AtivSem03] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [AtivSem03] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [AtivSem03] SET RECOVERY FULL 
GO

ALTER DATABASE [AtivSem03] SET  MULTI_USER 
GO

ALTER DATABASE [AtivSem03] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [AtivSem03] SET DB_CHAINING OFF 
GO

ALTER DATABASE [AtivSem03] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [AtivSem03] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [AtivSem03] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [AtivSem03] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [AtivSem03] SET QUERY_STORE = OFF
GO

ALTER DATABASE [AtivSem03] SET  READ_WRITE 
GO


USE [AtivSem03]
GO

/*Criando tabela Clientes*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](max) NOT NULL,
	[Telefone] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [AtivSem03]
GO
/*Criando tabela Procedimentos*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Procedimento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeProcedimento] [varchar](max) NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Procedimento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


USE [AtivSem03]
GO

/*Criando tabela Agendas*/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agendas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdProcedimento] [int] NOT NULL,
	[Realizado] [bit] NOT NULL,
	[DataAgendamento] [datetime] NULL,
 CONSTRAINT [PK_Agendas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/*inserindo dados na tabela Cliente*/
USE [AtivSem03]
GO

INSERT INTO [dbo].[Cliente]
           ([Nome]
           ,[Telefone])
     VALUES
           ('Janaina'
           ,11111111111),
		   ('Mhoary'
           ,22222222222),
		   ('Fernanda'
           ,33333333333),
		   ('Gabriela'
           ,44444444444),
		   ('Maria'
           ,55555555555),
		   ('Ana Clara'
           ,99999999999)
GO

/*Inserindo dados na tabela Procedimentos */

USE [AtivSem03]
GO

INSERT INTO [dbo].[Procedimento]
           ([NomeProcedimento]
           ,[Valor])
     VALUES
           ('Limpeza de Pele'
           , 100),
		   ('Manicure basica'
           , 30),
		   ('Manicure + unha gel'
           , 90),
		   ('Pedicure Basico'
           , 30),
		   ('Pedicure + unha de Gel'
           , 90),
		   ('Manicure + pedicure completo'
           , 160)
GO