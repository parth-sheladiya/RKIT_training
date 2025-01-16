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
SELECT Marks.SubjectName, COUNT(*) AS StudentsCount
FROM Marks
GROUP BY Marks.SubjectName;

-- Get the total marks obtained by students per subject
SELECT Marks.SubjectName, SUM(Marks.MarksObtained) AS TotalMarks
FROM Marks
GROUP BY Marks.SubjectName;

-- Get the average marks obtained by students per subject
SELECT Marks.SubjectName, AVG(Marks.MarksObtained) AS AverageMarks
FROM Marks
GROUP BY Marks.SubjectName;

-- Get the minimum marks obtained by students per subject
SELECT Marks.SubjectName, MIN(Marks.MarksObtained) AS MinMarks
FROM Marks
GROUP BY Marks.SubjectName;


-- Get the maximum marks obtained by students per subject
SELECT Marks.SubjectName, MAX(Marks.MarksObtained) AS MaxMarks
FROM Marks
GROUP BY Marks.SubjectName;


