using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
   
       
    public class UserController : Controller
    {
        private readonly IMapper _mapper = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IUserService _userService = null;

        public UserController(IUserService userService,IMapper mapper, RoleManager<Role> roleManager)
        {
            _userService = userService;           
            _mapper = mapper;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Create()
        //{

        //    //User user = new User { Email = "emre@emre.com", Name = "Emre", UserName = "0the1emre", PlakaNo = "26BY534",Role= new Role{Name}nameof(Roles.Admin)};
        //    //await _userManager.CreateAsync(user, "Emrekurtar007!");



        //    return View();
        //}

        [Authorize(Roles = nameof(Roles.User))]
        public IActionResult Index()
        {
            string username = User.Identity.Name;
            User user = _userService.GetAsync(x => x.UserName == username).Result.Data;


            return View(_mapper.Map<IndexUserDto>(user));
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        public IActionResult CreateUser()
        {

            return View();
        }

        [Authorize(Roles = nameof(Roles.Admin))]
        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserDto userdto)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

                return View(userdto);

            }
            User user = _mapper.Map<User>(userdto);

            // TO DO 
            // Do with RoleService 
            Role role = await _roleManager.FindByNameAsync("User");
            user.Roles.Add(role);

            var result = await _userService.AddAsync(user);
            var userPassword = result.Data;
            TempData["UserPassword"] = userPassword;

            if (result.Success)
            {
                return RedirectToAction("ShowInfoForUser", "User");
            }

            return View();
        }

        [Authorize(Roles = nameof(Roles.Admin) + "," + nameof(Roles.User))]
        [AllowAnonymous]
        public IActionResult LogOut(string username)
        {
            var result = _userService.LogOut(username).Result;

            // TO DO

            if (result.Success)
            {
                
            }

            return RedirectToAction("Login", "Home");
        }



        [Authorize(Roles = nameof(Roles.Admin))]
        public IActionResult ShowInfoForUser()
        {
            ViewBag.UserPassword = TempData["UserPassword"];
            return View();
        }

        [Authorize(Roles = nameof(Roles.User))]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = nameof(Roles.User))]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordUserDto userdto)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

                return View(userdto);
            }

            //Get current user's password & email adress
            string sessionpassword = HttpContext.Session.GetString("password");
            string sessionemail = HttpContext.Session.GetString("email");
            var dataresult = await _userService.GetAsync(x => x.Email == sessionemail);
            User user = dataresult.Data;

            // Check password validation 
            if (string.Equals(userdto.NewPassword, userdto.NewPasswordValidation))
            {
                var result = await _userService.ChangePassword(userdto.NewPasswordValidation,sessionpassword,sessionemail);
                if (result.Success)
                {
                    HttpContext.Session.Clear();
                    await _userService.LogOut(user.UserName);
                    return RedirectToAction("Login", "Home");
                }
            }


            return RedirectToAction("ChangePassword");
        }


        public IActionResult ShowMonthlyCharge()
        {
            string sessionemail = HttpContext.Session.GetString("email");
            User user = _userService.GetAsync(x => x.Email == sessionemail).Result.Data;
            var res = _userService.GetUserApartmentsWithMonthlyCharge(user);
            List<Apartment> sonuc = res.Result.Data;


            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(UserLoginViewModel model)
        //{
        //    User user = await _userManager.FindByEmailAsync(model.Email);

        //    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Index");
        //    }


        //}


    }
}
