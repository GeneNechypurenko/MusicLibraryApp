using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.Models;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.BLL.ModelsDTO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<UserDTO> _userService;

        public HomeController(IService<UserDTO> userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(HomeViewModel model)
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
            ModelState.AddModelError("", "Invalid username or password");

            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(HomeViewModel model)
        {
            UserDTO newUser = new UserDTO
            {
                Username = model.Registration.Username,
                Password = model.Registration.Password,
            };

            await _userService.CreateAsync(newUser);

            return View("Index", model);
        }
    }
}
