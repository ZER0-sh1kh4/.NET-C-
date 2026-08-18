-- Normalized tables
--Q1
CREATE TABLE Customers (CustomerID INT PRIMARY KEY, CustomerName VARCHAR(100) NOT NULL, CustomerPhone VARCHAR(20), CustomerCity VARCHAR(50));

CREATE TABLE SalesPersons (SalesPersonID INT PRIMARY KEY, SalesPersonName VARCHAR(100) NOT NULL);

CREATE TABLE Products (ProductID INT PRIMARY KEY, ProductName VARCHAR(100) NOT NULL UNIQUE);

CREATE TABLE SalesOrders (OrderID INT PRIMARY KEY, OrderDate DATE NOT NULL, CustomerID INT NOT NULL, SalesPersonID INT NOT NULL, FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID), FOREIGN KEY (SalesPersonID) REFERENCES SalesPersons(SalesPersonID));

CREATE TABLE OrderItems (OrderID INT NOT NULL, ProductID INT NOT NULL, Quantity INT NOT NULL, UnitPrice DECIMAL(10,2) NOT NULL, PRIMARY KEY (OrderID, ProductID), FOREIGN KEY (OrderID) 
  REFERENCES SalesOrders(OrderID), FOREIGN KEY (ProductID) REFERENCES Products(ProductID));

--q2
WITH OrderSales AS (SELECT OrderID, SUM(CAST(q.value AS INT) * CAST(p.value AS DECIMAL(10,2))) AS TotalSales 
  FROM Sales_Raw CROSS APPLY STRING_SPLIT(Quantities, ',', 1) q CROSS APPLY STRING_SPLIT(UnitPrices, ',', 1) p 
  WHERE q.ordinal = p.ordinal GROUP BY OrderID), RankedOrders AS (SELECT OrderID, TotalSales, DENSE_RANK() OVER (ORDER BY TotalSales DESC) AS SalesRank FROM OrderSales)
  SELECT OrderID, TotalSales FROM RankedOrders WHERE SalesRank = 3;

--q3
WITH OrderSales AS (SELECT OrderID, SalesPerson, SUM(CAST(q.value AS INT) * CAST(p.value AS DECIMAL(10,2))) AS TotalSales 
  FROM Sales_Raw CROSS APPLY STRING_SPLIT(Quantities, ',', 1) q CROSS APPLY STRING_SPLIT(UnitPrices, ',', 1) p 
  WHERE q.ordinal = p.ordinal GROUP BY OrderID, SalesPerson) SELECT SalesPerson, SUM(TotalSales) AS TotalSales FROM OrderSales GROUP BY SalesPerson HAVING SUM(TotalSales) > 60000;

--q4
WITH CustomerSales AS (SELECT CustomerName, SUM(CAST(q.value AS INT) * CAST(p.value AS DECIMAL(10,2))) AS TotalSpent FROM Sales_Raw CROSS APPLY STRING_SPLIT(Quantities, ',', 1) q 
  CROSS APPLY STRING_SPLIT(UnitPrices, ',', 1) p WHERE q.ordinal = p.ordinal GROUP BY CustomerName)
  SELECT CustomerName, TotalSpent FROM CustomerSales WHERE TotalSpent > (SELECT AVG(TotalSpent * 1.0) FROM CustomerSales);
