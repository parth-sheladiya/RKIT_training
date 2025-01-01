-- use of university data
use university;

-- top 5 student of student tbl
select * from Students limit 5;

-- retrive 3 subjects
select * from Subjects limit 3;

-- retrive 5 marks of mark tbl
select * from Marks limit 5;

-- retrive 5 student after skip 2 student
select * from students limit 2 , 5;

-- retrive top 3 highest mark 
select * from Marks order by Marks desc limit 3;

-- retrive top 3 lowest mark 
select * from marks order by marks asc limit 3;

-- alphabatically sorted 
select * from subjects order by SubjectName asc limit 4;

-- top 5 even num row retrive 
select * from students where studentid % 2 =0 limit 5;

-- randomly 5 row retrive 
select * from students order by rand() limit 4;