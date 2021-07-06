using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Service.Constants.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Services
{
    public class MonthlyChargeService : IMonthlyChargeService
    {
        private readonly IMonthlyChargeRepository _monthlyChargeRepository = null;
        public MonthlyChargeService(IMonthlyChargeRepository monthlyChargeRepository)
        {
            _monthlyChargeRepository = monthlyChargeRepository;
        }

        public async Task<IResult> AddAsync(MonthlyCharge item)
        {
            
            var result = await _monthlyChargeRepository.AddAsync(item);

            if(result > 0)
            {
                return new SuccessResult(MonthlyChargeMessages.SuccessfullyAdded);
            }

            return new ErrorResult(MonthlyChargeMessages.AddedFailed);
        }

        public async Task<IResult> Delete(MonthlyCharge item)
        {
            var result = _monthlyChargeRepository.Delete(item).Result;

            if (result > 0)
            {
                return new SuccessResult(MonthlyChargeMessages.DeletedSuccessfully);
            }

            return new ErrorResult(MonthlyChargeMessages.FailDeleted);

        }

        public Task<IDataResult<List<MonthlyCharge>>> GetAllAsync(Expression<Func<MonthlyCharge, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<MonthlyCharge>> GetAsync(Expression<Func<MonthlyCharge, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(MonthlyCharge item)
        {
            throw new NotImplementedException();
        }
    }
}
