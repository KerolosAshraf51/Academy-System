using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.ViewModel;

namespace Task2.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext Context = new ITIContext();
        public IActionResult Index()
        {
            List<Instructor> Instructorlist =
                Context.instructors.Include(x => x.Department).Include(y => y.Course)
                .ToList();
            return View("Index", Instructorlist);
        }

        public IActionResult Edit(int id)
        {
            Instructor instructorModel = Context.instructors.FirstOrDefault(i => i.Id == id);
            List<Department> departmentList = Context.departments.ToList();

            if (instructorModel == null)
            {
                return NotFound();
            }
            else
            {
                instructorWithDeptViewModel instViewModel = new instructorWithDeptViewModel
                {
                    Id = instructorModel.Id,
                    Name = instructorModel.Name,
                    Image = instructorModel.Image,
                    Salary = instructorModel.Salary,
                    Address = instructorModel.Address,
                    DeptList = departmentList,
                    Dept_id = instructorModel.Dept_id
                };
                return View("Edit", instViewModel);
            }
        }




        [HttpPost]
        public IActionResult SaveEdit(int id, instructorWithDeptViewModel insFromRequest)
        {
            if (insFromRequest.Name != null)
            {
                Instructor instructorFromDB = Context.instructors.FirstOrDefault(i => i.Id == id);
                if (instructorFromDB == null)
                {
                    return NotFound();
                }

                instructorFromDB.Name = insFromRequest.Name;
                instructorFromDB.Image = insFromRequest.Image;
                instructorFromDB.Salary = insFromRequest.Salary;
                instructorFromDB.Address = insFromRequest.Address;
                instructorFromDB.Dept_id = insFromRequest.Dept_id;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", insFromRequest);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = Context.instructors
                .FirstOrDefault(i => i.Id == id);
            return View("Details", instructor);

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        public IActionResult Delete(Instructor DelInstructor)
        {
            Context.instructors.Remove(DelInstructor);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult SaveAdd(Instructor newInsFromRequest)
        {
            if (newInsFromRequest.Name != null)
            {
                Context.instructors.Add(newInsFromRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");
                //return View("Index",Context.instructors.ToList());

            }
            return View("Add", newInsFromRequest);


        }

        public IActionResult Search(string name)
        {
            List<Instructor> instructors = Context.instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .Where(i => i.Name.Contains(name))
                .ToList();

            return View("Index", instructors);
        }


    }
}
