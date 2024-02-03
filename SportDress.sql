IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name = 'SportDress')
BEGIN
	DROP DATABASE SportDress
	print '' print '*** database of SportDress dropped'
END

GO
CREATE DATABASE SportDress
GO
print '' print '*** database of SportDress created'

GO
USE [SportDress]
GO
print '' print '*** database of SportDress is in use'

GO
CREATE TABLE [dbo].[Employees]
(
	[EmployeeID]		[int]	IDENTITY(100000,1)	NOT NULL,
	[GivenName]	[nvarchar](50)	NOT NULL,
	[FamilyName]	[nvarchar](50)	NOT NULL,
	[PhoneNumber]	[nvarchar](11)	NOT NULL,
	[Email]		[nvarchar](250)	NOT NULL,
	[PasswordHash]	[nvarchar](100)	NOT NULL,
	[Active]	[bit] default 1	NOT NULL,
	CONSTRAINT [pk_EmployeeID] PRIMARY KEY ([EmployeeID])
)
GO
print '' print '*** Employees table  created'

GO
print '' print '*** inserting samples data in employees table ***'
GO
INSERT INTO [dbo].[Employees]
	([GivenName], [FamilyName],[PhoneNumber],[Email],[PasswordHash],[Active])
	VALUES
	('first', 'employee', '3190000001','firstEmployee@company.com','5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',1),
	('second','employee','3190000002','secondEmployee@company.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',1),
		('third','employee','3190000003','third@company.com', '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',0)
GO


CREATE TABLE [dbo].[Roles]
(
	[RoleID]	[nvarchar](50)	NOT NULL,
	[Description]	[nvarchar](255)	NOT NULL
	CONSTRAINT [pk_RoleID] PRIMARY KEY ([RoleID])
)
GO
print '' print '*** Roles table  created'

GO
print '' print '*** inserting samples data in Roles table ***'
GO
INSERT INTO [dbo].[Roles]
	([RoleID], [Description])
	VALUES
	('employee', 'view and all views'),
	('manager','view and edit all views'),
	('admin','creat and update permissions')
GO

CREATE TABLE [dbo].[EmployeesRoles]
(
	[EmployeeID]	[int]	NOT NULL,
	[RoleID]	[nvarchar](50)	NOT NULL,
	CONSTRAINT [fk_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees]([EmployeeID]),
	CONSTRAINT [fk_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId]),
	CONSTRAINT [pk_RoleID_EmployeeID] PRIMARY KEY ([RoleID],[EmployeeID])
)
GO
print '' print '*** EmployeesRoles table  created'
GO
print '' print '*** inserting samples data in EmployeesRoles table ***'
GO
INSERT INTO [dbo].[EmployeesRoles]
	([EmployeeID], [RoleID])
	VALUES
	(100000, 'admin'),
	(100001,'manager'),
	(100002,'employee')
GO

CREATE TABLE [dbo].[Zipcodes]
(
	[zipcode]	[nvarchar](10)	NOT NULL,
	[city]		[nvarchar](50)	NOT NULL,
	[state]		[nvarchar](50)	NOT NULL
	CONSTRAINT [pk_zipcode] PRIMARY KEY ([zipcode])
)
GO
print '' print '*** Zipcodes table  created'
GO
print '' print '*** inserting samples data in Zipcodes table ***'
GO
INSERT INTO [dbo].[Zipcodes]
	([zipcode], [city],[state])
	VALUES
	('52404', 'cedar rapids','iowa')
GO

