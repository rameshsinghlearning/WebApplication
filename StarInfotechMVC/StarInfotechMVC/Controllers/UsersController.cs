using Microsoft.AspNetCore.Mvc;

namespace StarInfotechMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
