-- create a simple view that shows data from Teachers and Marks
create view teachermarksview as
select t.teacherid, t.teachername, m.studentid, m.marksobtained, m.subjectName
from teachers t
join marks m on t.teacherid = m.teacherid;

-- retrieve data from the TeacherMarksView
select * from teachermarksview;

-- create a view that shows teachers and marks for the Mathematics subject
create view mathteachersmarks as
select t.teacherid, t.teachername, m.studentid, m.marksobtained
from teachers t
join marks m on t.teacherid = m.teacherid
where m.subjectName = 'Mathematics';

-- create a view that calculates average marks by subject
create view averagemarksbysubject as
select m.subjectName, avg(m.marksobtained) as averagemarks
from marks m
group by m.subjectName;

-- update TeacherMarksView, changing the marks for TeacherID = 1
update teachermarksview
set marksobtained = 90
where teacherid = 1 and studentid = 1;

-- delete a record from TeacherMarksView
delete from teachermarksview
where teacherid = 2 and studentid = 2;

-- drop the TeacherMarksView
drop view teachermarksview;

-- view all views in the database
show full tables where table_type = 'view';
