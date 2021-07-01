using ApsisYönetim.Service.DTOs.Apartment;
using ApsisYönetim.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.MonthlyCharge
{
    public class MonthlyChargeDto
    {
       
        public decimal Subscription { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal HeatingCost { get; set; }
        public bool IsPaid
        {
            get
            {
                if (TotalCharge == 0)
                {
                    return true;
                }
                return false;
            }
        }
        public decimal TotalCharge => Subscription + ElectricBill + HeatingCost;
        public ListingUserDto User { get; set; }
        public ApartmentDto Apartment { get; set; }
    }
}
