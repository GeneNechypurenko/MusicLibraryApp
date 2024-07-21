using Microsoft.AspNetCore.Mvc;

namespace MusicLibraryApp.Controllers
{
	public class CategoryManagementController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
