using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using System.Collections.Generic;

namespace Task2.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository deptRepo;
        ICourseRepository courseRepo;

        public DepartmentController(IDepartmentRepository DeptRepo, ICourseRepository CrsRepo)
        {
            deptRepo = DeptRepo;
            courseRepo = CrsRepo;
        }

        public IActionResult crsdept()
        {
            return View("crsdept", deptRepo.GetAll());
        }

        public IActionResult getcrsbydeptid(int deptid)
        {
            List<Course> CourseList = courseRepo.getByDeptId(deptid);
            return Json(CourseList);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
