using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.Models;
using System.Diagnostics;

namespace MusicLibraryApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
