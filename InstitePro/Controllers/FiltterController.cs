using InstitePro.Filtters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InstitePro.Controllers
{
  //  [HandelError]
    public class FiltterController : Controller
    {

        public IActionResult Index()
        {
            throw new Exception("Action Thorw Exception");
        }
        public IActionResult Index2()
        {
            throw new Exception("Action Thorw Exception Action2");
        }
    }
}
