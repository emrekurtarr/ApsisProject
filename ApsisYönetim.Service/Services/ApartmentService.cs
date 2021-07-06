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
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository = null;
        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<IResult> AddAsync(Apartment item)
        {
            // Check is there the same apartment
            var existApartment = await _apartmentRepository.GetAsync(a => a.BlocNo == item.BlocNo && a.FloorNo == item.FloorNo);
            if (existApartment != null)
            {
                return new ErrorResult(ApartmentMessages.AlreadyExist);
            }

            int result = await _apartmentRepository.AddAsync(item);

            if (result > 0)
            {
                return new SuccessResult(ApartmentMessages.SuccessfullyAdded);
            }

            return new ErrorResult(ApartmentMessages.AddedFailed);
        }
        public async Task<IResult> Update(Apartment item)
        {
            // If the userid is not exist, set IsActive property to false
            if(item.UserId == null)
            {
                item.IsActive = false;
            }

            int res = await _apartmentRepository.Update(item);
            if(res > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        
        public async Task<IResult> Delete(Apartment item)
        {
            Apartment existApartment = await _apartmentRepository.GetAsync(x => x.ID == item.ID);
            
            if(existApartment == null)
            {
                return new ErrorDataResult<Apartment>(item, ApartmentMessages.NotFound);
            }

            var result = _apartmentRepository.Delete(item).Result;

            if (result > 0)
            {
                return new SuccessResult(ApartmentMessages.DeletedSuccessfully);
            }

            return new ErrorResult(MonthlyChargeMessages.FailDeleted);
        }

        public async Task<IDataResult<List<Apartment>>> GetAllApartmentsWithUsers()
        {
            var result = await _apartmentRepository.GetAllApartmentsWithUsers();


            return new SuccessDataResult<List<Apartment>>(result.ToList());
        }

        public async Task<IDataResult<List<Apartment>>> GetAllAsync(Expression<Func<Apartment, bool>> expression = null)
        {
            var result =  await _apartmentRepository.GetAllAsync(expression);
            List<Apartment> apartments = result.ToList();

            if (apartments == null)
            {
                return  new ErrorDataResult<List<Apartment>>();
            }

            return new SuccessDataResult<List<Apartment>>(apartments);

        }

        public async Task<IDataResult<List<Apartment>>> GetApartmentsWithMonthlyCharge(string userid)
        {

            var result = await _apartmentRepository.GetApartmentsWithMonthlyCharge(userid);
            List<Apartment> apartments = result.ToList();

            return new SuccessDataResult<List<Apartment>>(apartments);
        }

        public async Task<IDataResult<Apartment>> GetApartmentWithUser(int apartmentid)
        {
            var result = await _apartmentRepository.GetApartmentWithUser(apartmentid);
            
            if(result == null)
            {
                return new ErrorDataResult<Apartment>(result, ApartmentMessages.NotFound);
            }

            return new SuccessDataResult<Apartment>(result);
            

        }

        public async Task<IDataResult<Apartment>> GetAsync(Expression<Func<Apartment, bool>> expression)
        {
            var result = await _apartmentRepository.GetAsync(expression);
            
            if(result == null)
            {
                return new ErrorDataResult<Apartment>(result);
            }

            return new SuccessDataResult<Apartment>(result);

        }

        
    }
}
