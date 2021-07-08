using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Services
{
    public interface IMonthlyChargeService : IServiceBase<MonthlyCharge>
    {
        Task<IResult> SetPaid(int chargeid);
        Task<IDataResult<List<MonthlyCharge>>> GetAllMonthlyChargesByMonth(Months monthOfPayment);

    }
}
