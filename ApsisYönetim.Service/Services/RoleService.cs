using ApsisYönetim.Core.Entities;
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
    public class RoleService : IRoleService
    {

        public Task<IResult> AddAsync(Role item)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(Role item)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Role>>> GetAllAsync(Expression<Func<Role, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Role>> GetAsync(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
