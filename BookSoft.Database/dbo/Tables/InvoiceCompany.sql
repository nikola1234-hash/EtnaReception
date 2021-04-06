CREATE TABLE [dbo].[InvoiceCompany]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CompanyId] int not null,
	[InvoiceAmount] decimal(10, 2) not null,
	[InvoicePeriod] varchar(255) not null,
	[InvoiceDetails] text NOT NULL, 
    [Issued] DATETIME NOT NULL, 
    [Paid] DATETIME NULL, 
    [Canceled] DATETIME NULL, 
    CONSTRAINT [FK_InvoiceCompany_ToCompanyId] FOREIGN KEY (CompanyId) REFERENCES Company(Id) 

)
