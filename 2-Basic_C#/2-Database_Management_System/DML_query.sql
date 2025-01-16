-- Use the schooldb database
USE schooldb;

-- Truncate all data from the students table
TRUNCATE TABLE Students;

-- Truncate all data from the teachers table
TRUNCATE TABLE Teachers;

-- Truncate all data from the marks table
TRUNCATE TABLE Marks;

-- Insert 10 records into the teachers table
INSERT INTO Teachers (TeacherID, TeacherName, SubjectName)
VALUES 
(1, 'love babbr', 'Mathematics'),
(2, 'lakshya kumar', 'Science'),
(3, 'hitesh chaudhary', 'English'),
(4, 'harry', 'History'),
(5, 'amit rao', 'Geography'),
(6, 'nikunj vadher', 'Chemistry'),
(7, 'piyush garg', 'Physics'),
(8, 'sumit pandya', 'Biology'),
(9, 'nishant chahar', 'Computer Science'),
(10, 'santosh mishra', 'Political Science');

-- Delete teacher with TeacherID = 1
DELETE FROM Teacher WHERE TeacherID = 1;

-- Insert 10 records into the students table
INSERT INTO Students (StudentID, FirstName, LastName, Gender, DOB)
VALUES 
(1, 'parth', 'sheladiya', 'Male', '2005-04-15'),
(2, 'alish', 'pandya', 'Male', '2005-06-20'),
(3, 'keshvi', 'mishra', 'Female', '2005-09-10'),
(4, 'Emily', 'Davis', 'Female', '2004-11-25'),
(5, 'aarti', 'mehta', 'Female', '2004-02-10'),
(6, 'kavita', 'soni', 'Female', '2003-08-14'),
(7, 'keyur', 'shah', 'Male', '2003-12-30'),
(8, 'priyanka', 'gohel', 'Female', '2006-05-05'),
(9, 'aayush', 'mehta', 'Male', '2006-01-18'),
(10, 'meera', 'shah', 'Female', '2007-03-25');

-- LOCKING SYSTEM
LOCK TABLE Students WRITE;
UNLOCK TABLES;
START TRANSACTION;
COMMIT;
ROLLBACK;




select * FROM Students;
UPDATE Students SET Gender = "female" WHERE StudentID = 2;
INSERT INTO Students (StudentID, FirstName, LastName, Gender, DOB)
VALUES (11, 'meera', 'shah', 'Female', '2007-03-25');

-- Insert 10 records into the marks table
INSERT INTO Marks (MarkID, StudentID, TeacherID, MarksObtained, SubjectName)
VALUES 
(1, 1, 1, 85, 'Mathematics'),
(2, 2, 2, 90, 'Science'),
(3, 3, 3, 88, 'English'),
(4, 4, 4, 92, 'History'),
(5, 5, 1, 80, 'Mathematics'),
(6, 6, 2, 95, 'Science'),
(7, 7, 3, 89, 'English'),
(8, 8, 4, 91, 'History'),
(9, 9, 1, 75, 'Mathematics'),
(10, 10, 2, 85, 'Science');

-- Select all data from the students, teachers, and marks tables
SELECT * FROM Students, Teachers, Marks;

-- Select all data from the students table
SELECT * FROM Students;

-- Select all data from the teachers table
SELECT * FROM Teachers;

-- Select all data from the marks table
SELECT * FROM Marks;

-- Update the gender of the student with StudentID = 1
UPDATE Students
SET Gender = 'Female' 
WHERE StudentID = 1;

-- Update the marks of the student with MarkID = 1
UPDATE Marks 
SET MarksObtained = 95 
WHERE MarkID = 1;

-- Delete the student with StudentID = 5
DELETE FROM Students 
WHERE StudentID = 5;

-- Delete the record from the marks table with MarkID = 2
DELETE FROM Marks 
WHERE MarkID = 2;

-- Select marks greater than 85 from the marks table
SELECT * FROM Marks 
WHERE MarksObtained > 85;

-- Sort students by their first name
SELECT * FROM Students 
ORDER BY FirstName;

-- Sort marks in descending order by marks obtained
SELECT * FROM Marks 
ORDER BY MarksObtained DESC;

-- Retrieve 3 records starting from the 4th record (offset 3)
SELECT * FROM Students 
LIMIT 3, 2;

-- Retrieve the next 5 records after skipping the first 5 (offset 5)
SELECT * FROM Marks LIMIT 5 OFFSET 5;

-- Retrieve records for a specific teacher where teacher name is 'mr. sharma'
SELECT * FROM Teachers
WHERE TeacherName = 'patel';

-- Retrieve marks for a specific student with StudentID = 3
SELECT * FROM Marks
WHERE StudentID = 3;

-- Retrieve marks for a specific subject 'Mathematics'
SELECT * FROM Marks
WHERE SubjectName = 'Mathematics';

-- Retrieve teacher names and their subjects
SELECT TeacherName, SubjectName FROM Teachers;

-- Retrieve marks of all students for the subject 'Science'
SELECT StudentID, MarksObtained FROM Marks
WHERE SubjectName = 'Science';

-- Retrieve only the first name and last name from the students table
SELECT FirstName, LastName FROM Students;

-- Retrieve only the studentID and marks obtained from the marks table
SELECT StudentID, MarksObtained FROM Marks;

-- Count the total number of students
SELECT studentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY studentID;

-- Calculate the average, maximum, and minimum marks from the marks table
SELECT 
    AVG(MarksObtained) AS AverageMarks,   -- calculate average marks
    MAX(MarksObtained) AS MaxMarks,       -- get maximum marks
    MIN(MarksObtained) AS MinMarks        -- get minimum marks
FROM Marks;

-- Update multiple students with different first names and last names based on StudentID
UPDATE Students
SET
    FirstName = CASE 
        WHEN StudentID = 1 THEN 'ram'
        WHEN StudentID = 2 THEN 'raj'
        WHEN StudentID = 3 THEN 'jay'
        ELSE FirstName
    END,
    LastName = CASE 
        WHEN StudentID = 1 THEN 'patel'
        WHEN StudentID = 2 THEN 'chaudhary'
        WHEN StudentID = 3 THEN 'shah'
        ELSE LastName
    END
WHERE StudentID IN (1, 2, 3);

-- Get the maximum marks, maximum studentID, and maximum teacherID from the marks table
SELECT 
    MAX(MarksObtained) AS MaxMarks,
    MAX(StudentID) AS MaxStudentID,
    MAX(TeacherID) AS MaxTeacherID
FROM Marks;

-- Get the average marks for each student, teacher, and subject
SELECT 
    StudentID, 
    TeacherID, 
    SubjectName, 
    AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY StudentID, TeacherID, SubjectName;

-- Get the average marks for each student, teacher, and subject with conditions
SELECT 
    StudentID, 
    TeacherID, 
    SubjectName, 
    AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY StudentID, TeacherID, SubjectName
HAVING AVG(MarksObtained) > 60 OR MAX(MarksObtained) < 50;

-- Retrieve distinct StudentIDs from the marks table
SELECT DISTINCT StudentID
FROM Marks;

-- Retrieve distinct StudentID and SubjectName pairs from the marks table
SELECT DISTINCT StudentID, SubjectName
FROM Marks;

-- Retrieve distinct SubjectNames and calculate the average marks for each subject
SELECT DISTINCT SubjectName, AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY SubjectName;
