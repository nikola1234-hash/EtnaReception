CREATE TABLE [dbo].[Hotel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[HotelName] varchar(128) not null,
	[Description] text null,
	[CompanyId] int not null,
	[CityId] int not null,
	[IsActive] bit not null default 0, 
    CONSTRAINT [FK_hotel_ToCompany] FOREIGN KEY ([CompanyId]) REFERENCES Company([Id]), 
    CONSTRAINT [FK_hotel_ToCity] FOREIGN KEY ([CityId]) REFERENCES City([Id])
)
