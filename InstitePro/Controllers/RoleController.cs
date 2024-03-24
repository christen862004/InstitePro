using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    [Authorize(Roles ="Admin")]//have cookie (role =Admin) or not
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Create()
        {
            return View("Create");
        }
   
        [HttpPost]
        public async Task<IActionResult> SaveCreate(RoleViewModel roleVM)
        {
            if(ModelState.IsValid)
            {
                //save Db Role
                IdentityRole role = new IdentityRole();
                role.Name = roleVM.RoleName;
                IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Employee");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View("Create",roleVM);
        }

    }
}
