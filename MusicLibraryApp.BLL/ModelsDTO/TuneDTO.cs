using MusicLibraryApp.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.BLL.ModelsDTO
{
	public class TuneDTO
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Artist is required")]
        public string? Artist { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }
		public string? FileUrl { get; set; }
		public string? PosterUrl { get; set; }
		public bool IsAuthorized { get; set; }
		public bool IsBlocked { get; set; }
		public Category? Category { get; set; }
	}
}
