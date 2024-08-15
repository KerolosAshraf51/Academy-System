using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;

namespace Task2.Models


{
    public class ITIContext:DbContext
    {
       public DbSet<Department> departments { get; set; }
        public DbSet <Instructor> instructors { get; set; }
        public DbSet <Trainee> trainees { get; set; }
        public DbSet <Course> courses { get; set; }
        public DbSet<CrsResult> crsResults{ get; set; }

        public ITIContext():base()
        {
                
        }

        public ITIContext(DbContextOptions options):base(options)
        { 

        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Accademy ;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
