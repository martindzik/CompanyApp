USE [master]
GO
/****** Object:  Database [CompanyDb]    Script Date: 27/06/2019 10:15:55 ******/
CREATE DATABASE [CompanyDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompanyDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CompanyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompanyDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\CompanyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CompanyDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompanyDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompanyDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CompanyDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CompanyDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompanyDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompanyDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompanyDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CompanyDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CompanyDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompanyDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CompanyDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompanyDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompanyDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompanyDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompanyDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompanyDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompanyDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompanyDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompanyDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompanyDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CompanyDb] SET  MULTI_USER 
GO
ALTER DATABASE [CompanyDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompanyDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompanyDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompanyDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompanyDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompanyDb] SET QUERY_STORE = OFF
GO
USE [CompanyDb]
GO
/****** Object:  Table [dbo].[companies]    Script Date: 27/06/2019 10:15:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[DirectorId] [int] NULL,
 CONSTRAINT [PK_companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departments]    Script Date: 27/06/2019 10:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[LeaderId] [int] NULL,
 CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[divisions]    Script Date: 27/06/2019 10:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[divisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ManagerId] [int] NULL,
 CONSTRAINT [PK_divisions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 27/06/2019 10:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](10) NULL,
	[Name] [nchar](20) NOT NULL,
	[Surname] [nchar](20) NOT NULL,
	[PhoneNumber] [nchar](20) NOT NULL,
	[Email] [nchar](30) NOT NULL,
	[Position] [nchar](30) NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[leaders]    Script Date: 27/06/2019 10:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[leaders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](15) NULL,
	[Name] [nchar](20) NOT NULL,
	[Surname] [nchar](20) NOT NULL,
 CONSTRAINT [PK_leaders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[projects]    Script Date: 27/06/2019 10:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](30) NOT NULL,
	[DivisionId] [int] NOT NULL,
	[LeaderId] [int] NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[companies] ON 

INSERT [dbo].[companies] ([Id], [Name], [DirectorId]) VALUES (1, N'Company 1                     ', 1)
SET IDENTITY_INSERT [dbo].[companies] OFF
SET IDENTITY_INSERT [dbo].[departments] ON 

INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (1, N'Department 1                  ', 1, 13)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (2, N'Department 2                  ', 2, 14)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (3, N'Department 3                  ', 3, 15)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (4, N'Department 4                  ', 4, 16)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (5, N'Department 5                  ', 5, 17)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (6, N'Department 6                  ', 6, 18)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (7, N'Department 7                  ', 7, 19)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (8, N'Department 8                  ', 1, 20)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (9, N'Department 9                  ', 5, 21)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (10, N'Department 10                 ', 1, 22)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (11, N'Department 11                 ', 2, 23)
INSERT [dbo].[departments] ([Id], [Name], [ProjectId], [LeaderId]) VALUES (12, N'Department 12                 ', 1, 24)
SET IDENTITY_INSERT [dbo].[departments] OFF
SET IDENTITY_INSERT [dbo].[divisions] ON 

INSERT [dbo].[divisions] ([Id], [Name], [CompanyId], [ManagerId]) VALUES (1, N'Division 1                    ', 1, 2)
INSERT [dbo].[divisions] ([Id], [Name], [CompanyId], [ManagerId]) VALUES (2, N'Division 2                    ', 1, 3)
INSERT [dbo].[divisions] ([Id], [Name], [CompanyId], [ManagerId]) VALUES (3, N'Division 3                    ', 1, 4)
INSERT [dbo].[divisions] ([Id], [Name], [CompanyId], [ManagerId]) VALUES (4, N'Division 4                    ', 1, 5)
SET IDENTITY_INSERT [dbo].[divisions] OFF
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (1, N'Bc.       ', N'Adam                ', N'Líška               ', N'+421944111222       ', N'liska@example.com             ', N'C# developer                  ', 1)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (2, N'Ing.      ', N'Boris               ', N'Kocúr               ', N'+421908123456       ', N'kocur@example.com             ', N'.NET developer                ', 1)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (3, N'Ing.      ', N'Ján                 ', N'Malý                ', N'+421907999888       ', N'maly@example.com              ', N'Javascript developer          ', 1)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (4, N'Ing.      ', N'Adriana             ', N'Straková            ', N'+421908444555       ', N'strakova@example.com          ', N'C# developer                  ', 1)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (5, N'Ing.      ', N'Jozef               ', N'Rýchly              ', N'+421908777666       ', N'rychly@example.com            ', N'Fullstack developer           ', 8)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (6, N'Bc.       ', N'Milan               ', N'Škoda               ', N'+421944111777       ', N'skoda@example.com             ', N'Typescript developer          ', 8)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (7, N'Ing.      ', N'Valéria             ', N'Vysoká              ', N'+421908222333       ', N'vysoka@example.com            ', N'Angular developer             ', 8)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (8, N'Bc.       ', N'Lukáš               ', N'Študent             ', N'+421907789789       ', N'student@example.com           ', N'C# developer                  ', 2)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (9, N'Ing.      ', N'Peter               ', N'Veľký               ', N'+421908202303       ', N'velky@example.com             ', N'C# developer                  ', 2)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (10, N'Ing.      ', N'Michal              ', N'Sirota              ', N'+421944159159       ', N'sirota@example.com            ', N'.NET developer                ', 2)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (11, N'Ing.      ', N'Vanda               ', N'Ondrašinová         ', N'+421944145236       ', N'ondrasinova@example.com       ', N'Java developer                ', 9)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (12, N'Bc.       ', N'Jana                ', N'Fabová              ', N'+421907753753       ', N'fabova@example.com            ', N'Java developer                ', 9)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (13, N'Bc.       ', N'Marián              ', N'Matlák              ', N'+421907464131       ', N'matlak@example.com            ', N'React developer               ', 9)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (14, N'Ing.      ', N'Nikolas             ', N'Straka              ', N'+421907100100       ', N'straka@example.com            ', N'Angular developer             ', 5)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (15, N'Ing.      ', N'Michal              ', N'Silný               ', N'+421908555123       ', N'silny@example.com             ', N'Angular developer             ', 5)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (16, N'Bc.       ', N'Tatiana             ', N'Hlavová             ', N'+421907791197       ', N'hlavova@example.com           ', N'.NET developer                ', 5)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (17, N'Ing.      ', N'Juraj               ', N'Vinco               ', N'+4211944191900      ', N'vinco@example.com             ', N'Javascript developer          ', 9)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (18, N'Ing.      ', N'René                ', N'Dán                 ', N'+421904123789       ', N'dan@example.com               ', N'Frontend developer            ', 6)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (19, N'Bc.       ', N'Tomáš               ', N'Venco               ', N'+421944177889       ', N'venco@example.com             ', N'.NET developer                ', 6)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (20, N'Ing.      ', N'Peter               ', N'Hrubý               ', N'+421944155644       ', N'hruby@example.com             ', N'React developer               ', 11)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (21, N'Ing.      ', N'Michal              ', N'Masný               ', N'+421944777900       ', N'masny@example.com             ', N'.NET developer                ', 7)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (22, N'Bc.       ', N'Juraj               ', N'Jánoš               ', N'+421904753333       ', N'janos@example.com             ', N'Fullstack developer           ', 10)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (23, N'Ing.      ', N'Jana                ', N'Pokorná             ', N'+421908000897       ', N'pokorna@example.com           ', N'C# developer                  ', 12)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (24, N'Ing.      ', N'Peter               ', N'Palacinka           ', N'+421944400004       ', N'palacinka@example.com         ', N'Frontent developer            ', 3)
INSERT [dbo].[employees] ([Id], [Title], [Name], [Surname], [PhoneNumber], [Email], [Position], [DepartmentId]) VALUES (25, N'Ing.      ', N'Katarína            ', N'Zelená              ', N'+421944123000       ', N'zelena@example.com            ', N'Javascript developer          ', 4)
SET IDENTITY_INSERT [dbo].[employees] OFF
SET IDENTITY_INSERT [dbo].[leaders] ON 

INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (1, N'Phd.           ', N'Anton               ', N'Šéf                 ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (2, N'Ing.           ', N'Daniel              ', N'Drahňák             ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (3, N'Ing.           ', N'Dominika            ', N'Drahá               ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (4, N'Ing.           ', N'Vladimír            ', N'Danko               ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (5, N'Ing.           ', N'Peter               ', N'Dán                 ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (6, N'Ing.           ', N'Júlia               ', N'Prchká              ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (7, N'Ing.           ', N'Peter               ', N'Pavlovič            ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (8, N'Ing.           ', N'Zdenko              ', N'Popluhár            ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (9, N'Ing.           ', N'Andrej              ', N'Poruban             ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (10, N'Ing.           ', N'Andrea              ', N'Poláková            ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (11, N'Ing.           ', N'Juraj               ', N'Pohoda              ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (12, N'Ing.           ', N'Lucia               ', N'Prostá              ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (13, N'Ing.           ', N'Ján                 ', N'Bota                ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (14, N'Ing.           ', N'Ignác               ', N'Veľký               ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (15, N'Ing.           ', N'Dušan               ', N'Milo                ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (16, N'Ing.           ', N'Adam                ', N'Jarabica            ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (17, N'Phd.           ', N'Oliver              ', N'Biskup              ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (18, N'Ing.           ', N'František           ', N'Kocúr               ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (19, N'Ing.           ', N'Dušan               ', N'Nôta                ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (20, N'Ing.           ', N'Daniel              ', N'Kráľ                ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (21, N'Ing.           ', N'Vladimír            ', N'Silák               ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (22, N'Ing.           ', N'Ľubomír             ', N'Moravan             ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (23, N'Ing.           ', N'Anton               ', N'Hruška              ')
INSERT [dbo].[leaders] ([Id], [Title], [Name], [Surname]) VALUES (24, N'Ing.           ', N'Paulína             ', N'Pekná               ')
SET IDENTITY_INSERT [dbo].[leaders] OFF
SET IDENTITY_INSERT [dbo].[projects] ON 

INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (1, N'Project 1                     ', 1, 6)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (2, N'Project 2                     ', 2, 7)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (3, N'Project 3                     ', 2, 8)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (4, N'Project 4                     ', 2, 9)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (5, N'Project 5                     ', 3, 10)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (6, N'Project 6                     ', 4, 11)
INSERT [dbo].[projects] ([Id], [Name], [DivisionId], [LeaderId]) VALUES (7, N'Project 7                     ', 1, 12)
SET IDENTITY_INSERT [dbo].[projects] OFF
ALTER TABLE [dbo].[companies]  WITH CHECK ADD  CONSTRAINT [FK_companies_leaders] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[leaders] ([Id])
GO
ALTER TABLE [dbo].[companies] CHECK CONSTRAINT [FK_companies_leaders]
GO
ALTER TABLE [dbo].[departments]  WITH CHECK ADD  CONSTRAINT [FK_departments_leaders] FOREIGN KEY([LeaderId])
REFERENCES [dbo].[leaders] ([Id])
GO
ALTER TABLE [dbo].[departments] CHECK CONSTRAINT [FK_departments_leaders]
GO
ALTER TABLE [dbo].[departments]  WITH CHECK ADD  CONSTRAINT [FK_departments_projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[projects] ([Id])
GO
ALTER TABLE [dbo].[departments] CHECK CONSTRAINT [FK_departments_projects]
GO
ALTER TABLE [dbo].[divisions]  WITH CHECK ADD  CONSTRAINT [FK_divisions_companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[companies] ([Id])
GO
ALTER TABLE [dbo].[divisions] CHECK CONSTRAINT [FK_divisions_companies]
GO
ALTER TABLE [dbo].[divisions]  WITH CHECK ADD  CONSTRAINT [FK_divisions_leaders] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[leaders] ([Id])
GO
ALTER TABLE [dbo].[divisions] CHECK CONSTRAINT [FK_divisions_leaders]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[departments] ([Id])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_departments]
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD  CONSTRAINT [FK_projects_divisions] FOREIGN KEY([DivisionId])
REFERENCES [dbo].[divisions] ([Id])
GO
ALTER TABLE [dbo].[projects] CHECK CONSTRAINT [FK_projects_divisions]
GO
ALTER TABLE [dbo].[projects]  WITH CHECK ADD  CONSTRAINT [FK_projects_leaders] FOREIGN KEY([LeaderId])
REFERENCES [dbo].[leaders] ([Id])
GO
ALTER TABLE [dbo].[projects] CHECK CONSTRAINT [FK_projects_leaders]
GO
USE [master]
GO
ALTER DATABASE [CompanyDb] SET  READ_WRITE 
GO
