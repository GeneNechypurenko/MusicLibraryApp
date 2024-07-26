using Microsoft.AspNetCore.Mvc;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Localization.Filter;
using MusicLibraryApp.Models.CategoryManagement;
using MusicLibraryApp.Models.CommonModels;
using MusicLibraryApp.Models.Home;

namespace MusicLibraryApp.Controllers
{
	[LocalizationFilter]
	public class CategoryManagementController : Controller
	{
		private readonly IService<UserDTO> _user;
		private readonly IService<CategoryDTO> _category;

		public CategoryManagementController(IService<UserDTO> user, IService<CategoryDTO> category)
		{
			_user = user;
			_category = category;
		}

		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, int selectedItem = 0)
		{
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
			{
				return RedirectToAction("Login", "Account");
			}
			var currentUser = await _user.GetAsync(currentUserId.Value);

			var categories = await _category.GetAllAsync();
			var count = categories.Count();
			var categoriesOnPage = categories.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			IndexCategoryModel model = new IndexCategoryModel
			{
				Username = currentUser.Username!,
				Categories = categoriesOnPage,
				Page = new PaginationModel(count, pageNumber, pageSize),
			};

			return View(model);
		}

		public async Task<IActionResult> Create()
		{
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
			{
				return RedirectToAction("Login", "Account");
			}
			var currentUser = await _user.GetAsync(currentUserId.Value);

			CreateCategoryModel model = new CreateCategoryModel
			{
				Username = currentUser.Username!,
			};
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateCategoryModel model)
		{
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
			{
				return RedirectToAction("Login", "Account");
			}

			CategoryDTO newCategory = new CategoryDTO();
			newCategory.Genre = model.Genre;

			await _category.CreateAsync(newCategory);
			return Ok();
		}

		public async Task<IActionResult> Edit(int id)
		{
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
			{
				return RedirectToAction("Login", "Account");
			}
			var currentUser = await _user.GetAsync(currentUserId.Value);

			EditCategoryModel model = new EditCategoryModel
			{
				Username = currentUser.Username!,
				CategoryId = id,
			};
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditCategoryModel model)
		{
			CategoryDTO category = await _category.GetAsync(model.CategoryId);
			category.Genre = model.Genre;
			await _category.UpdateAsync(category);
			return RedirectToAction(nameof(Index));
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _category.DeleteAsync(id);
			return Ok();
		}
	}
}
