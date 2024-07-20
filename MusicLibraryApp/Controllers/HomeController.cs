using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.DAL.Models;
using MusicLibraryApp.Models.Base;

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

		public async Task<IActionResult> Index(int selectedGenreId = 0, int pageNumber = 1, int pageSize = 5)
		{
			var user = await _userService.GetAsync(HttpContext.Session.GetString("Username")!);

			if (user != null && !user.IsAdmin && !user.IsBlocked)
			{
				var categories = await _categoryService.GetAllAsync();
				var tunes = await _tuneService.GetAllAsync();

				if (selectedGenreId == 0)
				{
					tunes = tunes.Where(t => t.IsAuthorized && !t.IsBlocked).ToList();
				}
				else
				{
					tunes = tunes.Where(t => t.Category?.Id == selectedGenreId && !t.IsBlocked && t.IsAuthorized).ToList();
				}

				var totalItems = tunes.Count();
				var tunesOnPage = tunes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

				UserIndexViewModel viewModel = new UserIndexViewModel(
					tunesOnPage,
					new PaginationModel(totalItems, pageNumber, pageSize),
					new AdminTuneFilterViewModel(categories.ToList(), selectedGenreId),
					new UserModel(user),
					categories);

				return View(viewModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public async Task<IActionResult> Create(int selectedGenreId = 0)
		{
			var user = await _userService.GetAsync(HttpContext.Session.GetString("Username")!);
			var categories = await _categoryService.GetAllAsync();
			if (user != null && !user.IsAdmin && user.IsAuthorized && !user.IsBlocked)
			{
				UserCreateViewModel viewModel = new UserCreateViewModel(
					new UserModel(user),
					new TuneModel(),
					new FilterModel<CategoryDTO>(categories.ToList(), selectedGenreId));
				return View(viewModel);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(UserCreateViewModel model)
		{
			string fileSavePath = Path.Combine("res/Tunes/Upload", model.Tune.File.FileName);
			string posterSavePath = Path.Combine("res/Tunes/Posters", model.Tune.Poster.FileName);

			using (var fs = new FileStream(Path.Combine(_environment.WebRootPath, fileSavePath), FileMode.Create))
			{
				await model.Tune.File.CopyToAsync(fs);
			}

			using (var ps = new FileStream(Path.Combine(_environment.WebRootPath, posterSavePath), FileMode.Create))
			{
				await model.Tune.Poster.CopyToAsync(ps);
			}

			CategoryDTO selectedCategory = await _categoryService.GetAsync(model.Tune.CategoryId);
			TuneDTO newTune = new TuneDTO
			{
				Performer = model.Tune.Performer,
				Title = model.Tune.Title,
				FileUrl = "/" + fileSavePath,
				PosterUrl = "/" + posterSavePath,
				IsAuthorized = true,
				IsBlocked = false,
				Category = new Category
				{
					Id = selectedCategory.Id,
					Genre = selectedCategory.Genre,
					PosterUrl = selectedCategory.PosterUrl
				}
			};
			await _tuneService.CreateAsync(newTune);

			return RedirectToAction("Index");
		}



		public ActionResult Login() => RedirectToAction("Login", "Account");
		public ActionResult Registration() => RedirectToAction("Registration", "Account");
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
