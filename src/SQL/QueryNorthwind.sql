USE Northwind
-- 1. Obtener la lista de los productos no descatalogados incluyendo el nombre de la categoría ordenado por nombre de producto.
SELECT P.*, 
       C.CategoryName
FROM Products P
     JOIN Categories C ON C.CategoryID = P.CategoryID
WHERE P.Discontinued = 0
ORDER BY P.ProductName;

-- 2.	Mostrar el nombre de los clientes de Nancy Davolio.
SELECT C.CompanyName
FROM Employees E
     JOIN Orders O ON O.EmployeeID = E.EmployeeID
     JOIN Customers C ON C.CustomerID = O.CustomerID
WHERE CONCAT(E.FirstName, ' ', E.LastName) = 'Nancy Davolio'
GROUP BY C.CompanyName;

-- 3.	Mostrar el total facturado por año del empleado Steven Buchanan.
SELECT YEAR(O.OrderDate) AS Año, 
       ROUND(SUM((OD.UnitPrice * OD.Quantity * (1 - OD.Discount))),2) AS Facturación
FROM Orders O
     JOIN [Order Details] OD ON OD.OrderID = O.OrderID
     JOIN Employees E ON O.EmployeeID = E.EmployeeID
WHERE CONCAT(E.FirstName, ' ', E.LastName) = 'Steven Buchanan'
GROUP BY YEAR(O.OrderDate)
ORDER BY YEAR(O.OrderDate);

-- 4. Mostrar el nombre de los empleados que dependan directa o indirectamente de Andrew Fuller.
WITH CTE_Reports
     AS (SELECT EmployeeID, 
                CONCAT(FirstName, ' ', LastName) AS FullName, 
                ReportsTo
         FROM Employees
         WHERE CONCAT(FirstName, ' ', LastName) = 'Andrew Fuller'
         UNION ALL
         SELECT E.employeeID, 
                CONCAT(E.FirstName, ' ', E.LastName), 
                E.ReportsTo
         FROM Employees E
              INNER JOIN CTE_Reports m ON E.ReportsTo = m.employeeID)
     SELECT *
     FROM CTE_Reports
     WHERE FullName <> 'Andrew Fuller';




