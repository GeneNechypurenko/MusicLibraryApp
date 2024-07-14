using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.LoginPage;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MusicLibraryApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IService<UserDTO> _userService;

        public LoginController(IService<UserDTO> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userList = await _userService.GetAllAsync();
                var user = userList.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("Username", user.Username);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(login);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
