using Apsis.Shared.ControllerBases;
using ApsisYönetim.CardService.DTO;
using ApsisYönetim.CardService.Model;
using ApsisYönetim.CardService.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.CardService.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CreditcardController : CustomBaseController
    {
        private readonly ICreditCardService _creditcardService = null;
        private readonly IMapper _mapper = null; 

        public CreditcardController(ICreditCardService creditcardService, IMapper mapper)
        {
            _creditcardService = creditcardService;
            _mapper = mapper;
        }

        [HttpPost("withdrawmoney")]
        public async Task<IActionResult> WithDrawMoney([FromBody]CreditCardDto cardDto)
        {
            
            var response = await _creditcardService.WithDrawMoney(cardDto);

            return CreateActionResultInstance(response);
        }
    }
}
