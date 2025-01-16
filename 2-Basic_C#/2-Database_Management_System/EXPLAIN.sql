 -- use university database
 
 use schooldb;

-- explain keyword
 EXPLAIN FORMAT=JSON SELECT * FROM Marks  WHERE MarksObtained > 80;
 
 EXPLAIN FORMAT=TREE SELECT * FROM Marks  WHERE MarksObtained > 80;
EXPLAIN SELECT * FROM Marks  where MarksObtained>0 ;

