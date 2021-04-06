CREATE TABLE [dbo].[Invoice_Guest]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[GuestId] int not null,
	[ReservationId] int not null,
	[InvoiceAmount] decimal(10,2) not null,
	[Issued] DATETIME not null,
	[Paid] DATETIME null,
	[Canceled] DATETIME null, 
    CONSTRAINT [FK_Invoice_Guest_ToGuest] FOREIGN KEY (GuestId) REFERENCES Guest(Id), 
    CONSTRAINT [FK_Invoice_Guest_ToReservation] FOREIGN KEY (ReservationId) REFERENCES Reservation(Id)
)
