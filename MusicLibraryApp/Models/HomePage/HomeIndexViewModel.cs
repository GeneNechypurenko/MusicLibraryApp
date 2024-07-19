using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.HomePage
{
	public class HomeIndexViewModel : IndexViewModel
	{
		public HomeFilterViewModel Filter { get; set; }
		public HomeIndexViewModel(IEnumerable<TuneDTO> tunes, PaginationViewModel page, HomeFilterViewModel filter)
			: base(tunes, page, filter)
		{
			Filter = filter;
		}
	}
}
