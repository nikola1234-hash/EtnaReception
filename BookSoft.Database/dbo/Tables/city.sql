CREATE TABLE [dbo].[City]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CityName] varchar(128) not null,
	[CountryId] int not null, 
    CONSTRAINT [FK_city_ToCountry] FOREIGN KEY ([CountryId]) REFERENCES Country([Id])
)
