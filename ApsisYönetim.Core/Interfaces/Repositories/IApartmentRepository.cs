using ApsisYönetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Repositories
{
    public interface IApartmentRepository : IRepositoryBase<Apartment>
    {
        Task<ICollection<Apartment>> GetApartmentsWithMonthlyCharge(string userid);
        Task<ICollection<Apartment>> GetAllApartmentsWithUsers();
        Task<Apartment> GetApartmentWithUser(int apartmentid);
    }
}
