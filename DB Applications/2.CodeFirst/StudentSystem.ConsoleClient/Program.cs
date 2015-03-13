
namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Models;

    public class Program
    {
        public static void Main()
        {
            var studentSystemDbContext = new StudentSystemDbContext();

            bool input = false;
            if (input)
            {
                for (int i = 0; i < 10; i++)
                {
                    Student student = SeedDAO.CreateStudent();
                    Course course = SeedDAO.CreateCourse();
                    Homework homework = SeedDAO.CreateHomework();
                    Resource resource = SeedDAO.CreateResourse();

                    studentSystemDbContext.Students.Add(student);
                    studentSystemDbContext.Courses.Add(course);
                    studentSystemDbContext.Homework.Add(homework);
                    studentSystemDbContext.Resources.Add(resource);
                }
                
                var result = studentSystemDbContext.SaveChanges();
                Console.WriteLine("Affected rows: {0}", result);
            }

            SeedDAO.DisplayStudents(studentSystemDbContext);
            SeedDAO.DisplayCourses(studentSystemDbContext);
        }
    }
}
