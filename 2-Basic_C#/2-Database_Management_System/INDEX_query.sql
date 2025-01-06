-- use university database 
use university;

--  Creating index on sName column
create index idx_sName on students(sName);

select * from students where sName = 'Parth';

show indexes from Students;


-- Index on Multiple Columns

create index idx_age_class on students(age,class);

EXPLAIN SELECT * FROM Students WHERE sName = 'Parth';

-- Dropping the index on sName
DROP INDEX idx_sName ON Students;

