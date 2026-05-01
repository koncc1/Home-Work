using Microsoft.AspNetCore.Mvc;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {

        //HomeWork TAKS
        public IActionResult Index()
        {
            int count = 0;

            string value = Request.Cookies["visits"];

            if (value == null)
            {
                count = 1;
            }
            else
            {
                count = int.Parse(value);
                count = count + 1;
            }

            Response.Cookies.Append("visits", count.ToString());

            ViewBag.Count = count;

            return View();
        }
    }
}