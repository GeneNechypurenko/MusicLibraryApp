using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.Base;

namespace MusicLibraryApp.Models.HomePage
{
    public class HomeIndexViewModel : IndexModel
	{
		public HomeFilterViewModel Filter { get; set; }
		public HomeIndexViewModel(IEnumerable<TuneDTO> tunes, PaginationModel page, HomeFilterViewModel filter)
			: base(tunes, page, filter)
		{
			Filter = filter;
		}
	}
}
