CREATE DATABASE firstpartition;

USE firstpartition;

drop database firstpartition;

CREATE TABLE Sales (
    EmployeeID INT,
    SalesAmount DECIMAL(10, 2),
    SaleMonth VARCHAR(20)
)
PARTITION BY HASH(EmployeeID) PARTITIONS 4;

INSERT INTO Sales (EmployeeID, SalesAmount, SaleMonth) VALUES
(101, 1500.00, 'January'),
(102, 2000.00, 'February'),
(103, 2500.00, 'March'),
(104, 3000.00, 'April'),
(105, 3500.00, 'May'),
(106, 4000.00, 'June'),
(107, 4500.00, 'July'),
(108, 5000.00, 'August'),
(109, 5500.00, 'September'),
(110, 6000.00, 'October'),
(111, 6500.00, 'November'),
(112, 7000.00, 'December'),
(113, 7500.00, 'January'),
(114, 8000.00, 'February'),
(115, 8500.00, 'March'),
(116, 9000.00, 'April'),
(117, 9500.00, 'May'),
(118, 10000.00, 'June'),
(119, 10500.00, 'July'),
(120, 11000.00, 'August'),
(121, 11500.00, 'September'),
(122, 12000.00, 'October'),
(123, 12500.00, 'November'),
(124, 13000.00, 'December'),
(125, 13500.00, 'January'),
(126, 14000.00, 'February'),
(127, 14500.00, 'March'),
(128, 15000.00, 'April'),
(129, 15500.00, 'May'),
(130, 16000.00, 'June'),
(131, 16500.00, 'July'),
(132, 17000.00, 'August'),
(133, 17500.00, 'September'),
(134, 18000.00, 'October'),
(135, 18500.00, 'November'),
(136, 19000.00, 'December'),
(137, 19500.00, 'January'),
(138, 20000.00, 'February'),
(139, 20500.00, 'March'),
(140, 21000.00, 'April'),
(141, 21500.00, 'May'),
(142, 22000.00, 'June'),
(143, 22500.00, 'July'),
(144, 23000.00, 'August'),
(145, 23500.00, 'September'),
(146, 24000.00, 'October'),
(147, 24500.00, 'November'),
(148, 25000.00, 'December'),
(149, 25500.00, 'January'),
(150, 26000.00, 'February');

EXPLAIN SELECT * FROM Sales;

SELECT TABLE_NAME, PARTITION_NAME , TABLE_ROWS
FROM INFORMATION_SCHEMA.PARTITIONS 
WHERE TABLE_SCHEMA = "firstpartition" AND TABLE_NAME="Sales";

create database parth;
