using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class StateController : Controller
    {
        int count = 0;//StateManagemnt session /cookie
        public StateController()
        {
            count++;
        }
        public IActionResult SetSession()
        {
            //logic
            //employee ==>json  ==>PPT
            HttpContext.Session.SetString("Name", "Ahmed");
            HttpContext.Session.SetInt32("Age", 14);
            //logic
            return Content("Session Data Save");
        }
        //any controller
        public IActionResult GetSession()
        {
            //logic
            string n=HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");//.Value;
            //logic
            return Content($"NAme={n} \t Age={a}");
        }
    }
}
