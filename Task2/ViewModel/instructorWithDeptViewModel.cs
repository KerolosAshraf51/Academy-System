using Task2.Models;
namespace Task2.ViewModel
{
    public class instructorWithDeptViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? Salary { get; set; }
        public string? Address { get; set; }

        public int? Dept_id { get; set; }
        public List<Department> DeptList { get; set; }
    }
}
