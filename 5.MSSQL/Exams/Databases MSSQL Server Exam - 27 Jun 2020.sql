--01. DDL

CREATE TABLE [Clients]
(
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] VARCHAR(12) CHECK (LEN([Phone]) = 12)  NOT NULL
)

CREATE TABLE [Mechanics]
(
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Vendors]
(
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Models]
(
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE [Jobs]
(
	[JobId] INT PRIMARY KEY IDENTITY,
	[ModelId] INT FOREIGN KEY REFERENCES Models([ModelId]) NOT NULL,
	[Status] VARCHAR(10) DEFAULT 'Pending',
	[ClientId] INT FOREIGN KEY REFERENCES Clients([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES Mechanics([MechanicId]) NOT NULL,
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE 
)

CREATE TABLE [Parts]
(
	[PartId] INT PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	[Price] MONEY CHECK ([Price] > 0) NOT NULL,
	[VendorId] INT FOREIGN KEY REFERENCES Vendors([VendorId]) NOT NULL,
	[StockQty] INT CHECK ([StockQty] >= 0) DEFAULT 0
)

CREATE TABLE [Orders]
(
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES Jobs([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT DEFAULT 0
)

CREATE TABLE [OrderParts]
(
	[OrderId] INT FOREIGN KEY REFERENCES Orders([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES Parts([PartId]) NOT NULL,
	PRIMARY KEY ([OrderId],[PartId]),
	[Quantity] INT CHECK ([Quantity] > 0) DEFAULT 1
)

CREATE TABLE [PartsNeeded]
(
	[JobId] INT FOREIGN KEY REFERENCES Jobs([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES Parts([PartId]) NOT NULL,
	PRIMARY KEY ([JobId],[PartId]),
	[Quantity] INT CHECK ([Quantity] > 0) DEFAULT 1
)

--02. Insert

INSERT INTO [Clients]([FirstName],[LastName],[Phone])
VALUES
	('Teri','Ennaco','570-889-5187'),
	('Merlyn','Lawler', '201-588-7810'),
	('Georgene','Montezuma', '925-615-5185'),
	('Jettie','Mconnell', '908-802-3564'),
	('Lemuel','Latzke', '631-748-6479'),
	('Melodie','Knipp', '805-690-1682'),
	('Candida','Corbley', '908-275-8357')

INSERT INTO [Parts]([SerialNumber],[Description],[Price],[VendorId])
VALUES
	('WP8182119','Door Boot Seal',117.86,2),
	('W10780048','Suspension Rod',42.81,1),
	('W10841140','Silicone Adhesive ',6.77,4),
	('WPY055980','High Temperature Adhesive',13.94,3)

--03. Update

UPDATE [Jobs]
SET MechanicId = 3
WHERE [Status] = 'Pending'

UPDATE [Jobs]
SET [Status] = 'In Progress'
WHERE MechanicId = 3 AND [Status] = 'Pending'

--04. Delete

DELETE FROM [OrderParts]
WHERE [OrderId] = 19

DELETE FROM [Orders]
WHERE [OrderId] = 19

--05. Mechanic Assignments

SELECT CONCAT(m.[FirstName], ' ', m.[LastName]) AS [Mechanic], j.[Status], j.[IssueDate]
FROM [Mechanics] AS m
LEFT JOIN [Jobs] AS j
ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId], j.[IssueDate], j.[JobId]

--06. Current Clients

SELECT CONCAT(c.[FirstName], ' ', c.[LastName]) AS [Client], DATEDIFF(DAY, j.[IssueDate], '2017-04-24') AS [Days going], j.[Status]
FROM [Clients] AS c
LEFT JOIN [Jobs] AS j
ON c.[ClientId] = j.[ClientId]
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.[ClientId]

--07. Mechanic Performance

SELECT CONCAT(m.FirstName, ' ', m.[LastName]) AS [Mechanic],
AVG(DATEDIFF(DAY, j.[IssueDate], j.[FinishDate])) AS [Average Days]
FROM [Jobs] AS j
LEFT JOIN [Mechanics] AS m
ON j.[MechanicId] = m.[MechanicId]
WHERE j.[Status] = 'Finished'
GROUP BY m.[FirstName], m.[LastName], j.[MechanicId]
ORDER BY j.[MechanicId]

--08. Available Mechanics

SELECT CONCAT([FirstName], ' ', [LastName]) AS [Available]
FROM [Mechanics]
WHERE [MechanicId] NOT IN
	(
		SELECT [MechanicId]
		FROM [Jobs]
		WHERE [Status] = 'In Progress' OR [Status] IS NULL
		GROUP BY [MechanicId]
	)
ORDER BY [MechanicId]

--09. Past Expenses

SELECT j.[JobId], ISNULL(SUM(p.[Price] * op.[Quantity]),0) AS [Total]
FROM [Jobs] AS j
LEFT JOIN [Orders] AS o
ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op
ON o.[OrderId] = op.[OrderId]
LEFT JOIN [Parts] AS p
ON op.[PartId] = p.[PartId]
WHERE [Status] = 'Finished'
GROUP BY j.[JobId]
ORDER BY [Total] DESC, j.[JobId]

--10. Missing Parts

SELECT p.[PartId], p.[Description], pn.[Quantity] AS [Required], p.[StockQty] AS [In Stock], ISNULL(op.[Quantity], 0) AS [Ordered]
FROM [Jobs] AS j
LEFT JOIN [PartsNeeded] AS pn
ON j.[JobId] = pn.[JobId]
LEFT JOIN [Parts] AS p
ON pn.[PartId] = p.[PartId]
LEFT JOIN [Orders] AS o
ON j.[JobId] = o.[JobId]
LEFT JOIN [OrderParts] AS op
ON o.[OrderId] = op.[OrderId]
WHERE j.[Status] != 'Finished' AND pn.[Quantity] > p.[StockQty] AND op.[Quantity] IS NULL
GROUP BY p.[PartId], p.[Description], pn.[Quantity], p.[StockQty], op.[Quantity]
ORDER BY p.[PartId]

--11. Place Order

CREATE PROC usp_PlaceOrder(@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS
BEGIN
    IF(@quantity <= 0)
        THROW 50012, 'Part quantity must be more than zero!', 1  
    ELSE IF((SELECT [Status] FROM [Jobs] WHERE [JobId] = @jobId) IN ('Finished'))
        THROW 50011, 'This job is not active!', 1    
    ELSE IF(NOT EXISTS (SELECT [JobId] FROM [Jobs] WHERE [JobId] = @jobId)) 
        THROW 50013, 'Job not found!', 1    
    ELSE IF(NOT EXISTS (SELECT [PartId] FROM [Parts] WHERE [SerialNumber] = @partSerialNumber))
        THROW 50014, 'Part not found!', 1      
 
    DECLARE @partId INT = (SELECT [PartId]  FROM [Parts]  WHERE [SerialNumber] = @partSerialNumber)
    DECLARE @order  INT = (SELECT [OrderId] FROM [Orders] WHERE [JobId] = @jobId AND [IssueDate] IS NULL)
 
    IF(@order IS NULL)   
      BEGIN
        INSERT INTO [Orders]([JobId], [IssueDate])
             VALUES (@jobId, NULL)
 
        DECLARE @orderId INT = (SELECT [OrderId] FROM [Orders] WHERE [JobId] = @jobId AND [IssueDate] IS NULL)  
 
        INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
             VALUES (@orderId, @partId, @quantity)         
      END 
    ELSE IF(EXISTS (SELECT [Quantity] FROM [OrderParts] WHERE [OrderId] = @order AND [PartId] = @partId))
      BEGIN 
        UPDATE [OrderParts]
           SET [Quantity] += @quantity
         WHERE [OrderId] = @order AND [PartId] = @partId
      END
    ELSE 
      BEGIN
        INSERT INTO [OrderParts]([OrderId], [PartId], [Quantity])
             VALUES (@order, @partId, @quantity)    
      END
END

--12. Cost of Order

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
    DECLARE @totalCost DECIMAL(15,2)
 
    SET @totalCost = ( SELECT SUM(p.[Price] * op.[Quantity])
                         FROM [Jobs]       AS j
                         JOIN [Orders]     AS o  ON j.[JobId] = o.[JobId]
                         JOIN [OrderParts] AS op ON o.[OrderId] = op.[OrderId]
                         JOIN [Parts]      AS p  ON op.[PartId] = p.[PartId]
                        WHERE j.[JobId] = @jobId
                     )
 
     RETURN ISNULL(@totalCost, 0)
END

























