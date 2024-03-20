using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InstitePro.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //context.mode
            //context.Exception.Message;
            //ContentResult actionresult= new ContentResult();
            //actionresult.Content = context.Exception.Message;
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";
            //viewResult.ViewData[]
            context.Result = viewResult;
        }
    }
}
