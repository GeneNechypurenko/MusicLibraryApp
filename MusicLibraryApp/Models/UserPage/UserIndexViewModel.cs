using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;
using MusicLibraryApp.Models.HomePage;

namespace MusicLibraryApp.Models.UserPage
{
    public class UserIndexViewModel : HomeIndexViewModel
	{
		public UserModel User { get; set; }
		public IEnumerable<CategoryDTO> Categories { get; set; }
		public UserIndexViewModel(IEnumerable<TuneDTO> tunes, PaginationModel page, HomeFilterViewModel filter,
			UserModel user, IEnumerable<CategoryDTO> categories)
			: base(tunes, page, filter)
		{
			User = user;
			Categories = categories;
		}
	}
}
