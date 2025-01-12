-- database
-- all topics have to use schooldb
use schooldb;

-- truncate all data from students table
TRUNCATE TABLE Students;

-- truncate all data from classes table
TRUNCATE TABLE Teachers;

-- truncate all data from subjects table
TRUNCATE TABLE Marks;

-- teachers table me 10 records insert karte hain
INSERT INTO Teachers (TeacherID, TeacherName, Subject)
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

DELETE FROM Teacher WHERE TeacherID = 1;

-- students table me 10 records insert karte hain
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

-- marks table me 10 records insert karte hain
INSERT INTO Marks (MarkID, StudentID, TeacherID, MarksObtained, Subject)
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

-- students table ka data select karte hain
SELECT * FROM Students;

-- teachers table ka data select karte hain
SELECT * FROM Teachers;

-- marks table ka data select karte hain
SELECT * FROM Marks;

-- student ke gender ko update karte hain
UPDATE Students 
SET Gender = 'Female' 
WHERE StudentID = 1;

-- student ke marks update karte hain
UPDATE Marks 
SET MarksObtained = 95 
WHERE MarkID = 1;

-- ek student ko delete karte hain
DELETE FROM Students 
WHERE StudentID = 5;

-- ek record ko marks table se delete karte hain
DELETE FROM Marks 
WHERE MarkID = 2;

-- marks jo 85 se zyada hain unko select karte hain
SELECT * FROM Marks 
WHERE MarksObtained > 85;

-- students ko unke pehle naam ke hisab se sort karte hain
SELECT * FROM Students 
ORDER BY FirstName;

-- marks ko marksobtained ke hisab se sort karte hain
SELECT * FROM Marks 
ORDER BY MarksObtained DESC;

-- pehle 3 records ko retrieve karte hain
SELECT * FROM Students 
LIMIT 3;

-- next 5 records after skipping the first 5 (offset 5)
SELECT * FROM Marks LIMIT 5 OFFSET 5;

-- specific teacher ka record retrieve kar rahe hain, jahan teachername = 'mr. sharma'
SELECT * FROM Teachers
WHERE TeacherName = 'patel';

-- specific student ke marks retrieve kar rahe hain, jahan studentid = 3
SELECT * FROM Marks
WHERE StudentID = 3;

-- specific subject ke marks retrieve kar rahe hain, jahan subject = 'mathematics'
SELECT * FROM Marks
WHERE Subject = 'Mathematics';

-- teachers ke naam aur unke subjects ko retrieve kar rahe hain
SELECT TeacherName, Subject FROM Teachers;

-- specific subject ke liye sabhi students ke marks retrieve kar rahe hain, jahan subject = 'science'
SELECT StudentID, MarksObtained FROM Marks
WHERE Subject = 'Science';

-- students table se sirf firstname aur lastname ko retrieve kar rahe hain
SELECT FirstName, LastName FROM Students;

-- marks table se sirf studentid aur marksobtained ko retrieve kar rahe hain
SELECT StudentID, MarksObtained FROM Marks;

SELECT studentID, COUNT(*) AS TotalStudents
FROM Students
GROUP BY studentID;

SELECT 
    AVG(MarksObtained) AS AverageMarks,   -- calculate average marks
    MAX(MarksObtained) AS MaxMarks,       -- get maximum marks
    MIN(MarksObtained) AS MinMarks        -- get minimum marks
FROM Marks;

-- multiple students update 
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

-- multiple agg fun 
SELECT 
    MAX(MarksObtained) AS MaxMarks,
    MAX(StudentID) AS MaxStudentID,
    MAX(TeacherID) AS MaxTeacherID
FROM Marks;

SELECT 
    StudentID, 
    TeacherID, 
    Subject, 
    AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY StudentID, TeacherID, Subject;

SELECT 
    StudentID, 
    TeacherID, 
    Subject, 
    AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY StudentID, TeacherID, Subject
HAVING AVG(MarksObtained) > 60 OR MAX(MarksObtained) < 50;

SELECT DISTINCT StudentID
FROM Marks;

SELECT DISTINCT StudentID, Subject
FROM Marks;

SELECT DISTINCT Subject, AVG(MarksObtained) AS AverageMarks
FROM Marks
GROUP BY Subject;
