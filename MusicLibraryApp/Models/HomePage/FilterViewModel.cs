using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.HomePage
{
    public class FilterViewModel
    {
        public FilterViewModel(List<CategoryDTO> categories, int selectedGenreId, string search)
        {
            categories.Insert(0, new CategoryDTO { Id = 0, Genre = "All Genres" });
            Categories = new SelectList(categories, "Id", "Genre", selectedGenreId);
            SelectedGenreId = selectedGenreId;
            Search = search;
            
        }
        public SelectList Categories { get; }
        public int SelectedGenreId { get; }
        public string Search { get; }
    }
}
