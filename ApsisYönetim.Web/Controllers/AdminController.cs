using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs;
using ApsisYönetim.Service.DTOs.Apartment;
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
        private readonly IUserService _userService = null;
        private readonly IMapper _mapper = null;
        private readonly IApartmentService _apartmentService = null;

        public AdminController(IUserService userService, IMapper mapper, IApartmentService apartmentService)
        {
            _mapper = mapper;
            _userService = userService;
            _apartmentService = apartmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> DeleteUser(string userid)
        {
            var existUser = await _userService.GetAsync(x => x.Id == userid);
            var deleteResult = await _userService.Delete(existUser.Data);

            if (deleteResult.Success)
            {
                return RedirectToAction("ShowUser", "Admin");
            }
            
            return BadRequest();

        }


        public async Task<IActionResult> DetailUser(string userid)
        {
            var result = await _userService.GetAsync(x => x.Id == userid);
            if(result.Data == null)
            {
                return NotFound();
            }

            User user = result.Data;

            return View(_mapper.Map<EditUserDto>(user));

        }

        // TODO : VALIDATION 
        [HttpPost]
        public async Task<IActionResult> DetailUser(EditUserDto userdto)
        {

            var result = await _userService.Update(_mapper.Map<User>(userdto));

            if (result.Success)
            {
                return RedirectToAction("ShowUser", "Admin");
            }

            return RedirectToAction("UserNotUpdated");
        }

        public IActionResult UserNotUpdated()
        {
            return View();
        }

        public async Task<IActionResult> ShowUser()
        {
            var result = await _userService.GetAllUsersWithApartments();
            List<User> users = result.Data;
            List<ListingUserDto> userdto = _mapper.Map<List<ListingUserDto>>(users);

            // Please don't look at 3 foreach loops :)))
            // I could this in service layer, but there's not enough time
            foreach (User user in users)
            {
                foreach (Apartment apartment in user.Apartments)
                {
                    if (apartment != null)
                    {
                        foreach (var item in userdto)
                        {
                            if (item.Email == user.Email)
                            {
                                item.UsersApartments.Add(apartment.BlocNo + "-" + apartment.FloorNo);
                                break;
                            }
                        }
                    }
                }
            }

            return View(userdto);
        }

        





    }
}
