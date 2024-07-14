using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MusicLibraryApp.Models.HomePage;
using Microsoft.AspNetCore.Http;

namespace MusicLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<CategoryDTO> _categoryService;
        private readonly IService<UserDTO> _userService;

        public HomeController(IService<CategoryDTO> categoryService, IService<UserDTO> userService)
        {
            _categoryService = categoryService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(int selectedGenreId = 0, int pageNumber = 1, int pageSize = 4)
        {
            var categories = await _categoryService.GetAllAsync();
            var categoryViewModel = categories.Select(c => new CategoryViewModel
            {
                Genre = c.Genre,
                PosterUrl = c.PosterUrl
            }).ToList();

            int count = categoryViewModel.Count();
            var items = categoryViewModel.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var paginationViewModel = new PaginationViewModel(count, pageNumber, pageSize);

            var username = HttpContext.Session.GetString("Username");
            UserDTO userDto = null;
            if (!string.IsNullOrEmpty(username))
            {
                userDto = await _userService.GetAsync(username);
            }

            var homePageViewModel = new HomePageViewModel
            {
                Pagination = paginationViewModel,
                Categories = items,
                User = userDto != null ? new UserViewModel
                {
                    Username = userDto.Username,
                    IsAdmin = userDto.IsAdmin,
                    IsAuthorized = userDto.IsAuthorized,
                    IsBlocked = userDto.IsBlocked
                } : new UserViewModel()
            };

            return View(homePageViewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
