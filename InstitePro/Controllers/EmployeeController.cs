using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InstitePro.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        //Employee/DEatisl?id=1
        public IActionResult Details(int id)
        {

            ViewData["msg"] = "Hello";
            List<string> branches = new List<string>();
            branches.Add("Smart");
            branches.Add("Assiut");
            branches.Add("Alex");
            branches.Add("Sohag");

            ViewData["brch"] = branches;
            int temp = 10;
            ViewData["Temp"] = temp;
            string Color = "Red";



            ViewData["clr"] = Color;

            ViewBag.clr = "Blue";

            ViewBag.CurrentDate = DateTime.Now;//ViewData["CurrentDate"]=DateTime.Now

            Employee EmpModel =
                context.Employee.Include(e => e.Department)                
                .FirstOrDefault(e=>e.Id==id);
            
            return View("Details",EmpModel);//View Deatisl ,Model type Employee
        }

        public IActionResult DetailsVM(int id)
        {
            Employee EmpModel =
                context.Employee.FirstOrDefault(e => e.Id == id);

            //Mapping --automapper
            EmployeeNameWithBrchListMsgTempColorViewModel empVM =
                new EmployeeNameWithBrchListMsgTempColorViewModel();
            empVM.NAme = EmpModel.Name;
            empVM.ID = EmpModel.Id;
            empVM.Color = "red";
            empVM.Temp = 10;
            empVM.MEssage = "Hello";
            empVM.Branches = new List<string>() { "Alex", "Assiut", "Cairo", "New Capital" }; ;
            return View("DetailsVM",empVM);
            //View=DetailsVM ,Model =EmployeeNameWithBrchListMsgTempColorViewModel
        }
    }
}
