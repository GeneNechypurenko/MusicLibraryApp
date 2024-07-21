using Microsoft.AspNetCore.Mvc.Rendering;

namespace MusicLibraryApp.Models.Home
{
	public class EditTuneModel : CreateTuneModel
	{
		public int TuneId { get; set; }
		public int IsAuthorize { get; set; }
		public int IsBlocked { get; set; }
		public List<SelectListItem> Authorization { get; set; }
		public List<SelectListItem> Blocking { get; set; }
	}
}
