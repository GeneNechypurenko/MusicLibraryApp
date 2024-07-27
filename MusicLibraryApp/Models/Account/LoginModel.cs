using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace MusicLibraryApp.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
            ErrorMessageResourceName = "UsernameRequired")]
        public string Username { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "PasswordRequired")]
		[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
