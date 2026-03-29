using Microsoft.AspNetCore.Mvc;

namespace StarInfotechMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
