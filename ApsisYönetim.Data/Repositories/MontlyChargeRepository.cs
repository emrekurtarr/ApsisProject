using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Data.Repositories
{
    public class MontlyChargeRepository : RepositoryBase<MonthlyCharge>,IMonthlyChargeRepository
    {
        public MontlyChargeRepository(ApsisDBContext context):base(context)
        {

        }

        public async Task<List<MonthlyCharge>> GetAllMonthlyChargesByMonth(Months monthOfPayment)
        {
            var result = await _context.MonthlyCharges.Include(x => x.Apartment).Where(x => x.MonthOfPayment == monthOfPayment).ToListAsync();
            return result;
        }
    }
}
