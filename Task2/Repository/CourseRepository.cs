using Microsoft.EntityFrameworkCore;
using Task2.Models;

namespace Task2.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public string Id { get; set; }  
        ITIContext Context;

        public CourseRepository(ITIContext _Context)
        {
            Context = _Context;   /*new ITIContext();*/
            Id = Guid.NewGuid().ToString();
        }
        public void Add(Course obj)
        {
            Context.Add(obj);
        }
        public void Update(Course obj)
        {
            Context.Update(obj);
        }

        public void Delete(int id)
        {
            Course course = GetById(id);
            Context.Remove(course);    
        }

               
        public List<Course> GetAll()
        {
            return Context.courses.Include(course => course.Department).ToList();
        }

        public Course GetById(int id)
        {
            return Context.courses.FirstOrDefault(c=>c.Id==id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }


        public List<Course> getByDeptId(int deptId)
        {
            var courses = Context.courses.Where(c => c.Dept_id == deptId).ToList();

            // Log or inspect the result to ensure it's not empty
            Console.WriteLine($"Number of courses found: {courses.Count}");

            return courses;
        }


    }
}
