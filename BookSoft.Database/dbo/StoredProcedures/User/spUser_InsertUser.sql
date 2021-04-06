CREATE PROCEDURE [dbo].[spUser_InsertUser]
	@FirstName varchar(155),
	@LastName varchar(155),
	@Email varchar(255),
	@Username varchar(155),
	@Password varchar(255),
	@Created date,
	@Updated date,
	@CompanyId int
	AS
	BEGIN
		if not exists(select * from dbo.UserAccount where Username = @Username)
		BEGIN
			insert into dbo.UserAccount(FirstName, LastName, Email, Username, [Password], Created, Updated, CompanyId)
			VALUES (@FirstName, @LastName, @Email, @Username, @Password, @Created, @Updated, @CompanyId)
		END
	END