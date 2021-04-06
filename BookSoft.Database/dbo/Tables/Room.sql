CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RoomNumber] varchar(128) NOT NULL,
	[CapacityId] int not null,
	[HotelId] int not null,
	[RoomTypeId] int not null, 
    CONSTRAINT [FK_Room_ToCapacity] FOREIGN KEY (CapacityId) REFERENCES RoomCapacity(Id), 
    CONSTRAINT [FK_Room_ToHotel] FOREIGN KEY (HotelId) REFERENCES Hotel(Id), 
    CONSTRAINT [FK_Room_ToRoomType] FOREIGN KEY (RoomTypeId) REFERENCES RoomType(Id) 
)
