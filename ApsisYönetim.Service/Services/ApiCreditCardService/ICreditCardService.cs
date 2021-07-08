using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Service.DTOs.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Services.ApiCreditCardService
{
    public interface ICreditCardService
    {
        Task<IDataResult<CreditCardDto>> WithdrawMoney(CreditCardDto cardDto);
    }
}
