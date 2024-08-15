using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public string Degree { get; set; }

        [ForeignKey("Course")]
        public int Crs_id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int Trainee_id { get; set; }
        public Trainee Trainee { get; set; }
    }
}
