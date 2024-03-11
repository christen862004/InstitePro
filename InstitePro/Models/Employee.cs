using System.ComponentModel.DataAnnotations.Schema;

namespace InstitePro.Models
{
    public class Employee
    {
        public int Id { get; set; }//primary key identity
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string? JobTitle { get; set; }
        
        [ForeignKey("Department")]//property name Department
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
