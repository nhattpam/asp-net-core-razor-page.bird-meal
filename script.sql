USE [BirdMeal]
GO
/****** Object:  Table [dbo].[Meal_Product]    Script Date: 6/23/2023 8:59:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Meal_Product](
	[meal_product_ID] [int] IDENTITY(1,1) NOT NULL,
	[mealID] [varchar](50) NULL,
	[productID] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK__Meal_Pro__4D95404B5C495354] PRIMARY KEY CLUSTERED 
(
	[meal_product_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 6/23/2023 8:59:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Meals](
	[mealID] [varchar](50) NOT NULL,
	[description] [nvarchar](4000) NULL,
	[routingTime] [nvarchar](255) NULL,
	[totalCost] [float] NULL,
 CONSTRAINT [PK__Meals__0D609C9A61BFA9DF] PRIMARY KEY CLUSTERED 
(
	[mealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 6/23/2023 8:59:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order_Details](
	[orderDetailID] [int] IDENTITY(1,1) NOT NULL,
	[orderID] [int] NULL,
	[quantity] [int] NULL,
	[unitPrice] [float] NULL,
	[mealID] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[orderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/23/2023 8:59:14 PM ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 6/23/2023 8:59:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/23/2023 8:59:14 PM ******/
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
/****** Object:  Table [dbo].[Wallets]    Script Date: 6/23/2023 8:59:14 PM ******/
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
SET IDENTITY_INSERT [dbo].[Meal_Product] ON 

INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (47, N'OKLEA', 2, 0)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (48, N'OKLEA', 2, 0)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (80, N'1', 1, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (81, N'1', 1006, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (82, N'3333', 1, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (83, N'3333', 1006, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (84, N'5411', 1, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (85, N'5411', 1003, 11)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (86, N'CCCJKS', 4, 6)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (87, N'CCCJKS', 1006, 1)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (88, N'CICD', 3, 10)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (89, N'CSBHC', 4, 2)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (90, N'CSBHH', 1002, 3)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (91, N'CSBHH1', 1002, 3)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (92, N'CSBS1', 1, 2)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (93, N'CSBHH11', 4, 2)
INSERT [dbo].[Meal_Product] ([meal_product_ID], [mealID], [productID], [quantity]) VALUES (94, N'CSBS3', 2, 2)
SET IDENTITY_INSERT [dbo].[Meal_Product] OFF
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'1', N'gggg', N'1', 200123)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'3333', N'222', N'121', 200123)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'5411', N'123', N'123', 203795)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CCCJKS', N'very ok', N'20:00 - 12:00', 132123)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CICD', N'444', N'432', 220000)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBHC', N'CSBHH', N'CSBHH', 44000)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBHH', N'GOOD', N'10:00 - 12:00', 1035)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBHH1', N'fd', N'df', 1035)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBHH11', N'123', N'123', 44000)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBS1', N' VERY', N'10:00 - 12:00', 400000)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'CSBS3', N'danh cho chim con', N'7:00 - 11:00', 200000)
INSERT [dbo].[Meals] ([mealID], [description], [routingTime], [totalCost]) VALUES (N'OKLEA', N'4443124', N'4234', 300000)
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1, N'Flo Festival feeder with feeder mix 5.5kg', 200000, 20, N'This handy Flo Festival feeder pack contains everything you need to start feeding garden birds, with a great saving of £5!', 1, 100, N'6bf70812-8ff8-4ab8-b38e-f84d9ca56dd2.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (2, N'My Favourites hanging bird feeder and feeder mix 1.5kg', 100000, 20, N'Ideal for attracting small birds to your garden, this pack includes the My Favourites feeder and a bag of Feeder mix.

The pack includes:

1 x My Favourites hanging feeder.
1 x Feeder mix - 1.5kg.
The My Favourites hanging feeder is designed for smaller birds that cling when feeding such as blue tits, goldfinches and great tits. Made from durable plastic that won''t crack or discolour in the sun, it is easy to dismantle, clean and refill.