CREATE TABLE [dbo].[Customers]
(
	[CustomerID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[GivenName]	[nvarchar](50)	NOT NULL,
	[FamilyName]	[nvarchar](50)	NOT NULL,
	[PhoneNumber]	[nvarchar](11)	NOT NULL,
	[Email]		[nvarchar](250)	NOT NULL,
	[line1]		[nvarchar](250)	NOT NULL,
	[line2]		[nvarchar](250)	,
	[zipcode]	[nvarchar](10)	NOT NULL,
	CONSTRAINT [pk_CustomerID] PRIMARY KEY ([CustomerID]),
	CONSTRAINT [fk_zipcode] FOREIGN KEY ([zipcode]) REFERENCES [Zipcodes]([zipcode]),
)
GO
print '' print '*** Customers table  created'
Go
print '' print '*** inserting samples data in Customers table ***'
GO
INSERT INTO [dbo].[Customers]
	([GivenName], [FamilyName],[PhoneNumber],[Email],[line1],[line2],[zipcode])
	VALUES
	('first', 'customer','3180000001','firstCustomer@email.com','line1','line2','52404')
GO

CREATE TABLE [dbo].[CustomersCreditCards]
(
	[CustomerID]	[int]	NOT NULL,
	[CreditCardNumber]	[nvarchar](50)	NOT NULL,
	[zipcode]	[nvarchar](10)	NOT NULL,
	[cvv]	[nvarchar](11)	NOT NULL,
	[dateOfExpiration]	[nvarchar](250)	NOT NULL,
	[nameOnTheCard]		[nvarchar](250)	NOT NULL,
	CONSTRAINT [fk_CustomerID_CustomersCreditCards] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]),
	CONSTRAINT [fk_zipcode_CustomersCreditCards] FOREIGN KEY ([zipcode]) REFERENCES [zipcodes]([zipcode])
)
Go
print '' print '*** CustomersCreditCards table created ***'
Go
print '' print '*** inserting samples data in CustomersCreditCards table ***'
GO
INSERT INTO [dbo].[CustomersCreditCards]
	([CustomerID], [CreditCardNumber],[zipcode],[cvv],[dateOfExpiration],[nameOnTheCard])
	VALUES
	(100000, '1234567891011','52404','980','10/10/2040','first customer')
Go

CREATE TABLE [dbo].[productstypes]
(
	[productTypeName]	[nvarchar](50)	NOT NULL,
	[description]	[nvarchar](255)	NOT NULL,
	CONSTRAINT [pk_productTypeName] PRIMARY KEY ([productTypeName])
)
Go
print '' print '*** productstypes table created ***'
Go
print '' print '*** inserting samples data in productstypes table ***'
GO
INSERT INTO [dbo].[productstypes]
	([productTypeName], [description])
	VALUES
	('T-shirt', 'all t-shirts'),
	('shoes','all foot covers')


GO
CREATE TABLE [dbo].[productsSizes]
(
	[productsSizeName]	[nvarchar](4)	NOT NULL,
	[description]	[nvarchar](255)	,
	CONSTRAINT [pk_productsSizeName] PRIMARY KEY ([productsSizeName])
)
Go
print '' print '*** inserting samples data in productsSizes table ***'
GO
INSERT INTO [dbo].[productsSizes]
	([productsSizeName], [description])
	VALUES
	('xs', ''),
	('s',''),
	('m',''),
	('l',''),
	('xl','')


