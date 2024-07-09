namespace MusicLibraryApp.Models
{
    public class CategoryViewModel
    {
        public string Genre { get; set; }
        public IEnumerable<TuneViewModel> Tune { get; set; }
    }
}
