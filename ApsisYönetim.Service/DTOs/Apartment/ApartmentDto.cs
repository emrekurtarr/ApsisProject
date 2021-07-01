using ApsisYönetim.Service.DTOs.MonthlyCharge;
using ApsisYönetim.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.Apartment
{
    public class ApartmentDto
    {
        public string BlocNo { get; set; }
        public bool IsActive { get; set; }
        public string ApartType { get; set; }
        public int FloorNo { get; set; }
        public ListingUserDto UserDto { get; set; }
        public List<MonthlyChargeDto> MonthlyChargeDto { get; set; }
    }
}
