using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MusicLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<UserDTO> _userService;
        private readonly IService<CategoryDTO> _categoryService;
        private readonly IService<TuneDTO> _tuneService;

        public HomeController(IService<UserDTO> userService, IService<CategoryDTO> categoryService, IService<TuneDTO> tuneService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _tuneService = tuneService;
        }

        public async Task<IActionResult> Index(int selectedGenreId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var categories = await _categoryService.GetAllAsync();
            var tunes = await _tuneService.GetAllAsync();

            var tuneViewModels = tunes.Select(t => new TuneViewModel
            {
                Performer = t.Performer,
                Title = t.Title,
                FileUrl = t.FileUrl,
                PosterUrl = t.PosterUrl,
                IsAuthorized = t.IsAuthorized,
                IsBlocked = t.IsBlocked,
                CategoryId = t.Category?.Id,
                CategoryName = t.Category?.Genre
            }).ToList();

            if (selectedGenreId != 0)
            {
                tuneViewModels = tuneViewModels.Where(t => t.CategoryId == selectedGenreId).ToList();
            }

            int count = tuneViewModels.Count();
            var items = tuneViewModels.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var filterViewModel = new FilterViewModel(categories.ToList(), selectedGenreId)
            {
                Tunes = tuneViewModels
            };

            var paginationViewModel = new PaginationViewModel(count, pageNumber, pageSize);

            var homePageViewModel = new HomePageViewModel
            {
                Filter = filterViewModel,
                Pagination = paginationViewModel,
                Tunes = items
            };

            return View(homePageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = await _userService.GetAllAsync();
                var user = users.FirstOrDefault(u => u.Username == model.Login.Username && u.Password == model.Login.Password);

                if (user != null)
                {
                    if (user.IsAdmin)
                    {
                        return RedirectToAction("Index", "Admin", new { name = user.Username });
                    }
                    else
                    {
                        return RedirectToAction("Index", "User", new { name = user.Username });
                    }
                }
            }
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO newUser = new UserDTO
                {
                    Username = model.Registration.Username,
                    Password = model.Registration.Password,
                };

                await _userService.CreateAsync(newUser);
            }
            return View("Index", model);
        }
    }
}
