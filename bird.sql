use [BirdMeal]
CREATE TABLE [Wallets] (
  [walletId] int PRIMARY KEY IDENTITY(1,1),
  [balance] float,
  [transactionDate] date
)
GO

CREATE TABLE [Meals] (
  [mealID] int PRIMARY KEY IDENTITY(1,1),
  [description] nvarchar,
  [routingTime] nvarchar(255),
  [totalCost] float
)
GO

CREATE TABLE [Products] (
  [productID] int PRIMARY KEY IDENTITY(1,1),
  [productName] nvarchar,
  [price] float,
  [quantity] int,
  [description] nvarchar,
  [status] bit,
  [weight] float,
 
)
GO

CREATE TABLE [Users] (
  [userID] int PRIMARY KEY IDENTITY(1,1),
  [userName] nvarchar(255),
  [password] nvarchar(255),
  [fullName] nvarchar,
  [email] nvarchar(255),
  [phone] nvarchar(255),
  [address] nvarchar,
  [role] nvarchar(255),
  [walletId] int UNIQUE FOREIGN KEY REFERENCES [Wallets]([walletId])
)
GO



CREATE TABLE [Orders] (
  [orderID] int PRIMARY KEY IDENTITY(1,1),
  [userID] int FOREIGN KEY REFERENCES [Users]([userID]),
  [orderDate] date,
  [totalPrice] float,
  [status] nvarchar
)
GO


CREATE TABLE [Order_Details] (
  [orderDetailID] int PRIMARY KEY IDENTITY(1,1),
  [orderID] int FOREIGN KEY REFERENCES [Orders]([orderID]),
  [mealID] int FOREIGN KEY REFERENCES [Meals]([mealID]),
  [quantity] int,
  [unitPrice] float
)
GO


CREATE TABLE [Meal_Product] (
  [mealID] int FOREIGN KEY REFERENCES [Meals]([mealID]),
  [productID] int  FOREIGN KEY REFERENCES [Products]([productID]),
  [quantity] int
)
GO
