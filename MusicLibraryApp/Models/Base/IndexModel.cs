using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.HomePage;

namespace MusicLibraryApp.Models.Base
{
    public class IndexModel
    {
        public IEnumerable<TuneDTO> Tunes { get; set; }
        public PaginationModel Page { get; set; }
        public IndexModel(IEnumerable<TuneDTO> tunes, PaginationModel page, FilterModel<CategoryDTO> filter)
        {
            Tunes = tunes;
            Page = page;
        }
    }
}
