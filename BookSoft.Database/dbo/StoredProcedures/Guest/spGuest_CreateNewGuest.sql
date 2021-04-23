CREATE PROCEDURE [dbo].[spGuest_CreateNewGuest]
	@FirstName varchar(128),
	@LastName varchar(128),
	@Email varchar(255),
	@Phone varchar(255),
	@Address varchar(255),
	@Details text,
	@Jmbg varchar(255)
	AS
	BEGIN
		if not exists(select 1 from dbo.Guest 
		where FirstName = @FirstName
		AND LastName = @LastName
		AND Phone = @Phone)
		BEGIN
			insert into dbo.Guest(FirstName, LastName, [Address], Phone, Details, Email, Jmbg)
			VALUES
			(@FirstName, @LastName, @Address, @Phone, @Details, @Email, @Jmbg)

			Select * from dbo.Guest where Id = @@IDENTITY;
		END
		RETURN 0;
	END