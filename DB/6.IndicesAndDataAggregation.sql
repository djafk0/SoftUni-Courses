--01. Records’ Count

SELECT COUNT(*) FROM [WizzardDeposits]

--02. Longest Magic Wand

SELECT MAX([MagicWandSize]) AS [LongestMagicWand] FROM [WizzardDeposits]

--03. Longest Magic Wand per Deposit Groups

SELECT [DepositGroup], MAX([MagicWandSize]) AS [LongestMagicWand] FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--04. Smallest Deposit Group per Magic Wand Size (not included in final score)

SELECT TOP (2) [DepositGroup] FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG([MagicWandSize])

--05. Deposits Sum

SELECT [DepositGroup], SUM([DepositAmount]) FROM [WizzardDeposits]
GROUP BY [DepositGroup]

--06. Deposits Sum for Ollivander Family

SELECT [DepositGroup], SUM([DepositAmount]) 
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander Family'
GROUP BY [DepositGroup]

--07. Deposits Filter

SELECT [DepositGroup], SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander Family'
GROUP BY [DepositGroup]
HAVING  SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

--08. Deposit Charge

SELECT [DepositGroup], [MagicWandCreator], MIN([DepositCharge]) AS [MinDepositCharge] FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

--09. Age Groups

SELECT [AgeGroup], COUNT([Id]) AS [WizzardCount] FROM 
(
	SELECT *,
		CASE
			WHEN [Age] >= 0 AND [Age] <= 10 THEN '[0-10]'
			WHEN [Age] >= 11 AND [Age] <= 20 THEN '[11-20]'
			WHEN [Age] >= 21 AND [Age] <= 30 THEN '[21-30]'
			WHEN [Age] >= 31 AND [Age] <= 40 THEN '[31-40]'
			WHEN [Age] >= 41 AND [Age] <= 50 THEN '[41-50]'
			WHEN [Age] >= 51 AND [Age] <= 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup] FROM [WizzardDeposits]) AS [AgeGroupingQuery]
GROUP BY [AgeGroup]

--10. First Letter

SELECT SUBSTRING([FirstName],1,1) 
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY SUBSTRING([FirstName],1,1)

--11. Average Interest

SELECT [DepositGroup], [IsDepositExpired], AVG([DepositInterest]) AS [AverageInterest] FROM [WizzardDeposits]
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

--12. Rich Wizard, Poor Wizard (not included in final score)

SELECT SUM([Difference]) FROM 
(
	SELECT 
		q.[FirstName] AS e, 
		q.[DepositAmount] AS r, 
		w.[FirstName]AS t,
		w.[DepositAmount] AS u, 
		q.[DepositAmount] - w.[DepositAmount] AS [Difference]
	FROM [WizzardDeposits] AS q
	JOIN [WizzardDeposits] AS w
	ON q.[Id] + 1 = w.[Id]
) AS i

--13. Departments Total Salaries

SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary]
FROM [Employees] 
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14. Employees Minimum Salaries

SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary] FROM Employees
WHERE ([DepartmentID] = 2 OR [DepartmentID] = 5 OR [DepartmentID] = 7) AND [HireDate] > '2000/01/01'
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--15. Employees Average Salaries

SELECT *
  INTO [NewTable]
  FROM [Employees]
 WHERE [Salary] > 30000

 DELETE FROM [NewTable]
 WHERE [ManagerID] = 42

UPDATE [NewTable]
SET [Salary] += 5000
WHERE [DepartmentID] = 1
SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] FROM [NewTable]
GROUP BY [DepartmentID]

--16. Employees Maximum Salaries

SELECT [DepartmentID], MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX([Salary]) < 30000 OR MAX([Salary]) > 70000

--17. Employees Count Salaries

SELECT COUNT([FirstName]) AS [Count] FROM [Employees]
WHERE [ManagerID] IS NULL

--18. 3rd Highest Salary (not included in final score)

SELECT [DepartmentID],
        Result.[Salary] AS [ThirdHighestSalary]
   FROM
         (
			SELECT [DepartmentID]
                    ,[Salary]
                    ,DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
               FROM [Employees]
           GROUP BY [DepartmentID], [Salary]
         ) AS [Result]
   WHERE [Rank] = 3
ORDER BY [DepartmentID]

--19. Salary Challenge (not included in final score)

SELECT TOP (10) e.[FirstName], e.[LastName], e.[DepartmentID]
FROM  [Employees] AS e
WHERE e.[Salary] > 
	(
		SELECT AVG([Salary]) AS [AvgSalary]
		FROM [Employees] AS s
		WHERE e.[DepartmentID] = s.[DepartmentID]
		GROUP BY [DepartmentID]
	)
ORDER BY e.[DepartmentID]