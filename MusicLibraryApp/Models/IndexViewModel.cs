using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.HomePage;

namespace MusicLibraryApp.Models
{
	public class IndexViewModel
	{
		public IEnumerable<TuneDTO> Tunes { get; set; }
		public PaginationViewModel Page { get; set; }
		public IndexViewModel(IEnumerable<TuneDTO> tunes, PaginationViewModel page, HomeFilterViewModel filter)
		{
			Tunes = tunes;
			Page = page;
		}
	}
}
