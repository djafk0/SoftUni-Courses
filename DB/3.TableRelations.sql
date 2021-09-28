--01. One-To-One Relationship

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	PassportNumber VARCHAR(50) NOT NULL
)

CREATE TABLE Persons 
(
	PersonID INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	Salary FLOAT NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES [Passports]([PassportID])
)

INSERT INTO Passports (PassportNumber)
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

--02. One-To-Many Relationship

CREATE TABLE [Manufacturers]
(
	[ManufacturerID] INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[EstablishedOn] DATE NOT NULL
)

CREATE TABLE [Models]
(
	[ModelID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID]) NOT NULL
)

INSERT INTO [Manufacturers] ([Name], [EstablishedOn])
	VALUES
		('BMW', '07/03/1916'),
		('Tesla', '01/01/2003'),
		('Lada', '01/05/1966')

INSERT INTO [Models] ([Name], [ManufacturerID])
	VALUES
		('X1', 1),
		('i6', 1),
		('Model S', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3)

--03. Many-To-Many Relationship

CREATE TABLE [Students]
(
	[StudentID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Exams] 
(
	[ExamID] INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL,
	PRIMARY KEY ([StudentID], [ExamID])
)

INSERT INTO [Students] ([StudentID], [Name])
	VALUES
		(1, 'Mila'),
		(2, 'Toni'),
		(3, 'Ron')

INSERT INTO [Exams] ([ExamID], [Name])
	VALUES
		(101, 'SpringMVC'),
		(102, 'Neo4j'),
		(103, 'Oracle 11g')


INSERT INTO [StudentsExams] ([StudentID],[ExamID])
	VALUES
		(1,101),
		(1,102),
		(2,101),
		(3,103),
		(2,102),
		(2,103)

--04. Self-Referencing

CREATE TABLE [Teachers]
(
	[TeacherID] INT PRIMARY KEY IDENTITY(101,1) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers] ([Name], [ManagerID])
	VALUES
		('John', NULL),
		('Maya', 106),
		('Silvia', 106),
		('Ted', 105),
		('Mark', 101),
		('Greta', 101)

--05. Online Store Database

CREATE TABLE ItemTypes
(
	[ItemTypeID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	[ItemID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE Cities
(
	[CityID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	[CustomerID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Birthday] DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL
)

CREATE TABLE Orders 
(
	[OrderID] INT PRIMARY KEY,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

CREATE TABLE OrderItems
(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID])  NOT NULL
	PRIMARY KEY ([OrderID], [ItemID])
)

--06. University Database

CREATE TABLE Majors
(
	[MajorID] INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	[StudentID] INT PRIMARY KEY,
	[StudentNumber] INT UNIQUE NOT NULL,
	[StudentName] VARCHAR(50) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID]) NOT NULL
)

CREATE TABLE Payments
(
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAccount] VARCHAR(50) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL
)

CREATE TABLE Subjects
(
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE Agenda
(
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]) NOT NULL,
	PRIMARY KEY ([StudentID], [SubjectID])
)

--09. *Peaks in Rila

SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
FROM Peaks
INNER JOIN Mountains ON Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Peaks.Elevation DESC

