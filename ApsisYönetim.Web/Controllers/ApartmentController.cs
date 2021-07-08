using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.Apartment;
using ApsisYönetim.Service.DTOs.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    [Authorize(Roles = nameof(Roles.User) + "," + nameof(Roles.Admin))]
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService = null;
        private readonly IUserService _userService = null;
        private readonly IMapper _mapper = null;
        public ApartmentController(IApartmentService apartmentService, IUserService userService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowApartments()
        {
            var res = await _apartmentService.GetAllApartmentsWithUsers();
            List<Apartment> apartments = res.Data;
            return View(_mapper.Map<List<ListApartWithUserEmailDto>>(apartments));

        }

        public async Task<IActionResult> Delete(int apartmentid)
        {

            var existApart = await _apartmentService.GetAsync(x => x.ID == apartmentid);
            var result = await _apartmentService.Delete(existApart.Data);

            if (result.Success)
            {
                return RedirectToAction("ShowApartments", "Apartment");
            }

            return NotFound();
        }

        public async Task<IActionResult> Edit(int apartmentid)
        {
            var res = await _apartmentService.GetApartmentWithUser(apartmentid);
            Apartment apartment = res.Data;
            

            List<User> users = _userService.GetAllAsync().Result.Data;
           
            ViewBag.Users = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(users, "Id", "Email");


            return View(_mapper.Map<EditApartmentDto>(apartment));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditApartmentDto apartDto)
        {

            Apartment updatedApart = _mapper.Map<Apartment>(apartDto);

            var res = await _apartmentService.Update(updatedApart);
            if (res.Success)
            {

                return RedirectToAction("ShowApartments");
            }

            return RedirectToAction("Edit");
        }


        public async Task<IActionResult> Create()
        {
            List<User> users = _userService.GetAllAsync().Result.Data;

            ViewBag.Users = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(users,"Id","Email");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddApartmentDto apartmentdto)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

                return View(apartmentdto);

            }

            Apartment apartment = _mapper.Map<Apartment>(apartmentdto);
            User user = _userService.GetAsync(x => x.Id == apartmentdto.UserId).Result.Data;
            apartment.User = user;

            var result = await _apartmentService.AddAsync(apartment);

            if (result.Success)
            {
                return RedirectToAction("Index","Admin");
            }
            return View();
        }

        

        //public async Task<IActionResult> GetAllApertmentsWithUsers()
        //{
            
        //}

        public async Task<IActionResult> GetChargesWithApartments()
        {
            var user = await _userService.GetAsync(x => x.UserName == User.Identity.Name);

            //string useridfromsession = HttpContext.Session.GetString("userid");

            var result = await _apartmentService.GetApartmentsWithMonthlyCharge(user.Data.Id);
            List<Apartment> apartments = result.Data;
            List<ApartmentWithChargeDto> dto = new List<ApartmentWithChargeDto>();

            foreach (Apartment apart in apartments)
            {
                foreach (MonthlyCharge charge in apart.MonthlyCharge)
                {
                    dto.Add(new ApartmentWithChargeDto
                    {
                        IsPaid = charge.IsPaid,
                        MonthlyChargeID = charge.ID,
                        BlocNo = apart.BlocNo,
                        ElectricBill = charge.ElectricBill,
                        FloorNo = apart.FloorNo,
                        HeatingCost = charge.HeatingCost,
                        Subscription = charge.Subscription,
                        MonthOfPayment = charge.MonthOfPaymentAsString,
                    });
                }
            }


            return View(dto);
        }






    }
}
