namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StudentSystem.Models;
    using StudentSystem.Data;

    public static class SeedDAO
    {
        public static Student CreateStudent()
        {
            Student student = new Student();
            Random random = new Random();
            string phoneNumber = "+359";
            for (int i = 0; i < 9; i++)
            {
                phoneNumber += random.Next(0, 10);
            }

            student.Birthday = new DateTime(random.Next(1900, 2000), random.Next(1, 13), random.Next(1, 29));
            student.PhoneNumber = phoneNumber;
            student.RegistrationDate = new DateTime(random.Next(2014, 2017), random.Next(1, 13), random.Next(1, 29));
            student.FullName = "Georgi" + random.Next(0, 10) + " Georgiev" + random.Next(0, 10) + " Gosho" + +random.Next(0, 10);

            return student;
        }

        public static Course CreateCourse()
        {
            Course course = new Course();
            Random random = new Random();

            course.StartDate = new DateTime(random.Next(2014, 2017), random.Next(1, 13), random.Next(1, 29));
            course.EndDate = new DateTime(random.Next(2014, 2017), random.Next(1, 13), random.Next(1, 29));
            course.Description = "Java" + random.Next(0, 10);
            course.Price = (decimal)random.Next(0, 1000);

            return course;
        }

        public static Homework CreateHomework()
        {
            Homework homework = new Homework();
            Random random = new Random();
            byte[] content = new byte[100];
            for (int i = 0; i < 100; i++)
            {
                content[i] = (byte)random.Next(0, 2);
            }

            homework.Content = content;
            ContentType[] type = new ContentType[2] { ContentType.ApplicationPdf, ContentType.ApplicationZip };
            homework.Type = type[random.Next(0, 2)];
            homework.SubmittedOn = new DateTime(random.Next(2014, 2017), random.Next(1, 13), random.Next(1, 29));
            homework.Student = CreateStudent();

            return homework;
        }

        public static Resource CreateResourse()
        {
            Resource resourse = new Resource();
            Random random = new Random();
            ResourceType[] resourseType = new ResourceType[4] { ResourceType.Document, ResourceType.Presentation, ResourceType.Video, ResourceType.Other };
            resourse.Name = "resourse" + random.Next(0, 10);
            resourse.Type = resourseType[random.Next(0, 5)];
            resourse.Link = "link" + random.Next(0, 10);
            resourse.Course = CreateCourse();

            return resourse;
        }

        internal static void DisplayStudents(StudentSystemDbContext studentSystemDbContext)
        {
            using (var db = new StudentSystemDbContext())
            {
                foreach (var student in db.Students)
                {
                    Console.WriteLine(student.FullName);
                }
            }
        }

        internal static void DisplayCourses(StudentSystemDbContext studentSystemDbContext)
        {
            using (var db = new StudentSystemDbContext())
            {
                foreach (var course in db.Courses)
                {
                    Console.WriteLine(course.Description);
                }
            }
        }
    }
}
