CREATE PROCEDURE [dbo].[spCompany_SetInactive]
	@id int
	AS
	BEGIN
		UPDATE dbo.Company Set IsActive = 0 where Id = @id;
	END