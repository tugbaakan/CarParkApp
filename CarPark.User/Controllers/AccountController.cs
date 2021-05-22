using AspNetCore.Identity.MongoDbCore.Models;
using CarPark.Entities.Concrete;
using CarPark.Models.RequestModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Personnel> _userManager;
        private readonly SignInManager<Personnel> _signInManager;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public AccountController(UserManager<Personnel> userManager, SignInManager<Personnel> signInManager
             , RoleManager<MongoIdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new Personnel
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = "95236"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) 
                {
                    var role = new MongoIdentityRole { 
                        Name = "normal",
                        NormalizedName = "NORMAL"
                    };
                    var resultRole = await _roleManager.CreateAsync(role);
                    await _userManager.AddToRoleAsync(user,"normal");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                
                }
            }
            return View(model);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }


        }


        // login
        [HttpGet] // yazılmadıgı zaman default olarak httpget olur zaten o yuzden yazmana gerek yok
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

            }
            return View(model);
        }

        // logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

        public IActionResult AccessDenied()
        {

            return View();
        }

    }
}
