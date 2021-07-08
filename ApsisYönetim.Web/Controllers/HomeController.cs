using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserService _userService = null;
        private readonly IMapper _mapper = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly UserManager<User> _userManager = null;
        private readonly SignInManager<User> _signInManager = null;


        public HomeController(ILogger<HomeController> logger,IUserService userService, SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager,UserManager<User> userManager)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }

        [Authorize(Roles = nameof(Roles.Admin) + "," + nameof(Roles.User))]
        public async Task<IActionResult> Index()
        {
            var result = await _userService.GetAsync(x => x.UserName == User.Identity.Name);
            User currentUser = result.Data;
            var resultRoles = await _userService.GetUserRoles(currentUser);

            if (resultRoles.Data.Any(x=> x == "Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "User"); 
        }


        public IActionResult Login()
        {
           
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto userdto)
        {

            var result = await _userService.Login(_mapper.Map<User>(userdto),userdto.Password);
            if (result.Success)
            {
                var res = await _userService.GetAsync(x => x.Email == userdto.Email);
                User dbUser = res.Data;
                HttpContext.Session.SetString("userid", dbUser.Id);

                HttpContext.Session.SetString("password", userdto.Password);
                HttpContext.Session.SetString("email", userdto.Email);
                
                


                // Is Admin or Not 
                if (result.Data)
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index","User");
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
            Role role = await _roleManager.FindByNameAsync(nameof(Roles.Admin));
            User user = new User { Email = "emre@emre.com", Name = "Emre", UserName = "0the1emre", PlakaNo = "26BY534", };

            await _userManager.CreateAsync(user, "Emrekurtar007!");
            await _userManager.AddToRoleAsync(user, nameof(Roles.Admin));

            return View();
        }

        


    }
}
