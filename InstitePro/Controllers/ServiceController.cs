using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace InstitePro.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServiceController(IDepartmentRepository DeptRepo)
        {
            deptRepo = DeptRepo;
        }
        public IActionResult Index()//Department dept,[FromServices]IDepartmentRepository deptrepository)
        {
            ViewData["Id"] = deptRepo.Id;
            return View();
        }
    }
}
