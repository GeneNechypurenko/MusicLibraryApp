using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.HomePage
{
	public class HomeFilterViewModel : FilterViewModel<CategoryDTO>
	{
		public HomeFilterViewModel(List<CategoryDTO> items, int selectedItemId, string search)
			: base(items, selectedItemId, search)
		{
			items.Insert(0, new CategoryDTO { Id = 0, Genre = "All Genres" });
			new SelectList(items, "Id", "Genre", selectedItemId);
        }
	}
}