Our Feeder mix is a nutritious mix of oil-rich black and striped sunflower seeds, husk-free oats and canary seed, that''ll attract many garden birds such as blue tits, great tits and greenfinches.', 1, 200, N'79430ad2-1ee9-459d-a7e6-c7eb0604e78d.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (3, N'RSPB Roofed ground feeding table with bird food ', 22000, 20, N'Get ready to welcome ground-feeding birds to your garden with this roofed ground table and bird food pack.

It''s ideal for ground-feeders such as blackbirds, robins, dunnocks and thrushes.

This pack includes:

1 x RSPB Roofed ground table.
1 x No grow ground mix - 900g.
1 x RSPB Buggy nibbles - 1kg.
Our RSPB Roofed ground table is make in the UK from FSC® certified wood and features a gently sloping roof, ideal for keeping birds sheltered and food dry. It comes with a removeable recycled plastic tray for easy cleaning.

The No grow ground mix has been designed so that the seed mix is much less likely to germinate than standard seed mixes. All of the ingredients have been prepared and cut in a way that limits germination, but still offers great nutrition.

Our RSPB Buggy nibbles are made from a delicious mix of mealworms, premium UK suet and cereal and are great for sprinkling on bird tables - birds find them hard to resist!', 1, 100, N'7b2f6283-8d33-4bb1-a326-f877499448dd.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (4, N'RSPB Bird food trial pack', 22000, 20, N'Try out some of our best-selling bird food to see which the birds in your garden enjoy the most, with our great value trial pack.

Pack contains:

3 x RSPB Super suet mealworm cakes.
1 x RSPB Dried mealworms - 100g.
1 x RSPB Premium peanuts - 900g.
1 x RSPB Feeder mix - 1.5kg.
1 x RSPB Buggy nibbles - 550g.
', 1, 100, N'33ba6db7-c416-428f-a049-cacd85635cc9.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1002, N'I love robins feeder & dried mealworms ', 345, 20, N'This neat little feeder has a domed roof to help protect birds whilst they eat, and keep food dry in wet weather. Made from tough polycarbonate, the dome slides up and down so you can deter larger birds if you wish.

Perfect for our dried mealworms: a great source of protein and calories valuable during the hectic breeding season and through colder weather.




Features
Includes feeder & 200g dried mealworms |Dome measures 15.5 cm diameter', 1, 345, N'c9534853-9f15-4083-bbf4-7baf2db8f9ec.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1003, N'Dual suet feeder starter pack with fat balls & cakes ', 345, 20, N'This great offer includes everything to keep your birds fit and healthy all year round.

Our chalet-shaped feeder is made from powder-coated steel, with the roof keeping most of the rain off. Fill the feeder with up to three super suet cakes or suet balls.

Your delivery will contain:

1 x RSPB Dual suet feeder (R402047)
1 x pack of 6 Super suet balls mealworm flavour (R406409)
1 x pack of 3 Super suet cake mealworm pack (R420116)
The discount has already been applied to this pack. Simply add it to your basket.', 1, 11, N'423416b9-5247-4896-b649-c1fcf09a5305.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1004, N'RSPB Ground feeding table & food offer ', 8, 20, N'Our RSPB ground table with detachable wooden dividers allows you to attract a range of garden birds by feeding multiple types of bird food. The table is made from FSC® certified wood. The tray includes drainage on all four sides, and can be easily removed for cleaning.

And to get you started, we include 1 kg of our popular buggy nibbles and 900 g of no grow ground mix bird food with the table.




Features
Includes a ground table, 900 g no grow ground mix & 1 kg buggy nibbles |Table measures 34 cm square', 1, 678, N'5085ebbc-f97c-4baa-a109-f26d5dac7a0a.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1005, N'RSPB Premium feeding station & bumper bird food value pack ', 234, 20, N'Set up a bird café in your garden with our brilliant Premium feeding station pack, which contains everything you need to feed garden birds.

This pack contains:

1 x RSPB Premium feeding station.
1 x RSPB Buggy nibbles - 1kg.
10 x Buggy coconut treats.
1 x Feeder mix - 1.5kg.
1 x Classic Easy-clean® seed feeder - size small.
1 x Classic Easy-clean® nut & nibble feeder - size small.', 1, 234, N'49edc542-1a8d-41ad-ad2d-433379c753d8.jpg')
INSERT [dbo].[Products] ([productID], [productName], [price], [quantity], [description], [status], [weight], [image]) VALUES (1006, N'Suet gift box ', 123, 20, N'Suet may seem an odd present to give to someone but the birds will absolutely love you for it! This beautifully-presented box crammed with some of our bestselling, top quality suet products makes a lovely, thoughtful gift.

We''ve used our expertise over the years to craft some of the finest suet products available. Our Super suet recipe is high in fat and protein content, meaning it''s great for birds at all times of the year. Whether they are using up valuable energy feeding their young in springtime or struggling to survive the colder months, providing suet in your garden can make all the difference to our feathered friends.

This gift box would be appreciated by experienced feeders of birds and novices alike. It contains a range of foods which can be put out without the need for specialist feeders or any equipment. Our Super suet balls and Super suet cakes can be crumbled up and put onto a bird table or the ground (although suet ball or suet cake feeders are also a option). Buggy nibbles can equally be sprinkled on the ground (or put into a nut and nibble feeder if you have one). Our Coconut shell treats come with a string loop so they can be hung from a tree branch, fence post or feeding station.

If you''re looking for inspiration on how to create a lovely food and feeder bundle, you could try adding our Dual suet feeder, Classic easy-clean suet ball feeder and our Classic easy-clean nut and nibble feeder as well.

Suet gift box contains:
2 x RSPB Super suet balls 6 pack, mealworm flavour
2 x RSPB Buggy nibbles 550g
1 x RSPB Super suet coconut treat original flavour
1 x RSPB Super suet coconut treat buggy flavour
1 x RSPB Super suet cake triple pack mealworm flavour

All our Super suet is made in the UK from top quality ingredients. The gift box is fully recyclable.', 1, 234, N'c6cb76d1-6df7-4f67-ac87-0e5fbc14db1d.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (1, N'1', N'Admin', N'admin@outlook.com', N'0123456', N'123', N'ADMIN', NULL)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (9, N'1', N'Staff 1', N'staff@outlook.com', N'0123456', N'123', N'STAFF', 1)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (12, N'1', N'Staff 2', N'staff2@outlook.com', N'0123456', N'456', N'STAFF', 2)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (13, N'1', N'David', N'david@gmail.com', N'07897778', N'HA', N'CUSTOMER', 3)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (14, N'1', N'Karen', N'karen@gmail.com', N'0986445', N'SG', N'CUSTOMER', 4)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (21, N'1', N'Nhat Pham', N'nhat2up@gmail.com', N'0986438258', N'Sai Gon', N'CUSTOMER', 37)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (23, N'1', N'alo', N'nhatpro@gmail.com', N'0897987777', N'Sg', N'CUSTOMER', 27)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (24, N'1', N'cat', N'nhat1up@gmail.com', N'0312333322', N'SG', N'CUSTOMER', 35)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (25, N'1', N'OBAMA', N'DavidCopperfield@fuflowerbouquetsystem.com', N'098643588', N'SG', N'CUSTOMER', 16)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (26, N'1', N'SOLOLON', N'nhatpmse161552@fpt.edu.vn', N'098643546', N'HA LOI', N'CUSTOMER', 17)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (27, N'1', N'Nhat Pham', N'nhat9up@gmail.com', N'9798789', N'DA LASS', N'CUSTOMER', 18)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (28, N'1', N'Nhat Pham', N'nhat21up@gmail.com', N'0989898985', N'Sai Gon', N'CUSTOMER', 24)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (29, N'1', N'Nhat Pham', N'nhat221up@gmail.com', N'0989898985', N'Sai Gon', N'STAFF', 25)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (30, N'1', N'Nhat Pham', N'nhat02up@gmail.com', N'9864382582', N'Sai Gon', N'CUSTOMER', 26)
INSERT [dbo].[Users] ([userID], [password], [fullName], [email], [phone], [address], [role], [walletId]) VALUES (31, N'1', N'Nhat Pham', N'nhat7777up@gmail.com', N'0989898887', N'Sai Gon', N'CUSTOMER', 34)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Wallets] ON 

INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (1, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (2, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (3, 40000, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (4, 445646, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (5, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (6, 666666, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (7, 55555, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (8, 123345, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (9, 789, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (10, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (11, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (12, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (13, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (14, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (15, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (16, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (17, 2, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (18, 50, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (19, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (20, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (21, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (22, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (23, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (24, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (25, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (26, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (27, 111, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (28, 10, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (29, 11111, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (30, 999, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (31, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (32, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (33, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (34, 0, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (35, 70000000, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (36, 2000000, NULL)
INSERT [dbo].[Wallets] ([walletId], [balance], [transactionDate]) VALUES (37, 999888, NULL)
SET IDENTITY_INSERT [dbo].[Wallets] OFF
/****** Object:  Index [UQ__Users__3785C871EE5A8E15]    Script Date: 6/23/2023 8:59:14 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[walletId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Meal_Product]  WITH CHECK ADD  CONSTRAINT [FK__Meal_Prod__mealI__20C1E124] FOREIGN KEY([mealID])
REFERENCES [dbo].[Meals] ([mealID])
GO
ALTER TABLE [dbo].[Meal_Product] CHECK CONSTRAINT [FK__Meal_Prod__mealI__20C1E124]
GO
ALTER TABLE [dbo].[Meal_Product]  WITH CHECK ADD  CONSTRAINT [FK__Meal_Prod__produ__21B6055D] FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([productID])
GO
ALTER TABLE [dbo].[Meal_Product] CHECK CONSTRAINT [FK__Meal_Prod__produ__21B6055D]
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([orderID])
REFERENCES [dbo].[Orders] ([orderID])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Meals] FOREIGN KEY([mealID])
REFERENCES [dbo].[Meals] ([mealID])
GO
ALTER TABLE [dbo].[Order_Details] CHECK CONSTRAINT [FK_Order_Details_Meals]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([walletId])
REFERENCES [dbo].[Wallets] ([walletId])
GO
