-- Create database
CREATE DATABASE school_college_db;
USE school_college_db;

-- Create Student table
CREATE TABLE Student (
    StudentID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    Address TEXT,
    EnrollmentDate DATE NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create Course table
CREATE TABLE Course (
    CourseID INT AUTO_INCREMENT PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    CourseDescription TEXT,
    Credits INT NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create Teacher table
CREATE TABLE Teacher (
    TeacherID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    HireDate DATE NOT NULL,
    Department VARCHAR(100),
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create Enrollment table (many-to-many relationship between Student and Course)
CREATE TABLE Enrollment (
    EnrollmentID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    EnrollmentDate DATE NOT NULL,
    Grade CHAR(1),
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID)
);

-- Create Class table
CREATE TABLE Class (
    ClassID INT AUTO_INCREMENT PRIMARY KEY,
    ClassName VARCHAR(50) NOT NULL,
    ClassYear INT NOT NULL,
    TeacherID INT,
    FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID)
);

-- Create Attendance table
CREATE TABLE Attendance (
    AttendanceID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT,
    ClassID INT,
    AttendanceDate DATE NOT NULL,
    Status ENUM('Present', 'Absent', 'Late') DEFAULT 'Present',
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
);

-- DML: Insert Data into Student table
INSERT INTO Student (FirstName, LastName, DateOfBirth, Email, PhoneNumber, Address, EnrollmentDate)
VALUES 
('John', 'Doe', '2005-08-15', 'john.doe@example.com', '1234567890', '123 Elm St', '2022-09-01'),
('Jane', 'Smith', '2006-01-20', 'jane.smith@example.com', '0987654321', '456 Oak St', '2022-09-01');

-- Insert Data into Course table
INSERT INTO Course (CourseName, CourseDescription, Credits)
VALUES 
('Mathematics', 'Advanced Mathematics Course', 4),
('Physics', 'Physics with lab sessions', 3),
('Chemistry', 'Chemistry fundamentals and lab', 3);

-- Insert Data into Teacher table
INSERT INTO Teacher (FirstName, LastName, Email, PhoneNumber, HireDate, Department)
VALUES 
('Emily', 'Brown', 'emily.brown@example.com', '1112223333', '2020-06-15', 'Science'),
('Michael', 'Green', 'michael.green@example.com', '4445556666', '2018-03-20', 'Mathematics');

-- Insert Data into Enrollment table
INSERT INTO Enrollment (StudentID, CourseID, EnrollmentDate, Grade)
VALUES 
(1, 1, '2022-09-01', 'A'),
(1, 2, '2022-09-01', 'B'),
(2, 3, '2022-09-01', 'A');

-- Insert Data into Class table
INSERT INTO Class (ClassName, ClassYear, TeacherID)
VALUES 
('Class 10', 2022, 1),
('Class 12', 2022, 2);

-- Insert Data into Attendance table
INSERT INTO Attendance (StudentID, ClassID, AttendanceDate, Status)
VALUES 
(1, 1, '2023-01-10', 'Present'),
(2, 2, '2023-01-10', 'Absent');

-- DQL: Query 1: Get all students with their courses
SELECT s.StudentID, s.FirstName, s.LastName, c.CourseName, e.Grade
FROM Student s
JOIN Enrollment e ON s.StudentID = e.StudentID
JOIN Course c ON e.CourseID = c.CourseID;

-- Query 2: Get attendance record of a specific student
SELECT s.FirstName, s.LastName, a.AttendanceDate, a.Status
FROM Student s
JOIN Attendance a ON s.StudentID = a.StudentID
WHERE s.StudentID = 1;

-- Query 3: Get all classes with their teachers
SELECT c.ClassName, c.ClassYear, t.FirstName AS TeacherFirstName, t.LastName AS TeacherLastName
FROM Class c
JOIN Teacher t ON c.TeacherID = t.TeacherID;

-- Update Example: Update grade of a student
UPDATE Enrollment
SET Grade = 'A+'
WHERE EnrollmentID = 1;

-- Delete Example: Remove a student
DELETE FROM Student WHERE StudentID = 2;

-- Aggregate Function: Count total students
SELECT COUNT(*) AS TotalStudents FROM Student;

-- TCL: Transaction Example
START TRANSACTION;
INSERT INTO Student (FirstName, LastName, DateOfBirth, Email, PhoneNumber, Address, EnrollmentDate)
VALUES ('Alice', 'Walker', '2007-03-05', 'alice.walker@example.com', '3334445555', '789 Pine St', '2023-01-01');
INSERT INTO Enrollment (StudentID, CourseID, EnrollmentDate, Grade)
VALUES (3, 1, '2023-01-02', 'B');
COMMIT;

-- Subquery Example: Get students enrolled in courses with more than 3 credits
SELECT * FROM Student
WHERE StudentID IN (
    SELECT StudentID FROM Enrollment e
    JOIN Course c ON e.CourseID = c.CourseID
    WHERE c.Credits > 3
);

-- View Example: Create a view for student-course enrollment
CREATE VIEW StudentCourseView AS
SELECT s.StudentID, s.FirstName, s.LastName, c.CourseName, e.Grade
FROM Student s
JOIN Enrollment e ON s.StudentID = e.StudentID
JOIN Course c ON e.CourseID = c.CourseID;

SELECT * FROM StudentCourseView;

-- Index Example: Create an index on Student email
CREATE INDEX idx_student_email ON Student(Email);

-- DCL: Grant and Revoke Example
GRANT SELECT, INSERT, UPDATE ON school_college_db.* TO 'user1'@'localhost';
REVOKE UPDATE ON school_college_db.* FROM 'user1'@'localhost';

-- Backup & Restore
-- Backup: mysqldump -u root -p school_college_db > school_college_db_backup.sql
-- Restore: mysql -u root -p school_college_db < school_college_db_backup.sql

-- EXPLAIN Example
EXPLAIN SELECT s.StudentID, s.FirstName, c.CourseName FROM Student s JOIN Enrollment e ON s.StudentID = e.StudentID JOIN Course c ON e.CourseID = c.CourseID;
