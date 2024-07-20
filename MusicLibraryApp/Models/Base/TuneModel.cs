using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MusicLibraryApp.Models.Base
{
    public class TuneModel
    {
        [Required(ErrorMessage = "Performer is required")]
        public string? Performer { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

		[Required(ErrorMessage = "Music file is required")]
		public IFormFile File { get; set; }

		[Required(ErrorMessage = "Poster picture is required")]
		public IFormFile Poster { get; set; }

		public int CategoryId { get; set; }
    }
}
