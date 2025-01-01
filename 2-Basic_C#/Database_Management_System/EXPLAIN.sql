 -- use university database
 
 use university;


-- Basic EXPLAIN
EXPLAIN SELECT s.sName, m.Marks
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID;

-- EXPLAIN with WHERE Clause
EXPLAIN SELECT s.sName, m.Marks
FROM Students s
JOIN Marks m ON s.StudentID = m.StudentID
WHERE m.Marks > 80;
