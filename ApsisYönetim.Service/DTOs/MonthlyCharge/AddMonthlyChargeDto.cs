using ApsisYönetim.Service.DTOs.Apartment;
using ApsisYönetim.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.MonthlyCharge
{
    public class AddMonthlyChargeDto
    {

        public int ApartmentID { get; set; }
        public decimal Subscription { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal HeatingCost { get; set; }
        public int MonthOfPayment { get; set; }









    }
}
