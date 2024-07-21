using Microsoft.AspNetCore.Mvc;

namespace MusicLibraryApp.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
