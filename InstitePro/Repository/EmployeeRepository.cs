namespace InstitePro.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _context)
        {
            context = _context;
        }
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee Emp = GetById(id);
            context.Remove(Emp);
        }
        public List<Employee> GetByDeptID(int deptid)
        {
            return  context.Employee.Where(e=>e.DepartmentId== deptid).ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
