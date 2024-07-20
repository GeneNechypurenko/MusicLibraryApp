using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
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
                    tunes = tunes.Where(t => t.Category?.Id == selected && !t.IsBlocked && t.IsAuthorized).ToList();
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

            CreateModel create = new CreateModel
            {
                User = user,
                Tune = new TuneDTO(),
                File = null!,
                Poster = null!,
                Filter = new FilterModel(categories.ToList(), 0)
            };

            return View(create);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(UserCreateViewModel model)
        //{
        //	string fileSavePath = Path.Combine("res/Tunes/Upload", model.Tune.File.FileName);
        //	string posterSavePath = Path.Combine("res/Tunes/Posters", model.Tune.Poster.FileName);

        //	using (var fs = new FileStream(Path.Combine(_environment.WebRootPath, fileSavePath), FileMode.Create))
        //	{
        //		await model.Tune.File.CopyToAsync(fs);
        //	}

        //	using (var ps = new FileStream(Path.Combine(_environment.WebRootPath, posterSavePath), FileMode.Create))
        //	{
        //		await model.Tune.Poster.CopyToAsync(ps);
        //	}

        //	CategoryDTO selectedCategory = await _categoryService.GetAsync(model.Tune.CategoryId);
        //	TuneDTO newTune = new TuneDTO
        //	{
        //		Performer = model.Tune.Performer,
        //		Title = model.Tune.Title,
        //		FileUrl = "/" + fileSavePath,
        //		PosterUrl = "/" + posterSavePath,
        //		IsAuthorized = true,
        //		IsBlocked = false,
        //		Category = new Category
        //		{
        //			Id = selectedCategory.Id,
        //			Genre = selectedCategory.Genre,
        //			PosterUrl = selectedCategory.PosterUrl
        //		}
        //	};
        //	await _tuneService.CreateAsync(newTune);

        //	return RedirectToAction("Index");
        //}



        public ActionResult Login() => RedirectToAction("Login", "Account");
		public ActionResult Registration() => RedirectToAction("Registration", "Account");
		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}
	}
}
