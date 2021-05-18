CREATE PROCEDURE [dbo].[spScheduler_LoadStatusById]
	@id int
	AS

	BEGIN
		SELECT * from dbo.Status_Catalog where Id = @id;
	END