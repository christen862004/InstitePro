using InstitePro.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();

        //Student/all
        public IActionResult All()
       {
            //ask model data
            List<Student> StudentsModel = studentBL.GetAll();

            //send view to Display
            return View("ShowAll",StudentsModel);//View =ShowAll ,Model List<Student>
       }
        //End point 
        //Student/Details?id=1
        public IActionResult Details(int id)
        {
            Student stdModel = studentBL.GetByID(id);
            return View("DEtails",stdModel);//View =Details ,Model=Stduent
        }
    }
}
