using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;

namespace MusicLibraryApp.Models.UserPage
{
	public class UserCreateViewModel
	{
		public UserViewModel User { get; set; }
		public TuneViewModel Tune { get; set; }
		public UserCreateViewModel(UserViewModel user, TuneViewModel tune)
		{
			User = user;
			Tune = tune;
		}
	}
}
