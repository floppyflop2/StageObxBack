if exists (select * from sysdatabases where name='StageObx')
		drop database StageObx

CREATE TABLE Companies (
	"CompanyId" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyName" nvarchar (255) NOT NULL ,
	"CompanyCity" nvarchar(30) NOT NULL ,
	"CompanyStreetName" nvarchar(30) NOT NULL ,
	"CompanyPostalCode" int NOT NULL ,
	"CompanyTelephone" nvarchar (20) NOT NULL ,

	CONSTRAINT "PK_Company" PRIMARY KEY  CLUSTERED 
	(
		"CompanyId"
	)

) 

 CREATE  INDEX "CompanyCity" ON "dbo"."Companies"("city")

 CREATE  INDEX "CompanyName" ON "dbo"."Companies"("companyName")

 CREATE  INDEX "CompanyPostalCode" ON "dbo"."Companies"("postalCode")

 

CREATE TABLE Contacts (
	"ContactId" "int" IDENTITY (1, 1) NOT NULL ,
	"ContactName" nvarchar (40) NOT NULL ,
	"ContactFirstname" nvarchar (40) NOT NULL ,
	"ContactTelephone" nvarchar (20) NOT NULL ,
	"ContactEmail" nvarchar (30) NOT NULL ,
	"CompanyId" int NOT NULL,
	
	CONSTRAINT "PK_Contacts" PRIMARY KEY  CLUSTERED 
	(
		"ContactId"
	),
	CONSTRAINT "FK_Company" FOREIGN KEY 
	(
		"CompanyId"
	) REFERENCES "dbo"."Companies" (
		"CompanyId"
	),
) 

CREATE TABLE Internship
(
	"InternshipId" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyId" int,
	"StudentId" int,
	"InternshipYear" datetime,

	CONSTRAINT "FK_Company" FOREIGN KEY 
	(
		"CompanyId"
	) REFERENCES "dbo"."Companies" (
		"CompanyId"
	),

	CONSTRAINT "FK_Student" FOREIGN KEY 
	(
		"StudentId"
	) REFERENCES "dbo"."Students" (
		"StudentId"
	),

) 

CREATE TABLE Students (
	"StudentId" "int" IDENTITY (1, 1) NOT NULL ,
	"StudentName" nvarchar (40) NOT NULL ,
	"StudentFirstName" nvarchar (40) NOT NULL ,
	"StudentDepartement" nvarchar(5) NOT NULL ,
	"StudentTelephone" nvarchar (20) NOT NULL ,
	"StudentEmail" nvarchar (30) NOT NULL ,
	"StudentDocument" varbinary(MAX),

	CONSTRAINT "PK_Students" PRIMARY KEY  CLUSTERED 
	(
		"StudentId"
	)
) 
