using InstitePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //Employee/DEatisl?id=1
        public IActionResult Details(int id)
        {
            
           ViewData["msg"] = "Hello";
            List<string> branches= new List<string>();
            branches.Add("Smart");
            branches.Add("Assiut");
            branches.Add("Alex");
            branches.Add("Sohag");

            ViewData["brch"]= branches;
            int temp = 10;
            ViewData["Temp"] = temp;
            string Color = "Red";



            ViewData["clr"] = Color;

            ViewBag.clr = "Blue";

            ViewBag.CurrentDate=DateTime.Now;//ViewData["CurrentDate"]=DateTime.Now

            Employee EmpModel=
                context.Employee.FirstOrDefault(e=>e.Id==id);
            
            return View("Details",EmpModel);//View Deatisl ,Model type Employee
        }
    }
}
