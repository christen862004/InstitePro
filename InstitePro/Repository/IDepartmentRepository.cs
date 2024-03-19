namespace InstitePro.Repository
{
    public interface IDepartmentRepository
    {
        string Id { get; set; }

        List<Department> GetAll();//string includes=null)
        
        Department GetById(int id);

        void Insert(Department obj);

        void Update(Department obj);

        void Delete(int id);

        void Save();
        
    }
}