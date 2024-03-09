namespace InstitePro.Models
{
    //static
    public class StudentBL
    {
        List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1, Name = "Sara", Age = 22, DeptId = 1, ImageURL = "2.jpg" });
            students.Add(new Student() { Id = 2, Name = "Ahmed", Age = 22, DeptId = 2, ImageURL = "m.png" });
            students.Add(new Student() { Id = 3, Name = "Mahmoud", Age = 22, DeptId = 1, ImageURL = "m.png" });
            students.Add(new Student() { Id = 4, Name = "Asmaa", Age = 22, DeptId = 2, ImageURL = "2.jpg" });
        }

        public List<Student> GetAll() {
            return students;
        }
        public Student GetByID(int id)
        {
            return students.FirstOrDefault(e => e.Id == id);
        }
    }
}
