using MusicLibraryApp.BLL.ModelsDTO;
using System.ComponentModel.DataAnnotations;

namespace MusicLibraryApp.Models.CategoryManagement
{
	public class CreateCategoryModel
	{
		public string Username { get; set; }

		[Required(ErrorMessage = "Genre is required")]
		public string Genre { get; set; }
	}
}
