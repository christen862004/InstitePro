using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class BindController : Controller
    {
        /*
         <form action ="/Bind/testPrim" method="get">
                   <input name=age>
                   <input name=name>
                    <input name="color[0]">
        </form>
         */
        //Primitive Type(int ,string)
        //Bind/testPrim?age=12&name=Ahmed&color=red&color=blue
        public IActionResult testPrim(int age,string name,string[] color)
        {
            return Content("Hello");
        }

        //Collection List-Dic--
        //Bind/TestDic?name=mohamed&Phones[ahmed]=123&Phones[chris]=456
        public IActionResult TestDic(Dictionary<string,string> Phones,string name)
        {
            return Content("Hello");

        }

        //Class :Custom Type
        //Bind/testObj?name=SD&ManagerName=Ahmed&Employees[0].Name=alaa
        public IActionResult TestObj(Department dept)
        {
            return Content("Hello");
        }
    }
}
