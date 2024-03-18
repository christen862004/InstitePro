using System.ComponentModel.DataAnnotations;

namespace InstitePro.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            ITIContext context = new ITIContext();
            string name = value.ToString();
            Employee EmpFromRequest = validationContext.ObjectInstance as Employee;
            
            Employee EmpFromDb=context.Employee
                .FirstOrDefault(x => x.Name == name && x.DepartmentId==EmpFromRequest.DepartmentId);
            if(EmpFromDb == null)
            {
                //value valid
                return ValidationResult.Success;
            }

            return new ValidationResult("Name Already Found");
        }
    }
}
