/*
	Sample script to populate a dummy database, with legacy naming conventions for demonstration with Entity Framework
	
	Copyright: 2017 Mitchel Sellers
*/

CREATE TABLE dbo.tblCustomer(
	pkCustId INT IDENTITY(1,1) PRIMARY KEY,
	strCustName VARCHAR(50),
	strCustEmail VARCHAR(255),
	dteBirthdate DATETIME)
GO

CREATE TABLE dbo.tblCustomerAddresses(
	pkCAddId INT IDENTITY(1,1) PRIMARY KEY,
	fkCustId INT NOT NULL,
	strCAddStreet VARCHAR(50),
	strCAddCity VARCHAR(100),
	strCAddState CHAR(2),
	strCAddPostalCode CHAR(5)
)
GO

ALTER TABLE dbo.tblCustomerAddresses
	ADD CONSTRAINT FK_tblCustomerAddresses_tblCustomer 
		FOREIGN KEY (fkCustId) REFERENCES tblCustomer (pkCustId)
GO

CREATE TABLE dbo.tblOtherData(
	pkOtherId INT IDENTITY(1,1),
	strOtherName VARCHAR(500)
)
GO

/* 
	Load some dummy data
*/
INSERT INTO dbo.tblCustomer(strCustName, strCustEmail, dteBirthdate)
VALUES ('Test Customer', 'test@test.com', '1/1/1990')
INSERT INTO dbo.tblCustomer(strCustName, strCustEmail, dteBirthdate)
VALUES ('Secondary Person', 'joe@user.com', '5/1/1989')
INSERT INTO dbo.tblCustomer(strCustName, strCustEmail, dteBirthdate)
VALUES ('William Jones', 'bill@jones.com', '4/8/1972')
INSERT INTO dbo.tblCustomer(strCustName, strCustEmail, dteBirthdate)
VALUES ('Tommy Smith', 'tom@smith.com', '11/14/1964')
GO

INSERT INTO dbo.tblCustomerAddresses (fkCustId, strCAddStreet, strCAddCity, strCAddState, strCAddPostalCode)
SELECT C.pkCustId, '123 Main Street', 'Anytown', 'IA', '55511'
FROM dbo.tblCustomer C
WHERE C.strCustName = 'Test Customer'
GO


	