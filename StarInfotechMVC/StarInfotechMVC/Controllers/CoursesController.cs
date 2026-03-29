using Microsoft.AspNetCore.Mvc;

namespace StarInfotechMVC.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
