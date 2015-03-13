###Homework: Entity Framework
This document defines the homework assignments from the "Database Applications" Course @ Software University. Please submit as homework a single zip / rar / 7z archive holding the solutions (source code) of all below described problems.
##Problem 1.	Create a Database for Student System using Code First
Your task is to create a database for student system, using the EF code first approach with the following tables:
	Students: id, name, phone number, registration date, birthday
	Courses: id, name, description, start date, end date, price
	Resources: id, name, type of resource (video / presentation / document / other), link
	Homework: id, content, content-type (e.g. application/pdf or application/zip), date and time
Additional requirements:
	Students can be in many courses
	Courses can have many students
	Courses can have many resources
	One course can have many homework submissions
	Homework submissions have a student
Add navigational properties in all models to simplify navigation. Annotate the data models with the appropriate attributes and validations and enable code first migrations.
##Problem 2.	Seed Some Data in Database
Write a seed method that fills the database with sample data (randomly generated). Fill a few students, courses, resources and homework submissions. Configure the EF to run the seed method after the database is created for a first time. Run the application several times to ensure that it seeds sample data only once.
##Problem 3.	Write a Console Application that Works with the Data
Write a console application that:
	Lists all students and their homework submissions
	List all course and their resources
	Adds a new course with some resources
	Adds a new student
	Adds a new resource

