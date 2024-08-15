using System.ComponentModel.DataAnnotations.Schema;
using Task2.Models;

namespace Task2.ViewModel
{
    public class ShowTraineeResultWithCourseViewModel
    {
        public int? Degree { get; set; }
        public string? Course_name { get; set; }
        public string Trainee_name { get; set; }
        public bool IsPass {  get; set; }
        public string Color { get; set; }
    }
}
