CREATE PROCEDURE [dbo].[spCompany_GetCompany]
	@id int
	AS
	BEGIN
		select * from dbo.Company where Id = @id;
	END