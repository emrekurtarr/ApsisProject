using ApsisYönetim.Core.Entities;
using ApsisYönetim.Web.Models;
using ApsisYönetim.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly SignInManager<User> _signInManager = null;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel usermodel)
        {
            User loginedUser = await _userManager.FindByEmailAsync(usermodel.Email);

            if (loginedUser != null)
            {
                var result = await _signInManager.PasswordSignInAsync(loginedUser, usermodel.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();


        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        public async Task<IActionResult> AddRole()
        {
            await _roleManager.CreateAsync(new Role { Name = nameof(Roles.Admin) });
            await _roleManager.CreateAsync(new Role { Name = nameof(Roles.User) });
            return View();
        }


        public async Task<IActionResult> AddAdmin()
        {
            //Role role = await _roleManager.FindByNameAsync(nameof(Roles.Admin));
            //User user = new User { Email = "emre@emre.com", Name = "Emre", UserName = "0the1emre", PlakaNo = "26BY534", };

            //await _userManager.CreateAsync(user, "Emrekurtar007!");
            //await _userManager.AddToRoleAsync(user, nameof(Roles.Admin));

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
