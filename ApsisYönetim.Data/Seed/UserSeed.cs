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
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        string Adminid = "1af66980-6500-4f07-88a4-a7e98ec6013a";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            User adminUser = new User()
            {
                Id = Adminid,
                Email = "emre@emre.com",
                EmailConfirmed = true,
                TcNo = "12233344445",
                NormalizedEmail = "emre@emre.com",
                PlakaNo = "26BY534",
                Name = "Emre",
                Surname = "Kurtar",
                UserName = "0the1emre",
                NormalizedUserName = "0THE1EMRE",
                SecurityStamp = "CGNNGCGFBRIVQ3WBFEEI2MD2ZXUPT4ZH",
                ConcurrencyStamp = "d407eee2-6f8a-43e4-877d-b9c5c78b7c74"
            };
            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            adminUser.PasswordHash = ph.HashPassword(adminUser, "Emrekurtar007!");

            //seed user
            builder.HasData(adminUser);
        }

        
    }
}
