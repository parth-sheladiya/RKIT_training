-- Database Create karein
CREATE DATABASE universityDB;
USE universityDB;

-- Students Table
CREATE TABLE Students (
    StudentID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Class VARCHAR(10) NOT NULL
);

-- Subjects Table
CREATE TABLE Subjects (
    SubjectID INT AUTO_INCREMENT PRIMARY KEY,
    SubjectName VARCHAR(50) NOT NULL
);

-- Marks Table
CREATE TABLE Marks (
    MarkID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT,
    SubjectID INT,
    MarksObtained INT,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);

-- Students Data Insert
INSERT INTO Students (Name, Age, Class) VALUES 
('Rahul', 15, '10th'),
('Priya', 14, '9th'),
('Aman', 16, '11th');

-- Subjects Data Insert
INSERT INTO Subjects (SubjectName) VALUES 
('Math'),
('Science'),
('English');

-- Marks Data Insert
INSERT INTO Marks (StudentID, SubjectID, MarksObtained) VALUES 
(1, 1, 85), -- Rahul - Math
(1, 2, 90), -- Rahul - Science
(2, 1, 78), -- Priya - Math
(3, 3, 88); -- Aman - English

-- commit
START TRANSACTION;
-- update mark
UPDATE Marks SET MarksObtained = 95 WHERE MarkID = 1; 
-- insert data
INSERT INTO Marks (StudentID, SubjectID, MarksObtained) VALUES (2, 2, 88); 

COMMIT;

-- roll back
START TRANSACTION;

UPDATE Marks SET MarksObtained = 50 WHERE MarkID = 2; -- Galat update (Rahul ke Science ke marks galat ho gaye)
DELETE FROM Marks WHERE MarkID = 3; -- Aman ka English marks galti se delete ho gaya

ROLLBACK;

-- savepoint 
START TRANSACTION;

UPDATE Marks SET MarksObtained = 80 WHERE MarkID = 1; -- Rahul ke Math marks update
SAVEPOINT BeforeScienceUpdate;

UPDATE Marks SET MarksObtained = 70 WHERE MarkID = 2; -- Rahul ke Science marks update
SAVEPOINT AfterScienceUpdate;

-- Galti se kuch aur update ho gaya
UPDATE Marks SET MarksObtained = 60 WHERE MarkID = 4;

ROLLBACK TO BeforeScienceUpdate; -- Sirf BeforeScienceUpdate tak changes wapas ho gaye

COMMIT;




select * from Marks;
select * from Students;
select * from Subjects;
