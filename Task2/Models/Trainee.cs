using System.ComponentModel.DataAnnotations.Schema;

namespace Task2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public int? Grade { get; set; }

        [ForeignKey("Department")]
        public int Dept_id { get; set; }
        public Department Department { get; set; }

        public List<CrsResult> crsResults { get; set; }

    }
}
