-- use database schooldb for all topics 
use schooldb;

-- creating users admin , teacher , student
create user 'admin'@'localhost' identified by 'adminpassword123'; 
create user 'teacher'@'localhost' identified by 'teacherpassword123';  
create user 'student'@'localhost' identified by 'studentpassword123'; 

-- grant all permissions to admin on schooldb
grant all privileges on schooldb.* to 'admin'@'localhost';  

-- grant specific permissions to teacher on Teachers and Marks table
grant select, update on schooldb.Teachers to 'teacher'@'localhost';  
grant select, update on schooldb.Marks to 'teacher'@'localhost'; 

-- grant select permission to student on Marks table
grant select on schooldb.Marks to 'student'@'localhost';  

-- revoke update permission from teacher on Marks table
revoke update on schooldb.Marks from 'teacher'@'localhost';  

-- revoke delete permission from admin on entire database
revoke delete on schooldb.* from 'admin'@'localhost';

-- check permissions for admin user
show grants for 'admin'@'localhost';  

-- check permissions for student user
show grants for 'student'@'localhost'; 

-- delete teacher user
drop user 'teacher'@'localhost';  
drop user 'admin'@'localhost'; 
drop user 'student'@'localhost'; 

-- check grants for teacher user (this will give an error because the user has been deleted)
show grants for 'teacher'@'localhost'; 
