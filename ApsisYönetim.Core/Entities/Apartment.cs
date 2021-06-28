using ApsisYönetim.Core.Interfaces.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApsisYönetim.Core.Entities
{
    public class Apartment : IEntity
    {
        public int ID { get; set; }
        public string BlokNo { get; set; }
        public string BlocNo { get; set; }
        public bool IsActive { get; set; }
        public string ApartType { get; set; }
        public int FloorNo { get; set; }

        public virtual User User { get; set; }


    }
}
