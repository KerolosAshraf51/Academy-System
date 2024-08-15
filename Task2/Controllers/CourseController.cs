using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Task2.Models;
using Task2.Repository;

namespace Task2.Controllers
{
    public class CourseController : Controller
    {
        //ITIContext Context = new ITIContext();
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository courserepo,IDepartmentRepository Deptrepo)
        {
            courseRepository = courserepo;
            departmentRepository = Deptrepo;
        }

        public IActionResult Index()
        {
            List<Course> coursesList = courseRepository.GetAll();
            //Context.courses.Include(c => c.Department).ToList();
            return View("Index", coursesList);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Departments = departmentRepository.GetAll();
            /*new SelectList(Context.departments.ToList(), "Id", "Name");*/
            return View();
        }

        //public IActionResult Add()
        //{
        //    var departments = departmentRepository.GetAll();
        //    ViewBag.Departments = departments.Select(d => new SelectListItem
        //    {
        //        Value = d.Id.ToString(),
        //        Text = d.Name
        //    }).ToList();

        //    return View();
        //}

        [HttpPost]
        public IActionResult SaveCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Update(course);
                //Context.courses.Add(course);
                courseRepository.Save();//.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = /*new SelectList(Context.departments.ToList(), "Id", "Name",course.Dept_id*/
                departmentRepository.GetAll();
            return View("Add", course);
        }

        //public IActionResult SaveCourse(Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        courseRepository.Add(course);
        //        courseRepository.Save();
        //        return RedirectToAction("Index");
        //    }

        //    var departments = departmentRepository.GetAll();
        //    ViewBag.Departments = departments.Select(d => new SelectListItem
        //    {
        //        Value = d.Id.ToString(),
        //        Text = d.Name,
        //        Selected = course.Dept_id == d.Id
        //    }).ToList();

        //    return View("Add", course);
        //}

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

            return View("Index", coursesList);
        }




    }
}
