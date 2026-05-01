using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class UserController : Controller
    {
        public static List<UserInputViewModel> Users = new List<UserInputViewModel>();
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Save(UserInputViewModel user)
        {
            Users.Add(user);

            return RedirectToAction("Result");
        }


        [HttpGet]
        public IActionResult Result()
        {
            return View(Users);
        }
    }
}
