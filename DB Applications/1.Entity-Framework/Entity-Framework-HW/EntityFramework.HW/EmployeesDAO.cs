using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;

namespace EntityFramework.HW
{
    public static class EmployeesDAO
    {
        // Problem 2. Employee DAO Class
        // Your task is to create a Data Access Object (DAO) class with static methods, which provide functionality for inserting, modifying and deleting employees. Write a testing class.
         public static int CreateNewEmployee(SoftUniEntities db, string firstName, string lastName, string middleName, string jobTitle, int departmentId, int managerId, DateTime hireDate, decimal salary, int AddressId)
        {
            Employee newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                JobTitle = jobTitle,
                DepartmentID = departmentId,
                ManagerID = managerId,
                HireDate = hireDate,
                Salary = salary,
                AddressID = AddressId,
            };
            db.Employees.Add(newEmployee);
            db.SaveChanges();

            return newEmployee.EmployeeID;
        }

         public static void ModifyEmployeeName(SoftUniEntities db, int employeeId, string newName)
        {
            Employee employee = GetEmployeeById(db, employeeId);
            employee.FirstName = newName;
            db.SaveChanges();
        }

         public static void DeleteEmployee(SoftUniEntities db, int employeeId)
        {
            Employee employee = GetEmployeeById(db, employeeId);
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

        public static Employee GetEmployeeById(SoftUniEntities db, int employeeId)
        {
            Employee employee = db.Employees.FirstOrDefault(
                e => e.EmployeeID == employeeId);
            return employee;
        }

        public static void DisplayEmployeeByStartDate(SoftUniEntities db, DateTime date, int limit)
        {
            var employeesProjects = db.Employees
                 .Where(e => e.Projects.Any(p => p.StartDate.Year <= date.Year))
                 .Take(limit);

            foreach (var currentEmployee in employeesProjects)
            {
                Console.WriteLine("Name: {0} {1}",currentEmployee.FirstName, currentEmployee.LastName);
                foreach (var employeeProject in currentEmployee.Projects)
                {
                    Console.WriteLine("Project: {0}, Year: {1}",employeeProject.Name, employeeProject.StartDate);
                }

                Console.WriteLine();
            }
        }

        public static void DisplayEmployeesByStartDateSQLNative(SoftUniEntities db)
        {
            string nativeSqlQuery =
                "Select e.FirstName + ' ' + e.LastName + ' ' + p.Name + ' ' + cast(p.StartDate as nvarchar) " +
                    "from Employees e " +
                    "left join EmployeesProjects ep on ep.EmployeeID = e.EmployeeID " +
                    "left join Projects p on p.ProjectID = ep.ProjectID " +
                    "where p.StartDate >= '2002-01-01' ";
            var employees = db.Database.SqlQuery<string>(nativeSqlQuery).ToList();

            foreach (var empl in employees)
            {
                Console.WriteLine(empl);
            }
        }

        public static void DisplayEmployeeByDepartmentAndManager(SoftUniEntities db, string departmentName, string firstName, string lastName)
        {
            var manager = db.Employees.FirstOrDefault(e=> e.FirstName == firstName && e.LastName == lastName);
            var employees = db.Employees.Where(e => e.Department.Name == departmentName && e.ManagerID == manager.EmployeeID);

            foreach (var employee in employees)
            {
                Console.WriteLine("Name: {0} {1}; {2}; {3} {4}", employee.FirstName, employee.LastName, employee.Department.Name, manager.FirstName, manager.LastName);
            }
            Console.WriteLine();
        }

        public static void InsertProjectWithEmployees(SoftUniEntities db, string projectName, string projectDescription, DateTime startDate, DateTime endDate, List<Employee> employees)
        {
            Project newProject = new Project
            {
                Name = projectName,
                Description = projectDescription,
                StartDate = startDate,
                EndDate = endDate,
                Employees = employees,
            };
            db.Projects.Add(newProject);
            db.SaveChanges();
        }
    }
}
