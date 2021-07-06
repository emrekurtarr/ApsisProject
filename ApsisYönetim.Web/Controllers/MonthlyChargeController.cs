using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.Apartment;
using ApsisYönetim.Service.DTOs.MonthlyCharge;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    public class MonthlyChargeController : Controller
    {
        private readonly IApartmentService _apartmentService = null;
        private readonly IMonthlyChargeService _monthlyChargeService = null;
        private readonly IMapper _mapper = null;
        public MonthlyChargeController(IApartmentService apartmentService, IMonthlyChargeService monthlyChargeService,IMapper mapper)
        {
            _apartmentService = apartmentService;
            _monthlyChargeService = monthlyChargeService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddtoApartment()
        {
            List<Apartment> apartments = _apartmentService.GetAllAsync().Result.Data;
            var mappedaparts = _mapper.Map<List<AddChargeToApartDto>>(apartments);

            ViewBag.apartments = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(mappedaparts, "ID", "Info");

            
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddtoApartment(AddMonthlyChargeDto chargedto)
        {

            MonthlyCharge monthlyCharge = _mapper.Map<MonthlyCharge>(chargedto);

            var result = await _monthlyChargeService.AddAsync(monthlyCharge);

            if (result.Success)
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("AddtoApartment");
        }
    }
}
