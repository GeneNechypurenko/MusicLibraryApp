using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicLibraryApp.BLL.ModelsDTO;
using MusicLibraryApp.BLL.Services.Interfaces;
using MusicLibraryApp.Models.CommonModels;
using MusicLibraryApp.Models.UserManagement;

namespace MusicLibraryApp.Controllers
{
	public class UserManagementController : Controller
	{
		private readonly IService<UserDTO> _user;

		public UserManagementController(IService<UserDTO> user) => _user = user;

		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, int selectedItem = 0)
		{
			var currentUserId = HttpContext.Session.GetInt32("UserId");
			if (currentUserId == null)
			{
				return RedirectToAction("Login", "Account");
			}
			var currentUser = await _user.GetAsync(currentUserId.Value);

			var users = await _user.GetAllAsync();
			var userList = users.Where(u => !u.IsAdmin).ToList();

			if (selectedItem == 1)
			{
				userList = userList.Where(u => !u.IsAuthorized).ToList();
			}
			else if (selectedItem == 2)
			{
				userList = userList.Where(u => u.IsBlocked).ToList();
			}

			var count = userList.Count();
			var usersOnPage = userList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			Dictionary<int, string> result = new Dictionary<int, string>
			{
				{ 0, "All Users" },
				{ 1, "New" },
				{ 2, "Blocked" }
			};

			var model = new IndexUserModel
			{
				Username = currentUser.Username!,
				Users = usersOnPage,
				Page = new PaginationModel(count, pageNumber, pageSize),
				SelectedItem = selectedItem,
				Filter = result.Select(r => new SelectListItem
				{
					Value = r.Key.ToString(),
					Text = r.Value,
					Selected = r.Key == selectedItem
				}).ToList()
			};

			return View(model);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var admin = await _user.GetAsync(HttpContext.Session.GetInt32("UserId")!.Value);
			var user = await _user.GetAsync(id);

			Dictionary<int, string> authorization = new Dictionary<int, string> { { 0, "Authorized" }, { 1, "Unauthorized" } };
			Dictionary<int, string> blocking = new Dictionary<int, string> { { 0, "Blocked" }, { 1, "Unblocked" } };

			EditUserModel edit = new EditUserModel
			{
				Username = admin.Username!,
				UserId = user.Id!,
				IsAuthorized = user.IsAuthorized ? 0 : 1,
				IsBlocked = user.IsBlocked ? 0 : 1,
				Authorization = authorization.Select(a => new SelectListItem
				{
					Value = a.Key.ToString(),
					Text = a.Value,
					Selected = a.Key == (user.IsAuthorized ? 0 : 1)
				}).ToList(),
				Blocking = blocking.Select(b => new SelectListItem
				{
					Value = b.Key.ToString(),
					Text = b.Value,
					Selected = b.Key == (user.IsBlocked ? 0 : 1)
				}).ToList()
			};

			return View(edit);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditUserModel model)
		{
			UserDTO user = await _user.GetAsync(model.UserId);
			user.IsAuthorized = model.IsAuthorized == 0;
			user.IsBlocked = model.IsBlocked == 0;

			await _user.UpdateAsync(user);
			return RedirectToAction(nameof(Index));
		}

		[HttpDelete]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			await _user.DeleteAsync(id);
			return Ok();
		}
	}
}
