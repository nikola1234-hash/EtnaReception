CREATE PROCEDURE [dbo].[spStayType_GetById]
	@id int
	AS
	BEGIN
		Select * from dbo.StayType where Id = @id;
	END
