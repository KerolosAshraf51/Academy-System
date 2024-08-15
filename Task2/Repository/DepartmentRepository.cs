using Task2.Models;

namespace Task2.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITIContext Context;

        public DepartmentRepository(ITIContext _Context)
        {
            Context = _Context;
                /*new ITIContext();*/
        }
        public void Add(Department obj)
        {
            Context.Add(obj);
        }
        public void Update(Department obj)
        {
            Context.Update(obj);
        }

        public void Delete(int id)
        {
            Department dept = GetById(id);
            Context.Remove(dept);
        }


        public List<Department> GetAll()
        {
            return Context.departments.ToList();
        }

        public Department GetById(int id)
        {
            return Context.departments.FirstOrDefault(d => d.Id == id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        
        
    }
}
