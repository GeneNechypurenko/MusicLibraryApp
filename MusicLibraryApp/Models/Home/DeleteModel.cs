using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.Home
{
	public class DeleteModel
	{
		public string Username { get; set; }
		public TuneDTO Tune { get; set; }
	}
}
