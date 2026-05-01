using System.ComponentModel.DataAnnotations;

namespace db.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "enter email")]
        [EmailAddress(ErrorMessage = "invalid email")]
        public string Email { get; set; }

        [Range(1, 120, ErrorMessage = "age in range 1 - 120")]
        public int Age { get; set; }
    }
}
