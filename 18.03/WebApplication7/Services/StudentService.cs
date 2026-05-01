using WebApplication7.DTOs;
using WebApplication7.Services.Interfaces;

namespace WebApplication7.Services
{
    public class StudentService : IStudentService
    {
        static List<Models.Student> students = new List<Models.Student> {
        new Models.Student { Id = 1, FullName = "John Doe", Age = 20 },
        new Models.Student { Id = 2, FullName = "Jane Smith", Age = 22 },
        new Models.Student { Id = 3, FullName = "Alice Johnson", Age = 19 }
        };

        public void create(CreateStudentDto obj)
        {
            var student = new Models.Student
            {
                Id = students.Count + 1,
                FullName = obj.FullName,
                Age = obj.Age
            };
            students.Add(student);
        }

        public List<Models.Student> GetAll()
        {
            return students;
        }
    }
}
