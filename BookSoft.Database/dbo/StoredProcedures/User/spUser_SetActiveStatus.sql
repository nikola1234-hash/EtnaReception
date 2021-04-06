CREATE PROCEDURE [dbo].[spUser_SetActiveStatus]
	@id int,
	@isActive bit
	AS
	BEGIN
		UPDATE dbo.UserAccount set IsActive = @isActive where Id = @id;
	END