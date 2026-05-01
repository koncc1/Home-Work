using WebApplication7.DTOs;
using WebApplication7.Models;

namespace WebApplication7.Services.Interfaces
{
    public interface IStudentService
    {
        void create(CreateStudentDto obj);
        List<Student> GetAll();
    }
}
