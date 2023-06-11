CREATE TABLE [Products] (
  [productID] int,
  [productName] nvarchar,
  [price] float,
  [quantity] int,
  [description] nvarchar,
  [status] bit,
  [weight] float
)
GO

CREATE TABLE [Meal_Product] (
  [mealID] int,
  [productID] int,
  [quantity] int
)
GO

CREATE TABLE [Users] (
  [userID] int,
  [userName] nvarchar(255),
  [password] nvarchar(255),
  [fullName] nvarchar,
  [email] nvarchar(255),
  [phone] nvarchar(255),
  [address] nvarchar,
  [role] nvarchar(255),
  [walletId] int
)
GO

CREATE TABLE [Meals] (
  [mealID] int,
  [description] nvarchar,
  [routingTime] nvarchar(255),
  [totalCost] float
)
GO

CREATE TABLE [Orders] (
  [orderID] int,
  [userID] int,
  [orderDate] date,
  [totalPrice] float,
  [status] nvarchar
)
GO

CREATE TABLE [Order_Details] (
  [orderDetailID] int,
  [orderID] int,
  [mealID] int,
  [quantity] int,
  [unitPrice] float
)
GO

CREATE TABLE [Wallets] (
  [walletId] int,
  [balance] float,
  [transactionDate] date
)
GO

ALTER TABLE [Meal_Product] ADD FOREIGN KEY ([mealID]) REFERENCES [Meals] ([mealID])
GO

ALTER TABLE [Meal_Product] ADD FOREIGN KEY ([productID]) REFERENCES [Products] ([productID])
GO

ALTER TABLE [Order_Details] ADD FOREIGN KEY ([mealID]) REFERENCES [Meals] ([mealID])
GO

ALTER TABLE [Orders] ADD FOREIGN KEY ([userID]) REFERENCES [Users] ([userID])
GO

ALTER TABLE [Order_Details] ADD FOREIGN KEY ([orderID]) REFERENCES [Orders] ([orderID])
GO

ALTER TABLE [Wallets] ADD FOREIGN KEY ([walletId]) REFERENCES [Users] ([walletId])
GO
