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
using AutoMapper;

namespace ApsisYönetim.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly SignInManager<User> _signInManager = null;
        private readonly IApartmentService _apartmentService = null;
        private readonly IMapper _mapper = null;
        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager,IApartmentService apartmentService, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        public async Task<IDataResult<string>> AddAsync(User item)
        {
            // Show up generated password to the user
            string password = PasswordGenerator.CreateRandomPassword();
            IdentityResult result = await _userManager.CreateAsync(item, password);

            if (result.Succeeded)
            {
                // Add role to created User
                User createdUser = await _userManager.FindByEmailAsync(item.Email);

                foreach (Role role in item.Roles)
                {
                    await _userManager.AddToRoleAsync(createdUser, role.Name);
                }

                return new SuccessDataResult<string>(password, item.Name + UserMessages.SuccessfullyAdded);
            }
            return new ErrorDataResult<string>(message: item.Name + UserMessages.FailAdded);
        }

        public async Task<IResult> ChangePassword(string newpassword,string currentpassword, string usersemail)
        {
            User user = await _userManager.FindByEmailAsync(usersemail);
            var result = await _userManager.ChangePasswordAsync(user, currentpassword, newpassword);

            if (result.Succeeded)
            {
                return new SuccessResult();
            }

            return new ErrorResult();

        }

        // TODO : DELETE USER
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
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
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
            List<User> users = null;

            users = (expression == null) ? await _userManager.Users.ToListAsync() :
                                           await _userManager.Users.Where(expression).ToListAsync();

            if (users == null)
            {
                return new ErrorDataResult<List<User>>(users);
            }
            
            
            return new SuccessDataResult<List<User>>(users);

        }

        public async Task<IDataResult<List<User>>> GetAllUsersWithApartments()
        {
            var result = await _userManager.Users.Include(x => x.Apartments).ToListAsync();
            
            return new SuccessDataResult<List<User>>(result);
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

        //TODO : Is this func necessary ?
        public async Task<IDataResult<List<Apartment>>> GetUserApartmentsWithMonthlyCharge(User item)
        {
            User user = await _userManager.FindByEmailAsync(item.Email);
            List<Apartment> apartments = user.Apartments.ToList();
            

            //foreach (Apartment apart in apartments)
            //{
            //    List<Apartment> apartmentwithcharge = _apartmentService.GetApartmentsWithMonthlyCharge(apart.ID).Result.Data;
            //    foreach (var x in apartmentwithcharge)
            //    {
            //        if (apart.ID == x.ID)
            //        {
            //            apart.MonthlyCharge.Add()
            //        }
            //    }
            //}

            return new SuccessDataResult<List<Apartment>>(apartments);
        }

        public async Task<IDataResult<bool>> Login(User item,string password)
        {
            User user = await _userManager.FindByEmailAsync(item.Email);
            bool isPasswordtrue = await _userManager.CheckPasswordAsync(user, password);

            
            if (user == null)
            {
                return new ErrorDataResult<bool>(UserMessages.NotFound);
            }

            if (isPasswordtrue)
            {
                await _signInManager.SignOutAsync();
                SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);

                if (result.Succeeded)
                {
                    List<string> roles = _userManager.GetRolesAsync(user).Result as List<string>;
                    bool isAdmin = false;

                    foreach (string rolename in roles)
                    {
                        //If user is admin, then indicate
                        if (rolename == nameof(Roles.Admin))
                        {
                            isAdmin = true;

                        }
                        return new SuccessDataResult<bool>(isAdmin);
                    }

                    return new SuccessDataResult<bool>(false);
                }

                return new ErrorDataResult<bool>();

            }


            return new ErrorDataResult<bool>(false);
            
            
        }

        public async Task<IResult> LogOut(string username)
        {
            User user = await _userManager.FindByNameAsync(username);

            if(user == null)
            {
                return new ErrorResult();
            }

            await _signInManager.SignOutAsync();

            return new SuccessResult();
        }


        // TODO : UPDATE USER
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
            user.PhoneNumber = item.PhoneNumber;
            user.Email = item.Email;
            user.UserName = item.UserName;

            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded) return new SuccessResult();

            return new ErrorResult();



        }

        async Task<IResult> IServiceBase<User>.AddAsync(User item)
        {
            if (item == null)
            {
                return new ErrorDataResult<string>(item.Name + UserMessages.NotFound);
            }

            //_userManager.getuser

            // TODO : safdsgsgsgds
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
