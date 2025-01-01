-- Creating a view to combine student name, subject, and marks
CREATE VIEW StudentSubjectMarks AS
SELECT 
    s.sName, 
    sub.SubjectName, 
    m.Marks
FROM 
    Students s
JOIN 
    Marks m ON s.StudentID = m.StudentID
JOIN 
    Subjects sub ON m.SubjectID = sub.SubjectID;


-- Selecting data from the view
SELECT * FROM StudentSubjectMarks;


-- Modifying the view to add student age as well
CREATE OR REPLACE VIEW StudentSubjectMarks AS
SELECT 
    s.sName, 
    s.Age,
    sub.SubjectName, 
    m.Marks
FROM 
    Students s
JOIN 
    Marks m ON s.StudentID = m.StudentID
JOIN 
    Subjects sub ON m.SubjectID = sub.SubjectID;
    
-- Selecting data from the view
SELECT * FROM StudentSubjectMarks;

-- Dropping the view
DROP VIEW StudentSubjectMarks;




