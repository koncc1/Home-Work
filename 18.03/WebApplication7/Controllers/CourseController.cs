using Microsoft.AspNetCore.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class CourseController : Controller
    {
        static List<Course> courses = new List<Course>();

        public IActionResult Index()
        {
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            course.Id = courses.Count + 1;
            courses.Add(course);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Course course = courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course newCourse)
        {
            Course course = courses.FirstOrDefault(c => c.Id == newCourse.Id);

            if (course == null)
            {
                return NotFound();
            }

            course.Name = newCourse.Name;
            course.Description = newCourse.Description;
            course.Hours = newCourse.Hours;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Course course = courses.FirstOrDefault(c => c.Id == id);

            if (course != null)
            {
                courses.Remove(course);
            }

            return RedirectToAction("Index");
        }
    }
}