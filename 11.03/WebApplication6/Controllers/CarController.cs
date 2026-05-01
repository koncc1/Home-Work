using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class CarController : Controller
    {
        public static List<Car> Cars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(Cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            Cars.Add(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string model)
        {
            Car foundCar = null;

            foreach (var car in Cars)
            {
                if (car.Model == model)
                {
                    foundCar = car;
                    break;
                }
            }

            return View("SearchResult", foundCar);
        }
    }
}
