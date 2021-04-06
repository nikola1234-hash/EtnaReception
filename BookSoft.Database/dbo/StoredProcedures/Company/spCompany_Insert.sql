CREATE PROCEDURE [dbo].[spCompany_Insert]
	@companyName varchar(255),
	@email varchar(255),
	@companyAddress varchar(255),
	@details varchar(255),
	@cityId int
	AS
	BEGIN
	if not exists(select * from dbo.Company where CompanyName = @companyName)
		BEGIN
			insert into dbo.Company (CompanyName, CompanyAddress, CityId, Email, Details)
			VALUES (@companyName, @companyAddress, @cityId, @email, @details)
		END

	END