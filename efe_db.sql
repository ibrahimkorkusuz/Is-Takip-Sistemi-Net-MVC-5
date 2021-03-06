USE [EfeDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 31.07.2019 18:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](20) NOT NULL,
	[Description] [ntext] NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customers]    Script Date: 31.07.2019 18:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](50) NULL,
	[ContactName] [nvarchar](50) NULL,
	[ContactTitle] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](20) NULL,
	[Address] [nvarchar](80) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 31.07.2019 18:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL,
	[Title] [nvarchar](50) NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkDone]    Script Date: 31.07.2019 18:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkDone](
	[WorkDoneID] [int] NOT NULL,
	[PlugNo] [nchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[WorkName] [nvarchar](50) NULL,
	[CategoryID] [int] NOT NULL,
	[EmployeeID] [int] NULL,
	[Quantity] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[DueDate] [datetime] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Link] [nvarchar](150) NULL,
	[ProductName] [nvarchar](50) NULL,
	[CustomerID] [int] NULL,
 CONSTRAINT [PK_WorkDone] PRIMARY KEY CLUSTERED 
(
	[WorkDoneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkOrder]    Script Date: 31.07.2019 18:46:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkOrder](
	[WorkID] [int] IDENTITY(1,1) NOT NULL,
	[PlugNo] [nchar](10) NULL,
	[CreateDate] [datetime] NULL,
	[WorkName] [nvarchar](50) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[EmployeeID] [int] NULL,
	[Quantity] [nvarchar](10) NULL,
	[Description] [nvarchar](max) NULL,
	[DueDate] [datetime] NULL,
	[ProductName] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Link] [nvarchar](90) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[WorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (1, N'LAZER', NULL, NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (2, N'BASKES', NULL, NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (3, N'SÜBLİMASYON', NULL, NULL)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName], [Description], [Picture]) VALUES (6, N'DİGİTAL', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Email], [Phone], [Address]) VALUES (1, N'Şimşek Tercüme', N'Rabia Şimşek', N'Şirket Sahibi', NULL, N'0216 499 9999', N'Kozyatağı/İstanbul')
INSERT [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Email], [Phone], [Address]) VALUES (2, N'Modoko', N'Recep Şahin', N'Satın Alma', NULL, N'0534 979 0791', N'Ümranye İstanbul')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (1, N'Levent', N'Çakır', N'levent@efeajans.com.tr', N'1234', N'Şirket Sahibi', N'535 644 9845')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (2, N'Fatih', N'Yıldız', N'fatih@efeajans.com.tr', N'1234', N'Satış Müdürü', N'535 644 9775')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (3, N'Yavuz', N'Ülker', N'yavuz@efeajans.com.tr', N'1234', N'Satış Temsilcisi', N'532 455 9755')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (4, N'İbrahim', N'Korkusuz', N'ibrahim@efeajans.com.tr', N'1234', N'Webmaster', N'506 365 0277')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (5, N'Hasan', N'Kalkan', N'hasan@yandex.com', N'1234', N'Satış Temsilcisi', N'5063650277')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (7, N'Selim', N'Akkuzu2', N'selim@gmail.com', N'162451', N'Şöfor', N'05063650277')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Email], [Password], [Title], [Phone]) VALUES (8, N'Bünyamin', N'Kase', N'bunyamin@gmail.com', N'162451', N'Lazer Müdürü', N'5036554977')
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[WorkOrder] ON 

INSERT [dbo].[WorkOrder] ([WorkID], [PlugNo], [CreateDate], [WorkName], [CategoryID], [EmployeeID], [Quantity], [Description], [DueDate], [ProductName], [ImagePath], [Link]) VALUES (1, N'00012     ', CAST(0x0000AA1A00000000 AS DateTime), N'3D Lamba', 1, 1, N'4233', N'Bana çalışan adam lazım', CAST(0x0000AA2300000000 AS DateTime), N'MDF 4mm44', N'~/Content/uploads/1d58423d_2a9b_441f_8db3_88ef76c84c48.jpeg', N'\\CANAN-PC\tarama\LAZER\31.07.2019 Çiçek Sepeti')
INSERT [dbo].[WorkOrder] ([WorkID], [PlugNo], [CreateDate], [WorkName], [CategoryID], [EmployeeID], [Quantity], [Description], [DueDate], [ProductName], [ImagePath], [Link]) VALUES (3, N'0003      ', CAST(0x0000AA1700000000 AS DateTime), N'Kalem Seti', 1, 4, N'2300', N'Mikaile zam yok', CAST(0x0000AA1A00000000 AS DateTime), N'Kupa Bardak', N'~/Content/uploads/1d58423d_2a9b_441f_8db3_88ef76c84c48.jpeg', N'\\CANAN-PC\tarama\LAZER\31.07.2019 Çiçek Sepeti')
INSERT [dbo].[WorkOrder] ([WorkID], [PlugNo], [CreateDate], [WorkName], [CategoryID], [EmployeeID], [Quantity], [Description], [DueDate], [ProductName], [ImagePath], [Link]) VALUES (1011, N'4464      ', CAST(0x0000AA1A00000000 AS DateTime), N'Bayeks', 2, 2, N'233', N'sadafa', CAST(0x0000AAA200000000 AS DateTime), N'4mm akrilik', N'~/Content/uploads/acc4cb71_bcde_451f_a6dc_d26a840bcd2d.jpeg', N'\\CANAN-PC\tarama\LAZER\31.07.2019 Çiçek Sepeti')
INSERT [dbo].[WorkOrder] ([WorkID], [PlugNo], [CreateDate], [WorkName], [CategoryID], [EmployeeID], [Quantity], [Description], [DueDate], [ProductName], [ImagePath], [Link]) VALUES (1013, N'6555      ', CAST(0x0000AA8900000000 AS DateTime), N'Bayeks', 2, 2, N'2', N'asdaf', CAST(0x0000AAA200000000 AS DateTime), N'4mm akrilik', N'~/Content/uploads/e04737bd_431b_4eef_bc88_cdcc148827c4.jpeg', N'\\CANAN-PC\tarama\LAZER')
INSERT [dbo].[WorkOrder] ([WorkID], [PlugNo], [CreateDate], [WorkName], [CategoryID], [EmployeeID], [Quantity], [Description], [DueDate], [ProductName], [ImagePath], [Link]) VALUES (1014, N'4464      ', CAST(0x0000AA1A00000000 AS DateTime), N'Bayeks', 6, 4, N'33', N'denenee', CAST(0x0000AA8B00000000 AS DateTime), N'4mm akrilik', N'~/Content/uploads/b9e8f027_74e5_40cc_bbb4_a33417c7f5fb.jpeg', N'http://efeajans.com.tr/lazerkesim.html')
SET IDENTITY_INSERT [dbo].[WorkOrder] OFF
ALTER TABLE [dbo].[WorkDone]  WITH CHECK ADD  CONSTRAINT [FK_WorkDone_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[WorkDone] CHECK CONSTRAINT [FK_WorkDone_Categories]
GO
ALTER TABLE [dbo].[WorkDone]  WITH CHECK ADD  CONSTRAINT [FK_WorkDone_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[WorkDone] CHECK CONSTRAINT [FK_WorkDone_Customers]
GO
ALTER TABLE [dbo].[WorkDone]  WITH CHECK ADD  CONSTRAINT [FK_WorkDone_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[WorkDone] CHECK CONSTRAINT [FK_WorkDone_Employees]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[WorkOrder]  WITH CHECK ADD  CONSTRAINT [FK_WorkOrder_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[WorkOrder] CHECK CONSTRAINT [FK_WorkOrder_Employees]
GO
