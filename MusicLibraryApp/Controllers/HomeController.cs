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
        private readonly IService<TuneDTO> _tuneService;

        public HomeController(IService<CategoryDTO> categoryService, IService<UserDTO> userService, IService<TuneDTO> tuneService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _tuneService = tuneService;
        }

        public async Task<IActionResult> Index(string search, int selectedGenreId = 0, int pageNumber = 1, int pageSize = 10)
        {
            var tunes = await _tuneService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();

            if (selectedGenreId != 0)
                tunes.Where(t => t.Category.Id == selectedGenreId).ToList();

            if (!string.IsNullOrEmpty(search))
                tunes.Where(t => t.Title == search).ToList();

            HomePageViewModel viewModel = new HomePageViewModel
                (
                new UserViewModel(),
                tunes.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),
                new PageViewModel(tunes.Count(), pageNumber, pageSize),
                new FilterViewModel(categories.ToList(), selectedGenreId, search)
                );

            return View(viewModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
