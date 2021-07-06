using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
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
    }
}
