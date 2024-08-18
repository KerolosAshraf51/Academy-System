using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using Task2.Repository;

namespace Task2.Controllers
{
    public class CourseController : Controller
    {
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;

        public CourseController(ICourseRepository courserepo, IDepartmentRepository Deptrepo)
        {
            courseRepository = courserepo;
            departmentRepository = Deptrepo;
        }

        public IActionResult Index(int PageNo = 1)
        {
            var coursesList = courseRepository.GetAll();

            int noOfRecordsperpage = 5;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(coursesList.Count) / Convert.ToDouble(noOfRecordsperpage)));
            int noOfRecordsToSkip = (PageNo - 1) * noOfRecordsperpage;

            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = noOfPages;

            coursesList = coursesList.Skip(noOfRecordsToSkip).Take(noOfRecordsperpage).ToList();
            return View(coursesList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = departmentRepository.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult SaveCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(course);
                courseRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Departments = departmentRepository.GetAll();
            return View("Add", course);
        }

        public IActionResult CheckDegree(int Degree, int MinDegree)
        {
            if (Degree < MinDegree)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        public IActionResult CheckHours(int Hours)
        {
            if (Hours % 3 == 0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            var coursesList = courseRepository.GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                coursesList = coursesList.Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Set default values for pagination
            int PageNo = 1;
            int noOfRecordsperpage = 5;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(coursesList.Count) / Convert.ToDouble(noOfRecordsperpage)));
            int noOfRecordsToSkip = (PageNo - 1) * noOfRecordsperpage;

            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = noOfPages;

            // Paginate the courses list
            coursesList = coursesList.Skip(noOfRecordsToSkip).Take(noOfRecordsperpage).ToList();

            return View("Index", coursesList);
        }
    }
}
