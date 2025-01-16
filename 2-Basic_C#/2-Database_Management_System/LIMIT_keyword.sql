-- use of schooldb for all topics 
use schooldb;

-- Retrieve the first 3 students from the Students table
SELECT * FROM Students LIMIT 3;

-- Retrieve the top 5 students ordered by StudentID
SELECT * FROM Students ORDER BY StudentID LIMIT 5;

-- Retrieve the last 3 students from the Students table
SELECT * FROM Students ORDER BY StudentID DESC LIMIT 3;

-- Retrieve the first 3 teachers who teach 'Science'
SELECT * FROM Teachers WHERE SubjectName = 'Science' LIMIT 3;

-- Retrieve the first 3 students whose first name starts with 'a'
SELECT * FROM Students WHERE FirstName LIKE 'a%' LIMIT 3;

-- Retrieve the first 3 teachers whose name starts with 'A'
SELECT * FROM Teachers WHERE TeacherName LIKE 'A%' LIMIT 3;

-- Retrieve students starting from the 5th record (skip the first 4)
SELECT * FROM Students LIMIT 5 OFFSET 4;

-- Retrieve the first 3 teachers along with their subjects
SELECT TeacherName, SubjectName FROM Teachers LIMIT 3;

-- Retrieve teachers starting from the 3rd record
SELECT * FROM Teachers LIMIT 3 OFFSET 2;

-- Retrieve the next 3 students after skipping the first 5
SELECT * FROM Students LIMIT 3 OFFSET 2;
