using InstitePro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InstitePro.Controllers
{
    //public 
    //inherit from Contoller
    //End With Controller
   // [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //url/Home/Index
        [AllowAnonymous]
        public IActionResult Index()
        {
            //IdentityUser
            return View();
        }
        //url:/Home/privacy
        
        public IActionResult Privacy()
        {
            return View();
        }

        //MEthod ==> Action
        //Action must be public 
        //Action cant be static
        //Action cant be OverLoad
        //Home/ShowMsg
        //public string ShowMsg()
        //{
        //    return "Hello";
        //}
        public ViewResult ShowView()
        {
            //Logic
            //DEclare
            ViewResult result = new ViewResult();
            //Set
            result.ViewName = "View1";
            //Retrun
            return result;
        }
        public ContentResult ShowMsg()
        {
            //logic
            //DEclare
            ContentResult result = new ContentResult();
            //set
            result.Content = "Heelo from Action";
            //erturn
            return result;
        }
        //---------------------------------------
        //Home/ShowMix?stdno=1&name=ahmed
        public ActionResult ShowMix(int stdNo)//,string name)
        {
            if (stdNo == 13)
            {
                return Content("HEllo");
            }
            else
            {
                return View("View1");
            }
        }


        public ViewResult showview2()
        {
            //logic
            return View("View2");
        }
        //ViewResult View(string viewName)
        //{
        //    ViewResult result = new ViewResult();
        //    //Set
        //    result.ViewName = viewName;
        //    //Retrun
        //    return result;
        //}





        //Action CAn REturn
        /*
         1)String  --> ContentResult  ==>Content
         2)View    --> ViewResult     ==> View
         3)Json    --> JsonREsult     ==>json
         4)File    --> fileREsult
         5)NotFound -> NotFoundResult
         6)Unauthor -> UnauthotizeResult
         ......
         */



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
