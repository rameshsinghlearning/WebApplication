using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarInfotechAPI.Enums;
using StarInfotechAPI.Models;

namespace StarInfotechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public UserController()
        {
            dbContext = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = dbContext.Users
                .Select(x => new
                {
                    x.Id,
                    x.FirstName,
                    x.LastName,
                    x.Username,
                    x.Email,
                    x.MobileNo,
                    x.Role.Name,
                    x.IsActive,
                    x.AddedDate
                })
                .ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = dbContext.Users
                .Select(x => new
                {
                    x.Id,
                    x.FirstName,
                    x.LastName,
                    x.Username,
                    x.Email,
                    x.MobileNo,
                    x.Role.Name,
                    x.IsActive,
                    x.AddedDate
                })
                .FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User model)
        {
            var user = dbContext.Users
                    .FirstOrDefault(x => x.Username.ToLower().Trim() == model.Username.ToLower().Trim());

            if (user != null)
            {
                return Ok("Username already exists, try another one!");
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

                return Ok("User added successfully.");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id, [FromBody] User model)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);

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
            }

            return Ok("User updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }

            return Ok("User deleted successfully.");
        }
    }
}
