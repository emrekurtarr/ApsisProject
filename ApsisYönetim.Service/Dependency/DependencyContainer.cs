using ApsisYönetim.Core.Entities;
using ApsisYönetim.Core.Interfaces.Repositories;
using ApsisYönetim.Core.Interfaces.Services;
using ApsisYönetim.Data;
using ApsisYönetim.Data.Repositories;
using ApsisYönetim.Service.MapperProfiles;
using ApsisYönetim.Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.Dependency
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterService(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApsisDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")).UseLazyLoadingProxies());

            services.AddIdentity<User, Role>(options => 
            {   options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = false;                                                
            })
                    .AddRoles<Role>()
                    .AddUserManager<UserManager<User>>()
                    .AddEntityFrameworkStores<ApsisDBContext>();

            services.AddDistributedMemoryCache();
            services.AddSession();


            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<Role>>();
            services.AddScoped<SignInManager<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMonthlyChargeRepository, MontlyChargeRepository>();
            services.AddScoped<IMonthlyChargeService, MonthlyChargeService>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();


            services.AddRazorPages();
           


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
                mc.AddProfile(new ApartmentProfile());
                mc.AddProfile(new RoleProfile());
                mc.AddProfile(new MonthlyChargeProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.ConfigureApplicationCookie(options =>
            {

                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/AccessDenied";

            });
            

            

            return services;
        }
    }
}
