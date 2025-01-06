-- using university databse
use university;

-- inner join 
-- Find the names of students along with the subjects they are enrolled in and their marks.

select students.sName , Subjects.SubjectName , Marks.Marks from marks 
inner join Students on marks.studentID = students.studentID
inner join subjects on marks.SubjectID = subjects.SubjectID;

-- left join 
-- List all students along with their marks. If a student has no marks, still include their name with NULL.
select Students.sName,marks.marks from students left join marks on students.StudentID = marks.StudentID;

-- right join 
-- List all subjects along with the marks scored by students. If no marks exist for a subject, show NULL.

select subjects.subjectName , marks.marks from Marks right join Subjects on marks.subjectID = subjects.subjectID;

-- self join 
-- Find students who are in the same class as another student (excluding themselves).

SELECT A.sName AS Student1, B.sName AS Student2, A.Class
FROM Students A
INNER JOIN Students B ON A.Class = B.Class
WHERE A.StudentID != B.StudentID;

-- cross join 
-- Find all possible combinations of students and subjects.

select Students.sName , subjects.SubjectName from students cross join Subjects;


-- join with aggregate fun 
-- Find the total marks scored by each student.
select Students.sName , sum(marks.marks) as totalmark from Students 	
inner join marks on students.studentId = marks.studentId 
group by students.sName;
