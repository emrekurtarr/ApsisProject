using ApsisYönetim.Service.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.MonthlyCharge
{
    public class ShowChargesByMonthDto
    {
        public decimal Subscription { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal HeatingCost { get; set; }
        public decimal TotalCharge => Subscription + ElectricBill + HeatingCost;
        public ListApartWithUserEmailDto Apartment { get; set; }
    }
}
