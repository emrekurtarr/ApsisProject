using ApsisYönetim.Core.Entities;
using ApsisYönetim.Data;
using Microsoft.AspNet.Identity.EntityFramework;
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

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApsisDBContext>();

            services.ConfigureApplicationCookie(options =>
            {
                // TO DO
                //options.LoginPath = "login urlsi olucak";
                //options.AccessDeniedPath = "Yetkisi giriş sayfası olucak ";

            });
            

            

            return services;
        }
    }
}
