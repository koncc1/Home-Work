using HASHING.Models;
using HASHING.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HASHING.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthService _authService;

        public HomeController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            var users = _authService.GetAllUser();
            return View(users);
        }
    }
}
