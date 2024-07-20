using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;

namespace MusicLibraryApp.Models.HomePage
{
    public class HomeFilterViewModel : FilterModel<CategoryDTO>
	{
		public HomeFilterViewModel(List<CategoryDTO> items, int selectedItemId)
			: base(items, selectedItemId)
		{
			items.Insert(0, new CategoryDTO { Id = 0, Genre = "All Genres" });
        }
	}
}
