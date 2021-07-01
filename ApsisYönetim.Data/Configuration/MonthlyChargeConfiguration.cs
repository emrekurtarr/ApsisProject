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
    public class MonthlyChargeConfiguration : IEntityTypeConfiguration<MonthlyCharge>
    {
        public void Configure(EntityTypeBuilder<MonthlyCharge> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn();
            builder.Property(x => x.ElectricBill).HasColumnType("decimal(5,2)");
            builder.Property(x => x.HeatingCost).HasColumnType("decimal(5,2)");
            builder.Property(x => x.Subscription).HasColumnType("decimal(5,2)");
        }
    }
}
