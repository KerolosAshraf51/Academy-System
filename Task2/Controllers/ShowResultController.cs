using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2.Models;
using Task2.ViewModel;

namespace Task2.Controllers
{
    public class ShowResultController : Controller
    {
        public IActionResult Index(int id ,int Crs_id)
        {
            ITIContext context = new ITIContext();  
            Trainee trainee = context.trainees.FirstOrDefault(t=>t.Id==id);
            Course course = context.courses.FirstOrDefault(c =>c.Id == Crs_id);
            CrsResult crsResult = context.crsResults.FirstOrDefault(cR=>cR.Trainee_id==id);   

            string color = "green";
            bool IsPass = true;

            int? degree = Int32.Parse(crsResult.Degree);
            int? Minimumdegree = course.MinDegree;
            if (degree < Minimumdegree)
            {
                color = "red";
                IsPass = false;
            }
            ShowTraineeResultWithCourseViewModel Show = new ShowTraineeResultWithCourseViewModel();
            Show.Degree = degree;
            Show.Course_name = course.Name;
            Show.Trainee_name = trainee.Name;
            Show.IsPass = IsPass;
            Show.Color = color;

            return View ("index", Show);
        }
    }
}
