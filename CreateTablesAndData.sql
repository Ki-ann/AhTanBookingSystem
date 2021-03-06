GO
/****** Object:  Table [dbo].[Item]    Script Date: 11/1/2017 8:47:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Item](
	[ItemId] [int] NOT NULL,
	[ItemName] [varchar](100) NULL,
	[Photo] [varbinary](max) NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/1/2017 8:47:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDateTime] [datetime2](7) NULL CONSTRAINT [DF_Order_OrderDateTime]  DEFAULT (getdate()),
	[OrderedBy] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/1/2017 8:47:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailId] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[RentalId] [int] NULL,
	[ItemId] [int] NULL,
	[ReserveDate] [datetime2](7) NULL,
	[PickUpTimeSlot] [varchar](50) NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rental]    Script Date: 11/1/2017 8:47:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rental](
	[RentalId] [int] NOT NULL,
	[RentalType] [varchar](100) NULL,
	[RentalPrice] [decimal](18, 0) NULL,
	[ItemId] [int] NULL,
 CONSTRAINT [PK_Rental] PRIMARY KEY CLUSTERED 
(
	[RentalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/1/2017 8:47:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 1, N'CITY BIKE',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\CITY_BIKE.PNG',Single_Blob) as image

INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 2, N'TANDEM BIKE',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\TANDEM_BIKE.PNG',Single_Blob) as image

INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 3, N'TOURING BIKE',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\TOURING_BIKE.PNG',Single_Blob) as image

INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 4, N'KIDS BIKE',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\KIDS_BIKE.PNG',Single_Blob) as image

INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 5, N'KIDS TANDEM',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\KIDS_TANDEM.PNG',Single_Blob) as image

INSERT [dbo].[Item] ([ItemId], [ItemName],[Photo]) 
SELECT 6, N'KIDS CARGO BIKE',BulkColumn 
FROM Openrowset( Bulk 'C:\APPD\BookingSystem\ImageData\KIDS_CARGO_BIKE.PNG',Single_Blob) as image
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (1, N'3 Hours', CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (2, N'24 Hours', CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (3, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (4, N'Extra Half Day ', CAST(0 AS Decimal(18, 0)), 1)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (5, N'3 Hours', CAST(0 AS Decimal(18, 0)), 2)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (6, N'24 Hours', CAST(0 AS Decimal(18, 0)), 2)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (7, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 2)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (8, N'Extra Half Day', CAST(0 AS Decimal(18, 0)), 2)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (9, N'3 Hours', CAST(0 AS Decimal(18, 0)), 3)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (10, N'24 Hours', CAST(0 AS Decimal(18, 0)), 3)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (11, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 3)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (12, N'Extra Half Day', CAST(0 AS Decimal(18, 0)), 3)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (13, N'3 Hours', CAST(0 AS Decimal(18, 0)), 4)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (14, N'24 Hours', CAST(0 AS Decimal(18, 0)), 4)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (15, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 4)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (16, N'Extra Half Day', CAST(0 AS Decimal(18, 0)), 4)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (17, N'3 Hours', CAST(0 AS Decimal(18, 0)), 5)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (18, N'24 Hours', CAST(0 AS Decimal(18, 0)), 5)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (19, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 5)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (20, N'Extra Half Day', CAST(0 AS Decimal(18, 0)), 5)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (21, N'3 Hours', CAST(0 AS Decimal(18, 0)), 6)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (22, N'24 Hours', CAST(0 AS Decimal(18, 0)), 6)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (23, N'Extra Day (24 h)', CAST(0 AS Decimal(18, 0)), 6)
INSERT [dbo].[Rental] ([RentalId], [RentalType], [RentalPrice], [ItemId]) VALUES (24, N'Extra Half Day', CAST(0 AS Decimal(18, 0)), 6)

INSERT INTO [User] (UserName) VALUES (N'ROGER');
INSERT INTO [User] (UserName) VALUES (N'CINDY');