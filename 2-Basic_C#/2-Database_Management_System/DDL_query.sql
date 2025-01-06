-- ddl commands 
-- create , alter , drop ,truncate , rename 
-- create data base 


-- syntax: CREATE DATABASE databasename;
create database School;

-- use database 
use School;

-- create table 
create table Students(
	studentID int auto_increment primary key,
    sName varchar(50) not null,
    age int ,
    city varchar(20),
    createdAt datetime default current_timestamp 
);

create table Subjects(
subjectID int auto_increment primary key,
subjectName varchar(50) not null
);

create table Marks(
markID int auto_increment primary key,
studentID int,
subjectID int ,
marks int ,
constraint fk_student foreign key (studentID) references Students(studentID), -- beacuse table rename students to scholar
constraint fk_subject foreign key (subjectID) references Subjects(subjectID),
constraint chk_marks check (marks >=0 and marks<=100)

);
-- alter keyword 

-- add col
alter table Students add email varchar(30);
alter table Students add constraint UQ_email unique (email);
alter table Students add fatherAnnualIncome int ;

-- drop keyword 
alter table Students drop column city ;

alter table Students modify column email varchar(10);
alter table Students modify column age varchar(20);


-- drop 

drop database School;
drop table Students;
drop table marks;

-- truncate 

-- error throw using database  truncate database School;
truncate table Students;


-- rename command

-- rename table Students to Scholar;
rename table Scholar to Students;
alter table Students rename to Scholar;

-- show table structure 
-- describe Scholar;
describe Subjects;
describe marks;
describe Students;
show columns from Scholar;

