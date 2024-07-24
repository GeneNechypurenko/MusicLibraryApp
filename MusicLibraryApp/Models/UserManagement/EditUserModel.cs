using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;

namespace MusicLibraryApp.Models.UserManagement
{
	public class EditUserModel
	{
		public string Username { get; set; }
		public int UserId { get; set; }
		public int IsAuthorized { get; set; }
		public int IsBlocked { get; set; }
		public List<SelectListItem> Authorization { get; set; }
		public List<SelectListItem> Blocking { get; set; }
	}
}
