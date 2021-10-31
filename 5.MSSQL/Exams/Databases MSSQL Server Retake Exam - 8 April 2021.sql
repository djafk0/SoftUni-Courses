--01. DDL

CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[UserName] VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	[Birthdate] DATETIME,
	[Age] INT,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Birthdate] DATETIME,
	[Age] INT,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments([Id])
)

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments([Id]) NOT NULL
)

CREATE TABLE [Status]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE [Reports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
	[StatusId] INT FOREIGN KEY REFERENCES Status([Id]) NOT NULL,
	[OpenDate] DATETIME NOT NULL,
	[CloseDate] DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES Users([Id]) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id])
)

--02. Insert

INSERT INTO [Employees]([FirstName], [LastName], [Birthdate], [DepartmentId])
VALUES
	('Marlo', 'O''Malley', '1958-9-21', 1),
	('Niki', 'Stanaghan', '1969-11-26', 4),
	('Ayrton', 'Senna', '1960-03-21', 9),
	('Ronnie', 'Peterson', '1944-02-14', 9),
	('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO [Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId])
VALUES
	(1, 1,'2017-04-13', '', 'Stuck Road on Str.133',6,2),
	(6, 3,'2015-09-05' ,'2015-12-06','Charity trail running', 3, 5),
	(14, 2,'2015-09-07', '', 'Falling bricks on Str.58', 5, 2),
	(4, 3,'2017-07-03', '2017-07-06','Cut off streetlight on Str.11', 1, 1)

--03. Update

UPDATE [Reports]
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL

--04. Delete

DELETE FROM [Reports]
WHERE [StatusId] = 4

--05. Unassigned Reports

SELECT [Description], FORMAT([OpenDate], 'dd-MM-yyyy') AS [OpenDate]
FROM [Reports]
WHERE [EmployeeId] IS NULL
ORDER BY Reports.[OpenDate], [Description]

--06. Reports & Categories

SELECT r.[Description], c.[Name] AS [CategoryName] 
FROM [Reports] AS r
LEFT JOIN [Categories] AS c
ON r.[CategoryId] = c.[Id]
ORDER BY r.[Description], c.[Name]

--07. Most Reported Category

SELECT TOP (5) c.[Name] AS [CategoryName], COUNT(r.[CategoryId]) AS [ReportsNumber]
FROM [Categories] AS c
RIGHT JOIN [Reports] AS r
ON r.[CategoryId] = c.[Id]
GROUP BY c.[Name]
ORDER BY COUNT(r.[CategoryId]) DESC

--08. Birthday Report

SELECT u.[UserName], c.[Name] AS [CategoryName]
FROM [Users] AS u
LEFT JOIN [Reports] AS r
ON u.[Id] = r.[UserId]
LEFT JOIN [Categories] AS c
ON r.[CategoryId] = c.[Id]
WHERE DATEPART(MONTH, u.[Birthdate]) = DATEPART(MONTH, r.[OpenDate]) AND DATEPART(DAY, u.[Birthdate]) = DATEPART(DAY, r.[OpenDate])
ORDER BY u.[UserName], c.[Name]

--09. User per Employee

SELECT CONCAT(e.[FirstName], ' ', e.[LastName]) AS [FullName], COUNT(r.[UserId]) AS [UsersCount]
FROM [Employees] AS e
LEFT JOIN [Reports] AS r
ON e.[Id] = r.[EmployeeId]
LEFT JOIN [Users] AS u
ON u.[Id] = r.[UserId]
GROUP BY e.[FirstName], e.[LastName]
ORDER BY COUNT(r.[UserId]) DESC, [FullName]

--10. Full Info

SELECT IIF(CONCAT(e.[FirstName], ' ', e.[LastName]) = '', 'None', CONCAT(e.[FirstName], ' ', e.[LastName])) AS [Employee],
ISNULL(d.[Name], 'None') AS [Department], 
ISNULL(c.[Name], 'None') AS [Category], 
ISNULL(r.[Description], 'None'),
ISNULL(FORMAT(r.[OpenDate], 'dd.MM.yyyy'), 'None') AS [OpenDate],
ISNULL(s.[Label], 'None') AS [Status], 
ISNULL(u.[Name], 'None') AS [User]
FROM [Reports] AS r
LEFT JOIN [Employees]   AS e ON r.[EmployeeId] = e.[Id]
LEFT JOIN [Categories]  AS c ON r.[CategoryId] = c.[Id]
LEFT JOIN [Departments] AS d ON e.[DepartmentId] = d.[Id]
LEFT JOIN [Users]       AS u ON r.[UserId] = u.[Id]
LEFT JOIN [Status]      AS s ON r.[StatusId] = s.[Id]
ORDER BY e.[FirstName] DESC, e.[LastName] DESC, d.[Name], c.[Name], r.[Description], r.[OpenDate], s.[Label], u.[Name]

--11. Hours to Complete

CREATE FUNCTION udf_HoursToComplete(@startDate DATETIME, @endDate DATETIME)
RETURNS INT 
AS
BEGIN
	DECLARE @result INT

	SET @result = DATEDIFF(HOUR,@startDate,@endDate)

	RETURN @result
END

--12. Assign Employee

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
    DECLARE @employeeDepartment INT = (SELECT [DepartmentId] 
                                         FROM [Employees]
                                        WHERE [Id] = @EmployeeId
                                       )

    DECLARE @reportDepartment INT = (SELECT d.[Id] 
                                       FROM [Reports]     AS r 
                                       JOIN [Categories]  AS c ON r.[CategoryId] = c.[Id]
                                       JOIN [Departments] AS d ON c.[DepartmentId] = d.[Id]
                                      WHERE r.[Id] = @ReportId
                                    )

    IF(@employeeDepartment = @reportDepartment)
         UPDATE [Reports]
            SET [EmployeeId] = @EmployeeId
          WHERE    [Id] = @ReportId
     ELSE
       RAISERROR('Employee doesn''t belong to the appropriate department!',16, 1)
END