using CookieDemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookieDemo.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            if (obj.Login != "admin" && obj.Password != "admin")
            {
                ViewBag.Message = "Invalid login or password";
                return View(obj);
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, obj.Login),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Profile");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            ViewBag.Login = User.Identity?.Name;
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
