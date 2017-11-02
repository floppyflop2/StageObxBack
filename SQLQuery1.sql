﻿if exists (select * from sysdatabases where name='StageObx')
		drop database StageObx

CREATE TABLE Companies (
	"CompanyId" "int" IDENTITY (1, 1) NOT NULL ,
	"companyName" nvarchar (255) NOT NULL ,
	"city" nvarchar(30) NOT NULL ,
	"streetname" nvarchar(30) NOT NULL ,
	"postal_code" int NOT NULL ,
	"companyTelephone" nvarchar (20) NOT NULL ,

	CONSTRAINT "PK_Company" PRIMARY KEY  CLUSTERED 
	(
		"CompanyId"
	)

) 

 CREATE  INDEX "City" ON "dbo"."Companies"("city")

 CREATE  INDEX "CompanyName" ON "dbo"."Companies"("companyName")

 CREATE  INDEX "PostalCode" ON "dbo"."Companies"("postalCode")

 

CREATE TABLE Contacts (
	"ContactId" "int" IDENTITY (1, 1) NOT NULL ,
	"contactName" nvarchar (40) NOT NULL ,
	"contactSurname" nvarchar (40) NOT NULL ,
	"contactTelephone" nvarchar (20) NOT NULL ,
	"contactEmail" nvarchar (30) NOT NULL ,
	"CompanyId" int NOT NULL,
	
	CONSTRAINT "PK_Contacts" PRIMARY KEY  CLUSTERED 
	(
		"ContactId"
	),
	CONSTRAINT "FK_Company" FOREIGN KEY 
	(
		"CompanyID"
	) REFERENCES "dbo"."Companies" (
		"CompanyID"
	),
) 

CREATE TABLE Internship
(
	"InternshipId" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyId" int,
	"StudentId" int,
	"year" datetime,

	CONSTRAINT "FK_Company" FOREIGN KEY 
	(
		"CompanyID"
	) REFERENCES "dbo"."Companies" (
		"CompanyID"
	),

	CONSTRAINT "FK_Student" FOREIGN KEY 
	(
		"StudentID"
	) REFERENCES "dbo"."Students" (
		"StudentID"
	),

) 

CREATE TABLE Students (
	"StudentId" "int" IDENTITY (1, 1) NOT NULL ,
	"StudentName" nvarchar (40) NOT NULL ,
	"Studentsurname" nvarchar (40) NOT NULL ,
	"departement" nvarchar(5) NOT NULL ,
	"Studenttelephone" nvarchar (20) NOT NULL ,
	"Studentemail" nvarchar (30) NOT NULL ,
	"document" varbinary(MAX),

	CONSTRAINT "PK_Students" PRIMARY KEY  CLUSTERED 
	(
		"StudentId"
	)
) 
