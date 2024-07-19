using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.AdminPage;
using MusicLibraryApp.Models.Base;

namespace MusicLibraryApp.Controllers
{
	public class AdminController : Controller
	{
		private readonly IService<UserDTO> _userService;
		private readonly IService<CategoryDTO> _categoryService;
		private readonly IService<TuneDTO> _tuneService;

		public AdminController(IService<UserDTO> userService, IService<CategoryDTO> categoryService, IService<TuneDTO> tuneService)
		{
			_userService = userService;
			_categoryService = categoryService;
			_tuneService = tuneService;
		}

		public async Task<IActionResult> Index(string search, int selectedGenreId = 0, int pageNumber = 1, int pageSize = 5)
		{
			var user = await _userService.GetAsync(HttpContext.Session.GetString("Username")!);

			if (user != null && user.IsAdmin)
			{
				var categories = await _categoryService.GetAllAsync();
				var tunes = await _tuneService.GetAllAsync();

				if (selectedGenreId == 0)
				{
					tunes = tunes.Where(t => t.IsAuthorized && !t.IsBlocked).ToList();
				}
				else if (selectedGenreId == -1)
				{
					tunes = tunes.Where(t => !t.IsAuthorized).ToList();
				}
				else if (selectedGenreId == -2)
				{
					tunes = tunes.Where(t => t.IsBlocked).ToList();
				}
				else
				{
					tunes = tunes.Where(t => t.Category?.Id == selectedGenreId && !t.IsBlocked && t.IsAuthorized).ToList();
				}

				if (!string.IsNullOrEmpty(search))
				{
					tunes = tunes.Where(t => t.Title!.Contains(search)).ToList();
				}

				var totalItems = tunes.Count();
				var tunesOnPage = tunes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

				AdminIndexViewModel viewModel = new AdminIndexViewModel(
					tunesOnPage,
					new PaginationViewModel(totalItems, pageNumber, pageSize),
					new AdminTuneFilterViewModel(categories.ToList(), selectedGenreId, search),
					new UserViewModel(user),
					categories);

				return View(viewModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		//public IActionResult Create()
		//{
		//	string? username = HttpContext.Session.GetString("Username");
		//	AdminTuneViewModel viewModel = new AdminTuneViewModel
		//	{
		//		Username = username,
		//		Tune = new TuneViewModel()
		//	};
		//	return View(viewModel);
		//}

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
