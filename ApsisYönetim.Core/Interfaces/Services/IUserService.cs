using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Core;
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
        Task<IDataResult<bool>> Login(User item, string password);
        Task<IResult> LogOut(string username);
        Task<IResult> ChangePassword(string newpassword,string currentpassword,string usersemail);
        Task<IDataResult<List<Apartment>>> GetUserApartmentsWithMonthlyCharge(User item);
        Task<IDataResult<List<User>>> GetAllUsersWithApartments();

    }
}
