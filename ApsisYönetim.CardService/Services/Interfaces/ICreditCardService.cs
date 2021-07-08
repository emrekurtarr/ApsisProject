using Apsis.Shared.DTO;
using ApsisYönetim.CardService.DTO;
using ApsisYönetim.CardService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApsisYönetim.CardService.Services.Interfaces
{
    public interface ICreditCardService
    {
        Task<Response<CreditCardDto>> WithDrawMoney(CreditCardDto card);
    }
}
