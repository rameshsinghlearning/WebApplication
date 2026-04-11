using Microsoft.AspNetCore.Mvc;
using StarInfotechMVC.Models;
using StarInfotechMVC.ViewModels;

namespace StarInfotechMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new AppDbContext();

                var user = dbContext.Users
                    .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password && x.IsActive);

                if (user == null)
                {
                    ViewBag.Message = "Incorrect Username or Password!";
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Index", "Users");
                }
            }

            return View(model);
        }
    }
}
