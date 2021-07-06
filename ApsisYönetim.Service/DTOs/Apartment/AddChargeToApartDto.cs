using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.Apartment
{
    public class AddChargeToApartDto
    {
        public int ID { get; set; }
        public string BlocNo { get; set; }
        public int FloorNo { get; set; }
        public string Info => BlocNo + " " + FloorNo;

    }
}
