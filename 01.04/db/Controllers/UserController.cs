using Microsoft.AspNetCore.Mvc;
using db.Data;
using db.Models;

namespace db.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}