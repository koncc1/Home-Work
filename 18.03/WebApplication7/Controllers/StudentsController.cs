using Microsoft.AspNetCore.Mvc;
using WebApplication7.DTOs;
using WebApplication7.Services.Interfaces;

namespace WebApplication7.Controllers
{
    public class StudentsController : Controller
    {
        readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult create(CreateStudentDto obj) 
        {
        if(!ModelState.IsValid)
            {
                return View(obj);
            }
            _studentService.create(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
    }
}
