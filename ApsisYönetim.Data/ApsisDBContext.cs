using ApsisYönetim.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Data
{
    public class ApsisDBContext : IdentityDbContext
    {
        public ApsisDBContext(DbContextOptions<ApsisDBContext> options)
            : base(options)
        {

        }

        public DbSet<User> UsersTable { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }



    }
}
