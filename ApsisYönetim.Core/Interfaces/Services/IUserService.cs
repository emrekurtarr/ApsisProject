using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        new Task<IDataResult<string>> AddAsync(User item);
    }
}
