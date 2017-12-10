Drop table contracts
Drop table companies
Drop table students

CREATE TABLE Students
(StudentId int NOT NULL IDENTITY(1,1),
StudentName varchar(255) NOT NULL,
StudentFirstname varchar(255) NOT NULL,
StudentDepartement varchar(255) NOT NULL,
StudentEmail varchar(255) NOT NULL,
StudentDocument varchar(max),
AspNetUserId nvarchar(128) NOT NULL,
CONSTRAINT PK_StudentId PRIMARY KEY NONCLUSTERED (StudentId),     
CONSTRAINT FK_AspNetUsers FOREIGN KEY (AspNetUserId)     
    REFERENCES AspNetUsers (Id),     
UNIQUE (StudentEmail))

CREATE TABLE Companies
(CompanyId int NOT NULL IDENTITY(1,1),
CompanyName varchar(255) NOT NULL,
CompanyCity varchar(255) NOT NULL,
CompanyStreetName varchar(255) NOT NULL,
CompanyPostalCode varchar(255) NOT NULL,
CompanyTelephone varchar(255) NOT NULL,
StudentId int NOT NULL,
CONSTRAINT PK_CompanyId PRIMARY KEY NONCLUSTERED (CompanyId),     
CONSTRAINT FK_StudentId FOREIGN KEY (StudentId)     
    REFERENCES Students (StudentId))

CREATE TABLE Contracts
(ContractId int NOT NULL IDENTITY(1,1),
ContractName varchar(255) NOT NULL,
ContractSupervisorName varchar(255) NOT NULL,
ContractSupervisorFirstName varchar(255) NOT NULL,
ContractSupervisorMail varchar(255) NOT NULL,
ContractSupervisorPhone varchar(255) NOT NULL,
ContractAddressStreet varchar(255) NOT NULL,
ContractAddressNumber varchar(255) NOT NULL,
ContractAddressBox varchar(255) NOT NULL,
ContractAddressPostalCode varchar(255) NOT NULL,
ContractAddressCity varchar(255) NOT NULL,
ContractSubject varchar(255) NOT NULL,
ContractModality varchar(255) NOT NULL,
ContractContactTitle varchar(255) NOT NULL,
ContractContactName varchar(255) NOT NULL,
ContractPhone varchar(255) NOT NULL,
ContractOptionnalInstruction varchar(255) NOT NULL,
ContractArrivalTime varchar(255) NOT NULL,
ContractNotes varchar(255) NOT NULL,
StudentId int NOT NULL,
CONSTRAINT PK_ContractId PRIMARY KEY NONCLUSTERED (ContractId),     
CONSTRAINT FK_StudentIdContract FOREIGN KEY (StudentId)     
    REFERENCES Students (StudentId))



