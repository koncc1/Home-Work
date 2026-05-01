using HASHING.DTOs;
using HASHING.Services;
using Microsoft.AspNetCore.Mvc;

namespace HASHING.Controllers
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
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            _authService.Register(obj);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public IActionResult Users()
        {
            var users = _authService.GetAllUser();
            return View(users);
        }
        public IActionResult Index()
        {
            ViewBag.Users = _authService.GetAllUser();
            return View();
        }
        [HttpPost]
        public IActionResult Registr(RegistrDto obj)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
              
            _authService.Register(obj);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
            var user = _authService.Login(dto.Email, dto.Password);

            if (!user)
            {
                ModelState.AddModelError("", "Invalid login");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    
    
        
        
    
    
    
    
    
    
    
    }
}
