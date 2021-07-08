using ApsisYönetim.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
           

            builder.HasMany(x => x.Apartments)
                        .WithOne(x => x.User)
                         .HasForeignKey(x => x.UserId)
                          .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Roles)
                    .WithMany(x => x.Users);

            
        }
    }
}
