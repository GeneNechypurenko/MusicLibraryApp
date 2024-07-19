using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Base
{
    public class FilterViewModel<T>
    {
        public FilterViewModel(List<T> items, int selectedItemId, string search)
        {
            Items = new SelectList(items, "Id", "Genre", selectedItemId);
            SelectedItemId = selectedItemId;
            Search = search;
        }
        public SelectList Items { get; }
        public int SelectedItemId { get; }
        public string Search { get; }
    }
}
