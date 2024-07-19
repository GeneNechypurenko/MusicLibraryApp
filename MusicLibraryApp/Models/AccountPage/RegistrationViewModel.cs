using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.AccountPage
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^(?!admin$|Admin$).*", ErrorMessage = "Username cannot be 'Admin' or 'admin'")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain both letters and numbers!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirmation { get; set; }
    }
}
