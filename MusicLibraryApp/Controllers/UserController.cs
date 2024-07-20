using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;

namespace MusicLibraryApp.Controllers
{
	public class UserController : Controller
	{
		private readonly IService<UserDTO> _userService;
		private readonly IService<CategoryDTO> _categoryService;
		private readonly IService<TuneDTO> _tuneService;
		private readonly IWebHostEnvironment _environment;

		public UserController(IService<UserDTO> userService, IService<CategoryDTO> categoryService, IService<TuneDTO> tuneService,
			IWebHostEnvironment environment)
		{
			_userService = userService;
			_categoryService = categoryService;
			_tuneService = tuneService;
			_environment = environment;
		}


	}
}
