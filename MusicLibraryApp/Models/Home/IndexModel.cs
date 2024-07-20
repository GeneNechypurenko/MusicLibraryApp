using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Home
{
	public class IndexModel
	{
		public UserDTO? User { get; }
		public IEnumerable<TuneDTO> Tunes { get; set; }
		public PageModel Page { get; }
		public FilterModel Filter { get; }

		public IndexModel(UserDTO user, IEnumerable<TuneDTO> tunes, PageModel page, FilterModel filter)
		{
			User = user;
			Tunes = tunes;
			Page = page;
			Filter = filter;
		}
	}
}
