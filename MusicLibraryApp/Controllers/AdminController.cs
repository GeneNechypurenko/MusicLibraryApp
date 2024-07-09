using Microsoft.AspNetCore.Mvc;

namespace MusicLibraryApp.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index(string name)
		{
			ViewBag.AdminName = name;
			return View();
		}
	}
}
