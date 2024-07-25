using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.Home
{
	public class CreateTuneModel
	{
		public string Username { get; set; }

		[Required(ErrorMessage = "Artist is required")]
		public string Performer { get; set; }

		[Required(ErrorMessage = "Title is required")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Category is required")]
		public int CategoryId { get; set; }

		[Required(ErrorMessage = "Audio file is required")]
		public IFormFile File { get; set; }

		[Required(ErrorMessage = "Poster picture is required")]
		public IFormFile Poster { get; set; }

		public List<SelectListItem> Categories { get; set; }
	}
}
