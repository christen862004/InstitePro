using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class DepartmentController : Controller
    {
        //Department/GetEmpByDEptID?deptID=1
        public IActionResult GetEmpByDEptID(int deptID)
        {
            var  employees = context.Employee
                .Where(e => e.DepartmentId == deptID)
                .Select(e => new { e.Name,e.Id}).ToList();
            return Json(employees);
        }
        public IActionResult ShowDeptsEmp()
        {
            List<Department> depts = context.Department.ToList();
            return View("ShowDeptsEmp", depts);//List<DEpartment>
        }



        //action by default can handel any reuest type(Get |Post)
        ITIContext context=new ITIContext();
        public DepartmentController()
        {
            
        }

        public IActionResult GetPartialCard(int id)
        {
            Department deptModel=context.Department.FirstOrDefault(x => x.Id == id);
            // return PartialView("_DeptCard",deptModel);
            return Json(deptModel);
        }





        public IActionResult Index()
        {
            List<Department> deptListModel = context.Department.ToList();
            return View("Index",deptListModel);//View Index ,Model = List<department>
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
                context.Department.Add(Dept);
                context.SaveChanges();

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
            return View("Details", context.Department.FirstOrDefault(d => d.Id == id));
        }
        public IActionResult Delete(int id)
        {
            return View("Delete", context.Department.FirstOrDefault(d => d.Id == id));
        }
    }
}
