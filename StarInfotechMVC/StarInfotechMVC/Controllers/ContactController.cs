using Microsoft.AspNetCore.Mvc;

namespace StarInfotechMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
