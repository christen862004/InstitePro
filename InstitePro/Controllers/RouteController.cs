using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    //[Route("r/{action}")]
    public class RouteController : Controller
    {
        //Route/action1 not allow
        //A1 :litteral 1 segmat ==>mapping 
        //A1?name=Ahmed
        //A1/{name}/{age}/{color}
        //A1/ahmed/33
        //A1/ahmed/33/red
        [Route("A1/{age:int:max(40)}/{NAME?}/{color?}")] //the only route will call using it  WEb API
        public IActionResult action1(string NAME,int age,string color)
        {
            return Content($"Hello Rfom MEthod1 {NAME}");
        }

        public IActionResult action2()
        {
            return Content("Hello Rfom MEthod2");
        }
        public IActionResult action3()
        {
            return Content("Hello Rfom MEthod3");
        }

        //cant be overload one case
        //Route/MEthod1
        [HttpGet]
        public IActionResult Method1()
        {
            Employee emp = new();
            //return View("View1");     //View =View1  ,Model = null
            //return View("View1", emp);//view=View1 ,Model=Employee
            //return View();            //view name=Method1 ,Model =null
            //return View(emp);         //view name=MEthod1 ,ModelEmployee
            //return RedirectToAction("","",new { });
            return Content("M1");
        }
        
        [HttpPost]
        public IActionResult Method1(int id)
        {
            return Content("M1 Post");
        }
    }
}
