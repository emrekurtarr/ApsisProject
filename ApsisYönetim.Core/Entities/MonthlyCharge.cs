using ApsisYönetim.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class MonthlyCharge : IEntity
    {
        public int ID { get; set; }
        public decimal Subscription { get; set; }
        [ForeignKey("Apartment")]
        public int ApartmentID { get; set; }
        public decimal ElectricBill { get; set; }
        [Required]
        public string MonthOfPaymentAsString
        {
            get
            {
                return this.MonthOfPayment.ToString();
            }
            set
            {
                MonthOfPayment = (Months)Enum.Parse(typeof(Months), value, true);
            }
        }
        [EnumDataType(typeof(Months))]
        public Months MonthOfPayment { get; set; }
        public decimal HeatingCost { get; set; }
        //public DateTime LastPaymentDate { get; set; }
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
        public virtual Apartment Apartment { get; set; }
    }

    public enum Months
    {
        Ocak = 1,
        Şubat,
        Mart,
        Nisan,
        Mayıs,
        Haziran,
        Temmuz,
        Ağustos,
        Eylül,
        Ekim,
        Kasım,
        Aralık,
    }
}
