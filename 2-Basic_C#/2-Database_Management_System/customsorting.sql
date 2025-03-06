-- 1 role sorting
-- 2 e com store of my final demo asp .net core 
-- order status Pending Processing Shipped  Delivered Cancelled

CREATE DATABASE CompanyDB;
USE CompanyDB;

CREATE TABLE employees (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(50),
    role VARCHAR(50),
    salary INT
);

INSERT INTO employees (name, role, salary) VALUES
('Amit', 'Manager', 80000),
('Raj', 'Developer', 60000),
('Suman', 'Intern', 20000),
('Priya', 'Developer', 65000),
('Vikas', 'Manager', 90000),
('Neha', 'Intern', 25000),
('Rohit', 'Developer', 62000),
('Kunal', 'Manager', 85000),
('Swati', 'Intern', 23000),
('Pooja', 'Developer', 63000);



SELECT * FROM employees;
SELECT name,id,role,salary FROM employees;

SELECT id,name,role, FIELD(role, 'Manager', 'Developer', 'Intern') AS rolepriority FROM employees;
SELECT * FROM employees ORDER BY FIELD(role, 'Manager', 'Developer', 'Intern') ;

SHOW TABLE STATUS WHERE Name = 'employees';
SHOW ENGINES;


