using bbmscore.Data;
using bbmscore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace bbmscore.Controllers
{
    public class Account : Controller
    {
       
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AuthDbcontext authDbcontext;
        private readonly UserManager<IdentityUser> userManager;

        public Account(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,AuthDbcontext authDbcontext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authDbcontext = authDbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
         return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var identityuser = new IdentityUser
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email
            };
            var identityresult = await userManager.CreateAsync(identityuser, registerRequest.Password);

            if (identityresult.Succeeded)
            {
                //assiging a role
                var roleidresult = await userManager.AddToRoleAsync(identityuser, "User");
                if (roleidresult.Succeeded)
                {
                    //success notification
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
       [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        public async Task<IActionResult> AccessDenied(Guid id)
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddAdmins()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmins(AdminRequest adminRequest)
        {
            

            var identityuser = new IdentityUser
            {
                UserName = adminRequest.username,
                Email=adminRequest.Email
               
            };
            //creating for him
            var identityresult = await userManager.CreateAsync(identityuser,adminRequest.Password);

            if (identityresult.Succeeded)
            {
                //adding to the role
                var roleidresult = await userManager.AddToRoleAsync(identityuser, "Admin");
                if (roleidresult.Succeeded)
                {
                    
                    return RedirectToAction("AdminsList");
                }
               

            }
           

            return View();
        }
    
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminsList()
        {
            var admins = await userManager.GetUsersInRoleAsync("Admin");
            return View(admins);
        }
    }
}
    

