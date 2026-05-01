using System.ComponentModel.DataAnnotations;

namespace WebApplication7.DTOs
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage ="Full name")]
        public string FullName { get; set; }
        [Range(16,100,ErrorMessage ="Age")]
        public int Age { get; set; }
    }
}
