-- use schooldb database for all topics
use schooldb;

-- create an index on the TeacherName column of the Teachers table
-- this will make queries on the TeacherName column faster
create index idx_teacher_name on teachers(teachername);

-- view all existing indexes in the Teachers table
show indexes from teachers;

-- create an index on both StudentID and TeacherID columns in the Marks table
-- this will optimize queries that search using both columns
create index idx_student_teacher on marks(studentid, teacherid);

-- view all existing indexes in the Marks table
show indexes from marks;

-- drop the idx_teacher_name index from the Teachers table
drop index idx_teacher_name on teachers;

-- retrieve data from the Marks table based on the Subject column
-- using EXPLAIN to check if the index is being used
explain select * from marks where subject = 'Mathematics';

-- create a unique index on the StudentID column in the Students table
-- this will prevent duplicate values in the StudentID column
create unique index idx_unique_student_id on students(studentid);

-- create a full-text index on the TeacherName column in the Teachers table
create fulltext index idx_fulltext_teacher_name on teachers(teachername);
