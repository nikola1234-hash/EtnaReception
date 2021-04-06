CREATE PROCEDURE [dbo].[spUser_GetByUsername]
	@username varchar(155)
	AS
	BEGIN
		select * from dbo.UserAccount where Username = @username;
	END