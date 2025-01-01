-- use university databse
use university;

-- Basic UNION (Remove Duplicates)
select sName from students where class	= '7'

union 

select subjectName from subjects;


--  UNION ALL (Include Duplicates)
select sName from students where class = '7'
union all 
select subjectName from subjects;

-- UNION for Different Data Types
select sName , Age from Students where class = '7'
union 
select subjectName , null as age from Subjects;

-- UNION Across Multiple Tables
select sName from Students where class='7'
union 
select marks from marks where marks>90;

-- UNION to Combine Results from Different States

select sName from Students where class='7'
union 
select sName from students where class='9';

