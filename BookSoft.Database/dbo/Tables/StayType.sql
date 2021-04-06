CREATE TABLE [dbo].[StayType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] varchar(128) not null,
	[Price] decimal(10,2) not null
)