GO
CREATE TABLE [dbo].[products]
(
	[productID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[productName]	[nvarchar](50)	NOT NULL,
	[price] [nvarchar](50) NOT NULL,
	[type]	[nvarchar](50)	NOT NULL,
	[size]	[nvarchar](4)	NOT NULL,
	CONSTRAINT [pk_productID] PRIMARY KEY ([productID]),
	CONSTRAINT [fk_type] FOREIGN KEY ([type]) REFERENCES [productstypes]([productTypeName]),
	CONSTRAINT [fk_size] FOREIGN KEY ([size]) REFERENCES [productsSizes]([productsSizeName])
)
GO
print '' print '*** products table  created'
Go
print '' print '*** inserting samples data in products table ***'
GO
INSERT INTO [dbo].[products]
	([productName], [type],[size],[price])
	VALUES
	('product1', 'T-shirt','l','1000')


GO
CREATE TABLE [dbo].[productsImages]
(
	[imageID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[productID]	[int]	NOT NULL,
	[imageUrl]	[nvarchar](255)	NOT NULL,
	CONSTRAINT [pk_imageID] PRIMARY KEY ([imageID]),
	CONSTRAINT [fk_productID] FOREIGN KEY ([productID]) REFERENCES [products]([productID])
)
GO
print '' print '*** productsImages table  created'
Go
print '' print '*** inserting samples data in productsImages table ***'
GO
INSERT INTO [dbo].[productsImages]
	([productID], [imageUrl])
	VALUES
	('100000', 'http://images.image1')

GO

CREATE TABLE [dbo].[transactions]
(
	[transactionID]	[int]	IDENTITY(100000,1)	NOT NULL,
	[customerID]	[int]	NOT NULL,
	[productID]	[int]	NOT NULL,
	[price]	[nvarchar](255)	NOT NULL,
	[dateOfBuy]	[nvarchar](255)	NOT NULL,
	CONSTRAINT [pk_transactionID] PRIMARY KEY ([transactionID]),
	CONSTRAINT [fk_transactions_customerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers]([CustomerID]),
	CONSTRAINT [fk_transactions_productID] FOREIGN KEY([productID]) REFERENCES [products]([productID])
)
print '' print '*** transactions table  created'
Go


print '' print '*** creating sp_verify_user'
GO
CREATE PROCEDURE [dbo].[sp_verify_user]
(
	@Email		[nvarchar](250),
	@PasswordHash	[nvarchar](100)
)
AS
	BEGIN
		SELECT [EmployeeID],[Email],[PasswordHash]
		FROM [dbo].[Employees]
		WHERE Email = @Email
		AND PasswordHash = @PasswordHash
	END
GO
print '' print '*** creating sp_select_roles_by_employee_id'
GO
CREATE PROCEDURE [dbo].[sp_select_roles_by_employee_id]
(
	@employee_id		[int]
)
AS
	BEGIN
		SELECT [dbo].[Roles].[RoleID]
		FROM [dbo].[Roles]
		INNER JOIN [dbo].[EmployeesRoles] ON [dbo].[Roles].[RoleID] = [dbo].[EmployeesRoles].[RoleID]
		INNER JOIN [dbo].[Employees] ON [dbo].[EmployeesRoles].[EmployeeID] = [dbo].[Employees].[EmployeeID]
		WHERE [dbo].[Employees].[EmployeeID] = @employee_id;		
	END
GO
print '' print '*** creating sp_insert_employee'
GO
CREATE PROCEDURE [dbo].[sp_insert_employee]
(
	@GivenName [nvarchar](50), @FamilyName [nvarchar](50), @PhoneNumber [nvarchar](11), @Email [nvarchar](250), @PasswordHash [nvarchar](100),@Active [bit]
)
AS
	BEGIN
		INSERT INTO [dbo].[Employees]
		(GivenName,FamilyName,PhoneNumber,Email,PasswordHash,Active)	
		VALUES(@GivenName,@FamilyName,@PhoneNumber,@Email,@PasswordHash,@Active)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_select_employees'
GO
CREATE PROCEDURE [dbo].[sp_select_employee]
AS
	BEGIN
		SELECT EmployeeID,GivenName,FamilyName,PhoneNumber,Email,PasswordHash,Active
		FROM [dbo].[Employees]
		WHERE Active = 1
	END
GO
print '' print '*** creating sp_update_employees'
GO
CREATE PROCEDURE [dbo].[sp_update_employee](
@employeeId INT, @GivenName nvarchar(50), @FamilyName nvarchar(50), @PhoneNumber nvarchar(100), @Email nvarchar(250), @PasswordHash nvarchar(100),@Active bit
)
AS
	BEGIN
		UPDATE [dbo].[Employees]
		SET GivenName = @GivenName,
		    FamilyName = @FamilyName,
		    PhoneNumber = @PhoneNumber,
		    Email = @Email,
		    PasswordHash = @PasswordHash,
		    Active = @Active
		WHERE
		    employeeId = @employeeId
		Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_delete_employee'
GO
CREATE PROCEDURE [dbo].[sp_delete_employee](
@employeeId INT
)
AS
	BEGIN
		UPDATE [dbo].[Employees]
		SET Active = 0
		WHERE
		    employeeId = @employeeId
		Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_select_product_images'
GO
CREATE PROCEDURE [dbo].[sp_select_product_images]
AS
	BEGIN
		SELECT  imageID, productID,imageUrl
		FROM [dbo].[productsImages]
	END
GO
print '' print '*** creating sp_select_products'
GO
CREATE PROCEDURE [dbo].[sp_select_products]
AS
	BEGIN
		SELECT  [productID],[productName], [type],[size],[price]
		FROM [dbo].[products]
	END
GO
print '' print '*** creating sp_select_product_sizes'
GO
CREATE PROCEDURE [dbo].[sp_select_product_sizes]
AS
	BEGIN
		SELECT  [productsSizeName], [description]
		FROM [dbo].[productsSizes]
	END
GO
print '' print '*** creating sp_select_product_types'
GO
CREATE PROCEDURE [dbo].[sp_select_product_types]
AS
	BEGIN
		SELECT  [productTypeName], [description]
		FROM [dbo].[productstypes]
	END
GO
print '' print '*** creating sp_insert_product_image'
GO
CREATE PROCEDURE [dbo].[sp_insert_product_image]
(
	@ProductId int, @ImageUrl [nvarchar](255)
)
AS
	BEGIN
		INSERT INTO [dbo].[productsImages]
	([productID], [imageUrl])
	VALUES
	(@ProductId, @ImageUrl)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_insert_product'
GO
CREATE PROCEDURE [dbo].[sp_insert_product]
(
	@ProductName [nvarchar](50), @Type [nvarchar](50), @Size [nvarchar](50), @Price [nvarchar](4)
)
AS
	BEGIN
		INSERT INTO [dbo].[products]
	([productName], [type],[size],[price])
	VALUES
	(@ProductName, @Type,@Size,@Price)

	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_insert_product_type'
GO
CREATE PROCEDURE [dbo].[sp_insert_product_type]
(
	@ProductTypeName [nvarchar](50), @Description [nvarchar](255)
)
AS
	BEGIN
		INSERT INTO [dbo].[productstypes]
	([productTypeName], [description])
	VALUES
	(@ProductTypeName, @Description)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_insert_product_size'
GO
CREATE PROCEDURE [dbo].[sp_insert_product_size]
(
	@ProductsSizeName [nvarchar](4), @Description [nvarchar](255)
)
AS
	BEGIN
		INSERT INTO [dbo].[productsSizes]
	([productsSizeName], [description])
	VALUES
	(@ProductsSizeName, @Description)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_update_product_type'
GO
CREATE PROCEDURE [dbo].[sp_update_product_type]
(
	@ProductTypeName [nvarchar](50), @Description [nvarchar](255)
)
AS
	BEGIN
		UPDATE [dbo].[productstypes]
		SET [productTypeName]= @ProductTypeName, [description]= @Description
		WHERE [productTypeName]= @ProductTypeName
	Return @@ROWCOUNT
	END
GO

print '' print '*** creating  sp_update_product_image'
GO
CREATE PROCEDURE [dbo].[sp_update_product_image]
(
	@ImageID [int], @ProductId [int], @ImageUrl [nvarchar](255)
)
AS
	BEGIN
		UPDATE [dbo].[productsImages]
		SET [productID]= @ProductId, [imageUrl]= @ImageUrl
		WHERE [imageID]= @ImageID
		Return @@ROWCOUNT
	END
GO
print '' print '*** creating  sp_update_product'
GO
CREATE PROCEDURE [dbo].[sp_update_product]
(
	@ProductId [int], @ProductName [nvarchar](50), @Type [nvarchar](50), @Size [nvarchar](50), @Price [nvarchar](4)

)
AS
	BEGIN
		UPDATE [dbo].[products]
		SET [productName]=@ProductName, [type]=@Type,[size]=@Size,[price]=@Price
		WHERE [productID]= @ProductId
		Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_update_product_size'
GO
CREATE PROCEDURE [dbo].[sp_update_product_size]
(
	@ProductsSizeName [nvarchar](50), @Description [nvarchar](255)
)
AS
	BEGIN
		UPDATE [dbo].[productsSizes]
		SET [productsSizeName]= @ProductsSizeName, [description]= @Description
		WHERE [productsSizeName]= @ProductsSizeName
	Return @@ROWCOUNT
	END
GO

print '' print '*** creating sp_select_all_customers'
GO
CREATE PROCEDURE [dbo].[sp_select_all_customers]
AS
	BEGIN
		SELECT [CustomerID],[GivenName], [FamilyName],[PhoneNumber],[Email],[line1],[line2],[zipcode]
		FROM [dbo].[Customers]
	END
GO
print '' print '*** creating sp_insert_customer'
GO
CREATE PROCEDURE [dbo].[sp_insert_customer]
(
	@GivenName [nvarchar](50), @FamilyName [nvarchar](50),@PhoneNumber [nvarchar](11),@Email [nvarchar](250),@line1 [nvarchar](250),@line2 [nvarchar](250),@zipcode [nvarchar](10)
)
AS
	BEGIN
		INSERT INTO [dbo].[Customers]
	([GivenName], [FamilyName],[PhoneNumber],[Email],[line1],[line2],[zipcode])
	VALUES
	(@GivenName, @FamilyName,@PhoneNumber,@Email,@line1,@line2,@zipcode)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_select_all_zipcodes'
GO
CREATE PROCEDURE [dbo].[sp_select_all_zipcodes]
AS
	BEGIN
		SELECT [zipcode],[city], [state]
		FROM [dbo].[Zipcodes]
	END
GO
print '' print '*** creating sp_insert_zipcode'
GO
CREATE PROCEDURE [dbo].[sp_insert_zipcode]
(
	@zipcode [nvarchar](10), @city [nvarchar](50),@state [nvarchar](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[Zipcodes]
	([zipcode], [city],[state])
	VALUES
	(@zipcode, @city,@state)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_insert_customer_credit_card'
GO
CREATE PROCEDURE [dbo].[sp_insert_customer_credit_card]
(
	@CustomerID [int], @CreditCardNumber [nvarchar](50),@zipcode [nvarchar](10),
	@cvv [nvarchar](11),@dateOfExpiration [nvarchar](250),@nameOnTheCard [nvarchar](250)
)
AS
	BEGIN
		INSERT INTO [dbo].[CustomersCreditCards]
	([CustomerID], [CreditCardNumber],[zipcode],[cvv],[dateOfExpiration],[nameOnTheCard])
	VALUES
	(@CustomerID, @CreditCardNumber,@zipcode,@cvv,@dateOfExpiration,@nameOnTheCard)
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_select_customer_credit_card'
GO
CREATE PROCEDURE [dbo].[sp_select_customer_credit_card]
(
	@CustomerID [int]
)
AS
	BEGIN
		SELECT [CustomerID], [CreditCardNumber],[zipcode],[cvv],[dateOfExpiration],[nameOnTheCard]
		 FROM [dbo].[CustomersCreditCards]
		 WHERE [CustomerID] = @CustomerID
	END
GO
print '' print '*** creating sp_update_customer'
GO
CREATE PROCEDURE [dbo].[sp_update_customer]
(
	@CustomerID int,@GivenName [nvarchar](50), @FamilyName [nvarchar](50),@PhoneNumber [nvarchar](11),@Email [nvarchar](250),@line1 [nvarchar](250),@line2 [nvarchar](250),@zipcode [nvarchar](10)
)
AS
	BEGIN
		UPDATE [dbo].[Customers]
		SET [GivenName]=@GivenName, 
			[FamilyName]=@FamilyName,
			[PhoneNumber]= @PhoneNumber,
			[Email]= @Email,
			[line1]= @line1,
			[line2]= @line2,
			[zipcode]= @zipcode
		WHERE [CustomerID] =@CustomerID 
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_update_customer_credit_card'
GO
CREATE PROCEDURE [dbo].[sp_update_customer_credit_card]
(
	@CustomerID [int], @CreditCardNumber [nvarchar](50),@zipcode [nvarchar](10),
	@cvv [nvarchar](11),@dateOfExpiration [nvarchar](250),@nameOnTheCard [nvarchar](250)
)
AS
	BEGIN
		UPDATE [dbo].[CustomersCreditCards]
		SET  [CreditCardNumber]= @CreditCardNumber,
			[zipcode]= @zipcode,
			[cvv]= @cvv,
			[dateOfExpiration]= @dateOfExpiration,
			[nameOnTheCard]= @nameOnTheCard
		WHERE [CustomerID] = @CustomerID
	Return @@ROWCOUNT
	END
GO
print '' print '*** creating sp_insert_transaction'
GO
CREATE PROCEDURE [dbo].[sp_insert_transaction]
(
	@CustomerID [int],@productId [int],@price [nvarchar](50),@dateOfBuy [nvarchar](50)
)
AS
	BEGIN
		INSERT INTO [dbo].[transactions]
		([customerID],[productID],[price],[dateOfBuy])
		VALUES (@CustomerID , @productId, @price, @dateOfBuy)
	END
GO
print '' print '*** creating sp_select_customer_transactions'
GO
CREATE PROCEDURE [dbo].[sp_select_customer_transactions]
(
	@customerID [int]
)
AS
	BEGIN
		SELECT [customerID],[productID],[price],[dateOfBuy]
		FROM	[dbo].[transactions]
		WHERE [customerID] = @customerID
	END
GO