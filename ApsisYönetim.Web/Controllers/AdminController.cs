using ApsisYönetim.Core.Entities;
using ApsisYönetim.Service.DTOs;
using ApsisYönetim.Service.DTOs.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    [Authorize(Roles =nameof(Roles.Admin))]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager = null;
        private readonly IMapper _mapper = null;

        public AdminController(UserManager<User> userManager,IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            if(user != null)
            {
                

                IdentityResult result = _userManager.DeleteAsync(user).Result;
                if (result.Succeeded)
                {
                    return NoContent();
                }
                
            }
            
            return BadRequest();

        }


        public async Task<IActionResult> DetailUser(Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) return NotFound();

            ListingUserDto userdto = _mapper.Map<ListingUserDto>(user);

            return View(userdto);
        }


        public IActionResult ShowUser()
        {
            List<User> users = _userManager.Users.ToList();

            return View(_mapper.Map<List<ListingUserDto>>(users));

        }

        

       

       

    }
}
