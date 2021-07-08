using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Service.DTOs.CreditCard
{
    public class CreditCardDto
    {
        public string User { get; set; }
        public string CardNumber { get; set; }
        public string ValidMonth { get; set; }
        public string ValidYear { get; set; }
        public string Cvv { get; set; }
        public decimal Money { get; set; }
        public int ChargeId { get; set; }


    }
}
