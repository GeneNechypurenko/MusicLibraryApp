using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.AccountPage;

namespace MusicLibraryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService<UserDTO> _userService;

        public AccountController(IService<UserDTO> userService)
        {
            _userService = userService;
        }
        public IActionResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(loginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var userList = await _userService.GetAllAsync();
                var user = userList.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("Username", user.Username);

                    if (user.IsAdmin)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            return View(login);
        }

        public IActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel registration)
        {
            if (ModelState.IsValid)
            {
                var newUser = new UserDTO
                {
                    Username = registration.Username,
                    Password = registration.Password
                };

                await _userService.CreateAsync(newUser);
                return RedirectToAction("Index", "Home");
            }
            return View(registration);
        }

        public IActionResult Home() => RedirectToAction("Index", "Home");
    }
}
