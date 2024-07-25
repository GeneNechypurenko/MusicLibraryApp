using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models.CommonModels;

namespace MusicLibraryApp.Models.CategoryManagement
{
	public class IndexCategoryModel
	{
		public string Username { get; set; }
		public IEnumerable<CategoryDTO> Categories { get; set; }
		public PaginationModel Page { get; set; }
	}
}
