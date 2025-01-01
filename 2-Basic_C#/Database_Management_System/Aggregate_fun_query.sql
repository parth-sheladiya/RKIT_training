-- use university database
use university;

-- total marks of all students	

select sum(Marks) as totalmarks from Marks;

-- avarage marks of all students
select  avg(Marks) as avaragemarks from Marks;

-- count student 
select count(*) as totalstudent from Students;

-- maximum marks 
select max(Marks) as maxmarks from Marks;

-- min marks 
select min(Marks) as minmarks from Marks;

-- count student of each class 
select Class , count(*) as studentcount from Students group by Class;

-- total marks score by each student
select StudentID , sum(Marks) as totalmarks from Marks group by StudentId;

-- avarage marks in each subject 
select SubjectID , avg(Marks) as avgmarks from Marks group by SubjectID;

-- count how many subject 
select count(*) as totalsubject from Subjects;

-- highest marks in each subjects 
select SubjectId , max(Marks) as highestmark from Marks group by SubjectID;

-- lowest marks in each subjects 
select SubjectID , min(Marks) as lowestmark from Marks group by SubjectID;
