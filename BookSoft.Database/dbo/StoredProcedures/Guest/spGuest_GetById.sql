CREATE PROCEDURE [dbo].[spGuest_GetById]
	@Id int
	AS

	BEGIN
		SELECT * FROM dbo.Guest where Id = @Id;
	END