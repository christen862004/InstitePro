using Microsoft.EntityFrameworkCore;

namespace InstitePro.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }


        public ITIContext():base()
        {
            
        }
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {

        }
        //
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //insert DEpartment dtata
            modelBuilder.Entity<Department>()
                .HasData(new Department() { Id = 1, Name = "SD", ManagerName = "Eng.Ayman" });
            modelBuilder.Entity<Department>()
                .HasData(new Department() { Id = 2, Name = "UI/UX", ManagerName = "Eng.Saad" });
            //insert Employee Data
            modelBuilder.Entity<Employee>()
               .HasData(new Employee { Id = 1, Name = "Ahmed", Salary = 10000, ImageUrl = "m.png", JobTitle = "Manager", Address = "Alex", DepartmentId = 1 });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee { Id = 2, Name = "Mahomoud", Salary = 10000, ImageUrl = "m.png", JobTitle = "Manager", Address = "Alex", DepartmentId = 2 });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee { Id = 3, Name = "Sara", Salary = 10000, ImageUrl = "2.jpg", JobTitle = "Manager", Address = "Alex", DepartmentId = 1 });
            modelBuilder.Entity<Employee>()
               .HasData(new Employee { Id = 4, Name = "Aya", Salary = 10000, ImageUrl = "2.jpg", JobTitle = "Manager", Address = "Alex", DepartmentId = 2 });
            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=Assiut_Intake44;Integrated Security=True;Encrypt=False");
            //base.OnConfiguring(optionsBuilder);
        }
    }
}
