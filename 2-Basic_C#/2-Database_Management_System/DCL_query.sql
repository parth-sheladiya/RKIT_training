-- use database schooldb for all topics 
use schooldb;

-- creating users
create user 'admin'@'localhost' identified by 'adminpassword123';  -- create admin user
create user 'teacher'@'localhost' identified by 'teacherpassword123';  -- create teacher user
create user 'student'@'localhost' identified by 'studentpassword123';  -- create student user

-- grant all permissions to admin on schooldb
grant all privileges on schooldb.* to 'admin'@'localhost';  -- give full permissions to admin

-- grant specific permissions to teacher on Teachers and Marks table
grant select, update on schooldb.Teachers to 'teacher'@'localhost';  -- give select and update permissions on Teachers table to teacher
grant select, update on schooldb.Marks to 'teacher'@'localhost';  -- give select and update permissions on Marks table to teacher

-- grant select permission to student on Marks table
grant select on schooldb.Marks to 'student'@'localhost';  -- give select permission on Marks table to student

-- revoke update permission from teacher on Marks table
revoke update on schooldb.Marks from 'teacher'@'localhost';  -- revoke update permission on Marks table from teacher

-- revoke delete permission from admin on entire database
revoke delete on schooldb.* from 'admin'@'localhost';  -- revoke delete permission from admin on whole database

-- check permissions for admin user
show grants for 'admin'@'localhost';  -- check permissions for admin user

-- check permissions for student user
show grants for 'student'@'localhost';  -- check permissions for student user

-- delete teacher user
drop user 'teacher'@'localhost';  -- delete teacher user
drop user 'admin'@'localhost';  -- delete admin user
drop user 'student'@'localhost';  -- delete student user

-- check grants for teacher user (this will give an error because the user has been deleted)
show grants for 'teacher'@'localhost';  -- check grants for teacher user (will error out as user is deleted)
