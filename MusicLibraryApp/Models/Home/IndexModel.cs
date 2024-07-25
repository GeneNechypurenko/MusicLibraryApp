using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.CommonModels;

namespace MusicLibraryApp.Models.Home
{
    public class IndexModel
	{
		public UserDTO? User { get; }
		public IEnumerable<TuneDTO> Tunes { get; set; }
		public PaginationModel Page { get; }
		public FilterModel Filter { get; }

		public IndexModel(UserDTO user, IEnumerable<TuneDTO> tunes, PaginationModel page, FilterModel filter)
		{
			User = user;
			Tunes = tunes;
			Page = page;
			Filter = filter;
		}
	}
}
