CREATE TABLE [dbo].[Reservation_Status_Event]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ReservationId] int not null,
	[StatusId] int not null,
	[Details] text ,
	[Created] DATETIME not null, 
    CONSTRAINT [FK_Reservation_Status_Event_ToStatus] FOREIGN KEY (StatusId) REFERENCES Status_Catalog(Id), 
    CONSTRAINT [FK_Reservation_Status_Event_ToReservation] FOREIGN KEY (ReservationId) REFERENCES Reservation(Id) 
)
