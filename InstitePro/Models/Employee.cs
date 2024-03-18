using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstitePro.Models
{
    /*validation attribute */
    public class Employee
    {
        public int Id { get; set; }//primary key identity

        [MaxLength(25)]
        [Unique]
        [MinLength(3,ErrorMessage ="NAme Must be More Than 2 Letter")]
        public string Name { get; set; }

        //[Range(6000,25000)]
        [Remote("CheckSalary","Employee"
            ,ErrorMessage ="Salary Invalid",AdditionalFields = "JobTitle")]
        public int Salary { get; set; }

        [RegularExpression("(Alex|Assiut|Sohag)",ErrorMessage ="Address Must be Alex ,Assiut, Sohag")]
        public string Address { get; set; }

        [Display(Name="Profile Image")]
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must be jpg or png")]
        public string ImageUrl { get; set; }
        
        //[DataType(DataType.ImageUrl)]
        public string? JobTitle { get; set; }
        
        [ForeignKey("Department")]//property name Department
        [Display(Name="Select DEpartment")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}

