SELECT * FROM Products;

SELECT ProductID, ProductName, UnitPrice FROM Products;

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice > 15;

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice >= 15 AND UnitPrice <= 50;

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE UnitPrice BETWEEN 15 AND 50;

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE NOT UnitPrice > 15;

SELECT ProductID, ProductName, UnitPrice
FROM Products
WHERE ProductID > 15 OR UnitPrice < 10;

SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE 'D%';

SELECT EmployeeID, LastName FROM Employees
WHERE LastName LIKE '%N';

SELECT EmployeeID, LastName, Title FROM Employees
WHERE Title LIKE '%SALES%';

SELECT EmployeeID, LastName FROM Employees
WHERE LastName NOT LIKE 'D%';

SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID ASC;

SELECT ProductID, ProductName, UnitPrice
FROM Products
ORDER BY ProductID DESC;

SELECT DISTINCT OrderID FROM [Order Details];

SELECT TOP 5 OrderID, ProductID, Quantity
FROM [Order Details];

SELECT TOP 10 PERCENT OrderID, ProductID, Quantity
FROM [Order Details];

SELECT CategoryName AS [Nombre de Categoria]
FROM Categories;

SELECT OrderId, OrderDate, ShippedDate, ShippedDate + 5 AS RetrasoEnvio
FROM Orders;

SELECT P.ProductID, P.ProductName, OD.OrderID, OD.Quantity
FROM Products P
INNER JOIN [Order Details] OD
ON P.ProductID = OD.ProductID;

SELECT <lista_campos>
FROM <TablaA A>
INNER JOIN <TablaB B>
ON A.Key = B.Key;

