using Microsoft.AspNetCore.Mvc;

namespace Task2.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ICourseRepository courseRepository;

        public ServiceController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        public IActionResult Index()
        {
            ViewBag.Id = courseRepository.Id;
            return View("Index");
        }
    }
}
