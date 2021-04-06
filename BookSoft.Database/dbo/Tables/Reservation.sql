CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[GuestId] int not null,
	[StartDate] date not null, 
    [EndDate] DATE NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [Updated] DATETIME NOT NULL, 
    [DiscountPercent] DECIMAL(5, 2) NOT NULL, 
    [TotalPrice] DECIMAL(10, 2) NOT NULL, 
    CONSTRAINT [FK_Reservation_ToGuest] FOREIGN KEY (GuestId) REFERENCES Guest(Id)
)
