
namespace InstitePro.Repository
{
    public class DEpartmetnFromMEmoryRepository : IDepartmentRepository
    {
        List<Department> departmetn;
        public DEpartmetnFromMEmoryRepository()
        {
            departmetn= new List<Department>();
            departmetn.Add(new Department() { Id=1,Name="Ayha1",ManagerName="asd"});
            departmetn.Add(new Department() { Id = 2, Name = "Ayha2", ManagerName = "asd" });

        }

        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return departmetn;
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Department obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Department obj)
        {
            throw new NotImplementedException();
        }
    }
}
