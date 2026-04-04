using Microsoft.AspNetCore.Mvc;
using StarInfotechMVC.Models;

namespace StarInfotechMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext dbContext;

        public UsersController()
        {
            dbContext = new AppDbContext();
        }

        public IActionResult Index()
        {
            var users = dbContext.Users.ToList();
            return View(users);
        }

        public IActionResult View(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
    }
}
