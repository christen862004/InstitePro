using Microsoft.EntityFrameworkCore;

namespace InstitePro.Repository
{
    public class DepartmentRepository:IDepartmentRepository 
    {
        ITIContext context ;

        public string Id { get ; set ; }

        public DepartmentRepository(ITIContext _context)
        {
            
             Id = Guid.NewGuid().ToString();//unique
            context = _context;//new ITIContext();
        }
        public List<Department> GetAll()//string includes=null)
        {
            return context.Department.ToList();
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department dept= GetById(id);
            context.Remove(dept);
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
