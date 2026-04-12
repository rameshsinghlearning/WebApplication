using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarInfotechMVC.Filters;
using StarInfotechMVC.Models;

namespace StarInfotechMVC.Controllers
{
    [SessionAuthorize]
    public class UsersController : Controller
    {
        private readonly AppDbContext dbContext;

        public UsersController()
        {
            dbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = dbContext.Users.Include(x => x.Role).AsNoTracking().ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var user = dbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = dbContext.Users.Include(x => x.Role).FirstOrDefault(x => x.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == model.Id);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.MobileNo = model.MobileNo;
                user.RoleId = model.RoleId;
                user.IsActive = model.IsActive;

                dbContext.Users.Update(user);
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}