
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace InstitePro.Controllers
{
    //[xyz]
    public class DepartmentController : Controller
    {
        //action by default can handel any reuest type(Get |Post)
        //ITIContext context=new ITIContext();
        IDepartmentRepository DepartmentRepository;
        IEmployeeRepository EmployeeRepository;
        //DEpartment/index

        public DepartmentController(IDepartmentRepository DeptRepo,IEmployeeRepository empRepo)
        {
            
            DepartmentRepository = DeptRepo;
            EmployeeRepository = empRepo;
            
        }
        //Department/GetEmpByDEptID?deptID=1
       // [xyz]
        public IActionResult GetEmpByDEptID(int deptID)
        {
                var employees = EmployeeRepository.GetByDeptID(deptID)
                    .Select(e => new { e.Name, e.Id }).ToList();
                //----------------
                return Json(employees);
           
        }
        //[xyz]
        public IActionResult ShowDeptsEmp()
        {
            List<Department> depts = DepartmentRepository.GetAll();
            return View("ShowDeptsEmp", depts);//List<DEpartment>
        }



        

        public IActionResult GetPartialCard(int id)
        {
            Department deptModel=DepartmentRepository.GetById(id);
            // return PartialView("_DeptCard",deptModel);
            return Json(deptModel);
        }




        //[Authorize]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                List<Department> deptListModel = DepartmentRepository.GetAll();
                return View("Index", deptListModel);//View Index ,Model = List<department>
            }
            return RedirectToAction("Loing");
        }
        [HttpGet]//a - form method get
        public IActionResult New()
        {
            return View("NewDept");//Model =null
        }
        //local/Department/SaveNew?Name=val&ManagerName=value
        
        [HttpPost]//form method posyt
        public IActionResult SaveNEw(Department Dept)
        {
            //if(Request.Method != "POST")
            if (Dept.Name != null && Dept.ManagerName != null)
            {
                DepartmentRepository.Insert(Dept);
                DepartmentRepository.Save();

                //return RedirectToAction("Index");//index action in current controller
                return RedirectToAction("Index");//index action in current controller
                                                    //return RedirectToAction("Index", "Employee");
                                                    //return RedirectToAction("Index", new {id=Dept.Id});
                                                    //return RedirectToAction("DEtails", "Employee", new { id = 1 });
            }
            return View("NewDept", Dept);//view=NewDept ,Model= DEpartment
        }


        public IActionResult DEtails(int id)
        {
            return View("Details", DepartmentRepository.GetById(id));
        }
        public IActionResult Delete(int id)
        {
            return View("Delete", DepartmentRepository.GetById(id));
        }
    }
}
