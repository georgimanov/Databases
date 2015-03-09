SELECT <column>
	FROM <table>
	
SELECT TOP 10 <column>
	FROM <table>

DISTINCT - unique values only

UNION - returns all elements from 2 columns (unique values only between the 2 bases)

INTERSECT - returns all elements from 2 columns (only the elements that repeat in column 1 and column 2)

EXCEP - returns all elements from 2 columns (without the elements that repeat in column 1 and column 2)

BETWEEN - get values between 20 AND 200
		- sets range
	SELECT FirstName as Name
	FROM dbo 
	WHERE Salary <= 10000
	WHERE Salary BETWEEN 20 AND 200
	
IN - returns exact match only
	SELECT FirstName AS Name, Salary
	FROM dbo
	WHERE Salary IN (200, 20)
	
NOT IN - returns all value that does not match the exact value

LIKE - 
	SELECT FirstName
	FROM Employees
	WHERE FirstName LIKE 'S%'
	
	%S -> all values that starts with 's'
	%S -> ends with 's'
	
IS - all vales that cover the statement
	SELECT FirstName
	FROM Employees
	WHERE MaganerID IS NULL 
	
IS NOT - all vales that does NOT cover the statement
	SELECT FirstName
	FROM Employees
	WHERE MaganerID IS NOT NULL 
	
!!! WHERE MaganerID = NULL (this always returns FALSE)
		
NOT, OR, AND 

!SORTING:
ORDER BY column 
	ASC - ascending (by default)
	DESC - descending
	ASC and DESC can be set to each column
	
JOINING TABLES

INNER JOIN - returns only rows from tables matchin the join condition
	SELECT e.FirstName, d.Name, e.DepartmentID, d.DepartmentID
	FROM Employees e
		INNER JOIN DepartmentID d 
			ON e.DepartmentID = d.DepartmentID
			
LEFT(or RIGHT) JOIN - returns the results of the inner join as well as unmatched rows from the LEFT (or RIGHT) table

FULL OUTER JOIN - returns the results of an inner join as well as the results of a left and right join

CROSS JOIN - when there is no JOIN

THREE WAY JOIN 
	SELECT e.FirstName, e.LastName, t.Name as Town, a.AddressText 
	FROM Employees e
		JOIN Addresses a
			ON e.AddressID = a.AddressID
		JOIN Towns t
			ON a.TownID = t.TownID
			
SELF JOIN 
	SELECT e.FirstName + ' ' + e.LastName + ' is managed by ' + m.LastName
	FROM Employees e
		JOIN Employees m
			ON (e.ManagerID = m.MaganerID)
			
CROSS JOIN 
	Careful when you use it
	
INSERT INTO 
	INSERT INTO EmployeesProjects
	VALUES (229, 44)

	INSERT INTO Projects(Name, StartDate)
	VALUES ('New project', GETDATE())
 
	INSERT INTO Projects(Name, StartDate)
		SELECT Name + 'Restructuring' + GETDATE()
			FROM Departments
			
UPDATE 
	! DON'T FORGET THE WHERE CLAUSE !

	UPDATE <table> 
		SET <column=expression>
	WHERE <condition>
	
	UPDATE Employees
	SET JobTitle = 'Senior' + JobTitle
	FROM Employees e
		JOIN Departments d
		  ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	
DELETE 
	DELETE FROM Employees
		WHERE EmployeeID = 1
	
	DELETE FROM Employees
		WHERE LastName Lise 'S%'
		
	DELETE FROM Employees
	FROM Employees e
		JOIN Departments d
		  ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
		
FUNCTIONS 
	-> GETDATE() - returns current date

MATHEMATICAL FUNCTIONS 
	-> ROUND() - rounds up
	-> FLOOR() - rounds down
	-> POWER() - 
	-> ABS() -
	-> SQRT() -
	
	SELECT FLOOR(3.14) -> 3
	SELECT ROUND(5.86, 0) -> 6.00

DATE FUNCTIONS
	-> GETDATE()
	-> DATEADD()
	-> DAY()
	-> MOTH()
	-> YEAR()
	-> DATEDIFF() - calculates the difference between dates
	-> DATEDIFF(detepart, startdate, edndate)

COVERSION FUNCTIONS 
	-> CONVERT()
	-> CAST()

	SELECT CONVERT(DATETIME, '20051231', 112)
	-> 2005-12-31 00:00:00.000
	--- 112 is the ISO formatting style YYYYMMDD

