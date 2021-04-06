CREATE PROCEDURE [dbo].[spCompany_GetActiveCompany]
	AS
	BEGIN
		select * from dbo.Company where IsActive = 1
	END
