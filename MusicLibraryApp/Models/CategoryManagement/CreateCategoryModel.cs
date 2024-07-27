using MusicLibraryApp.BLL.ModelsDTO;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.CategoryManagement
{
	public class CreateCategoryModel
	{
		public string Username { get; set; }

		[Required(ErrorMessageResourceType = typeof(Resources.Resource),
			ErrorMessageResourceName = "GenreRequired")]
		public string Genre { get; set; }
	}
}
