using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

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
        public async Task<IActionResult> Register(RegisterUserViewModel userViewModel) {
        
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = userViewModel.UserName;
                user.PasswordHash = userViewModel.Password;
                user.Address = userViewModel.Address;

                //add user database AspNEtUser 
                IdentityResult result = 
                    await userManager.CreateAsync(user,user.PasswordHash);

                if(result.Succeeded)
                {
                    //add Claim to Db 
                    await userManager.AddClaimAsync(user, new Claim("color", "REd"));
                    //Assign To Role
                    await userManager.AddToRoleAsync(user,"Admin" );
                    //cookie
                    await signInManager.SignInAsync(user, false);//id,name.role
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

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        //handel only internal request
        [ValidateAntiForgeryToken]//request internal serve ,external reject this papge not work
        public async Task<IActionResult> SaveLogin(LoginViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //check Valida Account alread name & password (user)
                ApplicationUser userModel=
                    await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    //check pasww
                    bool found= await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found == true)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("Ads", userModel.Address));
                        //Claims.Add(new Claim(ClaimTypes.Name, userModel.UserName));

                        //cookie(id,name,[Role],address) 
                        // await signInManager.SignInAsync(userModel, userVM.RememberMe);
                        await signInManager.SignInWithClaimsAsync(userModel, userVM.RememberMe,Claims);
                        return RedirectToAction("Index", "Department");
                    }
                }
                ModelState.AddModelError("", "Invalid Account Data try Again");
            }
            return View("Login", userVM);
        }
    
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account"); 
        }
    }
}
