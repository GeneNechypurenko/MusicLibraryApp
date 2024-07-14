namespace MusicLibraryApp.Models.HomePage
{
	public class TunesPageViewModel : HomePageViewModel
	{
		public IEnumerable<TuneViewModel> Tunes { get; set; }
		public int SelectedGenreId { get; set; }
	}
}
