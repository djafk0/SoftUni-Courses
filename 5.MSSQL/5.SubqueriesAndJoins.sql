--1.Employee Address

SELECT TOP (5) [EmployeeID], [JobTitle], a.[AddressID], [AddressText]
FROM [Employees] AS e
LEFT JOIN [Addresses] AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID 

--2.Addresses with Towns

SELECT * FROM TOWNS

SELECT TOP (50) e.[FirstName], e.[LastName], t.[Name] AS [Town], [AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a
ON e.[AddressID] = a.[AddressID]
JOIN [Towns] AS t
ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName], e.[LastName]

--3.Sales Employee

SELECT e.[EmployeeID], e.[FirstName], e.[LastName], d.[Name]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE d.Name = 'Sales'
ORDER BY [EmployeeID]

--4.Employee Departments

SELECT TOP (5) e.[EmployeeID], e.[FirstName], e.[Salary], d.[Name]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[Salary] > 15000
ORDER BY d.[DepartmentID]

--5.Employees Without Project

SELECT TOP (3) e.[EmployeeID], e.[FirstName] 
FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID] 
WHERE ep.[EmployeeID] IS NULL
ORDER BY [EmployeeID]

--6.Employees Hired After

SELECT e.[FirstName], e.[LastName], e.[HireDate], d.[Name] AS [DeptName]
FROM [Employees] AS e
LEFT JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[HireDate] > '1.1.1999' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.[HireDate]

--7.Employees with Project

SELECT TOP (5) e.[EmployeeID], e.[FirstName], p.[Name] AS [ProjectName]
FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
LEFT JOIN [Projects] AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE p.[StartDate] > '2002.08.13' AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID]

--8.Employee 24

SELECT e.[EmployeeID], e.[FirstName],
CASE 
	WHEN p.[StartDate] > 2005 THEN 'NULL'
END
AS [ProjectName]
FROM [Employees] AS e
RIGHT JOIN [EmployeesProjects] AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
RIGHT JOIN [Projects] AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE e.[EmployeeID] = 24

--9.Employee Manager

SELECT e.[EmployeeID], e.[FirstName], e.[ManagerID], m.[FirstName] AS [ManagerName]
FROM [Employees] AS e
INNER JOIN [Employees] AS m
ON e.[ManagerID] = m.[EmployeeID]
WHERE m.[EmployeeID] IN (3,7)
ORDER BY e.[EmployeeID]

--10. Employee Summary

SELECT TOP (50) e.[EmployeeID], e.[FirstName] + ' ' + e.[LastName] AS [EmployeeName], m.[FirstName] + ' ' + m.[LastName] AS [ManagerName], d.[Name] AS [DepartmentName]
FROM [Employees] AS e
INNER JOIN [Employees] AS m
ON e.[ManagerID] = m.[EmployeeID]
LEFT JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]

--11. Min Average Salary
SELECT MIN(s.AvgSalary) 
	FROM
		(SELECT AVG(Salary) AS AvgSalary 
			FROM Employees GROUP BY DepartmentID) AS s

--12. Highest Peaks in Bulgaria

SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
ON mc.[MountainId] = p.[MountainId]
WHERE c.CountryName = 'Bulgaria' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

--13. Count Mountain Ranges

SELECT c.[CountryCode], COUNT(m.[MountainRange]) AS [MountainRanges] 
FROM [Countries]  AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
ON mc.[MountainId] = m.[Id]
WHERE c.CountryName = 'United States' OR c.CountryName = 'Russia' OR c.CountryName = 'Bulgaria'
GROUP BY c.[CountryCode]

--14. Countries with Rivers

SELECT TOP (5) [CountryName], r.[RiverName]
FROM [Continents] AS c
LEFT JOIN [Countries] AS cn
ON c.[ContinentCode] = cn.[ContinentCode]
LEFT JOIN [CountriesRivers] AS cr
ON cn.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentName] = 'Africa'
ORDER BY cn.[CountryName]

--15. *Continents and Currencies

SELECT rankedCurrencies.ContinentCode, rankedCurrencies.CurrencyCode, rankedCurrencies.Count
FROM (
SELECT c.ContinentCode, c.CurrencyCode, COUNT(c.CurrencyCode) AS [Count], DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank] 
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode) AS rankedCurrencies
WHERE rankedCurrencies.rank = 1 and rankedCurrencies.Count > 1

--Countries Without Any Mountains

SELECT COUNT(c.[CountryName]) AS [Count]
FROM [Mountains] AS m
FULL JOIN [MountainsCountries] AS mc
ON m.[Id] = mc.[MountainId]
FULL JOIN [Countries] AS c
ON mc.[CountryCode] = c.[CountryCode]
WHERE m.Id IS NULL

--16. Highest Peak and Longest River by Country

SELECT TOP (5) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT OUTER JOIN [MountainsCountries] AS mc ON c.[CountryCode] = mc.[CountryCode]
LEFT OUTER JOIN [Peaks] AS p ON p.[MountainId] = mc.[MountainId]
LEFT OUTER JOIN [CountriesRivers] AS cr ON c.[CountryCode] = cr.[CountryCode]
LEFT OUTER JOIN [Rivers] AS r ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.[CountryName]

--17. Highest Peak Name and Elevation by Country

SELECT c.[CountryName], p.[PeakName] AS [Highest Peak Name], p.[Elevation] AS [Highest Peak Elevation], m.[MountainRange] AS [Mountain]
FROM [Peaks] AS p
RIGHT JOIN [Mountains] AS m
ON p.[MountainId] = m.[Id]
RIGHT JOIN [MountainsCountries] AS mc
ON m.[Id] = mc.[MountainId] 
RIGHT JOIN [Countries] AS c
ON mc.[CountryCode] = c.[CountryCode]
ORDER BY c.[CountryName], [Highest Peak Name]

SELECT TOP (5) WITH TIES c.CountryName, ISNULL(p.PeakName, '(no highest peak)') AS 'HighestPeakName', ISNULL(MAX(p.Elevation), 0) AS 'HighestPeakElevation', ISNULL(m.MountainRange, '(no mountain)')
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName