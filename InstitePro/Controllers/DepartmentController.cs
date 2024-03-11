using InstitePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context=new ITIContext();
        public DepartmentController()
        {
            
        }
        public IActionResult Index()
        {
            List<Department> deptListModel = context.Department.ToList();
            return View("Index",deptListModel);//View Index ,Model = List<department>
        }
    }
}
