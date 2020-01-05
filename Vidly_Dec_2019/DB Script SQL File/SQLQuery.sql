
CREATE TABLE MembershipTypes 
(
    Id int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(255) ,
    SignUpFee int,
    DurationInMonths int,
    DiscountRate int 
);


CREATE TABLE Customers (
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255) NOT NULL,
    IsSubscribedToNewsletter bit NOT NULL,
    BirthDate datetime ,
	MembershipTypeId int FOREIGN KEY REFERENCES MembershipTypes(Id) NOT NULL
);




INSERT INTO [dbo].[MembershipTypes]
           ([Name]
           ,[SignUpFee]
           ,[DurationInMonths]
           ,[DiscountRate])
     VALUES
           ('Pay As You Go'
           ,0
           ,6
           ,0
		   )

		   INSERT INTO [dbo].[MembershipTypes]
           ([Name]
           ,[SignUpFee]
           ,[DurationInMonths]
           ,[DiscountRate])
     VALUES
           ('Monthly'
           ,300
           ,1
           ,10
		   )


		   INSERT INTO [dbo].[MembershipTypes]
           ([Name]
           ,[SignUpFee]
           ,[DurationInMonths]
           ,[DiscountRate])
     VALUES
           ('Quarterly'
           ,600
           ,3
           ,20
		   )


		   INSERT INTO [dbo].[MembershipTypes]
           ([Name]
           ,[SignUpFee]
           ,[DurationInMonths]
           ,[DiscountRate])
     VALUES
           ('Annualy'
           ,1200
           ,12
           ,30
		   )

GO


INSERT INTO [dbo].[Customers]
           ([Name]
           ,[IsSubscribedToNewsletter]
           ,[BirthDate]
           ,[MembershipTypeId])
     VALUES
           ('Rachit Srivastava'
           ,1
           ,CURRENT_TIMESTAMP--CONVERT(datetime, '19-04-1993', 101)
           ,4
		   )
		   



CREATE TABLE Genres (
    Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name varchar(255) NOT NULL
)


INSERT INTO [dbo].[Genres]
           ([Name])
     VALUES
           ('Romance')

INSERT INTO [dbo].[Genres]
           ([Name])
     VALUES
           ('Comedy')

		   INSERT INTO [dbo].[Genres]
           ([Name])
     VALUES
           ('Horror')

		   INSERT INTO [dbo].[Genres]
           ([Name])
     VALUES
           ('SciFi')
		   



CREATE TABLE Movies (
    Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Name varchar(255) NOT NULL,
    GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
    DateAdded datetime ,
	ReleaseDate datetime,
	NumberInStock INT
	--MembershipTypeId int  NOT NULL
);


USE [Vidly]
GO

INSERT INTO [dbo].[Movies]
           ([Name]
           ,[GenreId]
           ,[DateAdded]
           ,[ReleaseDate]
           ,[NumberInStock])
     VALUES
           ('Enter The Dragon'
           ,1
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP
           ,10
		   )


INSERT INTO [dbo].[Movies]
           ([Name]
           ,[GenreId]
           ,[DateAdded]
           ,[ReleaseDate]
           ,[NumberInStock])
     VALUES
           ('PS I Love You'
           ,2
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP
           ,10
		   )

INSERT INTO [dbo].[Movies]
           ([Name]
           ,[GenreId]
           ,[DateAdded]
           ,[ReleaseDate]
           ,[NumberInStock])
     VALUES
           ('Rush Hour'
           ,3
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP
           ,10
		   )

INSERT INTO [dbo].[Movies]
           ([Name]
           ,[GenreId]
           ,[DateAdded]
           ,[ReleaseDate]
           ,[NumberInStock])
     VALUES
           ('The Grudge'
           ,4
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP
           ,10
		   )

		   INSERT INTO [dbo].[Movies]
           ([Name]
           ,[GenreId]
           ,[DateAdded]
           ,[ReleaseDate]
           ,[NumberInStock])
     VALUES
           ('Star Trek'
           ,5
           ,CURRENT_TIMESTAMP
           ,CURRENT_TIMESTAMP
           ,10
		   )

GO
