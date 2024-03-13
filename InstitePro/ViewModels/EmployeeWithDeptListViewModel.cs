using System.ComponentModel.DataAnnotations.Schema;

namespace InstitePro.ViewModels
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }//primary key identity
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        public string? JobTitle { get; set; }
        public int DepartmentId { get; set; }

        public List<Department> DeptList { get; set; }
    }
}
