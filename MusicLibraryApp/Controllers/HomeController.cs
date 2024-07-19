using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.Base;
using MusicLibraryApp.Models.HomePage;

namespace MusicLibraryApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IService<CategoryDTO> _categoryService;
		private readonly IService<TuneDTO> _tuneService;

		public HomeController(IService<CategoryDTO> categoryService, IService<UserDTO> userService, IService<TuneDTO> tuneService)
		{
			_categoryService = categoryService;
			_tuneService = tuneService;
		}

		public async Task<IActionResult> Index(string search, int selectedGenreId = 0, int pageNumber = 1, int pageSize = 5)
		{
			var tunes = await _tuneService.GetAllAsync();
			var categories = await _categoryService.GetAllAsync();

			if (selectedGenreId == 0)
			{
				tunes = tunes.Where(t => t.IsAuthorized && !t.IsBlocked).ToList();
			}
			else
			{
				tunes = tunes.Where(t => t.Category.Id == selectedGenreId && !t.IsBlocked && t.IsAuthorized).ToList();
			}

			if (!string.IsNullOrEmpty(search))
				tunes = tunes.Where(t => t.Title.Contains(search));

			var totalItems = tunes.Count();
			var tunesOnPage = tunes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			HomeIndexViewModel viewModel = new HomeIndexViewModel(
				tunesOnPage,
				new PaginationViewModel(totalItems, pageNumber, pageSize),
				new HomeFilterViewModel(categories.ToList(), selectedGenreId, search));

			return View(viewModel);
		}

		public ActionResult Login() => RedirectToAction("Login", "Account");
		public ActionResult Registration() => RedirectToAction("Registration", "Account");
	}
}
