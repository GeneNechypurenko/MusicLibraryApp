using Microsoft.AspNetCore.Mvc;

namespace MusicLibraryApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(string name)
        {
            ViewBag.UserName = name;
            return View();
        }
    }
}
