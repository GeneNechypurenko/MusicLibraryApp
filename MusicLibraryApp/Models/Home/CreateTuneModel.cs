using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.Home
{
	public class CreateTuneModel
	{
		public string Username { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "ArtistRequired")]
		public string Performer { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "TitleRequired")]
		public string Title { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "GenreRequired")]
		public int CategoryId { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "AudioFileRequired")]
		public IFormFile File { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "PosterRequired")]
		public IFormFile Poster { get; set; }

		public List<SelectListItem> Categories { get; set; }
	}
}
