using System.ComponentModel.DataAnnotations;

namespace CookieDemo.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}