using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Security.Claims;

namespace InstitePro.Controllers
{
    public class ServiceController : Controller
    {
        //[Authorize]
        //Check Authorize & rEad FRom Cookie
        public IActionResult CheckAuth()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                //login take from db store Cookie read faster
                //id - ads
                Claim AddressClaim= User.Claims.FirstOrDefault(c => c.Type == "Ads");
                string address = AddressClaim.Value;

                Claim IdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id = IdClaim.Value;
            }
            return RedirectToAction("Login", "Account");
        }



        private readonly IDepartmentRepository deptRepo;
        private readonly IConfiguration config;

        public ServiceController(IDepartmentRepository DeptRepo,IConfiguration config)
        {
            deptRepo = DeptRepo;
            this.config = config;
        }
        public IActionResult Index()//Department dept,[FromServices]IDepartmentRepository deptrepository)
        {
            string appname=config.GetSection("appNAme").Value;

            ViewData["Id"] = deptRepo.Id;
            return View();
        }
    }
}
