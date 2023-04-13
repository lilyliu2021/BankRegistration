CREATE TABLE [dbo].[Customers]
(
	[CustomerID] INT NOT NULL PRIMARY KEY, 
    [BranchID] VARCHAR(50) NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL, 
    [StreetNo] VARCHAR(50) NOT NULL, 
    [StreetName] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [Province] VARCHAR(50) NOT NULL, 
    [PostalCode] VARCHAR(50) NOT NULL, 
    [Country] NCHAR(10) NOT NULL, 
    [PhoneNo] NCHAR(10) NOT NULL, 
    [Email] NCHAR(10) NOT NULL
)
GO
