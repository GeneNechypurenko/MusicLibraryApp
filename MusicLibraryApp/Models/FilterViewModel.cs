using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;
using System.Collections.Generic;

namespace MusicLibraryApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<CategoryDTO> categories, int selectedGenreId)
        {
            categories.Insert(0, new CategoryDTO { Id = 0, Genre = "All" });
            Categories = new SelectList(categories, "Id", "Genre", selectedGenreId);
            SelectedGenreId = selectedGenreId;
        }
        public SelectList Categories { get; }
        public int SelectedGenreId { get; }
        public List<TuneViewModel> Tunes { get; set; }
    }
}
