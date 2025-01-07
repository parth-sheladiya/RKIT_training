-- database
create database university; 
use university;
-- student table
create table Students (
    StudentID int auto_increment primary key,
    sName varchar(50),
    Age int,
    Class varchar(10)
);
-- subject tabke
create table Subjects (
SubjectID int auto_increment primary key,
SubjectName varchar(20)

);

-- mark table 
create table Marks(
MarkID int auto_increment primary key ,
StudentID int,
SubjectID int,
Marks int, 
foreign key (StudentID) references Students(StudentID),
foreign key (SubjectID) references Subjects(SubjectID)
);


-- single row insert 
insert into 
			Students(sName , Age , Class ) 
values ("parth" , 21 ,  "7");

insert into 
			Subjects(SubjectName)
values ("physics");

insert into 
			Marks(StudentID , SubjectID , Marks)
values (1,1,90);


-- multiple row insert 
insert into 
			Students(sName, Age , Class)
            values
('Parth', 21, '7'),
('Riya', 14, '9'),
('Mohit', 16, '11'),
('Neha', 15, '10'),
('Diya', 11, '9'),
('Ravi', 17, '12'),
('Jeel', 18, '12'),
('Arpit', 14, '9'),
('Harit', 19, '11'),
('Keyur', 12, '10'),
('Nisha', 13, '8'),
('Rohan', 15, '10');

INSERT INTO Subjects(SubjectName) VALUES
('Physics'),
('Chemistry'),
('Mathematics'),
('Biology'),
('English'),
('Computer Science'),
('History'),
('Geography'),
('Economics'),
('Political Science'),
('Hindi'),
('Sanskrit');

INSERT INTO Marks(StudentID, SubjectID, Marks) VALUES
(1, 1, 85),
(2, 2, 90),
(3, 3, 78),
(4, 4, 98),
(5, 5, 76),
(6, 6, 89),
(7, 7, 95),
(8, 8, 72),
(9, 9, 84),
(10, 10, 91),
(11, 11, 75),
(12, 12, 82);


-- select cmd
-- retrive all details
select * from Students;
select * from Subjects;
select * from Marks;

-- retrive specific details
select sName, Class from Students;
select SubjectName from Subjects;

-- using where 
select * from Students 
where Class = "11" ;

-- order by 
select * from Students 
order by Age asc;

-- limit keyword
select * from Students
order by age desc limit 1;

-- join 
select s.sName , m.Marks 
from Students s join Marks m on s.StudentID = m.StudentID;


-- update
-- single row update 

update Students 
set age =23 
where sName = 'jeel';
SET SQL_SAFE_UPDATES = 0;
update Marks 
set MArks = Marks-2
where StudentID =1;
SET SQL_SAFE_UPDATES = 1;

-- delelte

delete from Students 
where sName='diya';

-- all row delete 
delete from Marks;


-- using aggrigate fun 
-- avg , max , min
select avg(Marks) as avarage_marks,
		max(Marks) as max_Marks,
        min(Marks) as min_marks
from Marks;

-- count 
select Class , count(*) as totalstudents
from Students 
group by Class;

-- having 
select Class , count(*) as totalstudents 
from Students 
group by Class 
having totalstudents=2;

-- as keyword 
select sName as StudentName , Class as Section 
from Students;


-- distinct 
select distinct Class 
from Students;

drop table Students;
drop table Marks;
drop table Subjects;