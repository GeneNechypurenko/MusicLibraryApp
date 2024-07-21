using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Home
{
	public class FilterModel
	{
		public SelectList Category { get; }
		public int Selected { get; set; }
		public FilterModel(List<CategoryDTO> category, int selected)
		{
			Category = new SelectList(category, "Id", "Genre", selected);
			Selected = selected;
		}
	}
}
