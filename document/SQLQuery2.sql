create database LibraryDB ;

CREATE TABLE [Book](
	[BID] [varchar](50) NOT NULL primary key,
	[Name] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[NoCopy] [int] NOT NULL,
	[NoActiveCopys] [int] NOT NULL ) ;

CREATE TABLE [dbo].[Customer](
	[CID] [varchar](10) NOT NULL primary key,
	[FName] [varchar](50) NULL,
	[LName] [varchar](50) NOT NULL,
	[NIC] [varchar](20) NOT NULL,
	[PNo] [int] NOT NULL,
	[Email] [varchar](50) NULL) ;

CREATE TABLE [dbo].[setting](
	[name] [varchar](50) NOT NULL primary key,
	[value] [float] NULL, );

CREATE TABLE [dbo].[MonthlyPayment](
	[PID] [varchar](10) NOT NULL ,
	[CID] [varchar](10) NOT NULL,
	[Month] [int] NOT NULL,
	CONSTRAINT PK_MonthlyPayment_CID_Month PRIMARY KEY (CID, Month));

CREATE TABLE [dbo].[Payment](
	[PID] [varchar](10) NOT NULL primary key,
	[Date] [datetime] NOT NULL,
	[Amount] [float] NOT NULL,
	[CID] [varchar](10) NOT NULL,
	[Type] [varchar](10) NOT NULL) ;

CREATE TABLE [dbo].[Reservation](
	[RID] [varchar](50) NOT NULL primary key,
	[CID] [varchar](10) NULL,
	[BID] [varchar](50) NULL,
	[Date] [datetime] NULL,
	[Status] [int] NULL,
	[PID] [varchar](10) NULL) ;

ALTER TABLE [dbo].[MonthlyPayment]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyPayment_Customer] FOREIGN KEY([CID])
REFERENCES [dbo].[Customer] ([CID])
GO
ALTER TABLE [dbo].[MonthlyPayment] CHECK CONSTRAINT [FK_MonthlyPayment_Customer]
GO
ALTER TABLE [dbo].[MonthlyPayment]  WITH CHECK ADD  CONSTRAINT [FK_MonthlyPayment_Payment] FOREIGN KEY([PID])
REFERENCES [dbo].[Payment] ([PID])
GO
ALTER TABLE [dbo].[MonthlyPayment] CHECK CONSTRAINT [FK_MonthlyPayment_Payment]
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
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Payment] FOREIGN KEY([PID])
REFERENCES [dbo].[Payment] ([PID])
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Payment]
GO

INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B002', N'madolduwa', 1500, 14, 14)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B003', N'C# fundamental', 1500, 6, 6)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'B004', N'java fundamental', 2600, 8, 8)
INSERT [dbo].[Book] ([BID], [Name], [Price], [NoCopy], [NoActiveCopys]) VALUES (N'dhnmcod345', N'hatpana', 1300, 8, 8)
GO
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000001', N'Ashen', N'Kavinda', N'200307200526', 783117761, N'Ashen@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000002', N'Himeth', N'Raveen', N'200407200256', 774237321, N'Himeth@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000003', N'Adisha', N'Disas', N'200107256485', 777452845, N'Adisha@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000004', N'Sadis', N'Kumara', N'19984586125', 778954623, N'Sadis@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000005', N'Nimesh', N'Duslina', N'200315200658', 789541256, N'Nimesh@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000006', N'Manith', N'Thusitha', N'199716455v', 912254879, N'thusitha@yahoo.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000007', N'Kalidu', N'Suraj', N'200245698752', 789542583, N'kalidu@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000008', N'Vimukthi', N'Thushara', N'19971564v', 915448921, N'Viukthi@gmail.com');
INSERT [dbo].[Customer] ([CID], [FName], [LName], [NIC], [PNo], [Email]) VALUES (N'C000009', N'Kusal', N'Sathsara', N'200045689751', 745659213, N'kusal@gmail.com');

GO
INSERT [dbo].[setting] ([name], [value]) VALUES (N'Monthlyfee', 200)
INSERT [dbo].[setting] ([name], [value]) VALUES (N'overdue', 30)
INSERT [dbo].[setting] ([name], [value]) VALUES (N'register', 400)
INSERT [dbo].[setting] ([name], [value]) VALUES (N'overDueDayLimit', 14)
INSERT [dbo].[setting] ([name], [value]) VALUES (N'overDueBookLimit', 2)
GO
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000001', CAST(N'2024-04-19T14:02:24.957' AS DateTime), 400, N'C000001', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000002', CAST(N'2024-04-19T14:04:29.490' AS DateTime), 400, N'C000002', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000003', CAST(N'2024-04-19T14:02:24.957' AS DateTime), 400, N'C000003', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000004', CAST(N'2024-04-19T14:04:29.490' AS DateTime), 400, N'C000004', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000005', CAST(N'2024-05-03T00:22:41.083' AS DateTime), 400, N'C000005', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000006', CAST(N'2024-04-19T14:04:29.490' AS DateTime), 400, N'C000006', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000007', CAST(N'2024-04-19T14:04:29.490' AS DateTime), 400, N'C000007', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000008', CAST(N'2024-05-03T21:03:18.413' AS DateTime), 400, N'C000008', N'R')
INSERT [dbo].[Payment] ([PID], [Date], [Amount], [CID], [Type]) VALUES (N'P000009', CAST(N'2024-05-05T17:09:04.693' AS DateTime), 400, N'C000009', N'R')
