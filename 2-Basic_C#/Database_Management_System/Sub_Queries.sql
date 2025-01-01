-- use university database 
use university;

-- find the student who scored the highest mrks 
	select sName from Students where StudentID = (
									select StudentID from Marks order by Marks desc limit 1
);	

-- find the student who scored the lowest  mrks 
	select sName from Students where StudentID = (
									select StudentID from Marks order by Marks asc limit 1
    );
    
-- List subjects in which any student scored more than 90 marks
   select SubjectName from Subjects where SubjectID 	in (
									select SubjectID from Marks where Marks >90
   );
   
-- ind the students who are in the same class as 'Riya'
select sName from Students where Class = (
							select Class from Students where sName= "Riya"
);

-- find total mark of specific student 

select sum(Marks) as totalmarks from Marks where StudentID =(
						 select StudentID from Students where sName="Arpit"
);

-- Find the subjects in which 'Parth' has scored marks
select SubjectName from Subjects where SubjectID in (
						select SubjectID from Marks where StudentID in (
									select StudentID  from students where sName = "Parth"
                        )
);

-- find the second marks of mark table 
select max(Marks) as secondmarks from Marks where marks < (
					select  max(Marks) from Marks
);

-- find student whi have scored below avg marks 

select sName from Students where StudentID in (
		select StudentID from marks where marks < (select avg(marks) from marks)
);

-- Find students who scored the same marks as the highest marks in
select sName from Students where StudentID in (
						select StudentID from marks where marks = (
									select  max(marks) from marks where SubjectID = (
											select SubjectID from Subjects where SubjectName = "mathematics"
                                    )
                        
                        )
);