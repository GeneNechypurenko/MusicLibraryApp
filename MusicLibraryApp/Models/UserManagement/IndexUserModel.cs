using MusicLibraryApp.Models.Home;
using MusicLibraryApp.BLL.ModelsDTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicLibraryApp.Models.UserManagement
{
	public class IndexUserModel
	{
		public string Username { get; set; }
		public IEnumerable<UserDTO> Users { get; set; }
		public PageModel Page { get; set; }
		public int SelectedItem { get; set; }
		public List<SelectListItem> Filter { get; set; }
	}
}
