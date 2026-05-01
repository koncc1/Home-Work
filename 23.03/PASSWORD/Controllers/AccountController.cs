using Microsoft.AspNetCore.Mvc;
using PASSWORD.Models;
using PASSWORD.Services;

namespace PASSWORD.Controllers
{
    public class AccountController : Controller
    {
        static List<User> users = new List<User>();

        PasswordService passwordService = new PasswordService();

        public AccountController()
        {
            if (users.Count == 0)
            {
                string salt = passwordService.CreateSalt();
                string hash = passwordService.HashPassword("12345", salt);

                User user = new User();

                user.Id = 1;
                user.Email = "admin@gmail.com";
                user.Password = "12345";
                user.Salt = salt;
                user.PasswordHash = hash;

                users.Add(user);
            }
        }

        private User FindUser(string email)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == email)
                {
                    return users[i];
                }
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            User user = FindUser(model.Email);

            if (user == null)
            {
                ViewBag.Message = "Uesr not found";
                return View(model);
            }

            bool okHash = passwordService.CheckHash(
                model.Password,
                user.Salt,
                user.PasswordHash
            );

            if (okHash == true)
            {
                ViewBag.Message = "OK";
                return View("Profile", user);
            }

            bool okSimple = passwordService.CheckSimple(
                model.Password,
                user.Password
            );

            if (okSimple == true)
            {
                ViewBag.Message = "OK";
                return View("Profile", user);
            }

            ViewBag.Message = "Wrong password";
            return View(model);
        }
    }
}