-- create database for schooldb
create database schooldb;

-- use the created database
use schooldb;

-- create table for teachers
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,         -- unique ID for the teacher
    TeacherName VARCHAR(100),          -- name of the teacher
    SubjectName VARCHAR(50)                -- subject taught by the teacher
);

-- create table for students
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,         -- unique ID for the student
    FirstName VARCHAR(50),             -- first name of the student
    LastName VARCHAR(50),              -- last name of the student
    Gender VARCHAR(10),                -- gender of the student (Male/Female)
    DOB DATE                           -- date of birth of the student
);

-- create table for marks
CREATE TABLE Marks (
    MarkID INT PRIMARY KEY,            -- unique ID for the marks record
    StudentID INT,                     -- student ID, foreign key referencing Students table
    TeacherID INT,                     -- teacher ID, foreign key referencing Teachers table
    MarksObtained INT DEFAULT 0,                 -- marks obtained by the student
    CHECK (MarksObtained>0),
    SubjectName VARCHAR(50),               -- subject of the marks record
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID) ON DELETE CASCADE,  -- foreign key to Students table
    FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID) ON DELETE CASCADE  -- foreign key to Teachers table
);


-- drop the entire 'schooldb' database
DROP DATABASE schooldb;

-- add new column 'RoomNumber' to the Teacher table
-- column to store room number information
ALTER TABLE Teachers 
ADD RoomNumber VARCHAR(10);  

-- delete 'RoomNumber' column from the Teacher table
ALTER TABLE Teachers 
DROP COLUMN RoomNumber;  -- removing the 'RoomNumber' column

-- add primary key constraint on 'TeacherID' in the Teacher table
ALTER TABLE Teachers 
ADD CONSTRAINT PK_TeacherID PRIMARY KEY (TeacherID);  

-- change the data type of 'Gender' column in Students table from VARCHAR(10) to VARCHAR(20)
ALTER TABLE Students 
MODIFY Gender VARCHAR(20);  

-- drop all tables (Marks, Student, Teacher)
DROP TABLE Marks;  -- dropping the Marks table
DROP TABLE Students;  -- dropping the Students table
DROP TABLE Teachers;  -- dropping the Teachers table

-- truncate all tables (removes all rows from the table)
TRUNCATE TABLE Students;  -- removing all data from the Students table
TRUNCATE TABLE Marks;    -- removing all data from the Marks table
TRUNCATE TABLE Teachers;  -- removing all data from the Teachers table

-- check current database in use
SELECT DATABASE();  -- checking the current database in use

-- list all tables in the current database
SHOW TABLES;  -- displaying all tables in the current database

-- show the structure of the Student table
DESCRIBE Students;  -- displaying the structure of the Students table

-- show the structure of the Teacher table
DESCRIBE Teachers;  -- displaying the structure of the Teachers table

-- show the structure of the Marks table
DESCRIBE Marks;    -- displaying the structure of the Marks table

-- rename the Student table to StudentDetails
RENAME TABLE Students TO StudentDetails;  -- renaming the Students table

-- rename the Teacher table to TeacherDetails
RENAME TABLE Teachers TO TeacherDetails;  -- renaming the Teachers table

-- rename the Marks table to MarksDetails
RENAME TABLE Marks TO MarksDetails;  -- renaming the Marks table

-- rename the 'Gender' column in Student table to 'StudentGender' and change its data type to VARCHAR(20)
ALTER TABLE Students CHANGE Gender StudentGender VARCHAR(20); 
ALTER TABLE Students MODIFY Gender VARCHAR(20);
-- that's why diff between change and modify keyword it is important to small mistake

-- add a new column 'Address' to the Student table
ALTER TABLE Students 
ADD Address VARCHAR(255);  -- adding a new column 'Address' to the Students table
