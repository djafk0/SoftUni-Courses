--1.Employees with Salary Above 35000

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS 
BEGIN
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [Salary] > 35000
END

--2.Employees with Salary Above Number

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @minSalary DECIMAL(18,4)
AS 
BEGIN
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [Salary] >= @minSalary
END

--3.Town Names Starting With

CREATE PROCEDURE usp_GetTownsStartingWith @startString NVARCHAR(50)
AS 
BEGIN
	SELECT [Name]
	FROM [Towns]
	WHERE [Name] LIKE @startString + '%'
END

--4.Employees from Town

CREATE PROCEDURE usp_GetEmployeesFromTown @cityName NVARCHAR(50)
AS 
BEGIN 
	SELECT [FirstName], [LastName] 
	FROM [Employees] AS e
	LEFT JOIN [Addresses] AS a
	ON e.[AddressID] = a.[AddressID]
	LEFT JOIN [Towns] AS t
	ON a.[TownID] = t.TownID
	WHERE t.[Name] = @cityName
END

--5.Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(7)

	IF @salary < 30000
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END

	RETURN @salaryLevel
END

--6.Employees by Salary Level 

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE dbo.ufn_GetSalaryLevel([Salary]) = @salaryLevel
END

--7.Define Function 

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR (50), @word VARCHAR (50)) 
RETURNS BIT
AS
BEGIN
     DECLARE @index INT = 1
     DECLARE @length INT = LEN(@word)
     DECLARE @letter CHAR(1)

     WHILE (@index <= @length)
     BEGIN
          SET @letter = SUBSTRING(@word, @index, 1)
          IF (CHARINDEX(@letter, @setOfLetters) > 0)
             SET @index = @index + 1
          ELSE
             RETURN 0
     END
     RETURN 1
END 

--8.*Delete Employees and Departments

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
    DELETE FROM [EmployeesProjects]
    WHERE [EmployeeID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    UPDATE [Employees]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
 
    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerID] INT
 
    UPDATE [Departments]
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
                            SELECT [EmployeeID]
                              FROM [Employees]
                             WHERE [DepartmentID] = @departmentId
                          )
    
    DELETE FROM [Employees]
    WHERE [DepartmentID] = @departmentId
 
    DELETE FROM [Departments]
    WHERE [DepartmentID] = @departmentId
 
    SELECT COUNT(*)
      FROM [Employees]
     WHERE [DepartmentID] = @departmentId
END

--9.Find Full Name

CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [Full Name] FROM [AccountHolders]
END

--10.People with Balance Higher Than

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@limit DECIMAL)
AS
BEGIN
     SELECT ah.FirstName    AS [First Name]
            ,ah.LastName    AS [Last Name]
       FROM AccountHolders  AS ah
       JOIN Accounts        AS a  ON ah.Id = a.AccountHolderId
   GROUP BY ah.Id, ah.FirstName, ah.LastName
     HAVING SUM(Balance) > @limit
   ORDER BY [First Name], [Last Name]
END

--11.Future Value Function

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,4), @yearlyInterestRate FLOAT, @yearsNumber INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @result DECIMAL(18,4)
	SET @result = @sum * POWER(1 + @yearlyInterestRate, @yearsNumber)
	RETURN @result
END

--12.Calculating Interest

CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT) 
AS
BEGIN
	SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON ah.Id = a.Id
	WHERE a.Id = @AccountId
END

--13.*Scalar Function: Cash in User Games Odd Rows

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS 
RETURN SELECT(
            SELECT SUM([Cash]) AS [SumCash]
            FROM (
                    SELECT g.[Name],
                           ug.[Cash],
                           ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.[Cash] DESC) AS [RowNumber]
                      FROM [UsersGames] AS ug
                    JOIN [Games] AS g
                    ON ug.[GameId] = g.[Id]
                    WHERE g.[Name] = @gameName
                 ) AS [RowNumberSubQuery]
            WHERE [RowNumber] % 2 <> 0
         ) AS [SumCash]
 