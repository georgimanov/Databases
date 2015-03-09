using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;


namespace EntityFramework.HW
{

    class EntityFramework
    {
        static void Main()
        {
            using (var db = new SoftUniEntities())
            {

                //Problem 2. Employee DAO Class
                var newEmplID = EmployeesDAO.CreateNewEmployee(db, "Petar", "Petrov", "Pesho", "Higienist", 7, 16, new DateTime(2000, 01, 05), 35000, 166);

                Console.WriteLine(EmployeesDAO.GetEmployeeById(db, newEmplID).EmployeeID + ": inserted");

                EmployeesDAO.ModifyEmployeeName(db, EmployeesDAO.GetEmployeeById(db, newEmplID).EmployeeID, "Gosho");

                var checkUpdate = EmployeesDAO.GetEmployeeById(db, EmployeesDAO.GetEmployeeById(db, newEmplID).EmployeeID);
                Console.WriteLine("New name : {0}; Employee ID: {1}", checkUpdate.FirstName, checkUpdate.EmployeeID);

                ////Problem 3. Employees with Projects after 2002
                //EmployeesDAO.DisplayEmployeeByStartDate(db, new DateTime(2002, 01, 01), 5);

                ////Problem 4. Native SQL Query
                //EmployeesDAO.DisplayEmployeesByStartDateSQLNative(db);

                ////Problem 5. Employees by Department and Manager
                //EmployeesDAO.DisplayEmployeeByDepartmentAndManager(db, "Engineering", "Roberto", "Tamburello");

                ////Problem 8. Insert a New Project
                //var empl1 = EmployeesDAO.GetEmployeeById(db, 1);
                //var empl2 = EmployeesDAO.GetEmployeeById(db, 3);
                //var empl3 = EmployeesDAO.GetEmployeeById(db, 5);
                //List<Employee> emplList = new List<Employee>() {empl1, empl2, empl3};

                //EmployeesDAO.InsertProjectWithEmployees(db, "TestProject", "Test", new DateTime(2012, 04, 01), new DateTime(2013, 04, 01), emplList);
                //Console.WriteLine("New project added!");

                // Problem 9.	Call a Stored Procedure
                //var employeeProjects = db.sp_GetEmployeeProjects("Guy", "Gilbert");

                //if (employeeProjects.Count() > 0)
                //{
                //    foreach (var project in employeeProjects)
                //    {
                //        Console.WriteLine(project.ProjectID);
                //    }
                //}
                
            }

            ////Problem 6. Concurrent Database Changes with EF
            //var softUni1 = new SoftUniEntities();
            //var softUni2 = new SoftUniEntities();
            //var employee1 = EmployeesDAO.CreateNewEmployee(softUni1, "Petar1", "Petrov1", "Pesho1", "Higienist", 7, 16, new DateTime(2000, 01, 05), 35000, 166);
            //var employee2 = EmployeesDAO.CreateNewEmployee(softUni2, "Petar2", "Petrov2", "Pesho2", "Higienist", 7, 16, new DateTime(2000, 01, 05), 35000, 166);
            //softUni1.SaveChanges();
            //softUni2.SaveChanges();
            //Console.WriteLine("Problem 6: Done!");
        }


    }
}
