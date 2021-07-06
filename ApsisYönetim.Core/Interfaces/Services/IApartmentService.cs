using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Services
{
    public interface IApartmentService : IServiceBase<Apartment>
    {
        Task<IDataResult<List<Apartment>>> GetApartmentsWithMonthlyCharge(string userid);
        Task<IDataResult<List<Apartment>>> GetAllApartmentsWithUsers();
        Task<IDataResult<Apartment>> GetApartmentWithUser(int apartmentid);
    }
}
