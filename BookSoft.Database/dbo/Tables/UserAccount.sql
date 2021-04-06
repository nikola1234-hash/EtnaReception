CREATE TABLE [dbo].[UserAccount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(128) NOT NULL, 
    [LastName] VARCHAR(128) NOT NULL, 
    [Email] VARCHAR(255) NOT NULL, 
    [Username] VARCHAR(255) NOT NULL, 
    [Password] VARCHAR(255) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [Created] DATETIME NOT NULL, 
    [Updated] DATETIME NOT NULL, 
    [CompanyId] INT NOT NULL, 
    CONSTRAINT [FK_user_account_ToCompany] FOREIGN KEY ([CompanyId]) REFERENCES Company([Id])
)
