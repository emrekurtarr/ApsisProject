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
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();



            builder.HasOne(x => x.User)
                    .WithMany(x => x.Apartments)
                     .HasForeignKey(x => x.UserId)
                      .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.MonthlyCharge)
                    .WithOne(x => x.Apartment)
                     .HasForeignKey(x => x.ApartmentID)
                      .OnDelete(DeleteBehavior.Cascade);

           

        }
    }
}
