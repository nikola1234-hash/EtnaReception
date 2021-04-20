CREATE PROCEDURE [dbo].[spGuest_Search]
	@FirstName varchar(155),
	@LastName varchar(155),
	@Jmbg varchar(255),
	@Address varchar(255),
	@Phone varchar(255)
	AS
	BEGIN
		Select * 
		from dbo.Guest 
		WHERE Contains(FirstName, @FirstName)
		OR Contains(FirstName,@FirstName) AND Contains(LastName, @LastName)
		OR Contains(FirstName,@FirstName) AND Contains(LastName, @LastName) AND Contains([Address], @Address)
		OR Contains(Phone, @Phone);
	END