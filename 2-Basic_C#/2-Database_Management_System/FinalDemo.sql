-- create the database if it doesn't exist
CREATE DATABASE IF NOT EXISTS OrderManagementDB;

-- use the created database
USE OrderManagementDB;

-- create the Customers table
CREATE TABLE IF NOT EXISTS Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,  -- unique identifier for customers
    CustomerName VARCHAR(100),  -- name of the customer
    Email VARCHAR(100),  -- email address of the customer
    PhoneNumber VARCHAR(15)  -- phone number of the customer
);

-- create the Products table
CREATE TABLE IF NOT EXISTS Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,  -- unique identifier for products
    ProductName VARCHAR(100),  -- name of the product
    Price DECIMAL(10, 2)  -- price of the product
);

-- create the Orders table
CREATE TABLE IF NOT EXISTS Orders (
    OrderID INT AUTO_INCREMENT PRIMARY KEY,  -- unique identifier for orders
    CustomerID INT,  -- reference to the customer who placed the order
    ProductID INT,  -- reference to the product ordered
    OrderDate DATE,  -- date when the order was placed
    Quantity INT,  -- quantity of the product ordered
    OrderStatus VARCHAR(20)  -- status of the order (e.g., pending, completed, canceled)
);

INSERT INTO Customers (CustomerName, Email, PhoneNumber) 
VALUES 
('Ravi Ramani', 'ravi.ramani@example.com', '9876543210'),
('Aarti Varma', 'aarti.varma@example.com', '8765432109'),
('Ajay Thumar', 'ajay.thumar@example.com', '9871234567'),
('Priya Varsani', 'priya.varsani@example.com', '9123456789'),
('Manish Sisodiya', 'manish.sisodiya@example.com', '9988776655'),
('Sneha Patel', 'sneha.patel@example.com', '9988223344'),
('Rahul Bhatt', 'rahul.bhatt@example.com', '9777888999'),
('Neha Chauhan', 'neha.chauhan@example.com', '9666775544'),
('Vikram Thakor', 'vikram.thakor@example.com', '9555664433');


-- insert 10 records into the Products table
INSERT INTO Products (ProductName, Price) 
VALUES 
('Laptop', 1000.00),
('Smartphone', 500.00),
('Tablet', 300.00),
('Headphones', 150.00),
('Smartwatch', 250.00),
('Charger', 20.00),
('Keyboard', 30.00),
('Mouse', 25.00),
('Camera', 400.00),
('Printer', 350.00);

-- insert 7 records into the Orders table
INSERT INTO Orders (CustomerID, ProductID, OrderDate, Quantity, OrderStatus)
VALUES 
(1, 1, '2025-01-10', 2, 'Pending'),
(1, 2, '2025-01-11', 1, 'Completed'),
(2, 3, '2025-01-12', 3, 'Canceled'),
(3, 4, '2025-01-13', 1, 'Pending'),
(4, 5, '2025-01-14', 2, 'Completed'),
(5, 6, '2025-01-15', 5, 'Pending'),
(6, 7, '2025-01-16', 3, 'Completed');

-- view all orders
SELECT OrderID, CustomerID, ProductID, OrderDate, Quantity, OrderStatus
FROM Orders;

-- view only pending orders
SELECT OrderID, CustomerID, ProductID, OrderDate, Quantity, OrderStatus
FROM Orders
WHERE OrderStatus = 'Pending';

-- calculate total quantity of all orders
SELECT SUM(Quantity) AS TotalQuantity FROM Orders;

-- calculate total revenue (quantity * price) for all orders
SELECT SUM(Quantity * Price) AS TotalRevenue
FROM Orders o, Products p
WHERE o.ProductID = p.ProductID;

-- calculate average quantity per customer
SELECT CustomerID, AVG(Quantity) AS AverageQuantity
FROM Orders
GROUP BY CustomerID;

-- view orders where quantity is greater than 2
SELECT OrderID, CustomerID, ProductID, Quantity
FROM Orders
WHERE Quantity > 2;

-- view customers who have total order quantity greater than 2
SELECT CustomerID, SUM(Quantity) AS TotalQuantity
FROM Orders
GROUP BY CustomerID
HAVING SUM(Quantity) > 2;

-- create an index on the OrderStatus column in the Orders table
CREATE INDEX idx_order_status ON Orders (OrderStatus);

-- use the created index to query orders with 'Completed' status
SELECT * FROM Orders WHERE OrderStatus = 'Completed';

-- combine two queries using UNION to show products ordered by customers 1 and 2
SELECT ProductID, Quantity FROM Orders WHERE CustomerID = 1
UNION
SELECT ProductID, Quantity FROM Orders WHERE CustomerID = 2;

-- Create 'admin' user with password
CREATE USER 'admin'@'localhost' IDENTIFIED BY 'adminpassword123';

-- Create 'customer' user with password
CREATE USER 'customer'@'localhost' IDENTIFIED BY 'customerpassword123';

-- Grant all privileges on the database to the 'admin' user
GRANT ALL PRIVILEGES ON OrderManagementDB.* TO 'admin'@'localhost';

-- Grant SELECT permission on the Orders table to the 'customer' user
GRANT SELECT ON OrderManagementDB.Orders TO 'customer'@'localhost';

-- Flush privileges to apply changes
FLUSH PRIVILEGES;


-- start a transaction
START TRANSACTION;

-- insert a new order into the Orders table
INSERT INTO Orders (CustomerID, ProductID, OrderDate, Quantity, OrderStatus)
VALUES (2, 1, '2025-01-13', 1, 'Pending');

-- commit the transaction to save the changes
COMMIT;

-- if any issue occurs, rollback the transaction to undo changes
ROLLBACK;
