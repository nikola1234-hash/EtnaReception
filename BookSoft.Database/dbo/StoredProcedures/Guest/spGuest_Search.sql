CREATE PROCEDURE [dbo].[spGuest_Search]
	@FirstName varchar(128),
	@LastName varchar(128),
	@Phone varchar(255)
	AS
	BEGIN
		if @FirstName is not null AND @LastName IS NOT NULL
		Begin
		if @Phone is not null
			Begin
				Select * from dbo.Guest 
				where CHARINDEX(@FirstName, FirstName) > 0 
				AND CHARINDEX(@LastName, LastName) > 0
				AND CHARINDEX(@Phone, Phone) > 0;
			End
			Select * from dbo.Guest 
			where CHARINDEX(@FirstName, FirstName) > 0 AND CHARINDEX(@LastName, LastName) > 0
		END
		if @FirstName is not null AND @LastName IS NULL AND @Phone IS NULL
		begin 
			select * from dbo.Guest 
			where CHARINDEX(@FirstName, FirstName) > 0;
		end
	END