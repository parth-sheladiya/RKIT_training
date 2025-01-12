-- use schooldb database fro all topics 
use schooldb;

-- Get the total number of students
SELECT COUNT(*) AS TotalStudents FROM Students;

-- Get the sum of all student IDs
SELECT SUM(StudentID) AS TotalStudentIDSum FROM Students;

-- Get the average of all student IDs
SELECT AVG(StudentID) AS AverageStudentID FROM Students;

-- Get the minimum student ID
SELECT MIN(StudentID) AS MinStudentID FROM Students;

-- Get the maximum student ID
SELECT MAX(StudentID) AS MaxStudentID FROM Students;

-- Get the total number of marks records
SELECT COUNT(*) AS TotalMarksRecords FROM Marks;

-- Get the total sum of marks obtained by all students
SELECT SUM(MarksObtained) AS TotalMarksObtained FROM Marks;

-- Get the minimum marks obtained
SELECT MIN(MarksObtained) AS MinMarksObtained FROM Marks;

-- Get the maximum marks obtained
SELECT MAX(MarksObtained) AS MaxMarksObtained FROM Marks;

-- Get the number of students per subject
SELECT Marks.Subject, COUNT(*) AS StudentsCount
FROM Marks
GROUP BY Marks.Subject;

-- Get the total marks obtained by students per subject
SELECT Marks.Subject, SUM(Marks.MarksObtained) AS TotalMarks
FROM Marks
GROUP BY Marks.Subject;

-- Get the average marks obtained by students per subject
SELECT Marks.Subject, AVG(Marks.MarksObtained) AS AverageMarks
FROM Marks
GROUP BY Marks.Subject;

-- Get the minimum marks obtained by students per subject
SELECT Marks.Subject, MIN(Marks.MarksObtained) AS MinMarks
FROM Marks
GROUP BY Marks.Subject;


-- Get the maximum marks obtained by students per subject
SELECT Marks.Subject, MAX(Marks.MarksObtained) AS MaxMarks
FROM Marks
GROUP BY Marks.Subject;


























-- total marks of all students	

select sum(Marks) as totalmarks from Marks;

-- avarage marks of all students
select  avg(Marks) as avaragemarks from Marks;

-- count student 
select count(*) as totalstudent from Students;

-- maximum marks 
select max(Marks) as maxmarks from Marks;

-- min marks 
select min(Marks) as minmarks from Marks;

-- count student of each class 
select Class , count(*) as studentcount from Students group by Class;

-- total marks score by each student
select StudentID , sum(Marks) as totalmarks from Marks group by StudentId;

-- avarage marks in each subject 
select SubjectID , avg(Marks) as avgmarks from Marks group by SubjectID;

-- count how many subject 
select count(*) as totalsubject from Subjects;

-- highest marks in each subjects 
select SubjectId , max(Marks) as highestmark from Marks group by SubjectID;

-- lowest marks in each subjects 
select SubjectID , min(Marks) as lowestmark from Marks group by SubjectID;
