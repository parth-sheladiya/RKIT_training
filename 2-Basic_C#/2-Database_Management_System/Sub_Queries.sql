-- use schooldb database for all topic 
use schooldb;

-- Find students whose marks are greater than average marks
SELECT FirstName, LastName
FROM Students
WHERE StudentID IN (
    SELECT StudentID
    FROM Marks
    WHERE MarksObtained > (
        SELECT AVG(MarksObtained) FROM Marks
    )
);

-- Find teachers who teach Mathematics
SELECT TeacherName
FROM Teachers
WHERE TeacherID IN (
    SELECT TeacherID
    FROM Marks
    WHERE Subject = 'Mathematics'
);

-- Find the student with the highest marks in Science
SELECT FirstName, LastName
FROM Students
WHERE StudentID = (
    SELECT StudentID
    FROM Marks
    WHERE Subject = 'Science'
    ORDER BY MarksObtained DESC
    LIMIT 1
);

-- Find teachers who have taught students with marks above 80
SELECT TeacherName
FROM Teachers
WHERE TeacherID IN (
    SELECT TeacherID
    FROM Marks
    WHERE MarksObtained > 80
);

-- Find students who have marks less than the maximum marks in History
SELECT FirstName, LastName
FROM Students
WHERE StudentID IN (
    SELECT StudentID
    FROM Marks
    WHERE Subject = 'History' AND MarksObtained < (
        SELECT MAX(MarksObtained)
        FROM Marks
        WHERE Subject = 'History'
    )
);

-- Find teachers who teach more than one subject
SELECT TeacherName
FROM Teachers
WHERE TeacherID IN (
    SELECT TeacherID
    GROUP BY TeacherID
    HAVING COUNT(DISTINCT Subject) > 1
);

-- Find students who have marks less than the average in English
SELECT FirstName, LastName
FROM Students
WHERE StudentID IN (
    SELECT StudentID
    FROM Marks
    WHERE Subject = 'English' AND MarksObtained < (
        SELECT AVG(MarksObtained)
        FROM Marks
        WHERE Subject = 'English'
    )
);

