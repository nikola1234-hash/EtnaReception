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

GO

CREATE TRIGGER [dbo].[Trigger_Reservation]
    ON [dbo].[Reservation]
    FOR INSERT
    AS
    BEGIN
    IF(ROWCOUNT_BIG() = 0)
    RETURN;
        SET NoCount ON
        declare @reservationId int;

        Select @reservationId = i.Id from inserted as i;

        insert into dbo.Reservation_Status_Event(ReservationId, Created, StatusId)
        VALUES (@reservationId, GETDATE(), 1);
    END