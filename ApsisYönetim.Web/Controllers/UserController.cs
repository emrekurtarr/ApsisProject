using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.User;
using ApsisYönetim.Web.Models.ViewModels;
using AutoMapper;
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
        private readonly UserManager<User> _userManager = null;
        private readonly SignInManager<User> _signInManager = null;
        private readonly IMapper _mapper = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IUserService _userService = null;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager,IMapper mapper, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        //public async Task<IActionResult> Create()
        //{

        //    //User user = new User { Email = "emre@emre.com", Name = "Emre", UserName = "0the1emre", PlakaNo = "26BY534",Role= new Role{Name}nameof(Roles.Admin)};
        //    //await _userManager.CreateAsync(user, "Emrekurtar007!");



        //    return View();
        //}
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserDto userdto)
        {

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
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult CreateUser()
        {

            return View();
        }

        

        public IActionResult ShowInfoForUser()
        {
            ViewBag.UserPassword = TempData["UserPassword"];
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
