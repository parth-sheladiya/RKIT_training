-- use database for all topics
use schooldb;

-- students table query 
-- Retrieve all records from the Students table
SELECT * FROM Students;

-- Retrieve all students who are 'Male'
SELECT * FROM Students WHERE Gender = 'Male';

-- Retrieve all students whose date of birth is before 2005
SELECT * FROM Students WHERE DOB < '2005-01-01';

-- Retrieve students with the first name 'aarti'
SELECT * FROM Students WHERE FirstName = 'aarti';

-- Count the total number of students in the Students table
SELECT COUNT(*) AS TotalStudents FROM Students;

-- Retrieve students whose last name starts with 'S'
SELECT * FROM Students WHERE LastName LIKE 'S%';

-- Retrieve students whose age is less than 20 years
SELECT * FROM Students WHERE YEAR(CURDATE()) - YEAR(DOB) < 20;

-- Retrieve the first 5 students from the Students table
SELECT * FROM Students LIMIT 5;

-- Retrieve the last student in the Students table
SELECT * FROM Students ORDER BY StudentID DESC LIMIT 1;

-- teacher table query 
-- Retrieve all records from the Teachers table
SELECT * FROM Teachers;

-- Retrieve teachers who teach the subject 'Mathematics'
SELECT * FROM Teachers WHERE SubjectName = 'Mathematics';

-- Retrieve teachers whose name starts with 'A'
SELECT * FROM Teachers WHERE TeacherName LIKE 'A%';

-- Count the total number of teachers in the Teachers table
SELECT COUNT(*) AS TotalTeachers FROM Teachers;

-- Retrieve the teacher who teaches the subject 'Science'
SELECT * FROM Teachers WHERE SubjectName = 'Science';

-- Retrieve the teacher with the highest TeacherID
SELECT * FROM Teachers WHERE TeacherID = (SELECT MAX(TeacherID) FROM Teachers);

-- Retrieve teachers who teach subjects starting with 'C'
SELECT * FROM Teachers WHERE SubjectName LIKE 'C%';

-- Retrieve teachers with TeacherID between 1 and 5
SELECT * FROM Teachers WHERE TeacherID BETWEEN 1 AND 5;

-- Retrieve teachers who do not teach the subject 'History'
SELECT * FROM Teachers WHERE SubjectName != 'History';

-- Retrieve teachers who teach either 'English' or 'Mathematics'
SELECT * FROM Teachers WHERE SubjectName  IN ('English', 'Mathematics');


-- marks table query 
-- Retrieve all records from the Marks table
SELECT * FROM Marks;

-- Retrieve marks for the student with StudentID 1
SELECT * FROM Marks WHERE StudentID = 1;

-- Calculate the average marks obtained for each subject
SELECT SubjectName, AVG(MarksObtained) AS AverageMarks FROM Marks GROUP BY SubjectName;

-- Calculate the total marks obtained by each student
SELECT StudentID, SUM(MarksObtained) AS TotalMarks FROM Marks GROUP BY StudentID;

-- Retrieve marks for students who studied 'Mathematics'
SELECT * FROM Marks WHERE SubjectName = 'Mathematics';

-- Retrieve the maximum marks obtained by any student in any subject
SELECT MAX(MarksObtained) AS MaxMarks FROM Marks;

-- Retrieve marks ordered by MarksObtained in descending order
SELECT * FROM Marks ORDER BY MarksObtained DESC;

-- Retrieve marks for students who scored more than 80 marks
SELECT * FROM Marks WHERE MarksObtained > 80;




