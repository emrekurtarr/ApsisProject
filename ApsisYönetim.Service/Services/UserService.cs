using ApsisYönetim.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApsisYönetim.Core.Interfaces.Services;
using System.Linq.Expressions;
using ApsisYönetim.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using ApsisYönetim.Service.DTOs.User;
using ApsisYönetim.Core.Utilities.Result;
using ApsisYönetim.Service.Constants.Messages;
using Microsoft.EntityFrameworkCore;
using ApsisYönetim.Core.Utilities;

namespace ApsisYönetim.Service.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager = null;
        private RoleManager<Role> _roleManager = null;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IDataResult<string>> AddAsync(User item)
        {
            if (item == null)
            {
                return new ErrorDataResult<string>(message: item.Name + UserMessages.NotFound);
            }

            //_userManager.getuser

            // TO DO
            // Show up generated password to the user
            // + I did it with IDataresult check it
            string password = PasswordGenerator.CreateRandomPassword();
            IdentityResult result = await _userManager.CreateAsync(item, password);



            if (result.Succeeded)
            {
                return new SuccessDataResult<string>(password, item.Name + UserMessages.SuccessfullyAdded);
            }

            return new ErrorDataResult<string>(message: item.Name + UserMessages.FailAdded);
        }

        public async Task<IResult> Delete(User item)
        {
            User user = await _userManager.FindByIdAsync(item.Id);

            if (user == null)
            {
                return new ErrorResult(item.Name + UserMessages.NotFound);
            }


            // If user have apartments, first set to null "apart.User" property for cascade delete operation.
            if (user.Apartments.Count > 0)
            {
                foreach (Apartment apart in user.Apartments)
                {
                    apart.UserId = null;
                    apart.User = null;
                }
            }

            // TO DO
            // Yukarıdaki if statement ile bunu birleştirebilirsin
            // Role null yapıyorum ama databasedeki aspnetuserroles'dan silemiyorum.
            if (user.Roles != null)
            {
                foreach (Role role in user.Roles)
                {
                    await _userManager.RemoveFromRoleAsync(user,role.Name);
                }
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return new SuccessResult(user.Name + UserMessages.DeletedSuccessfully);
            }

            return new ErrorResult(user.Name + UserMessages.FailDeleted);

        }

        public async Task<IDataResult<List<User>>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            // TO DO
            // Don't need to async operation, there is no async method version of "ToList"

            List<User> users = _userManager.Users.Where(expression).ToList();

            if (users == null)
            {
                return new ErrorDataResult<List<User>>(users);
            }


            return new SuccessDataResult<List<User>>(users);


        }

        public async Task<IDataResult<User>> GetAsync(Expression<Func<User, bool>> expression)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(expression);

            if (user == null)
            {
                return new ErrorDataResult<User>(user);
            }

            return new SuccessDataResult<User>(user);

        }


        // TO DO
        public async Task<IResult> Update(User item)
        {
            User user = await _userManager.FindByIdAsync(item.Id);

            if (user == null)
            {
                return new ErrorResult(UserMessages.NotFound);
            }

            user.TcNo = item.TcNo;
            user.PlakaNo = item.PlakaNo;
            user.Surname = item.Surname;
            user.Name = item.Name;

            return new ErrorResult();



        }

        async Task<IResult> IServiceBase<User>.AddAsync(User item)
        {
            if (item == null)
            {
                return new ErrorDataResult<string>(item.Name + UserMessages.NotFound);
            }

            //_userManager.getuser

            // TO DO
            // Show up generated password to the user
            // + I did it with IDataresult check it
            string password = PasswordGenerator.CreateRandomPassword();
            IdentityResult result = await _userManager.CreateAsync(item, password);



            if (result.Succeeded)
            {
                return new SuccessResult(item.Name + UserMessages.SuccessfullyAdded);
            }

            return new ErrorResult(item.Name + UserMessages.FailAdded);
        }
    }
}
