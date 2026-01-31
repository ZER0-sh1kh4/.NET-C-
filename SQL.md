## Customer_Master schema
 ```sql
USE [newone]
GO

/****** Object:  Table [dbo].[Customer_Master]    Script Date: 31-01-2026 15:30:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer_Master](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[CustomerPhone] [varchar](50) NOT NULL,
	[CustomerCity] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer_Master] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
## OrderDetail schema
```sql
USE [newone]
GO

/****** Object:  Table [dbo].[OrderDetail]    Script Date: 31-01-2026 15:36:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderDetail](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Orders]
GO

ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product_Master] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product_Master] ([ProductID])
GO

ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product_Master]
GO

```

## Orders schema
```sql
USE [newone]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 31-01-2026 15:38:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderID] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[SalesPersonID] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer_Master] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer_Master] ([CustomerID])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer_Master]
GO
```

## Product_Master schema
```sql
USE [newone]
GO

/****** Object:  Table [dbo].[Product_Master]    Script Date: 31-01-2026 15:40:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Master](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[UnitPrice] [int] NOT NULL,
 CONSTRAINT [PK_Product_Master] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

## SalesPerson schema 
```sql
USE [newone]
GO

/****** Object:  Table [dbo].[SalesPerson]    Script Date: 31-01-2026 23:03:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalesPerson](
	[SalesPersonID] [int] IDENTITY(1,1) NOT NULL,
	[SalesPerson] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SalesPerson] PRIMARY KEY CLUSTERED 
(
	[SalesPersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

## Question 2
```sql
select distinct Total from(select OrderDetail.OrderID,SUM(OrderDetail.Quantity*Product_Master.UnitPrice) as Total from OrderDetail inner Join Product_Master on 
	OrderDetail.ProductID=Product_Master.ProductID group by OrderDetail.OrderID) t
	order by Total desc OFFSET 1 rows fetch next 1 row only
```

## Question 3
```sql
select SalesPerson.SalesPerson from SalesPerson inner join Orders on SalesPerson.SalesPersonID=Orders.SalesPersonID
		inner join OrderDetail on Orders.OrderID=OrderDetail.OrderID 
		inner join Product_Master on OrderDetail.ProductID=Product_Master.ProductID 
		group by SalesPerson.SalesPersonID, SalesPerson.SalesPerson having
		sum(OrderDetail.Quantity*Product_Master.UnitPrice)>60000
```

## Question 4
```sql
select Customer_Master.CustomerName, Sum(OrderDetail.Quantity* Product_Master.UnitPrice) as Total from Customer_Master 
	inner join Orders on Customer_Master.CustomerID=Orders.CustomerID 
	inner join OrderDetail on Orders.OrderID=OrderDetail.OrderID 
	inner join Product_Master on OrderDetail.ProductID=Product_Master.ProductID
	group by Customer_Master.CustomerID, Customer_Master.CustomerName
	having Sum(OrderDetail.Quantity* Product_Master.UnitPrice)> (
	select AVG(customers) from (select Orders.CustomerID,sum(OrderDetail.Quantity*Product_Master.UnitPrice) as customers from Orders 
	inner join OrderDetail on Orders.OrderID=OrderDetail.OrderID 
	inner join Product_Master on OrderDetail.ProductID=Product_Master.ProductID
	group by Orders.CustomerID)x );
```

