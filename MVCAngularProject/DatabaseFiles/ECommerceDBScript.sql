CREATE TABLE Users (
[UserId]	   INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[UserName]     VARCHAR(55) NOT NULL,
[Email]		   VARCHAR(100) UNIQUE NOT NULL,
[Password]     VARCHAR(55) NOT NULL,
[Name]		   VARCHAR(55) NOT NULL,
[Address]	   VARCHAR(255) NOT NULL,
[ContactNo]    VARCHAR(10) NOT NULL,
[CreateDate]   DATETIME NOT NULL,
[UpdateDate]   DATETIME
)

CREATE TABLE Roles (
[RoleId]		INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[Name]			VARCHAR(30) NOT NULL,
[Description]   VARCHAR(55) NOT NULL,
[CreateDate]	DATETIME NOT NULL,
[UpdateDate]	DATETIME
)

--A User can have many roles like Admin Role, Sub-Admin Role etc so between User and Roles there is a many to many relationship
--which we are managing by creating another table UserRoles
CREATE TABLE UserRoles (
[UserRoleId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[UserId]	 INT FOREIGN KEY REFERENCES Users(UserId),
[RoleId]	 INT FOREIGN KEY REFERENCES Roles(RoleId)
)

--One to Many relationship between Category and Product
--A single category can have multiple products but a product cannot belong to more than one category
CREATE TABLE Categories (
[CategoryID]   INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[CategoryName] VARCHAR(55) NOT NULL,
[Description]  VARCHAR(255) NOT NULL,
[CreateDate]   DATETIME NOT NULL,
[UpdateDate]   DATETIME
);


CREATE TABLE Products (
[ProductID]    INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[CategoryID]   INT FOREIGN KEY REFERENCES Categories(CategoryID),
[Name]		   VARCHAR(55)  NOT NULL,
[Description]  VARCHAR(MAX) NOT NULL,
[UnitPrice]    DECIMAL(10,2) CHECK ([UnitPrice] > 0)  DEFAULT 0,
[ImageName]    VARCHAR(55)  NOT NULL,
[ImagePath]    VARCHAR(500) NOT NULL, -- VARBINARY(MAX) NOT NULL,
[CreateDate]   DATETIME NOT NULL,
[UpdateDate]   DATETIME
);

-- A single user can add more than one item into the shopping cart
-- Also whatever data we are storing in Carts, the same we need to store in Transactions table
-- because that Carts table will definitely have the User transaction status if the user has done the checkout
CREATE TABLE Carts (
[CartId]        INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[UserId]		INT FOREIGN KEY REFERENCES Users(UserId),
[Total]         DECIMAL(10,2) NOT NULL,
[CreateDate]	DATETIME NOT NULL,
[UpdateDate]	DATETIME
);

--It's like a ShoppingCart which is displayed on the UI
CREATE TABLE CartItems (
[CartItemId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[ProductId]  INT FOREIGN KEY REFERENCES Products(ProductId),
[CartId]     INT FOREIGN KEY REFERENCES Carts(CartId),
[UnitPrice]  DECIMAL(10,2) CHECK ([UnitPrice] > 0)  DEFAULT 0,
[Quantity]   INT NOT NULL,
[Total]      INT NOT NULL
);

-- We will send CartItems/ShoppingCart information to the PaymentGateway and from PaymentGateway we will get the Transaction Status
-- Also Whatever Carts table we are storing, the same we are storing in Transaction table
--because that Carts table will definitely have the Users transaction status if the user has done the checkout
CREATE TABLE Transactions (
[Id]			  INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[TransactionId]   VARCHAR(30) NOT NULL,
[UserId]		  INT FOREIGN KEY REFERENCES Users(UserId),
[CartId]          INT FOREIGN KEY REFERENCES Carts(CartId),
[PaymentId]		  VARCHAR(30) NOT NULL,
[Status]		  VARCHAR(8)  NOT NULL,
[PaymentType]	  VARCHAR(20)  NOT NULL,
[Amount]		  DECIMAL(10,2) NOT NULL,
[CreateDate]      DATETIME NOT NULL,
[UpdateDate]      DATETIME
);

CREATE TABLE Orders (
[OrderId]		   INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[CartId]           INT FOREIGN KEY REFERENCES Carts(CartId),
[UserId]		   INT FOREIGN KEY REFERENCES Users(UserId),
[Customer]		   VARCHAR(50) NOT NULL,
[ShippingAddress]  VARCHAR(100) NOT NULL,
[ContactNo]		   VARCHAR(8)  NOT NULL,
[Total]            DECIMAL(10,2) NOT NULL,
[Status]		   VARCHAR(8)  NOT NULL,
[CreateDate]       DATETIME NOT NULL,
[UpdateDate]       DATETIME
);

-- A single Order can have multiple OrderItems
CREATE TABLE OrderItems (
[OrderItemId] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
[OrderId]     INT FOREIGN KEY REFERENCES Orders(OrderId),
[ProductId]   INT FOREIGN KEY REFERENCES Products(ProductId),
[UnitPrice]   DECIMAL(10,2) CHECK ([UnitPrice] > 0)  DEFAULT 0 NOT NULL ,
[Quantity]    INT NOT NULL,
[Total]       INT NOT NULL
);  