using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitePro.Models
{
    public class Employee
    {
        public int Id { get; set; }//primary key identity
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [Display(Name="Profile Image")]
        public string ImageUrl { get; set; }
        //[DataType(DataType.ImageUrl)]
        public string? JobTitle { get; set; }
        
        [ForeignKey("Department")]//property name Department
        [Display(Name="Select DEpartment")]
        public int DepartmentId { get; set; }
        //public bool Isdelete { get; set; } = false;

        public Department Department { get; set; }
    }
}
