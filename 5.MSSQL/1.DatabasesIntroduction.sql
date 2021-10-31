--04. Insert Records in Both Tables

INSERT INTO [Towns] ([Id], [Name]) VALUES
(1,	'Sofia'),
(2,	'Plovdiv'),
(3,	'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId]) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--07. Create Table People

CREATE TABLE People
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARCHAR(MAX),
	[Height] FLOAT,
	[Weight] FLOAT,
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)


INSERT INTO People ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
 VALUES 
 ('asdgagsd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', 1.62, 55.2, 'm', '2000-12-1', 'asgfwewqwqdasd'),
 ('asdsasaddgagsd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', 1.62, 55.2, 'f', '2002-1-1', 'ahwefasdv'),
 ('asdgagsagsdd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', 1.62, 55.2, 'f', '2001-2-5', 'asfhdgewf'),
 ('asdgagasdgfsd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', 1.62, 55.2, 'm', '2005-6-10', 'adhfagsfewafsd'),
 ('asdgagasdfsd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', 1.62, 55.2, 'f', '2012-7-6', 'agsdaew')

 --08. Create Table Users

 CREATE TABLE Users
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARCHAR(MAX),
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT
)

INSERT INTO Users ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
 VALUES 
 ('asdasdf', 'asdasdf', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', '2021/3/1', 0),
 ('asdf', 'asdf', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', '2021/3/1', 0),
 ('fva', 'asdfgadsgd', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', '2021/12/31', 0),
 ('asdfgasd', 'asdagsdgdsf', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', '2021/9/12', 0),
 ('adsggdsagsda', 'asadsggdsgdf', 'http://www.coogfans.com/uploads/db5902/original/3X/8/1/81173237ffa580ef710b0862fdddaac163274db1.jpeg', '2050/3/17', 0)

 --13. Movies Database

 CREATE TABLE Directors
(
	[Id] INT IDENTITY,
	[DirectorName] NVARCHAR(30),
	[Notes] NVARCHAR(30)
)

CREATE TABLE Genres
(
	[Id] INT IDENTITY,
	[GenreName] NVARCHAR(30),
	[Notes] NVARCHAR(30)
)
CREATE TABLE Categories
(
	[Id] INT IDENTITY,
	[CategoryName] NVARCHAR(30),
	[Notes] NVARCHAR(30)
)
CREATE TABLE Movies
(
	[Id] INT IDENTITY,
	[Title] NVARCHAR(30),
	[DirectorId] INT,
	[CopyrightYear] DATETIME2,
	[Length] INT,
	[Genreld] NVARCHAR(30),
	[CategoryId] INT,
	[Rating] FLOAT,
	[Notes] NVARCHAR(30)
)

ALTER TABLE Directors
ADD CONSTRAINT PK_Director
PRIMARY KEY (Id)

ALTER TABLE Genres
ADD CONSTRAINT PK_Genre
PRIMARY KEY (Id)

ALTER TABLE Categories
ADD CONSTRAINT PK_Category
PRIMARY KEY (Id)

ALTER TABLE Movies
ADD CONSTRAINT PK_Movie
PRIMARY KEY (Id)

INSERT INTO Directors (DirectorName, Notes)
VALUES
('asdqwf', 'agswea'),
('asgssadfdaf', 'qfsdsaqdaf'),
('asgasfdsdaf', 'qfsxzcwdaf'),
('asgzcxvsdaf', 'qfsasdsdaf'),
('asfsdagsdaf', 'qfsqzwddaf')


INSERT INTO Genres (GenreName, Notes)
VALUES
('agwaefds', 'ahwaeafsd'),
('asgssadfdaf', 'qfsdsaqdaf'),
('asgasfdsdaf', 'qfsxzcwdaf'),
('asgzcxvsdaf', 'qfsasdsdaf'),
('asfsdagsdaf', 'qfsqzwddaf')

INSERT INTO Categories (CategoryName, Notes)
VALUES
('agwzxcaefds', 'ahwaeazxfsd'),
('asgsassadfdaf', 'qfsdsaqdaf'),
('asgazxcsfdsdaf', 'qfsxaqzasdcwdaf'),
('asgzcxvafsdaf', 'qfsaqwsdsdaf'),
('asfsdvzagsdaf', 'qfsqzwzvddaf')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], Genreld, CategoryId, Rating, Notes) 
VALUES
('agsewadfs', 1, '2020/12/12', 12, 'ahggweaf', 1, 12.3, 'hgawefsd') ,
('agsasdqwewadfs', 2, '2020/12/12', 11, 'ahggweaf', 2, 112.3, 'hgawefsd') ,
('agseasxdzcxwadfs', 3, '2020/12/12', 10, 'ahggweaf', 3, 122.3, 'hgawefsd') ,
('agseasdwadfs', 4, '2020/12/12', 19, 'ahggweaf', 4, 124.3, 'hgawefsd') ,
('agsezcxcwadfs', 5, '2020/12/12', 18, 'ahggweaf', 5, 1222.3, 'hgawefsd') 

--14. Car Rental Database

CREATE TABLE Categories
(
	[Id] INT,
	[CategoryName] NVARCHAR(50),
	[DaylyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)

CREATE TABLE Cars
(
	[Id] INT,
	[PlateNumber] INT,
	[Manufacturer] NVARCHAR(50),
	[Model] NVARCHAR(50),
	[CarYear] DATETIME2,
	[CategoryId] INT,
	[Doors] INT,
	[Picture] NVARCHAR(MAX),
	[Condition] NVARCHAR(50),
	[Available] NVARCHAR(50)
)

CREATE TABLE Employees
(
	[Id] INT,
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE Customers
(
	[Id] INT,
	[DriverLicenceNumber] INT,
	[FullName] NVARCHAR(50),
	[Adress] NVARCHAR(50),
	[City] NVARCHAR(50),
	[ZIPCode] INT,
	[Notes] NVARCHAR(50)
)

CREATE TABLE RentalOrders
(
	[Id] INT,
	[EmployeeId] INT,
	[CustomerId] INT,
	[CarId] INT,
	[TankLevel] INT,
	[KilometrageStart] FLOAT,
	[KilometrageEnd] FLOAT,
	[TotalKilometrage] FLOAT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplied] INT,
	[TaxRate] INT,
	[OrderStatus] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

ALTER TABLE Categories ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE Cars ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE Employees ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE Customers ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE RentalOrders ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE Categories
ADD CONSTRAINT PK_Category
PRIMARY KEY (Id)

ALTER TABLE Cars
ADD CONSTRAINT PK_Car
PRIMARY KEY (Id)

ALTER TABLE Employees
ADD CONSTRAINT PK_Employee
PRIMARY KEY (Id)

ALTER TABLE Customers
ADD CONSTRAINT PK_Customer
PRIMARY KEY (Id)

ALTER TABLE RentalOrders
ADD CONSTRAINT PK_RentalOrder
PRIMARY KEY (Id)

INSERT INTO Categories (Id, CategoryName, DaylyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES 
(1, 'qftwfsda', 2, 3, 4, 5),
(2, 'qftwfsdaasf', 3, 4, 5, 6),
(3, 'qftwfsdaqwrdas', 4, 5, 6, 7)

INSERT INTO Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
(1, 15243, 'qdwdas', '124eqwew', '2222/12/12', 4, 4, 'https://pbs.twimg.com/profile_images/653700295395016708/WjGTnKGQ_400x400.png', 'hawsfd', 'yes'),
(2, 15244213, 'qdasdwdas', '12qtg4eqwew', '2202/10/10', 5, 5, 'https://pbs.twimg.com/profile_images/653700295395016708/WjGTnKGQ_400x400.png', 'hawsfqwdd', 'yes'),
(3, 1515243, 'qdwdaqtrws', '124egqeqwew', '2202/11/11', 6, 6, 'https://pbs.twimg.com/profile_images/653700295395016708/WjGTnKGQ_400x400.png', 'hawsfdqwtf', 'yes')

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
(1, 'agwefds', 'hqreg', 'jherafs', 'hjreagsfd'),
(2, 'agwefdqwdss', 'hqgafsdreg', 'jherafqwereds', 'hjreagsfddas'),
(3, 'agwefdfqwadss', 'hqreqwdasg', 'jheratqffs', 'hjreagsfqwedd')

INSERT INTO Customers (Id, DriverLicenceNumber, FullName, Adress, City, ZIPCode, Notes)
VALUES
(1, 1231, 'fweqasd', 'fagwqwde', 'feawfd24s', 509, 'wqfead'),
(2, 12351, 'fweqqgfesasd', 'fagwqasfdwde', 'feawfdasfds', 5029, 'wqfeaqwfrd'),
(3, 12311, 'fweqaagfsrdsd', 'fagwqwdadse', 'feawfdgasds', 5509, 'wqfeaqwd')

INSERT INTO RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES 
(1, 24, 555, 12512, 7, 4123, 4124, 1, '1222/12/12', '1222/12/13', 1, 5, 6, 'qgsadf', 'garsd'),
(2, 2421, 512355, 12512, 8, 412513, 41214, 1, '1222/12/13', '1222/12/14', 1, 6, 7, 'qgqwdsadf', 'gawqfdsarsd'),
(3, 245, 554125, 12512, 9, 415123, 412564, 1, '1222/12/14', '1222/12/15', 1, 7, 8, 'qgaxcssadf', 'gzxcarsd')

15. Hotel Database

CREATE TABLE Employees 
(
	[Id] INT,
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE Customers
(
	[AccountNumber] INT,
	[FirstName] NVARCHAR(50),
	[LastName] NVARCHAR(50),
	[PhoneNumber] INT,
	[EmergencyName] NVARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] NVARCHAR(50)
)

CREATE TABLE RoomStatus
(
	[RoomStatus] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE RoomTypes
(
	[RoomType] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE BedTypes
(
	[BedType] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE Rooms
(
	[RoomNumber] INT,
	[RoomType] NVARCHAR(50),
	[BedType] NVARCHAR(50),
	[Rate] INT,
	[RoomStatus] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

CREATE TABLE Payments
(
	[Id] INT,
	[EmployeeId] INT,
	[PaymentDate] DATETIME2,
	[AccountNumber] INT,
	[FirstDateOccupied] DATETIME2,
	[LastDateOccupied] DATETIME2,
	[TotalDays] INT,
	[AmountCharged] INT,
	[TaxRate] INT,
	[TaxAmount] INT,
	[PaymentTotal] INT,
	[Notes] NVARCHAR(50)
)

CREATE TABLE Occupancies
(
	[Id] INT,
	[EmployeeId] INT,
	[DateOccupied] DATETIME2,
	[AccountNumber] INT,
	[RoomNumber] INT,
	[RateApplied] INT,
	[PhoneCharge] NVARCHAR(50),
	[Notes] NVARCHAR(50)
)

ALTER TABLE Employees ALTER COLUMN [Id] INT NOT NULL
ALTER TABLE Customers ALTER COLUMN [AccountNumber] NVARCHAR(50) NOT NULL
ALTER TABLE RoomStatus ALTER COLUMN [RoomStatus] NVARCHAR(50) NOT NULL
ALTER TABLE RoomTypes ALTER COLUMN [RoomType] NVARCHAR(50) NOT NULL
ALTER TABLE BedTypes ALTER COLUMN [BedType] NVARCHAR(50) NOT NULL
ALTER TABLE Rooms ALTER COLUMN [RoomNumber] INT NOT NULL
ALTER TABLE Payments ALTER COLUMN [Id] INT NOT NULL
ALTER TABLE Occupancies ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE Employees
ADD CONSTRAINT PK_Employees
PRIMARY KEY (Id)

ALTER TABLE Customers
ADD CONSTRAINT PK_Customers
PRIMARY KEY ([AccountNumber])

ALTER TABLE RoomStatus
ADD CONSTRAINT PK_RoomStatus
PRIMARY KEY (RoomStatus)

ALTER TABLE RoomTypes
ADD CONSTRAINT PK_RoomType
PRIMARY KEY (RoomType)

ALTER TABLE BedTypes
ADD CONSTRAINT PK_BedType
PRIMARY KEY (BedType)

ALTER TABLE Rooms
ADD CONSTRAINT PK_Room
PRIMARY KEY (RoomNumber)

ALTER TABLE Payments
ADD CONSTRAINT PK_Payment
PRIMARY KEY (Id)

ALTER TABLE Occupancies
ADD CONSTRAINT PK_Occupancy
PRIMARY KEY (Id)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes)
VALUES
(1, 'gqwerafgds', 'qheargfsd', 'qhgfsd', 'hjqweragfds'),
(2, 'gqweraaywsdffgds', 'qheargfahdfsd', 'qhgahfdfsd', 'hjqweragfdasds'),
(3, 'gqweraawergsdfgds', 'qhearahdsfgfsd', 'qhgfharesd', 'hjqweraghraefds')

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES
(12413, 'qtrweads', 'qhyaergsdf', 1532415, 'ahraasdf', 16523, 'ahersedf'),
(12412313, 'qtrhadfsgweads', 'qhyaergadfssdf', 15324215, 'ahrsdf', 1656523, 'ahersherasedf'),
(124113, 'qgaasgdtrweads', 'qhyaergshaedsfrdf', 15332415, 'ahrsdfas', 1651223, 'ahershasdfedf')

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES
('hyaesdf', 'hjasdfg'),
('hyaesdhasdfgf', 'hhajdfgjasdfg'),
('hyaesahfddf', 'hjasdagefsdfg')

INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('ahjdfgs', 'uhjasdf'),
('ahjdfjahfdgsgs', 'uhjasjhandfdf'),
('ahjdfhasdfgs', 'uhjasdhaedrfsf')

INSERT INTO BedTypes (BedType, Notes)
VALUES
('jhadsf', 'jaergsdfz'),
('jhadajhdfsgsf', 'jajafsdgergsdfz'),
('jhadjadfhgsf', 'jaergsdaygsdfdsfz')

INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
VALUES
(123, 'qyrasgdf', 'hayersdf', 6, 'ehayrs', 'ahjersdf'),
(124, 'qyahdsrasgdf', 'hayeahdfgdszrsdf', 7, 'ehahfsddayrs', 'ahjersjhasdfdf'),
(125, 'qyrasghgfgdsaadf', 'hayerasdfsdf', 8, 'ehayahgsdfrs', 'ahfsdhjersdf')

INSERT INTO Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(1, 123, '1234/1/2', 12345, '1234/2/3', '1234/3/4', 123, 12345, 5, 5, 12345, 'qtwead'),
(2, 16123, '1234/2/3', 12341235, '1234/3/4', '1234/4/5', 11223, 1234125, 55, 56, 123545, 'qtweahadesfd'),
(3, 12123, '1234/3/4', 12351245, '1234/4/5', '1234/5/6', 12123, 12315245, 56, 75, 123425, 'qtweahjdfgad')

INSERT INTO Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES
(1, 1234, '1234/12/12', 12345, 123, 12, 'yes', 'ajhsedf'),
(2, 1231234, '1234/12/11', 12341245, 121423, 1212, 'no', 'ajhseagdsfdf'),
(3, 1213234, '1234/12/10', 12315245, 12143, 11232, 'yes', 'ajhsasgdedf')

--19. Basic Select All Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--20. Basic Select All Fields and Order Them

SELECT * FROM Towns ORDER BY Name ASC
SELECT * FROM Departments ORDER BY Name ASC
SELECT * FROM Employees ORDER BY Salary DESC

--21. Basic Select Some Fields

SELECT Name FROM Towns ORDER BY Name ASC
SELECT Name FROM Departments ORDER BY Name ASC
SELECT FirstName,LastName,JobTitle,Salary FROM Employees ORDER BY Salary DESC

--22. Increase Employees Salary

UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees

--23. Decrease Tax Rate

UPDATE Payments
SET TaxRate *= 0.97
SELECT TaxRate FROM Payments

--24. Delete All Records

DELETE FROM Occupancies