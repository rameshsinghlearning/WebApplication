using Microsoft.AspNetCore.Mvc;
using StarInfotechMVC.Enums;
using StarInfotechMVC.Models;
using StarInfotechMVC.ViewModels;

namespace StarInfotechMVC.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new AppDbContext();
                
                var user = dbContext.Users
                    .FirstOrDefault(x => x.Username.ToLower().Trim() == model.Username.ToLower().Trim());

                if(user != null)
                {
                    ViewBag.Message = "Username already exists, try another one!";
                }
                else
                {
                    var newUser = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Username = model.Username,
                        Password = model.Password,
                        Email = model.Email,
                        MobileNo = model.MobileNo,
                        IsActive = true,
                        AddedDate = DateTime.Now,
                        RoleId = (int)RoleEnum.Staff,
                    };

                    dbContext.Users.Add(newUser);
                    dbContext.SaveChanges();

                    return RedirectToAction("Index", "Users");
                }
            }

            return View(model);
        }
    }
}
