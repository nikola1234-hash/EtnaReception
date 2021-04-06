CREATE TABLE [dbo].[Company]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyName] VARCHAR(255) not null,
	[Email] VARCHAR(255) not null,
	[CityId] int not null,
	[CompanyAddress] varchar(255) not null, 
	[Details] text null,
	[IsActive] bit not null default 1, 
    CONSTRAINT [FK_Company_ToCity] FOREIGN KEY (CityId) REFERENCES City(Id)
)
