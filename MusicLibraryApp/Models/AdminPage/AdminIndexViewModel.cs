using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;
using MusicLibraryApp.Models.HomePage;
using MusicLibraryApp.Models.UserPage;
using System.Collections.Generic;

namespace MusicLibraryApp.Models.AdminPage
{
    public class AdminIndexViewModel : UserIndexViewModel
	{
		public AdminIndexViewModel(IEnumerable<TuneDTO> tunes, PaginationViewModel page, HomeFilterViewModel filter,
			UserViewModel user, IEnumerable<CategoryDTO> categories) : base(tunes, page, filter, user, categories) { }
	}
}
