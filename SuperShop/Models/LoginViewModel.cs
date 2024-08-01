using System.ComponentModel.DataAnnotations;

namespace SuperShop.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must contain at least 6 characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
