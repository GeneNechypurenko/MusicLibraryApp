using MusicLibraryApp.DAL.Models;

namespace MusicLibraryApp.BLL.ModelsDTO
{
	public class TuneDTO
	{
		public int Id { get; set; }
		public string? Performer { get; set; }
		public string? Title { get; set; }
		public string? FileUrl { get; set; }
		public string? PosterUrl { get; set; }
		public bool IsAuthorized { get; set; }
		public bool IsBlocked { get; set; }
		public Category? Category { get; set; }
	}
}
