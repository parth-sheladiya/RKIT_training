-- use schooldb databse for all topics 
use schooldb;


-- Combine FirstName from Students and TeacherName from Teachers using UNION
SELECT FirstName AS Name FROM Students
UNION
SELECT TeacherName AS Name FROM Teachers;

-- Combine FirstName from Students and TeacherName from Teachers using UNION ALL
SELECT FirstName AS Name FROM Students
UNION ALL
SELECT TeacherName AS Name FROM Teachers;

-- Combine marks obtained in Mathematics and Science using UNION
SELECT MarksObtained FROM Marks WHERE Subject = 'Mathematics'
UNION
SELECT MarksObtained FROM Marks WHERE Subject = 'Science';

-- Combine marks obtained in Mathematics and Science using UNION ALL
SELECT MarksObtained As objtainedmarks FROM Marks WHERE Subject = 'Mathematics'
UNION ALL
SELECT MarksObtained FROM Marks WHERE Subject = 'Science';


-- Find students who have marks in both Mathematics and Science using UNION
SELECT StudentID FROM Marks WHERE Subject = 'Mathematics'
UNION
SELECT StudentID FROM Marks WHERE Subject = 'Science';

-- Combine teachers who teach Mathematics or Science using UNION
SELECT TeacherName FROM Teachers WHERE Subject = 'Mathematics'
UNION
SELECT TeacherName FROM Teachers WHERE Subject = 'Science';

-- Find students who have marks in both English and History using UNION
SELECT StudentID FROM Marks WHERE Subject = 'English'
UNION
SELECT StudentID FROM Marks WHERE Subject = 'History';

-- Combine all marks in Mathematics and English using UNION ALL
SELECT MarksObtained FROM Marks WHERE Subject = 'Mathematics'
UNION ALL
SELECT MarksObtained FROM Marks WHERE Subject = 'English';

-- Combine Teacher and Student names for all subjects using UNION
SELECT TeacherName AS Name FROM Teachers
UNION
SELECT CONCAT(FirstName, ' ', LastName) AS Name FROM Students;

-- Combine students who have marks above 80 in any subject using UNION
SELECT StudentID FROM Marks WHERE MarksObtained > 80
UNION
SELECT StudentID FROM Marks WHERE MarksObtained > 80;














-- Basic UNION (Remove Duplicates)
select sName from students where class	= '7'

union 

select subjectName from subjects;


--  UNION ALL (Include Duplicates)
select sName from students where class = '7'
union all 
select subjectName from subjects;

-- UNION for Different Data Types
select sName , Age from Students where class = '7'
union 
select subjectName , null as age from Subjects;

-- UNION Across Multiple Tables
select sName from Students where class='7'
union 
select marks from marks where marks>90;

-- UNION to Combine Results from Different States

select sName from Students where class='7'
union 
select sName from students where class='9';

