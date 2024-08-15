using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name = "Course Name")]
        [Required]
        [MaxLength(20, ErrorMessage = "The Maximum length should be 20")]
        [MinLength(2, ErrorMessage = "The minimum length should be 2")]
        [Unique]
        public string Name { get; set; }

        [Required]
        [Range(50, 100, ErrorMessage = "the range should between 50 To 100")]

        [Remote ("CheckDegree","Course",AdditionalFields = "MinDegree",ErrorMessage ="The degree should greater than minimum degree")]
        public int? Degree { get; set; }

        [Required]
        public int? MinDegree { get; set; }

        [Remote ("CheckHours","Course",ErrorMessage = "Hours should be Divisible by 3")]
        public int? Hours { get; set; }


        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int Dept_id { get; set; }
        public Department? Department { get; set; }

        public List<Instructor>? instructors { get; set; }

        public List<CrsResult>? crsResults { get; set; }
    }
}
