using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.DAL.Models;
using MusicLibraryApp.Models.Home;

namespace MusicLibraryApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IService<UserDTO> _user;
		private readonly IService<CategoryDTO> _category;
		private readonly IService<TuneDTO> _tune;
		private readonly IWebHostEnvironment _web;

		public HomeController(IService<UserDTO> user, IService<CategoryDTO> category, IService<TuneDTO> tune,
			IWebHostEnvironment web)
		{
			_user = user;
			_category = category;
			_tune = tune;
			_web = web;
		}

		public async Task<IActionResult> Index(int selected = 0, int pageNumber = 1, int pageSize = 5)
		{
			UserDTO user = null!;

			var categories = await _category.GetAllAsync();
			var categoriesList = categories.ToList();
			categoriesList.Insert(0, new CategoryDTO { Genre = "All Genres", Id = 0 });

			if (HttpContext.Session.GetInt32("UserId").HasValue)
			{
				user = await _user.GetAsync(HttpContext.Session.GetInt32("UserId")!.Value);

				if (user.IsAdmin)
				{
					categoriesList.Insert(1, new CategoryDTO { Genre = "New", Id = -2 });
					categoriesList.Insert(2, new CategoryDTO { Genre = "Blocked", Id = -1 });
				}
			}

			var filter = new FilterModel(categoriesList, selected);

			var tunes = await _tune.GetAllAsync();

			switch (selected)
			{
				case -2:
					tunes = tunes.Where(t => !t.IsAuthorized).ToList();
					break;
				case -1:
					tunes = tunes.Where(t => t.IsBlocked).ToList();
					break;
				case 0:
					tunes = tunes.Where(t => t.IsAuthorized && !t.IsBlocked).ToList();
					break;
				default:
					tunes = tunes.Where(t => t.CategoryId == selected && !t.IsBlocked && t.IsAuthorized).ToList();
					break;
			}

			var count = tunes.Count();
			var tunesOnPage = tunes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			IndexModel index = new IndexModel(user, tunesOnPage, new PageModel(count, pageNumber, pageSize), filter);
			return View(index);
		}

		public async Task<IActionResult> Create()
		{
			var user = await _user.GetAsync(HttpContext.Session.GetInt32("UserId")!.Value);
			var categories = await _category.GetAllAsync();
			var model = new CreateTuneModel
			{
				Username = user.Username!,
				IsAdmin = user.IsAdmin,
				Categories = categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Genre }).ToList()
			};
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateTuneModel model)
		{
			string tuneFilePath = await FileUpload(model.File, "res/Tunes/Upload");
			string posterFilePath = await FileUpload(model.Poster, "res/Tunes/Posters");

			var tune = new TuneDTO
			{
				Performer = model.Performer,
				Title = model.Title,
				FileUrl = tuneFilePath,
				PosterUrl = posterFilePath,
				CategoryId = model.CategoryId,
				IsAuthorized = true,
				IsBlocked = false
			};

			await _tune.CreateAsync(tune);
			return RedirectToAction(nameof(Index));
		}


		//public async Task<IActionResult> Create()
		//{
		//	var user = await _user.GetAsync(HttpContext.Session.GetInt32("UserId")!.Value);
		//	var categories = await _category.GetAllAsync();
		//	var filter = new FilterModel(categories.ToList(), 0);

		//	CreateModel create = new CreateModel() { Filter = filter };
		//	return View(create);
		//}


		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Create(CreateModel model)
		//{
		//	model.User = await _user.GetAsync(HttpContext.Session.GetInt32("UserId")!.Value);
		//	var selectedCategory = await _category.GetAsync(model.Filter.Selected);

		//	string filePath = await FileUpload(model.File, "res/Tunes/Upload");
		//	string posterPath = await FileUpload(model.Poster, "res/Tunes/Posters");

		//	var tune = new TuneDTO
		//	{
		//		Performer = model.Tune.Performer,
		//		Title = model.Tune.Title,
		//		FileUrl = filePath,
		//		PosterUrl = posterPath,
		//		IsAuthorized = true,
		//		IsBlocked = false,
		//		CategoryId = selectedCategory.Id,
		//	};

		//	await _tune.CreateAsync(tune);
		//	return RedirectToAction("Index");
		//}

		public ActionResult Login() => RedirectToAction("Login", "Account");
		public ActionResult Registration() => RedirectToAction("Registration", "Account");
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		private async Task<string> FileUpload(IFormFile file, string folderPath)
		{
			if (file == null || file.Length == 0)
				return string.Empty;

			string uploadPath = Path.Combine(_web.WebRootPath, folderPath);
			if (!Directory.Exists(uploadPath))
			{
				Directory.CreateDirectory(uploadPath);
			}

			string fileName = Path.GetFileName(file.FileName);
			string filePath = Path.Combine(uploadPath, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return Path.Combine(folderPath, fileName).Replace('\\', '/');
		}
	}
}
