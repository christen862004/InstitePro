using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace InstitePro.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
        //    UserStore<>
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel userViewModel) {
        
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userViewModel.UserName;
                user.PasswordHash = userViewModel.Password;
                user.Address = userViewModel.Address;

                
                IdentityResult result= await userManager.CreateAsync(user,user.PasswordHash);
                if(result.Succeeded)
                {
                    
                    //cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Department");
                    //UserManager<ApplicationUser> manager=new UserManager<ApplicationUser>()
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                //save db add
            }
            return View("Register", userViewModel);
        }
    }
}
