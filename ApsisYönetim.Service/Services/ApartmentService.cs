using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Core.Utilities.Result;
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

        public Task<IResult> AddAsync(Apartment item)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(Apartment item)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Apartment>>> GetAllAsync(Expression<Func<Apartment, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Apartment>> GetAsync(Expression<Func<Apartment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Apartment item)
        {
            throw new NotImplementedException();
        }
    }
}
