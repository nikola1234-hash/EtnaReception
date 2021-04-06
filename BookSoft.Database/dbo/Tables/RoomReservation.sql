CREATE TABLE [dbo].[RoomReservation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ReservationId] int not null,
	[RoomId] int not null,
	[Persons] int not null,
	[StayTypeId] int not null, 
    CONSTRAINT [FK_RoomReservation_ToRoom] FOREIGN KEY (RoomId) REFERENCES Room(Id), 
    CONSTRAINT [FK_RoomReservation_ToReservation] FOREIGN KEY (ReservationId) REFERENCES Reservation(Id), 
    CONSTRAINT [FK_RoomReservation_ToStayType] FOREIGN KEY (StayTypeId) REFERENCES StayType(Id)
)
