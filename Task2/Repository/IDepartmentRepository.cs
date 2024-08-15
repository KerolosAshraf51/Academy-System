using Task2.Models;

namespace Task2.Repository
{
    public interface IDepartmentRepository 
    {

        public void Add(Department obj);

        public void Update(Department obj);

        public void Delete(int id);

        public List<Department> GetAll();

        public Department GetById(int id);
        public void Save();


}
}