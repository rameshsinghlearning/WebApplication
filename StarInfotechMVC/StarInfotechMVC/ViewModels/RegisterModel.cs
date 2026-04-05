using System.ComponentModel.DataAnnotations;

namespace StarInfotechMVC.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        public string? Email { get; set; }

        public string? MobileNo { get; set; }
    }
}
