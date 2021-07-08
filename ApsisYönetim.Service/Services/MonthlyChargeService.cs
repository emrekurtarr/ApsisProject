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

        public async Task<IDataResult<List<MonthlyCharge>>> GetAllAsync(Expression<Func<MonthlyCharge, bool>> expression = null)
        {
            var result = await _monthlyChargeRepository.GetAllAsync(expression);

            return new SuccessDataResult<List<MonthlyCharge>>(result.ToList());
        }

        public async Task<IDataResult<List<MonthlyCharge>>> GetAllMonthlyChargesByMonth(Months monthOfPayment)
        {
            var result = await _monthlyChargeRepository.GetAllMonthlyChargesByMonth(monthOfPayment);

            return new SuccessDataResult<List<MonthlyCharge>>(result);
        }

        public async Task<IDataResult<MonthlyCharge>> GetAsync(Expression<Func<MonthlyCharge, bool>> expression)
        {
            MonthlyCharge charge = await _monthlyChargeRepository.GetAsync(expression);

            if (charge == null)
            {
                return new ErrorDataResult<MonthlyCharge>(); 
            }
            return new SuccessDataResult<MonthlyCharge>(charge);
        }

        public async Task<IResult> SetPaid(int chargeid)
        {
            MonthlyCharge charge = await _monthlyChargeRepository.GetAsync(x => x.ID == chargeid);
            charge.IsPaid = true;

            var result =  await Update(charge);

            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public async Task<IResult> Update(MonthlyCharge item)
        {
            MonthlyCharge charge = await _monthlyChargeRepository.GetAsync(x => x.ID == item.ID);

            if(charge == null)
            {
                return new ErrorResult(MonthlyChargeMessages.NotFound);
            }


            int result = await _monthlyChargeRepository.Update(item);

            if(result < 0)
            {
                return new ErrorResult(MonthlyChargeMessages.FailUpdated); 
            }

            return new SuccessResult();

        }
    }
}
