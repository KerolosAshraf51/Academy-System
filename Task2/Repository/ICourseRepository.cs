using Task2.Models;

namespace Task2.Repository
{
    public interface ICourseRepository
    {
        public string Id { get; set; }

        public void Add(Course obj);

        public void Update(Course obj);

        public void Delete(int id);

        public List<Course> GetAll();

        public Course GetById(int id);

        public void Save();

        public List<Course> getByDeptId(int deptId);
                

    }
}
