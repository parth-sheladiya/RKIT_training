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
SELECT MarksObtained FROM Marks WHERE SubjectName = 'Mathematics'
UNION
SELECT MarksObtained FROM Marks WHERE SubjectName = 'Science';

-- Combine marks obtained in Mathematics and Science using UNION ALL
SELECT MarksObtained As objtainedmarks FROM Marks WHERE SubjectName = 'Mathematics' and MarksObtained >90
UNION ALL
SELECT MarksObtained  As objtainedmarks FROM Marks WHERE SubjectName = 'Science' and  MarksObtained >90;

-- Find students who have marks in both Mathematics and Science using UNION
SELECT StudentID FROM Marks WHERE SubjectName = 'Mathematics'
UNION
SELECT StudentID FROM Marks WHERE SubjectName = 'Science';

-- Combine teachers who teach Mathematics or Science using UNION
SELECT TeacherName FROM Teachers WHERE SubjectName = 'Mathematics'
UNION
SELECT TeacherName FROM Teachers WHERE SubjectName = 'Science';

-- Find students who have marks in both English and History using UNION
SELECT StudentID FROM Marks WHERE SubjectName = 'English'
UNION
SELECT StudentID FROM Marks WHERE SubjectName = 'History';

-- Combine all marks in Mathematics and English using UNION ALL
SELECT MarksObtained FROM Marks WHERE SubjectName = 'Mathematics'
UNION ALL
SELECT MarksObtained FROM Marks WHERE SubjectName = 'English';

-- Combine Teacher and Student names for all subjects using UNION
SELECT TeacherName AS Name FROM Teachers
UNION
SELECT CONCAT(FirstName, ' ', LastName) AS Name FROM Students;

-- Combine students who have marks above 80 in any subject using UNION
SELECT StudentID FROM Marks WHERE MarksObtained > 80
UNION
SELECT StudentID FROM Marks WHERE MarksObtained > 80;

