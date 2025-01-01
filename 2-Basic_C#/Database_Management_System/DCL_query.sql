create database SchoolDB;
use SchoolDB;

create table Students (
    StudentID int auto_increment primary key,
    Name varchar(50),
    Age int,
    Class varchar(10)
);

create table Subjects (
    SubjectID int auto_increment primary key,
    SubjectName varchar(50)
);

create table Marks (
    MarkID int AUTO_INCREMENT primary key,
    StudentID int,
    SubjectID int,
    MarksObtained int,
    foreign key  (StudentID) references Students(StudentID),
    foreign key (SubjectID) references Subjects(SubjectID)
);

-- user create
create user 'admin'@'localhost' identified by 'adminpassword123';
create user 'teacher'@'localhost' identified by 'teacherpassword123';
create user 'student'@'localhost' identified by 'studentpassword123';

-- grant keyword 
GRANT ALL PRIVILEGES ON SchoolDB.* TO 'admin'@'localhost';

-- specific permission for teacher 
GRANT SELECT, UPDATE ON SchoolDB.Subjects TO 'teacher'@'localhost';
GRANT SELECT, UPDATE ON SchoolDB.Marks TO 'teacher'@'localhost';

-- permision for student
GRANT SELECT ON SchoolDB.Marks TO 'student'@'localhost';


-- revoke permission
-- remove permission for update 
REVOKE UPDATE ON SchoolDB.Marks FROM 'teacher'@'localhost';

-- revoke delete permission to admin 
REVOKE DELETE ON SchoolDB.* FROM 'admin'@'localhost';


-- check permission 
SHOW GRANTS FOR 'admin'@'localhost';
SHOW GRANTS FOR 'student'@'localhost';
-- drop teacher user 
DROP USER 'teacher'@'localhost';
SHOW GRANTS FOR 'teacher'@'localhost';










