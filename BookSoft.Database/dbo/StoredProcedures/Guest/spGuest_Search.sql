CREATE PROCEDURE [dbo].[spGuest_Search]
	@FirstName varchar(128),
	@LastName varchar(128),
	@Phone varchar(255)
	AS
	BEGIN
		Select * 
		from dbo.Guest 
		WHERE FirstName LIKE @FirstName + '%'
		OR FirstName LIKE @FirstName +'%' AND LastName Like @LastName +'%'
		OR FirstName LIKE @FirstName +'%' AND LastName Like @LastName +'%' AND Phone Like @Phone +'%' ;
	END