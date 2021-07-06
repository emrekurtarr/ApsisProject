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
    public class ApartmentRepository : RepositoryBase<Apartment>,IApartmentRepository
    {

        public ApartmentRepository(ApsisDBContext context):base(context)
        {
            
        }

        public async Task<ICollection<Apartment>> GetAllApartmentsWithUsers()
        {
            return await _context.Apartments.Include(x => x.User).ToListAsync();
        }

        public async Task<ICollection<Apartment>> GetApartmentsWithMonthlyCharge(string userid)
        {
            return await _context.Apartments.Include(x => x.User).Include(x => x.MonthlyCharge).Where(x => x.UserId == userid).ToListAsync();

            //return await _context.Apartments.Include(x => x.MonthlyCharge).Where(x => x.ID == apartmentid).ToListAsync();
        }

        public async Task<Apartment> GetApartmentWithUser(int apartmentid)
        {
            return await _context.Apartments.Include(x => x.User).Where(x => x.ID == apartmentid).FirstOrDefaultAsync();
        }
    }
}
