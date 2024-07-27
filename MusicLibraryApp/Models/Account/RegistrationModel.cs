using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.Account
{
	public class RegistrationModel
	{
		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "UsernameRequired")]
		[RegularExpression(@"^(?!admin$|Admin$).*", ErrorMessage = "Username cannot be 'Admin' or 'admin'")]
		public string Username { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "PasswordRequired")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
			ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "PasswordRequirements")]
		public string Password { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "ConfirmationRequired")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "PasswordComparison")]
		public string Confirmation { get; set; }
	}
}
