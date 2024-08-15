using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int? Dept_id { get; set; }    

        
        public Department Department { get; set; }

        [ForeignKey("Course")]
        public int? Crs_id{ get; set; }  
        public Course Course { get; set; }

    }
}
