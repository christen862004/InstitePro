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


        public IActionResult SetCookie()
        {
            //logic DB
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            //info State Managment Using Cooike==>end user
            HttpContext.Response.Cookies.Append("Name", "Saaed");
            //session Cookie "Life time <==> session
            HttpContext.Response.Cookies.Append("Color", "Blue",cookieOptions);//Presisitent Cookie

            return Content("Cookie Saved");
        }

        public IActionResult GetCookie()
        {
            //logic
            //read Data Cookie
            string clr= HttpContext.Request.Cookies["Color"];
            string n = HttpContext.Request.Cookies["Name"];
            return Content($"Data FRom Cookie :{clr} - {n}");
        }
    }
}
