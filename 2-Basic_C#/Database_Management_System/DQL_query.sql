-- database
create database university; 
use university;
-- student table
create table Students (
    StudentID int auto_increment primary key,
    sName varchar(50),
    Age int,
    Class varchar(10)
);
-- subject tabke
create table Subjects (
SubjectID int auto_increment primary key,
SubjectName varchar(20)

);

-- mark table 
create table Marks(
MarkID int auto_increment primary key ,
StudentID int,
SubjectID int,
Marks int, 
foreign key (StudentID) references Students(StudentID),
foreign key (SubjectID) references Subjects(SubjectID)
);


-- single row insert 
insert into 
			Students(sName , Age , Class ) 
values ("parth" , 21 ,  "7");

insert into 
			Subjects(SubjectName)
values ("physics");

insert into 
			Marks(StudentID , SubjectID , Marks)
values (1,1,90);


-- multiple row insert 
insert into 
			Students(sName, Age , Class)
            values
('Parth', 21, '7'),
('Riya', 14, '9'),
('Mohit', 16, '11'),
('Neha', 15, '10'),
('Diya', 11, '9'),
('Ravi', 17, '12'),
('Jeel', 18, '12'),
('Arpit', 14, '9'),
('Harit', 19, '11'),
('Keyur', 12, '10'),
('Nisha', 13, '8'),
('Rohan', 15, '10');

INSERT INTO Subjects(SubjectName) VALUES
('Physics'),
('Chemistry'),
('Mathematics'),
('Biology'),
('English'),
('Computer Science'),
('History'),
('Geography'),
('Economics'),
('Political Science'),
('Hindi'),
('Sanskrit');

INSERT INTO Marks(StudentID, SubjectID, Marks) VALUES
(1, 1, 85),
(2, 2, 90),
(3, 3, 78),
(4, 4, 98),
(5, 5, 76),
(6, 6, 89),
(7, 7, 95),
(8, 8, 72),
(9, 9, 84),
(10, 10, 91),
(11, 11, 75),
(12, 12, 82);


-- select cmd
-- select all columns
-- retrive all details
select * from Students;
select * from Subjects;
select * from Marks;

-- select specific columns
select  
		StudentID,sName,age 
from 
		Students;

-- select with condition 
select 
		StudentID,sName,age 
from   	
		Students 
        where age>16;
        
-- select with order by 
SELECT *
FROM 	Students 
ORDER BY Age DESC;

-- select with  distinct 
SELECT DISTINCT  Class
FROM Students;

-- select with aggrigate fun

SELECT COUNT(*) AS TotalStudents 
FROM Students;

SELECT AVG(Marks) AS AverageMarks 
FROM Marks;


-- select with group  by

SELECT SubjectID, AVG(Marks) AS AvgMarks
FROM Marks
GROUP BY SubjectID;

-- having 
SELECT SubjectID, AVG(Marks) AS AvgMarks
FROM Marks
GROUP BY SubjectID
HAVING AVG(Marks) > 85;

-- select with limit
SELECT * FROM Students LIMIT 5;


-- between 
SELECT * FROM Marks WHERE Marks BETWEEN 80 AND 90;

-- in 
SELECT * FROM Students WHERE StudentID IN (1, 2, 3 , 9);

-- union 
SELECT sName FROM Students WHERE Age > 15
UNION
SELECT sName FROM Students WHERE Class = '9';

-- order by multiple col 
SELECT * FROM Students ORDER BY Age ASC, sName DESC;

-- like
SELECT * FROM Students WHERE sName LIKE 'P%';


