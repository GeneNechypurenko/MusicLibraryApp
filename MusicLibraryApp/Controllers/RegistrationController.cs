using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.RegistrationPage;

namespace MusicLibraryApp.Controllers
{
	public class RegistrationController : Controller
	{
		private readonly IService<UserDTO> _userService;
        public RegistrationController(IService<UserDTO> userService) => _userService = userService;
        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registration(RegistrationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var newUser = new UserDTO
				{
					Username = model.Username,
					Password = model.Password
				};

				await _userService.CreateAsync(newUser);
			}
            return RedirectToAction("Index");
        }
	}
}
