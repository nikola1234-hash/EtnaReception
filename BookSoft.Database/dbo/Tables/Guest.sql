CREATE TABLE [dbo].[Guest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] varchar(128) not null,
	[LastName] varchar(128) not null,
	[Email] varchar(255) null,
	[Phone] varchar(255) null,
	[Address] varchar(255) null,
	[Details] text null
)
