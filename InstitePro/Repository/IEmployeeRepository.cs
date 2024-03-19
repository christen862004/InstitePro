namespace InstitePro.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAll();//string includes=null)

        Employee GetById(int id);

        void Insert(Employee obj);

        void Update(Employee obj);

        void Delete(int id);

        void Save();
        List<Employee> GetByDeptID(int deptid);
    }
}