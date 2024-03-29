﻿using ApsisYönetim.Core.Entities;
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

        public DbSet<Note> Notes{ get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<MonthlyCharge> MonthlyCharges { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            
            base.OnModelCreating(builder);
        }

    }
}
