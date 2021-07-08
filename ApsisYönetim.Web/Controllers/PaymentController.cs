using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Service.DTOs.CreditCard;
using ApsisYönetim.Service.Services.ApiCreditCardService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.Web.Controllers
{
    [Authorize(Roles = nameof(Roles.User))]
    public class PaymentController : Controller
    {
        private readonly ICreditCardService _creditcardService = null;
        private readonly IMonthlyChargeService _monthlyChargeService = null;

        public PaymentController(ICreditCardService creditcardService, IMonthlyChargeService monthlyChargeService)
        {
            _creditcardService = creditcardService;
            _monthlyChargeService = monthlyChargeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PayCard(int chargeid)
        {
            var result = await _monthlyChargeService.GetAsync(x => x.ID == chargeid);
            MonthlyCharge charge = result.Data;

            //TempData["chargemoney"] = charge.TotalCharge;
            //TempData["chargeid"] = charge.ID ;

            CreditCardDto cardDto = new CreditCardDto { ChargeId = charge.ID, Money = charge.TotalCharge};


            return View(cardDto);

        } 
           

        [HttpPost]
        public async Task<IActionResult> PayCard(CreditCardDto cardDto)
        {

            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();

                return View(cardDto);
            }

            var result = await _creditcardService.WithdrawMoney(cardDto);

            if (result.Success)
            {
                await _monthlyChargeService.SetPaid(cardDto.ChargeId);
                return RedirectToAction("Index", "User");
            }

            return View("ErrorDuringThePayment");
        }


        //public async Task<IActionResult> PayWithCreditCard(int chargeid)
        //{
        //    var result = await _monthlyChargeService.GetAsync(x => x.ID == chargeid);
        //    MonthlyCharge charge = result.Data;
        //    TempData["chargemoney"] = charge.TotalCharge;
        //    TempData["chargeid"] = chargeid;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> PayWithCreditCard(CreditCardDto cardDto)
        //{
        //    cardDto.Money = (int)TempData["chargemoney"];
        //    int chargeid = (int)TempData["chargeid"];
        //    var result = await _creditcardService.WithdrawMoney(cardDto);

        //    if (result.Success)
        //    {
        //        await _monthlyChargeService.SetPaid(chargeid);
        //        return RedirectToAction("Index","User");
        //    }

        //    return View("ErrorDuringThePayment");
        //}

    }
}
