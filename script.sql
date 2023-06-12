USE [BirdMeal]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 6/12/2023 9:43:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[billID] [int] IDENTITY(1,1) NOT NULL,
	[orderDetailID] [int] NULL,
	[meal_product_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[billID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meal_Product]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meal_Product](
	[meal_product_ID] [int] IDENTITY(1,1) NOT NULL,
	[mealID] [int] NULL,
	[productID] [int] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[meal_product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[mealID] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](4000) NULL,
	[routingTime] [nvarchar](255) NULL,
	[totalCost] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[mealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[orderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[orderID] [int] NULL,
	[quantity] [int] NULL,
	[unitPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[orderID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[orderDate] [datetime] NULL,
	[totalPrice] [float] NULL,
	[status] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[productID] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](255) NULL,
	[price] [float] NULL,
	[quantity] [int] NULL,
	[description] [nvarchar](4000) NULL,
	[status] [bit] NULL,
	[weight] [float] NULL,
	[image] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[password] [nvarchar](255) NULL,
	[fullName] [nvarchar](255) NULL,
	[email] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[address] [nvarchar](255) NULL,
	[role] [nvarchar](255) NULL,
	[walletId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wallets]    Script Date: 6/12/2023 9:43:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wallets](
	[walletId] [int] IDENTITY(1,1) NOT NULL,
	[balance] [float] NULL,
	[transactionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[walletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1, N'Thuc An Chim 100g', 299999, 19, N'VERY', 1, 10, NULL)
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (2, N'Thuc An Chim 50g', 300000, 20, N'OK', 1, 20, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (1, N'1', N'Admin', N'admin@outlook.com', N'0123456', N'123', N'ADMIN', NULL)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (9, N'1', N'Staff 1', N'staff@outlook.com', N'0123456', N'123', N'STAFF', 1)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (12, N'1', N'Staff 2', N'staff2@outlook.com', N'0123456', N'456', N'STAFF', 2)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (13, N'1', N'David', N'david@gmail.com', N'07897778', N'HA', N'CUSTOMER', 3)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (14, N'1', N'Karen', N'karen@gmail.com', N'0986445', N'SG', N'CUSTOMER', 4)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (21, N'1', N'Nhat Pham', N'nhat2up@gmail.com', N'0986438258', N'Sai Gon', N'CUSTOMER', 11)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (23, N'1', N'Nhat Pham', N'nhat1up@gmail.com', N'9798789', N'Sai Gon', N'CUSTOMER', 13)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (24, N'1', N'Nhat Pham', N'nhat0up@gmail.com', N'0986438258', N'Sai Gon', N'CUSTOMER', 15)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (25, N'1', N'OBAMA', N'DavidCopperfield@fuflowerbouquetsystem.com', N'098643588', N'SG', N'CUSTOMER', 16)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (26, N'1', N'SOLOLON', N'nhatpmse161552@fpt.edu.vn', N'098643546', N'HA LOI', N'CUSTOMER', 17)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (27, N'1', N'Nhat Pham', N'nhat9up@gmail.com', N'9798789', N'DA LASS', N'CUSTOMER', 18)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Wallets] ON 

INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (1, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (2, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (3, 40000, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (4, 445646, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (5, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (6, 666666, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (7, 55555, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (8, 123345, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (9, 789, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (10, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (11, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (12, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (13, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (14, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (15, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (16, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (17, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (18, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (19, 0, NULL)
SET IDENTITY_INSERT [dbo].[Wallets] OFF
GO
/****** Object:  Index [UQ__Users__3785C87188AD8BF7]    Script Date: 6/12/2023 9:43:13 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[walletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([meal_product_ID])
REFERENCES [dbo].[Meal_Product] ([meal_product_ID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([orderDetailID])
REFERENCES [dbo].[Order_Details] ([orderDetailID])
GO
ALTER TABLE [dbo].[Meal_Product]  WITH CHECK ADD FOREIGN KEY([mealID])
REFERENCES [dbo].[Meals] ([mealID])
GO
ALTER TABLE [dbo].[Meal_Product]  WITH CHECK ADD FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([productID])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([orderID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([walletId])
REFERENCES [dbo].[Wallets] ([walletId])
GO
