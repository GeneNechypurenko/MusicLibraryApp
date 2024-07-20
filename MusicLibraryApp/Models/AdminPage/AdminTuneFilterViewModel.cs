using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.HomePage;

namespace MusicLibraryApp.Models.AdminPage
{
	public class AdminTuneFilterViewModel : HomeFilterViewModel
	{
		public AdminTuneFilterViewModel(List<CategoryDTO> items, int selectedItemId) 
			: base(items, selectedItemId)
		{
			items.Insert(1, new CategoryDTO { Id = -2, Genre = "New" });
			items.Insert(2, new CategoryDTO { Id = -1, Genre = "Blocked" });
		}
	}
}
