USE [guicwnibm_]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BID] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[NoCopy] [int] NOT NULL,
	[NoActiveCopys] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CID] [varchar](10) NOT NULL,
	[FName] [varchar](50) NULL,
	[LName] [varchar](50) NOT NULL,
	[NIC] [varchar](20) NOT NULL,
	[PNo] [int] NOT NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fees]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fees](
	[PaymentType] [varchar](50) NOT NULL,
	[fee] [float] NULL,
 CONSTRAINT [PK_fees] PRIMARY KEY CLUSTERED 
(
	[PaymentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonthlyPayment]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonthlyPayment](
	[PID] [varchar](10) NOT NULL,
	[CID] [varchar](10) NOT NULL,
	[Month] [int] NOT NULL,
 CONSTRAINT [PK_MonthlyPayment] PRIMARY KEY CLUSTERED 
(
	[CID] ASC,
	[Month] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PID] [varchar](10) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Amount] [float] NOT NULL,
	[CID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Payment_1] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 5/16/2024 10:57:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[RID] [varchar](50) NOT NULL,
	[CID] [varchar](10) NULL,
	[BID] [varchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B002', N'madolduwa', 1500, 14, 4)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B003', N'C# fundamental', 1500, 6, 6)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B004', N'java fundamental', 2600, 8, 6)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'dhnmcod345', N'hatpana', 1300, 8, 8)
GO
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000001', N'Ashen', N'Kavinda', N'200307200526', 783117761, N'Ashen@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000002', N'Himeth', N'Raveen', N'200407200256', 774237321, N'Himeth@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000003', N'Adisha', N'Disas', N'200107256485', 777452845, N'Adisha@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000004', N'Sadis', N'Kumara', N'19984586125', 778954623, N'Sadis@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000005', N'Nimesh', N'Duslina', N'200315200658', 789541256, N'Nimesh@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000006', N'Manith', N'Thusitha', N'199716455v', 912254879, N'thusitha@yahoo.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000007', N'Kalidu', N'Suraj', N'200245698752', 789542583, N'kalidu@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000008', N'Vimukthi', N'Thushara', N'19971564v', 915448921, N'Viukthi@gmail.com')
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'D000009', N'Kusal', N'Sathsara', N'200045689751', 745659213, N'kusal@gmail.com')
GO
INSERT [dbo].[fees] ([PaymentType], [fee]) VALUES (N'Monthlyfee', 200)
INSERT [dbo].[fees] ([PaymentType], [fee]) VALUES (N'overdue', 30)
INSERT [dbo].[fees] ([PaymentType], [fee]) VALUES (N'register', 400)
GO
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000025', N'D000001', 5)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000004', N'D000001', 6)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000004', N'D000001', 7)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000021', N'D000001', 11)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000003', N'D000002', 4)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000003', N'D000002', 5)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000005', N'D000002', 8)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000006', N'D000003', 9)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 1)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 2)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 3)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 4)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 5)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000022', N'D000004', 6)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000024', N'D000004', 7)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000008', N'D000005', 5)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000008', N'D000005', 6)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000010', N'D000005', 7)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000020', N'D000005', 9)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000009', N'D000006', 5)
INSERT [dbo].[MonthlyPayment] ([PID], [CID], [Month]) VALUES (N'P000027', N'D000009', 5)
GO
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000001', CAST(N'2024-04-19T14:02:24.957' AS DateTime), 400, N'D000002')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000002', CAST(N'2024-04-19T14:04:29.490' AS DateTime), 400, N'D000002')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000003', CAST(N'2024-04-19T14:57:38.267' AS DateTime), 800, N'D000002')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000004', CAST(N'2024-05-02T22:52:23.160' AS DateTime), 800, N'D000001')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000005', CAST(N'2024-05-03T00:15:36.107' AS DateTime), 200, N'D000002')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000006', CAST(N'2024-05-03T00:20:33.850' AS DateTime), 200, N'D000003')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000007', CAST(N'2024-05-03T00:21:26.910' AS DateTime), 200, N'D000003')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000008', CAST(N'2024-05-03T00:22:41.083' AS DateTime), 400, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000009', CAST(N'2024-05-03T00:26:13.560' AS DateTime), 200, N'D000006')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000010', CAST(N'2024-05-03T00:30:12.503' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000011', CAST(N'2024-05-03T00:30:26.247' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000012', CAST(N'2024-05-03T00:30:29.017' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000013', CAST(N'2024-05-03T00:30:29.530' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000014', CAST(N'2024-05-03T00:30:31.137' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000015', CAST(N'2024-05-03T00:30:31.327' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000016', CAST(N'2024-05-03T00:30:31.537' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000017', CAST(N'2024-05-03T00:30:32.993' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000018', CAST(N'2024-05-03T00:31:33.860' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000019', CAST(N'2024-05-03T00:31:43.213' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000020', CAST(N'2024-05-03T00:44:14.037' AS DateTime), 200, N'D000005')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000021', CAST(N'2024-05-03T20:03:58.773' AS DateTime), 200, N'D000001')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000022', CAST(N'2024-05-03T20:29:17.377' AS DateTime), 1200, N'D000004')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000023', CAST(N'2024-05-03T21:03:18.413' AS DateTime), 400, N'D000008')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000024', CAST(N'2024-05-03T21:32:07.800' AS DateTime), 200, N'D000004')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000025', CAST(N'2024-05-05T16:55:30.757' AS DateTime), 200, N'D000001')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000026', CAST(N'2024-05-05T17:09:04.693' AS DateTime), 400, N'D000009')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000027', CAST(N'2024-05-05T17:10:58.520' AS DateTime), 200, N'D000009')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID]) VALUES (N'P000028', CAST(N'2024-05-10T23:36:47.207' AS DateTime), 200, N'D000001')
GO
INSERT [dbo].[Reservation] ([RID], [CID], [BID], [Date]) VALUES (N'R000001', N'D000002', N'B002', CAST(N'2024-05-03T22:56:50.167' AS DateTime))
INSERT [dbo].[Reservation] ([RID], [CID], [BID], [Date]) VALUES (N'R000002', N'D000002', N'B002', CAST(N'2024-05-04T14:30:00.000' AS DateTime))
INSERT [dbo].[Reservation] ([RID], [CID], [BID], [Date]) VALUES (N'R000003', N'D000001', N'B004', CAST(N'2024-05-05T16:56:22.013' AS DateTime))
INSERT [dbo].[Reservation] ([RID], [CID], [BID], [Date]) VALUES (N'R000006', N'D000001', N'B002', CAST(N'2024-05-05T17:07:56.787' AS DateTime))
INSERT [dbo].[Reservation] ([RID], [CID], [BID], [Date]) VALUES (N'R000008', N'D000001', N'B004', CAST(N'2024-05-10T23:04:07.880' AS DateTime))
GO
ALTER TABLE [dbo].[MonthlyPayment]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyPayment_Customer] FOREIGN KEY([CID])
REFERENCES [dbo].[Customer] ([CID])
GO
ALTER TABLE [dbo].[MonthlyPayment] CHECK CONSTRAINT [FK_MonthlyPayment_Customer]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Customer] FOREIGN KEY([CID])
REFERENCES [dbo].[Customer] ([CID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Customer]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Book] FOREIGN KEY([BID])
REFERENCES [dbo].[Book] ([BID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Book]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Customer] FOREIGN KEY([CID])
REFERENCES [dbo].[Customer] ([CID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Customer]
GO
