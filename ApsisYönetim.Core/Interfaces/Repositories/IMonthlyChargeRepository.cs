﻿using ApsisYönetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Repositories
{
    public interface IMonthlyChargeRepository : IRepositoryBase<MonthlyCharge>
    {
        Task<List<MonthlyCharge>> GetAllMonthlyChargesByMonth(Months monthOfPayment);
    }
}
