using ApsisYönetim.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class MonthlyCharge : IEntity
    {
        public int ID { get; set; }
        public decimal Subscription { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal HeatingCost { get; set; }
        public bool IsPaid { get; set; }
        public virtual User User { get; set; }

    }
}
