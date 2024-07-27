using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Localization.Filter;
using MusicLibraryApp.Localization.Services;
using MusicLibraryApp.Models.Account;
using System.Reflection.PortableExecutable;

namespace MusicLibraryApp.Controllers
{
	[LocalizationFilter]
	public class AccountController : Controller
	{
		private readonly IService<UserDTO> _userService;
		private readonly ILangReader _langReader;

		public AccountController(IService<UserDTO> userService, ILangReader langReader)
		{
			_userService = userService;
			_langReader = langReader;
		}
		public IActionResult Login() => View();
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginModel login)
		{
            string? returnUrl = HttpContext.Session.GetString("path");

            if (ModelState.IsValid)
			{
				var userList = await _userService.GetAllAsync();
				var user = userList.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);
				if (user != null)
				{
					HttpContext.Session.SetInt32("UserId", user.Id);

					if (!user.IsBlocked)
					{
						return RedirectToAction("Index", "Home");
					}
				}
			}
			return View(login);
		}

		public IActionResult Registration() => View();
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Registration(RegistrationModel registration)
		{
			HttpContext.Session.SetString("path", Request.Path);

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

		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			return RedirectToAction("Index", "Home");
		}

		public ActionResult ChangeCulture(string language)
		{
			string? returnUrl = HttpContext.Session.GetString("path");

			List<string> cultures = _langReader.LanguageList().Select(t => t.Abbreviation).ToList()!;

			if (!cultures.Contains(language))
			{
				language = "uk";
			}

			CookieOptions option = new CookieOptions();
			option.Expires = DateTime.Now.AddDays(10);
			Response.Cookies.Append("Localization", language, option);
			return Redirect(returnUrl);
		}

		public IActionResult Home() => RedirectToAction("Index", "Home");
	}
}
