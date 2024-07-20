using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Base
{
    public class FilterModel<T>
    {
        public SelectList Items { get; }
        public int SelectedItemId { get; }
		public FilterModel(List<T> items, int selectedItemId)
		{
			Items = new SelectList(items, "Id", "Genre" ?? "Username",  selectedItemId);
			SelectedItemId = selectedItemId;
		}
	}
}
