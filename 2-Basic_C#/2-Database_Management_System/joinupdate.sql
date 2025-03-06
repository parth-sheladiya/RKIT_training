CREATE DATABASE Mark;
USE mark;


CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,       
    TeacherName VARCHAR(100),          
    SubjectName VARCHAR(50)           
);

-- Creating Marks Table
CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,           
    StudentName VARCHAR(50),         
    TeacherID INT,                     
    MarksObtained INT DEFAULT 0,    
    SubjectName VARCHAR(50),        
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID) 
);


-- Inserting data into Teachers table
INSERT INTO Teachers (TeacherID, TeacherName, SubjectName)
VALUES
(1, 'Mr. John', 'Mathematics'),
(2, 'Ms. Sarah', 'Science'),
(3, 'Mr. Mike', 'English');

-- Inserting data into Marks table
INSERT INTO Marks (MarkID, StudentName, TeacherID, MarksObtained, SubjectName)
VALUES
(1, 'James', 1, 80, 'Mathematics'),  
(2, 'Emma', 2, 90, 'Science'),   
(3, 'Olivia', 3, 85, 'English');   
SET  sql_safe_updates = 0;
SET  sql_safe_updates = 1;
-- Update Marks for James in Mathematics using JOIN
UPDATE Marks
JOIN Teachers ON Marks.TeacherID = Teachers.TeacherID
SET Marks.MarksObtained = 95   
WHERE Marks.StudentName = 'James' 
AND Teachers.SubjectName = 'Mathematics'; 


SELECT * FROM teachers;
SELECT * FROM marks;
 
