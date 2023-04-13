CREATE TABLE [dbo].[Customer] (
    [CustomerID] INT IDENTITY (1,1)  NOT NULL,
    [BranchID]   INT          NULL,
    [FirstName]  VARCHAR (50) NOT NULL,
    [LastName]   VARCHAR (50) NOT NULL,
    [DOB]        DATE         NOT NULL,
    [StreetNo]   VARCHAR (50) NOT NULL,
    [StreetName] VARCHAR (50) NOT NULL,
    [City]       VARCHAR (50) NOT NULL,
    [Province]   VARCHAR (50) NOT NULL,
    [PostalCode] VARCHAR (6)  NOT NULL,
    [Country]    VARCHAR (50) NOT NULL,
    [PhoneNo]    VARCHAR (50) NOT NULL,
    [Email]      VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);
SELECT SCOPE_IDENTITY() FROM Customer;

