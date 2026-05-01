using Microsoft.AspNetCore.Mvc;
using PASSWORD.DTOs;
using PASSWORD.Services.Interfaces;

namespace PASSWORD.Controllers
{
    public class AuthController : Controller
    {
        readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegistrDto obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }

            _authService.Register(obj);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _authService.getallUser();
            return View(users);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
