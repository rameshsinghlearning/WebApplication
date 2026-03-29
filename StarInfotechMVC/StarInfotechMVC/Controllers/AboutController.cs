using Microsoft.AspNetCore.Mvc;

namespace StarInfotechMVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
