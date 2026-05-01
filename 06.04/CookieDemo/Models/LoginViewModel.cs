using System.ComponentModel.DataAnnotations;

namespace CookieDemo.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
