using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InstitePro.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            return View("Index", context.Employee.ToList());
        }
        //Employee/DEatisl?id=1&age=112
        //Employee/DEtails/1?age=12
        public IActionResult Details(int id,int age)//name paramter input 
        {
            //Request.Form.con
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

        [HttpGet]//click on link
        public IActionResult Edit(int id)
        {
            Employee empModel = context.Employee.FirstOrDefault(e => e.Id == id);
            if(empModel == null)
                return NotFound("Emp Not Found");
            EmployeeWithDeptListViewModel empVM = new EmployeeWithDeptListViewModel();
            empVM.Name = empModel.Name;
            empVM.Id = empModel.Id;
            empVM.JobTitle = empModel.JobTitle;
            empVM.DepartmentId = empModel.DepartmentId;
            empVM.Salary = empModel.Salary;
            empVM.Address = empModel.Address;
            empVM.ImageUrl = empModel.ImageUrl;
            empVM.DeptList = context.Department.ToList(); ;

            return View("Edit", empVM);//view =Edit ,Model =ViewModel
        }
        [HttpPost]
        public IActionResult SaveEdit(Employee employeeModelReq)//Vm
        {
            if (employeeModelReq.Name != null)
            {
                //get old using context
                //update from new set old
                context.Update(employeeModelReq);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            EmployeeWithDeptListViewModel empVM = new EmployeeWithDeptListViewModel();
            empVM.Name = employeeModelReq.Name;
            empVM.Id   = employeeModelReq.Id;
            empVM.Address = employeeModelReq.Address;
            empVM.JobTitle = employeeModelReq.JobTitle;
            empVM.Salary = employeeModelReq.Salary;
            empVM.DepartmentId = employeeModelReq.DepartmentId;
            empVM.ImageUrl= employeeModelReq.ImageUrl;
           
            empVM.DeptList = context.Department.ToList();

            return View("Edit", empVM);//Model =Employee
           // return RedirectToAction("Edit", new {id=employeeModelReq.Id});
        }

        public IActionResult New()
        {
            ViewData["DeptList"] = context.Department.ToList();
            return View("New");//Model Null
        }

        [HttpPost]
        public IActionResult SaveNew(Employee empModelFromREquest) {
            if(empModelFromREquest.Name != null)
            {
                context.Add(empModelFromREquest); 
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["DeptList"] = context.Department.ToList();
            return View("New", empModelFromREquest);//Model +List
        
        }
    }
}
