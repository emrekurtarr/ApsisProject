using ApsisYönetim.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Data.Seed
{
    public class RoleSeed : IEntityTypeConfiguration<Role>
    {

        private string UserRoleId = "7d1391c9-69d6-49a5-9a55-0e0abb65f6b1";
        private string AdminRoleId = "8d648279-0f75-4f5c-94f7-c46c37f921f2";

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new IdentityRole{Name = "Admin",NormalizedName = "Admin", Id = AdminRoleId,ConcurrencyStamp = AdminRoleId},
                new IdentityRole{Name = "User", NormalizedName = "User",Id = UserRoleId,ConcurrencyStamp = UserRoleId }
                );
        }
    }
}
