using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.Apartment
{
    public class ApartmentWithChargeDto
    {
        public int MonthlyChargeID { get; set; }
        public string BlocNo { get; set; }
        public int FloorNo { get; set; }
        public decimal Subscription { get; set; }
        public decimal ElectricBill { get; set; }
        public decimal HeatingCost { get; set; }

        public string MonthOfPayment { get; set; }
        public decimal TotalCharge => Subscription + ElectricBill + HeatingCost;

    }
}
