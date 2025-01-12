-- using schooldb database for all topics
use schooldb;

-- inner join: joining marks and students table
-- here, we are joining based on studentid
select students.studentid, students.firstname, students.lastname, marks.subject, marks.marksobtained
from students
inner join marks on students.studentid = marks.studentid;

-- left join: joining students and marks table
-- here, we will get all student records, whether matching records exist in marks table or not
select students.studentid, students.firstname, students.lastname, marks.subject, marks.marksobtained
from students
left join marks on students.studentid = marks.studentid;

-- right join: joining marks and students table
-- here, we will get all marks records, whether matching student records exist or not
select marks.markid, marks.subject, marks.marksobtained, students.firstname, students.lastname
from marks
right join students on marks.studentid = students.studentid;

-- self join: joining students table with itself
-- here, we are joining students based on same gender
select a.studentid as student1, a.firstname as firstname1, b.studentid as student2, b.firstname as firstname2
from students a, students b
where a.gender = b.gender and a.studentid != b.studentid;

-- using aliases to join: marks, students, and teachers
select s.studentid, s.firstname, m.subject, m.marksobtained, t.teachername
from marks m
inner join students s on m.studentid = s.studentid
inner join teachers t on m.teacherid = t.teacherid;

-- join with where clause: joining marks table with students and teachers
-- and only showing records for the subject 'Mathematics'
select students.studentid, students.firstname, marks.marksobtained, teachers.teachername
from marks
inner join students on marks.studentid = students.studentid
inner join teachers on marks.teacherid = teachers.teacherid
where marks.subject = 'Mathematics';
