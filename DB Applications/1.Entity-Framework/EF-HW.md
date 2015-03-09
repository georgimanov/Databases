**Homework: Entity Framework**

This document defines the homework assignments from the "Database Applications" Course @ Software University. Please submit as homework a single zip / rar / 7z archive holding the solutions (source code) of all below described problems.
**Problem** 1.	DbContext for the SoftUni Database
Your task is to create a DbContext for the SoftUni database using the Visual Studio Entity Framework Designer. Map all database tables. Exclude any stored procedures.

**Problem** 2.	Employee DAO Class
Your task is to create a Data Access Object (DAO) class with static methods, which provide functionality for inserting, modifying and deleting employees. Write a testing class.

**Problem** 3.	Employees with Projects after 2002
Your task is to write a method that finds all employees who have projects with start date in 2002 year.

**Problem** 4.	Native SQL Query
Your task is to solve the previous task by using native SQL query and executing it through the DbContext.

**Problem** 5.	Employees by Department and Manager
Your task is to write a method that finds all employees by specified department (name) and manager (first name and last name).

**Problem** 6.	Concurrent Database Changes with EF
Your task is to try to open two different data contexts and to perform concurrent changes on the same records in some database table. What will happen at SaveChanges()? How to deal with it?

**Problem** 7.	Employees with Corresponding Territories
Your task is to create a class, which allows employees to access their corresponding territories as property of the type EntitySet<T> by inheriting the Employee entity class or by using a partial class.

**Problem** 8.	Insert a New Project
Your task is to create a method that inserts a new project in the SoftUni database. The project should contain several employees.

**Problem** 9.	Call a Stored Procedure
Your task is to create a stored procedure in the SoftUni database for finding all projects for given employee (first name and last name). Using EF implement a C# method that calls the stored procedure and returns the retuned record set.

**Problem** 10.	* Play with the SQL Server Profiler
Your task is to use the SQL Server ExpressProfiler to view all your queries from the previous homework task. Submit a screenshot as a homework.

**Problem** 11.	* Explore the Full Source Code of Entity Framework
Your task is to download (clone the repository) and explore the full source code of Entity Framework. You can find it on http://entityframework.codeplex.com. Do not submit anything for this problem.

