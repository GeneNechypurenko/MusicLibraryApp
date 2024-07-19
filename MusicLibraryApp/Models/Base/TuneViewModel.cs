namespace MusicLibraryApp.Models.Base
{
    public class TuneViewModel
    {
        public string? Performer { get; set; }
        public string? Title { get; set; }
        public string? FileUrl { get; set; }
        public string? PosterUrl { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsBlocked { get; set; }
        public int? CategoryId { get; set; }
    }
}
